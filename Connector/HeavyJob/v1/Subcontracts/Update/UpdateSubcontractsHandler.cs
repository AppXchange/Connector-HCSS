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

namespace Connector.HeavyJob.v1.Subcontracts.Update;

public class UpdateSubcontractsHandler : IActionHandler<UpdateSubcontractsAction>
{
    private readonly ILogger<UpdateSubcontractsHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdateSubcontractsHandler(
        ILogger<UpdateSubcontractsHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateSubcontractsActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.UpdateSubcontract(
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
                            Source = new[] { nameof(UpdateSubcontractsHandler) },
                            Text = $"Failed to update subcontract. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new UpdateSubcontractsActionOutput { Success = true });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating subcontract");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(UpdateSubcontractsHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
