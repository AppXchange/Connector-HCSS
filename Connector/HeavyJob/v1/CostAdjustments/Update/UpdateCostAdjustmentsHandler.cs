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

namespace Connector.HeavyJob.v1.CostAdjustments.Update;

public class UpdateCostAdjustmentsHandler : IActionHandler<UpdateCostAdjustmentsAction>
{
    private readonly ILogger<UpdateCostAdjustmentsHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdateCostAdjustmentsHandler(
        ILogger<UpdateCostAdjustmentsHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateCostAdjustmentsActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.UpdateCostAdjustment(input, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(UpdateCostAdjustmentsHandler) },
                            Text = $"Failed to update cost adjustment. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new UpdateCostAdjustmentsActionOutput 
            { 
                Id = input.Id 
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
                        Source = new[] { nameof(UpdateCostAdjustmentsHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
