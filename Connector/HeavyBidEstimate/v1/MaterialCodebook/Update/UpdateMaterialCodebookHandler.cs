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

namespace Connector.HeavyBidEstimate.v1.MaterialCodebook.Update;

public class UpdateMaterialCodebookHandler : IActionHandler<UpdateMaterialCodebookAction>
{
    private readonly ILogger<UpdateMaterialCodebookHandler> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public UpdateMaterialCodebookHandler(
        ILogger<UpdateMaterialCodebookHandler> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateMaterialCodebookActionInput>(actionInstance.InputJson)!;
        try
        {
            var response = await _apiClient.UpdateMaterialCodebook(
                id: input.Id,
                businessUnitId: _connectionConfig.BusinessUnitId,
                input: input,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful || response.Data?.Data == null)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(UpdateMaterialCodebookHandler) },
                            Text = $"Failed to update material codebook. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            var operations = new List<SyncOperation>();
            var keyResolver = new DefaultDataObjectKey();
            var key = keyResolver.BuildKeyResolver()(response.Data.Data);
            operations.Add(SyncOperation.CreateSyncOperation(UpdateOperation.Upsert.ToString(), key.UrlPart, key.PropertyNames, response.Data.Data));

            var resultList = new List<CacheSyncCollection>
            {
                new() { DataObjectType = typeof(MaterialCodebookDataObject), CacheChanges = operations.ToArray() }
            };

            return ActionHandlerOutcome.Successful(response.Data.Data, resultList);
        }
        catch (HttpRequestException exception)
        {
            var errorSource = new List<string> { nameof(UpdateMaterialCodebookHandler) };
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
