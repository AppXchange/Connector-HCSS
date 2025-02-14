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

namespace Connector.Equipment360.v1.EquipmentType.Create;

public class CreateEquipmentTypeHandler : IActionHandler<CreateEquipmentTypeAction>
{
    private readonly ILogger<CreateEquipmentTypeHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateEquipmentTypeHandler(
        ILogger<CreateEquipmentTypeHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance,
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateEquipmentTypeActionInput>(actionInstance.InputJson)!;
        try
        {
            var response = await _apiClient.CreateEquipmentType(input, cancellationToken);

            if (!response.IsSuccessful || response.Data == null)
            {
                _logger.LogError("Failed to create equipment type. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to create equipment type. API StatusCode: {response.StatusCode}");
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
                new() { DataObjectType = typeof(EquipmentTypeDataObject), CacheChanges = operations.ToArray() }
            };

            return ActionHandlerOutcome.Successful(response.Data, resultList);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while creating equipment type");
            
            var errorSource = new List<string> { nameof(CreateEquipmentTypeHandler) };
            if (!string.IsNullOrEmpty(exception.Source)) 
                errorSource.Add(exception.Source);
            
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
