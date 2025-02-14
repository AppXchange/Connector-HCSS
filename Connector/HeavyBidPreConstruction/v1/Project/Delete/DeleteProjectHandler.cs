using Connector.Client;
using Connector.Connections;
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

namespace Connector.HeavyBidPreConstruction.v1.Project.Delete;

public class DeleteProjectHandler : IActionHandler<DeleteProjectAction>
{
    private readonly ILogger<DeleteProjectHandler> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public DeleteProjectHandler(
        ILogger<DeleteProjectHandler> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        if (_connectionConfig.BusinessUnitId == default)
        {
            throw new InvalidOperationException("BusinessUnitId must be configured in the connection settings");
        }

        var input = JsonSerializer.Deserialize<DeleteProjectActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.DeleteProject(_connectionConfig.BusinessUnitId, input.Id, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(DeleteProjectHandler) },
                            Text = $"Failed to delete project. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            var operations = new List<SyncOperation>();
            var keyResolver = new DefaultDataObjectKey();
            var key = keyResolver.BuildKeyResolver()(new { Id = input.Id });
            operations.Add(SyncOperation.CreateSyncOperation(UpdateOperation.Delete.ToString(), key.UrlPart, key.PropertyNames, new { }));

            var resultList = new List<CacheSyncCollection>
            {
                new() { DataObjectType = typeof(ProjectDataObject), CacheChanges = operations.ToArray() }
            };

            return ActionHandlerOutcome.Successful(new DeleteProjectActionOutput { Success = true }, resultList);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting project");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(DeleteProjectHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
