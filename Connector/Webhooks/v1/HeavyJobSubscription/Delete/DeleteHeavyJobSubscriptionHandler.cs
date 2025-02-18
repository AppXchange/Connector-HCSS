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

namespace Connector.Webhooks.v1.HeavyJobSubscription.Delete;

public class DeleteHeavyJobSubscriptionHandler : IActionHandler<DeleteHeavyJobSubscriptionAction>
{
    private readonly ILogger<DeleteHeavyJobSubscriptionHandler> _logger;
    private readonly ApiClient _apiClient;

    public DeleteHeavyJobSubscriptionHandler(
        ILogger<DeleteHeavyJobSubscriptionHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<DeleteHeavyJobSubscriptionActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.DeleteHeavyJobSubscription(input.Url, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(DeleteHeavyJobSubscriptionHandler) },
                            Text = $"Failed to delete webhook subscription. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new DeleteHeavyJobSubscriptionActionOutput());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting webhook subscription");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(DeleteHeavyJobSubscriptionHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
