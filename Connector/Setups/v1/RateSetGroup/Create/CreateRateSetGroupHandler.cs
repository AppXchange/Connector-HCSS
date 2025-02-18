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

namespace Connector.Setups.v1.RateSetGroup.Create;

public class CreateRateSetGroupHandler : IActionHandler<CreateRateSetGroupAction>
{
    private readonly ILogger<CreateRateSetGroupHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateRateSetGroupHandler(
        ILogger<CreateRateSetGroupHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateRateSetGroupActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.CreateRateSetGroup(input, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(CreateRateSetGroupHandler) },
                            Text = $"Failed to create rate set group. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            var output = new CreateRateSetGroupActionOutput { Id = response.Data };
            return ActionHandlerOutcome.Successful(output);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating rate set group");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(CreateRateSetGroupHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
