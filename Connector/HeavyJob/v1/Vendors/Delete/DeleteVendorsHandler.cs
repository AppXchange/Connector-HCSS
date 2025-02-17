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

namespace Connector.HeavyJob.v1.Vendors.Delete;

public class DeleteVendorsHandler : IActionHandler<DeleteVendorsAction>
{
    private readonly ILogger<DeleteVendorsHandler> _logger;
    private readonly ApiClient _apiClient;

    public DeleteVendorsHandler(
        ILogger<DeleteVendorsHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<DeleteVendorsActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.DeleteVendor(input, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(DeleteVendorsHandler) },
                            Text = $"Failed to delete vendor. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            // Since this is a 204 response with no content, we return success with empty output
            return ActionHandlerOutcome.Successful(new DeleteVendorsActionOutput());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting vendor");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(DeleteVendorsHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
