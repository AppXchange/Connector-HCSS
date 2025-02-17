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

namespace Connector.HeavyJob.v1.QuantityAdjustment.Create;

public class CreateQuantityAdjustmentHandler : IActionHandler<CreateQuantityAdjustmentAction>
{
    private readonly ILogger<CreateQuantityAdjustmentHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateQuantityAdjustmentHandler(
        ILogger<CreateQuantityAdjustmentHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateQuantityAdjustmentActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.CreateQuantityAdjustment(
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
                            Source = new[] { nameof(CreateQuantityAdjustmentHandler) },
                            Text = $"Failed to create quantity adjustment. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            // Since this is a 204 response, we'll create our own success output
            var output = new CreateQuantityAdjustmentActionOutput { Success = true };
            return ActionHandlerOutcome.Successful(output);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating quantity adjustment");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(CreateQuantityAdjustmentHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
