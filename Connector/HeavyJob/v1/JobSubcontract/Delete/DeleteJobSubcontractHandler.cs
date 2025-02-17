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

namespace Connector.HeavyJob.v1.JobSubcontract.Delete;

public class DeleteJobSubcontractHandler : IActionHandler<DeleteJobSubcontractAction>
{
    private readonly ILogger<DeleteJobSubcontractHandler> _logger;
    private readonly ApiClient _apiClient;

    public DeleteJobSubcontractHandler(
        ILogger<DeleteJobSubcontractHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<DeleteJobSubcontractActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.DeleteJobSubcontract(
                input.Id,
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
                            Source = new[] { nameof(DeleteJobSubcontractHandler) },
                            Text = $"Failed to delete job subcontract. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new DeleteJobSubcontractActionOutput { Success = true });
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
                        Source = new[] { nameof(DeleteJobSubcontractHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
