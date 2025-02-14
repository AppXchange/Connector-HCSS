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

namespace Connector.Contacts.v1.Contact.Create;

public class CreateContactHandler : IActionHandler<CreateContactAction>
{
    private readonly ILogger<CreateContactHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateContactHandler(
        ILogger<CreateContactHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateContactActionInput>(actionInstance.InputJson);
        if (input == null)
        {
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "400",
                Errors = new[] { new Error { Source = new[] { "CreateContactHandler" }, Text = "Invalid input" } }
            });
        }

        try
        {
            var response = await _apiClient.CreateContact(input, cancellationToken);
            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[] { new Error 
                    { 
                        Source = new[] { "CreateContactHandler" }, 
                        Text = $"Failed to create contact. Status code: {response.StatusCode}" 
                    }}
                });
            }

            // Get the full contact details for cache sync
            var contactDetails = await _apiClient.GetContact(response.Data, input.BusinessUnitId, cancellationToken);
            if (contactDetails.Data != null)
            {
                var operations = new List<SyncOperation>();
                var keyResolver = new DefaultDataObjectKey();
                var key = keyResolver.BuildKeyResolver()(contactDetails.Data);
                operations.Add(SyncOperation.CreateSyncOperation(
                    UpdateOperation.Upsert.ToString(), 
                    key.UrlPart, 
                    key.PropertyNames, 
                    contactDetails.Data));

                var resultList = new List<CacheSyncCollection>
                {
                    new() { 
                        DataObjectType = typeof(ContactDataObject), 
                        CacheChanges = operations.ToArray() 
                    }
                };

                return ActionHandlerOutcome.Successful(new CreateContactActionOutput { Id = response.Data }, resultList);
            }

            return ActionHandlerOutcome.Successful(new CreateContactActionOutput { Id = response.Data });
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Error creating contact");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = exception.StatusCode?.ToString() ?? "500",
                Errors = new[] { new Error
                {
                    Source = new[] { "CreateContactHandler", exception.Source ?? "Unknown" },
                    Text = exception.Message
                }}
            });
        }
    }
}
