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

namespace Connector.HeavyJob.v1.PurchaseOrders.Create;

public class CreatePurchaseOrdersHandler : IActionHandler<CreatePurchaseOrdersAction>
{
    private readonly ILogger<CreatePurchaseOrdersHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreatePurchaseOrdersHandler(
        ILogger<CreatePurchaseOrdersHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreatePurchaseOrdersActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.CreatePurchaseOrder(
                input.JobId,
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
                            Source = new[] { nameof(CreatePurchaseOrdersHandler) },
                            Text = $"Failed to create purchase order. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            // Build sync operations to update caches
            var operations = new List<SyncOperation>();
            var keyResolver = new DefaultDataObjectKey();
            if (response.Data == null)
            {
                throw new InvalidOperationException("Response data was null after successful API call");
            }
            var key = keyResolver.BuildKeyResolver()(response.Data);
            operations.Add(SyncOperation.CreateSyncOperation(
                UpdateOperation.Upsert.ToString(), 
                key.UrlPart,
                key.PropertyNames, 
                response.Data));

            var resultList = new List<CacheSyncCollection>
            {
                new() { 
                    DataObjectType = typeof(PurchaseOrdersDataObject), 
                    CacheChanges = operations.ToArray() 
                }
            };

            return ActionHandlerOutcome.Successful(response.Data, resultList);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating purchase order");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(CreatePurchaseOrdersHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
