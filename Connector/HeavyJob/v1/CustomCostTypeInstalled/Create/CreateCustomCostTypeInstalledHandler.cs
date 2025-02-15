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

namespace Connector.HeavyJob.v1.CustomCostTypeInstalled.Create;

public class CreateCustomCostTypeInstalledHandler : IActionHandler<CreateCustomCostTypeInstalledAction>
{
    private readonly ILogger<CreateCustomCostTypeInstalledHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateCustomCostTypeInstalledHandler(
        ILogger<CreateCustomCostTypeInstalledHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateCustomCostTypeInstalledActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.GetCustomCostTypeInstalled(
                input.BusinessUnitId,
                input.JobIds,
                input.JobTagIds,
                input.ForemanIds,
                input.StartDate,
                input.EndDate,
                input.Cursor,
                input.Limit,
                input.CostCodeIds,
                input.ModifiedSince,
                input.OnlyTM,
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
                            Source = new[] { nameof(CreateCustomCostTypeInstalledHandler) },
                            Text = $"Failed to get custom cost type installed items. Status code: {response.StatusCode}"
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
                        Source = new[] { nameof(CreateCustomCostTypeInstalledHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
