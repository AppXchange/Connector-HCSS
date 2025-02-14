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

namespace Connector.HeavyJob.v1.CostCategories.Create;

public class CreateCostCategoriesHandler : IActionHandler<CreateCostCategoriesAction>
{
    private readonly ILogger<CreateCostCategoriesHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateCostCategoriesHandler(
        ILogger<CreateCostCategoriesHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateCostCategoriesActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.CreateCostCategory(input, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(CreateCostCategoriesHandler) },
                            Text = $"Failed to create cost category. Status code: {response.StatusCode}"
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
                            Source = new[] { nameof(CreateCostCategoriesHandler) },
                            Text = "No data returned from create cost category request"
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
                new CacheSyncCollection { DataObjectType = typeof(CostCategoriesDataObject), CacheChanges = operations.ToArray() }
            };

            return ActionHandlerOutcome.Successful(response.Data, resultList);
        }
        catch (ApiException exception)
        {
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = exception.StatusCode.ToString(),
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(CreateCostCategoriesHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
