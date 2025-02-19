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

namespace Connector.Safety.v1.Alerts.Delete;

public class DeleteAlertsHandler : IActionHandler<DeleteAlertsAction>
{
    private readonly ILogger<DeleteAlertsHandler> _logger;
    private readonly ApiClient _apiClient;

    public DeleteAlertsHandler(
        ILogger<DeleteAlertsHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<DeleteAlertsActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.DeleteAlert(input, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(DeleteAlertsHandler) },
                            Text = $"Failed to delete alert. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            // Since this is a 204 response with no content, we return success with empty output
            return ActionHandlerOutcome.Successful(new DeleteAlertsActionOutput());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting alert");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(DeleteAlertsHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
