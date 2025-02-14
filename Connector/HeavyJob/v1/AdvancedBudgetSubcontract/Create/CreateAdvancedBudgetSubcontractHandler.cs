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

namespace Connector.HeavyJob.v1.AdvancedBudgetSubcontract.Create;

public class CreateAdvancedBudgetSubcontractHandler : IActionHandler<CreateAdvancedBudgetSubcontractAction>
{
    private readonly ILogger<CreateAdvancedBudgetSubcontractHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateAdvancedBudgetSubcontractHandler(
        ILogger<CreateAdvancedBudgetSubcontractHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateAdvancedBudgetSubcontractActionInput>(actionInstance.InputJson);
        try
        {
            var response = await _apiClient.CreateAdvancedBudgetSubcontract(
                input!,
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
                            Source = new[] { "CreateAdvancedBudgetSubcontractHandler" },
                            Text = $"Failed to create advanced budget subcontract. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            var operations = new List<SyncOperation>();
            if (response.Data != null)
            {
                var keyResolver = new DefaultDataObjectKey();
                var key = keyResolver.BuildKeyResolver()(response.Data);
                operations.Add(SyncOperation.CreateSyncOperation(UpdateOperation.Upsert.ToString(), key.UrlPart, key.PropertyNames, response.Data));
            }

            var resultList = new List<CacheSyncCollection>
            {
                new() { DataObjectType = typeof(AdvancedBudgetSubcontractDataObject), CacheChanges = operations.ToArray() }
            };

            return ActionHandlerOutcome.Successful(response.Data, resultList);
        }
        catch (HttpRequestException exception)
        {
            var errorSource = new List<string> { "CreateAdvancedBudgetSubcontractHandler" };
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
