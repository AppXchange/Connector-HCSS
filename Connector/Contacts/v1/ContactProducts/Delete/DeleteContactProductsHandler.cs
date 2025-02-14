using Connector.Client;
using ESR.Hosting.Action;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xchange.Connector.SDK.Action;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Client.AppNetwork;

namespace Connector.Contacts.v1.ContactProducts.Delete;

public class DeleteContactProductsHandler : IActionHandler<DeleteContactProductsAction>
{
    private readonly ILogger<DeleteContactProductsHandler> _logger;
    private readonly ApiClient _apiClient;

    public DeleteContactProductsHandler(
        ILogger<DeleteContactProductsHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<DeleteContactProductsActionInput>(actionInstance.InputJson);
        if (input == null)
        {
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "400",
                Errors = new[] { new Error { Source = new[] { "DeleteContactProductsHandler" }, Text = "Invalid input" } }
            });
        }

        try
        {
            var response = await _apiClient.DeleteContactProduct(input, cancellationToken);
            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[] { new Error 
                    { 
                        Source = new[] { "DeleteContactProductsHandler" }, 
                        Text = $"Failed to delete contact product. Status code: {response.StatusCode}" 
                    }}
                });
            }

            // Since this is a delete operation, we need to remove the item from cache
            var operations = new List<SyncOperation>();
            var keyResolver = new DefaultDataObjectKey();
            var key = keyResolver.BuildKeyResolver()(new ContactProductsDataObject 
            { 
                VendorProductId = input.VendorProductId,
                ProductTypeId = Guid.Empty  // Using empty GUID since we only need VendorProductId for key resolution
            });
            operations.Add(SyncOperation.CreateSyncOperation(
                UpdateOperation.Delete.ToString(), 
                key.UrlPart, 
                key.PropertyNames, 
                new ContactProductsDataObject 
                { 
                    VendorProductId = input.VendorProductId,
                    ProductTypeId = Guid.Empty
                }));

            var resultList = new List<CacheSyncCollection>
            {
                new() { 
                    DataObjectType = typeof(ContactProductsDataObject), 
                    CacheChanges = operations.ToArray() 
                }
            };

            return ActionHandlerOutcome.Successful(new DeleteContactProductsActionOutput(), resultList);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Error deleting contact product");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = exception.StatusCode?.ToString() ?? "500",
                Errors = new[] { new Error
                {
                    Source = new[] { "DeleteContactProductsHandler", exception.Source ?? "Unknown" },
                    Text = exception.Message
                }}
            });
        }
    }
}
