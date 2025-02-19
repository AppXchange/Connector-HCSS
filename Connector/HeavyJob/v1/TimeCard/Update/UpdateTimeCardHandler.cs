using Connector.Client;
using ESR.Hosting.Action;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xchange.Connector.SDK.Action;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Client.AppNetwork;

namespace Connector.HeavyJob.v1.TimeCard.Update;

public class UpdateTimeCardHandler : IActionHandler<UpdateTimeCardAction>
{
    private readonly ILogger<UpdateTimeCardHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdateTimeCardHandler(
        ILogger<UpdateTimeCardHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateTimeCardActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.UpdateTimeCard(
                input.Id,
                input,
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
                            Source = new[] { nameof(UpdateTimeCardHandler) },
                            Text = $"Failed to update time card. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new UpdateTimeCardActionOutput { Success = true });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating time card");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(UpdateTimeCardHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
