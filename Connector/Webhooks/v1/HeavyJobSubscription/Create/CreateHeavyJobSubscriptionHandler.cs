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

namespace Connector.Webhooks.v1.HeavyJobSubscription.Create;

public class CreateHeavyJobSubscriptionHandler : IActionHandler<CreateHeavyJobSubscriptionAction>
{
    private readonly ILogger<CreateHeavyJobSubscriptionHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateHeavyJobSubscriptionHandler(
        ILogger<CreateHeavyJobSubscriptionHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateHeavyJobSubscriptionActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.CreateHeavyJobSubscription(input, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(CreateHeavyJobSubscriptionHandler) },
                            Text = $"Failed to create webhook subscription. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(response.Data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating webhook subscription");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(CreateHeavyJobSubscriptionHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
