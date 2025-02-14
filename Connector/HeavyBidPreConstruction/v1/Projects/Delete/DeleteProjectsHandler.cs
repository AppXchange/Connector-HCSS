using Connector.Client;
using Connector.Connections;
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

namespace Connector.HeavyBidPreConstruction.v1.Projects.Delete;

public class DeleteProjectsHandler : IActionHandler<DeleteProjectsAction>
{
    private readonly ILogger<DeleteProjectsHandler> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public DeleteProjectsHandler(
        ILogger<DeleteProjectsHandler> logger,
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

        var input = JsonSerializer.Deserialize<DeleteProjectsActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.DeleteProjects(
                _connectionConfig.BusinessUnitId,
                input.ProjectIds,
                cancellationToken);

            if (!response.IsSuccessful || response.Data == null)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(DeleteProjectsHandler) },
                            Text = $"Failed to delete projects. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            var operations = new List<SyncOperation>();
            var keyResolver = new DefaultDataObjectKey();

            if (response.Data.Success != null)
            {
                foreach (var projectId in response.Data.Success)
                {
                    var key = keyResolver.BuildKeyResolver()(new { Id = Guid.Parse(projectId) });
                    operations.Add(SyncOperation.CreateSyncOperation(UpdateOperation.Delete.ToString(), key.UrlPart, key.PropertyNames, new { }));
                }
            }

            var resultList = new List<CacheSyncCollection>
            {
                new() { DataObjectType = typeof(ProjectsDataObject), CacheChanges = operations.ToArray() }
            };

            return ActionHandlerOutcome.Successful(response.Data, resultList);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting projects");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(DeleteProjectsHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
