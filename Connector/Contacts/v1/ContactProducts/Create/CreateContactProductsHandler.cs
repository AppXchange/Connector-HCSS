using Connector.Client;
using ESR.Hosting.Action;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xchange.Connector.SDK.Action;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Client.AppNetwork;

namespace Connector.Contacts.v1.ContactProducts.Create;

public class CreateContactProductsHandler : IActionHandler<CreateContactProductsAction>
{
    private readonly ILogger<CreateContactProductsHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateContactProductsHandler(
        ILogger<CreateContactProductsHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateContactProductsActionInput>(actionInstance.InputJson);
        if (input == null)
        {
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "400",
                Errors = new[] { new Error { Source = new[] { "CreateContactProductsHandler" }, Text = "Invalid input" } }
            });
        }

        try
        {
            var response = await _apiClient.CreateContactProduct(input, cancellationToken);
            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[] { new Error 
                    { 
                        Source = new[] { "CreateContactProductsHandler" }, 
                        Text = $"Failed to create contact product. Status code: {response.StatusCode}" 
                    }}
                });
            }

            // Get the full product details for cache sync
            var productDetails = await _apiClient.GetContactProducts(input.ContactId, input.BusinessUnitId, cancellationToken);
            var newProduct = productDetails.Data?.FirstOrDefault(p => p.VendorProductId == input.VendorProductId);
            
            if (newProduct != null)
            {
                var operations = new List<SyncOperation>();
                var keyResolver = new DefaultDataObjectKey();
                var key = keyResolver.BuildKeyResolver()(newProduct);
                operations.Add(SyncOperation.CreateSyncOperation(
                    UpdateOperation.Upsert.ToString(), 
                    key.UrlPart, 
                    key.PropertyNames, 
                    newProduct));

                var resultList = new List<CacheSyncCollection>
                {
                    new() { 
                        DataObjectType = typeof(ContactProductsDataObject), 
                        CacheChanges = operations.ToArray() 
                    }
                };

                return ActionHandlerOutcome.Successful(new CreateContactProductsActionOutput { Id = response.Data }, resultList);
            }

            return ActionHandlerOutcome.Successful(new CreateContactProductsActionOutput { Id = response.Data });
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Error creating contact product");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = exception.StatusCode?.ToString() ?? "500",
                Errors = new[] { new Error
                {
                    Source = new[] { "CreateContactProductsHandler", exception.Source ?? "Unknown" },
                    Text = exception.Message
                }}
            });
        }
    }
}
