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

namespace Connector.HeavyJob.v1.CostCodeCosts.Update;

public class UpdateCostCodeCostsHandler : IActionHandler<UpdateCostCodeCostsAction>
{
    private readonly ILogger<UpdateCostCodeCostsHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdateCostCodeCostsHandler(
        ILogger<UpdateCostCodeCostsHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateCostCodeCostsActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.UpdateCostCodeCosts(input, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(UpdateCostCodeCostsHandler) },
                            Text = $"Failed to update cost code costs. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new UpdateCostCodeCostsActionOutput 
            { 
                CostCodeId = input.CostCodeId 
            });
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
                        Source = new[] { nameof(UpdateCostCodeCostsHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
