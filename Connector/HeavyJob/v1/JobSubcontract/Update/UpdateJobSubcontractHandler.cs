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

namespace Connector.HeavyJob.v1.JobSubcontract.Update;

public class UpdateJobSubcontractHandler : IActionHandler<UpdateJobSubcontractAction>
{
    private readonly ILogger<UpdateJobSubcontractHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdateJobSubcontractHandler(
        ILogger<UpdateJobSubcontractHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateJobSubcontractActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.UpdateJobSubcontract(
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
                            Source = new[] { nameof(UpdateJobSubcontractHandler) },
                            Text = $"Failed to update job subcontract. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new UpdateJobSubcontractActionOutput 
            { 
                Success = true,
                JobSubcontract = response.Data
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
                        Source = new[] { nameof(UpdateJobSubcontractHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
