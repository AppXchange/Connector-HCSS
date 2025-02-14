using Connector.Client;
using ESR.Hosting.Action;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xchange.Connector.SDK.Action;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Client.AppNetwork;

namespace Connector.HeavyJob.v1.ChangeOrder.Delete;

public class DeleteChangeOrderHandler : IActionHandler<DeleteChangeOrderAction>
{
    private readonly ILogger<DeleteChangeOrderHandler> _logger;
    private readonly ApiClient _apiClient;

    public DeleteChangeOrderHandler(
        ILogger<DeleteChangeOrderHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<DeleteChangeOrderActionInput>(actionInstance.InputJson);
        if (input == null)
        {
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "400",
                Errors = new[] { new Error { Source = new[] { "DeleteChangeOrderHandler" }, Text = "Invalid input" } }
            });
        }

        try
        {
            var response = await _apiClient.DeleteChangeOrder(input.Id, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { "DeleteChangeOrderHandler" },
                            Text = $"Failed to delete change order. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            var operations = new List<SyncOperation>();
            var keyResolver = new DefaultDataObjectKey();
            var key = keyResolver.BuildKeyResolver()(new ChangeOrderDataObject 
            { 
                Id = input.Id,
                ChangeOrderNumber = 0,  // Default value since we only need Id for delete
                Subject = string.Empty  // Default value since we only need Id for delete
            });
            operations.Add(SyncOperation.CreateSyncOperation(UpdateOperation.Delete.ToString(), key.UrlPart, key.PropertyNames, new object()));

            var resultList = new List<CacheSyncCollection>
            {
                new() { DataObjectType = typeof(ChangeOrderDataObject), CacheChanges = operations.ToArray() }
            };

            return ActionHandlerOutcome.Successful(new DeleteChangeOrderActionOutput { Id = input.Id }, resultList);
        }
        catch (HttpRequestException exception)
        {
            var errorSource = new List<string> { "DeleteChangeOrderHandler" };
            if (!string.IsNullOrEmpty(exception.Source)) errorSource.Add(exception.Source);
            
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = exception.StatusCode?.ToString() ?? "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = errorSource.ToArray(),
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
