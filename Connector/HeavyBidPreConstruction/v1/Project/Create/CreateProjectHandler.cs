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

namespace Connector.HeavyBidPreConstruction.v1.Project.Create;

public class CreateProjectHandler : IActionHandler<CreateProjectAction>
{
    private readonly ILogger<CreateProjectHandler> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public CreateProjectHandler(
        ILogger<CreateProjectHandler> logger,
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

        var input = JsonSerializer.Deserialize<CreateProjectActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.CreateProject(_connectionConfig.BusinessUnitId, input, cancellationToken);

            if (!response.IsSuccessful || response.Data == null)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(CreateProjectHandler) },
                            Text = $"Failed to create project. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            var operations = new List<SyncOperation>();
            var keyResolver = new DefaultDataObjectKey();
            var key = keyResolver.BuildKeyResolver()(response.Data);
            operations.Add(SyncOperation.CreateSyncOperation(UpdateOperation.Upsert.ToString(), key.UrlPart, key.PropertyNames, response.Data));

            var resultList = new List<CacheSyncCollection>
            {
                new() { DataObjectType = typeof(ProjectDataObject), CacheChanges = operations.ToArray() }
            };

            return ActionHandlerOutcome.Successful(response.Data, resultList);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating project");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(CreateProjectHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
