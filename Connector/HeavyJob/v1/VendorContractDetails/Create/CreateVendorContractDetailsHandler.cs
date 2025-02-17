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

namespace Connector.HeavyJob.v1.VendorContractDetails.Create;

public class CreateVendorContractDetailsHandler : IActionHandler<CreateVendorContractDetailsAction>
{
    private readonly ILogger<CreateVendorContractDetailsHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateVendorContractDetailsHandler(
        ILogger<CreateVendorContractDetailsHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateVendorContractDetailsActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.CreateVendorContractDetails(input, cancellationToken);

            if (!response.IsSuccessful || response.Data == null)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(CreateVendorContractDetailsHandler) },
                            Text = $"Failed to create vendor contract details. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            // Build sync operations to update cache
            var operations = new List<SyncOperation>();
            var keyResolver = new DefaultDataObjectKey();
            var key = keyResolver.BuildKeyResolver()(response.Data);
            operations.Add(SyncOperation.CreateSyncOperation(UpdateOperation.Upsert.ToString(), key.UrlPart, key.PropertyNames, response.Data));

            var resultList = new List<CacheSyncCollection>
            {
                new CacheSyncCollection() { DataObjectType = typeof(VendorContractDetailsDataObject), CacheChanges = operations.ToArray() }
            };

            return ActionHandlerOutcome.Successful(response.Data, resultList);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating vendor contract details");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(CreateVendorContractDetailsHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
