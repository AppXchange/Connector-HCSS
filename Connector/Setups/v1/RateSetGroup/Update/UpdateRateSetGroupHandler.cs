using Connector.Client;
using ESR.Hosting.Action;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xchange.Connector.SDK.Action;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Client.AppNetwork;

namespace Connector.Setups.v1.RateSetGroup.Update;

public class UpdateRateSetGroupHandler : IActionHandler<UpdateRateSetGroupAction>
{
    private readonly ILogger<UpdateRateSetGroupHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdateRateSetGroupHandler(
        ILogger<UpdateRateSetGroupHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateRateSetGroupActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.UpdateRateSetGroup(input.Id, input, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(UpdateRateSetGroupHandler) },
                            Text = $"Failed to update rate set group. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(response.Data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating rate set group");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(UpdateRateSetGroupHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
