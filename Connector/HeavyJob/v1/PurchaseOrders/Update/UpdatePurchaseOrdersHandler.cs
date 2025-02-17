using Connector.Client;
using ESR.Hosting.Action;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xchange.Connector.SDK.Action;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Client.AppNetwork;

namespace Connector.HeavyJob.v1.PurchaseOrders.Update;

public class UpdatePurchaseOrdersHandler : IActionHandler<UpdatePurchaseOrdersAction>
{
    private readonly ILogger<UpdatePurchaseOrdersHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdatePurchaseOrdersHandler(
        ILogger<UpdatePurchaseOrdersHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdatePurchaseOrdersActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.UpdatePurchaseOrder(
                input.Id,
                input,
                cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(UpdatePurchaseOrdersHandler) },
                            Text = $"Failed to update purchase order. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            // Since this is a 204 response, we'll create our own success output
            var output = new UpdatePurchaseOrdersActionOutput { Success = true };

            // Get the updated purchase order to sync cache
            var getResponse = await _apiClient.GetPurchaseOrders(
                purchaseOrderId: input.Id,
                cancellationToken: cancellationToken);

            if (getResponse.IsSuccessful && getResponse.Data?.Results.Length > 0)
            {
                var operations = new List<SyncOperation>();
                var keyResolver = new DefaultDataObjectKey();
                var key = keyResolver.BuildKeyResolver()(getResponse.Data.Results[0]);
                operations.Add(SyncOperation.CreateSyncOperation(
                    UpdateOperation.Upsert.ToString(), 
                    key.UrlPart,
                    key.PropertyNames, 
                    getResponse.Data.Results[0]));

                var resultList = new List<CacheSyncCollection>
                {
                    new() { 
                        DataObjectType = typeof(PurchaseOrdersDataObject), 
                        CacheChanges = operations.ToArray() 
                    }
                };

                return ActionHandlerOutcome.Successful(output, resultList);
            }

            return ActionHandlerOutcome.Successful(output);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating purchase order");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(UpdatePurchaseOrdersHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
