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

namespace Connector.HeavyJob.v1.Subcontracts.Create;

public class CreateSubcontractsHandler : IActionHandler<CreateSubcontractsAction>
{
    private readonly ILogger<CreateSubcontractsHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateSubcontractsHandler(
        ILogger<CreateSubcontractsHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateSubcontractsActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.CreateSubcontract(
                input.BusinessUnitId,
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
                            Source = new[] { nameof(CreateSubcontractsHandler) },
                            Text = $"Failed to create subcontract. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            if (response.Data == null)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = "500",
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(CreateSubcontractsHandler) },
                            Text = "Response data was null after successful API call"
                        }
                    }
                });
            }

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
                    DataObjectType = typeof(SubcontractsDataObject), 
                    CacheChanges = operations.ToArray() 
                }
            };

            return ActionHandlerOutcome.Successful(response.Data, resultList);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating subcontract");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(CreateSubcontractsHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
