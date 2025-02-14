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

namespace Connector.HeavyJob.v1.CostCodes.Update;

public class UpdateCostCodesHandler : IActionHandler<UpdateCostCodesAction>
{
    private readonly ILogger<UpdateCostCodesHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdateCostCodesHandler(
        ILogger<UpdateCostCodesHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateCostCodesActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.UpdateCostCodeBudgets(input.Budgets, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(UpdateCostCodesHandler) },
                            Text = $"Failed to update cost code budgets. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new UpdateCostCodesActionOutput());
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
                        Source = new[] { nameof(UpdateCostCodesHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
