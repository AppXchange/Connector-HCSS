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

namespace Connector.HeavyJob.v1.ChangeOrder.Update;

public class UpdateChangeOrderHandler : IActionHandler<UpdateChangeOrderAction>
{
    private readonly ILogger<UpdateChangeOrderHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdateChangeOrderHandler(
        ILogger<UpdateChangeOrderHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateChangeOrderActionInput>(actionInstance.InputJson);
        if (input == null)
        {
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "400",
                Errors = new[] { new Error { Source = new[] { "UpdateChangeOrderHandler" }, Text = "Invalid input" } }
            });
        }

        try
        {
            var response = await _apiClient.UpdateChangeOrder(input, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { "UpdateChangeOrderHandler" },
                            Text = $"Failed to update change order. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            // Get updated change order to return
            var updatedOrder = await _apiClient.GetChangeOrder(input.Id, cancellationToken);
            if (!updatedOrder.IsSuccessful || updatedOrder.Data == null)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = updatedOrder.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { "UpdateChangeOrderHandler" },
                            Text = $"Failed to retrieve updated change order. Status code: {updatedOrder.StatusCode}"
                        }
                    }
                });
            }

            var operations = new List<SyncOperation>();
            var keyResolver = new DefaultDataObjectKey();
            var key = keyResolver.BuildKeyResolver()(updatedOrder.Data);
            operations.Add(SyncOperation.CreateSyncOperation(UpdateOperation.Upsert.ToString(), key.UrlPart, key.PropertyNames, updatedOrder.Data));

            var resultList = new List<CacheSyncCollection>
            {
                new() { DataObjectType = typeof(ChangeOrderDataObject), CacheChanges = operations.ToArray() }
            };

            return ActionHandlerOutcome.Successful(updatedOrder.Data, resultList);
        }
        catch (HttpRequestException exception)
        {
            var errorSource = new List<string> { "UpdateChangeOrderHandler" };
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
