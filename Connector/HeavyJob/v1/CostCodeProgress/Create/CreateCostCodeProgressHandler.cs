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

namespace Connector.HeavyJob.v1.CostCodeProgress.Create;

public class CreateCostCodeProgressHandler : IActionHandler<CreateCostCodeProgressAction>
{
    private readonly ILogger<CreateCostCodeProgressHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateCostCodeProgressHandler(
        ILogger<CreateCostCodeProgressHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateCostCodeProgressActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.GetCostCodeProgress(
                input.JobId,
                input.Cursor,
                input.Limit,
                input.StartDate,
                input.EndDate,
                input.CostCodeIds,
                input.CostCodeTagIds,
                input.CostCodeTransactionTagIds,
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
                            Source = new[] { nameof(CreateCostCodeProgressHandler) },
                            Text = $"Failed to get cost code progress. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(response.Data);
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
                        Source = new[] { nameof(CreateCostCodeProgressHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
