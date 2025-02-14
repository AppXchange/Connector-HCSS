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

namespace Connector.Contacts.v1.Contact.Update;

public class UpdateContactHandler : IActionHandler<UpdateContactAction>
{
    private readonly ILogger<UpdateContactHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdateContactHandler(
        ILogger<UpdateContactHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateContactActionInput>(actionInstance.InputJson);
        if (input == null)
        {
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "400",
                Errors = new[] { new Error { Source = new[] { "UpdateContactHandler" }, Text = "Invalid input" } }
            });
        }

        try
        {
            var response = await _apiClient.UpdateContact(input, cancellationToken);
            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[] { new Error 
                    { 
                        Source = new[] { "UpdateContactHandler" }, 
                        Text = $"Failed to update contact. Status code: {response.StatusCode}" 
                    }}
                });
            }

            if (response.Data != null)
            {
                var operations = new List<SyncOperation>();
                var keyResolver = new DefaultDataObjectKey();
                var key = keyResolver.BuildKeyResolver()(response.Data);
                operations.Add(SyncOperation.CreateSyncOperation(
                    UpdateOperation.Upsert.ToString(), 
                    key.UrlPart, 
                    key.PropertyNames, 
                    response.Data));

                var resultList = new List<CacheSyncCollection>
                {
                    new() { 
                        DataObjectType = typeof(ContactDataObject), 
                        CacheChanges = operations.ToArray() 
                    }
                };

                return ActionHandlerOutcome.Successful(new UpdateContactActionOutput { Id = response.Data.Id }, resultList);
            }

            return ActionHandlerOutcome.Successful(new UpdateContactActionOutput { Id = input.ContactId });
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Error updating contact");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = exception.StatusCode?.ToString() ?? "500",
                Errors = new[] { new Error
                {
                    Source = new[] { "UpdateContactHandler", exception.Source ?? "Unknown" },
                    Text = exception.Message
                }}
            });
        }
    }
}
