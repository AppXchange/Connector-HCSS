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

namespace Connector.Contacts.v1.Office.Create;

public class CreateOfficeHandler : IActionHandler<CreateOfficeAction>
{
    private readonly ILogger<CreateOfficeHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateOfficeHandler(
        ILogger<CreateOfficeHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateOfficeActionInput>(actionInstance.InputJson);
        if (input == null)
        {
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "400",
                Errors = new[] { new Error { Source = new[] { "CreateOfficeHandler" }, Text = "Invalid input" } }
            });
        }

        try
        {
            var response = await _apiClient.CreateOffice(input, cancellationToken);
            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[] { new Error 
                    { 
                        Source = new[] { "CreateOfficeHandler" }, 
                        Text = $"Failed to create office. Status code: {response.StatusCode}" 
                    }}
                });
            }

            // Get the full office details for cache sync
            var officeDetails = await _apiClient.GetOffice(response.Data, input.BusinessUnitId, cancellationToken);
            if (officeDetails.Data != null)
            {
                var operations = new List<SyncOperation>();
                var keyResolver = new DefaultDataObjectKey();
                var key = keyResolver.BuildKeyResolver()(officeDetails.Data);
                operations.Add(SyncOperation.CreateSyncOperation(
                    UpdateOperation.Upsert.ToString(), 
                    key.UrlPart, 
                    key.PropertyNames, 
                    officeDetails.Data));

                var resultList = new List<CacheSyncCollection>
                {
                    new() { 
                        DataObjectType = typeof(OfficeDataObject), 
                        CacheChanges = operations.ToArray() 
                    }
                };

                return ActionHandlerOutcome.Successful(new CreateOfficeActionOutput { Id = response.Data }, resultList);
            }

            return ActionHandlerOutcome.Successful(new CreateOfficeActionOutput { Id = response.Data });
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Error creating office");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = exception.StatusCode?.ToString() ?? "500",
                Errors = new[] { new Error
                {
                    Source = new[] { "CreateOfficeHandler", exception.Source ?? "Unknown" },
                    Text = exception.Message
                }}
            });
        }
    }
}
