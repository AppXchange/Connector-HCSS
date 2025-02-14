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

namespace Connector.HeavyBidPreConstruction.v1.Projects.Create;

public class CreateProjectsHandler : IActionHandler<CreateProjectsAction>
{
    private readonly ILogger<CreateProjectsHandler> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public CreateProjectsHandler(
        ILogger<CreateProjectsHandler> logger,
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

        var input = JsonSerializer.Deserialize<CreateProjectsActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.CreateProjects(
                _connectionConfig.BusinessUnitId,
                input.Projects,
                input.SkipInvalidFields,
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
                            Source = new[] { nameof(CreateProjectsHandler) },
                            Text = $"Failed to create projects. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            var operations = new List<SyncOperation>();
            var keyResolver = new DefaultDataObjectKey();

            if (response.Data.Success != null)
            {
                foreach (var project in response.Data.Success)
                {
                    var key = keyResolver.BuildKeyResolver()(project);
                    operations.Add(SyncOperation.CreateSyncOperation(UpdateOperation.Upsert.ToString(), key.UrlPart, key.PropertyNames, project));
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
            _logger.LogError(ex, "Error creating projects");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(CreateProjectsHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
