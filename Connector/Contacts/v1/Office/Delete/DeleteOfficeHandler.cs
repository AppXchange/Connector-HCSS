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

namespace Connector.Contacts.v1.Office.Delete;

public class DeleteOfficeHandler : IActionHandler<DeleteOfficeAction>
{
    private readonly ILogger<DeleteOfficeHandler> _logger;
    private readonly ApiClient _apiClient;

    public DeleteOfficeHandler(
        ILogger<DeleteOfficeHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<DeleteOfficeActionInput>(actionInstance.InputJson);
        if (input == null)
        {
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "400",
                Errors = new[] { new Error { Source = new[] { "DeleteOfficeHandler" }, Text = "Invalid input" } }
            });
        }

        try
        {
            var response = await _apiClient.DeleteOffice(input, cancellationToken);
            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[] { new Error 
                    { 
                        Source = new[] { "DeleteOfficeHandler" }, 
                        Text = $"Failed to delete office. Status code: {response.StatusCode}" 
                    }}
                });
            }

            // Since this is a delete operation, we need to remove the item from cache
            var operations = new List<SyncOperation>();
            var keyResolver = new DefaultDataObjectKey();
            var key = keyResolver.BuildKeyResolver()(new OfficeDataObject 
            { 
                Id = input.OfficeId,
                VendorId = Guid.Empty  // Using empty GUID since we only need Id for key resolution
            });
            operations.Add(SyncOperation.CreateSyncOperation(
                UpdateOperation.Delete.ToString(), 
                key.UrlPart, 
                key.PropertyNames, 
                new OfficeDataObject 
                { 
                    Id = input.OfficeId,
                    VendorId = Guid.Empty
                }));

            var resultList = new List<CacheSyncCollection>
            {
                new() { 
                    DataObjectType = typeof(OfficeDataObject), 
                    CacheChanges = operations.ToArray() 
                }
            };

            return ActionHandlerOutcome.Successful(new DeleteOfficeActionOutput(), resultList);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Error deleting office");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = exception.StatusCode?.ToString() ?? "500",
                Errors = new[] { new Error
                {
                    Source = new[] { "DeleteOfficeHandler", exception.Source ?? "Unknown" },
                    Text = exception.Message
                }}
            });
        }
    }
}
