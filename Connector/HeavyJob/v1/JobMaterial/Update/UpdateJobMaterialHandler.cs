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

namespace Connector.HeavyJob.v1.JobMaterial.Update;

public class UpdateJobMaterialHandler : IActionHandler<UpdateJobMaterialAction>
{
    private readonly ILogger<UpdateJobMaterialHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdateJobMaterialHandler(
        ILogger<UpdateJobMaterialHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateJobMaterialActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.UpdateJobMaterial(
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
                            Source = new[] { nameof(UpdateJobMaterialHandler) },
                            Text = $"Failed to update job material. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new UpdateJobMaterialActionOutput 
            { 
                Success = true,
                JobMaterial = response.Data
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
                        Source = new[] { nameof(UpdateJobMaterialHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
