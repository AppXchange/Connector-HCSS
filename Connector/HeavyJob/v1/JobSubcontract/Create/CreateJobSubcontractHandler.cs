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

namespace Connector.HeavyJob.v1.JobSubcontract.Create;

public class CreateJobSubcontractHandler : IActionHandler<CreateJobSubcontractAction>
{
    private readonly ILogger<CreateJobSubcontractHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateJobSubcontractHandler(
        ILogger<CreateJobSubcontractHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateJobSubcontractActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.CreateJobSubcontract(
                input.JobId,
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
                            Source = new[] { nameof(CreateJobSubcontractHandler) },
                            Text = $"Failed to create job subcontract. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new CreateJobSubcontractActionOutput 
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
                        Source = new[] { nameof(CreateJobSubcontractHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
