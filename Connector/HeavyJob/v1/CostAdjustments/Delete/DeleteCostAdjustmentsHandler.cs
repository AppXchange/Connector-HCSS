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

namespace Connector.HeavyJob.v1.CostAdjustments.Delete;

public class DeleteCostAdjustmentsHandler : IActionHandler<DeleteCostAdjustmentsAction>
{
    private readonly ILogger<DeleteCostAdjustmentsHandler> _logger;
    private readonly ApiClient _apiClient;

    public DeleteCostAdjustmentsHandler(
        ILogger<DeleteCostAdjustmentsHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<DeleteCostAdjustmentsActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.DeleteCostAdjustment(input.Id, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(DeleteCostAdjustmentsHandler) },
                            Text = $"Failed to delete cost adjustment. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new DeleteCostAdjustmentsActionOutput 
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
                        Source = new[] { nameof(DeleteCostAdjustmentsHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
