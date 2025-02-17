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

namespace Connector.HeavyJob.v1.MaterialSubsAndCustomCosts.Update;

public class UpdateMaterialSubsAndCustomCostsHandler : IActionHandler<UpdateMaterialSubsAndCustomCostsAction>
{
    private readonly ILogger<UpdateMaterialSubsAndCustomCostsHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdateMaterialSubsAndCustomCostsHandler(
        ILogger<UpdateMaterialSubsAndCustomCostsHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateMaterialSubsAndCustomCostsActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.UpdateMaterialSubsAndCustomCosts(
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
                            Source = new[] { nameof(UpdateMaterialSubsAndCustomCostsHandler) },
                            Text = $"Failed to update material subs and custom costs. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new UpdateMaterialSubsAndCustomCostsActionOutput { Success = true });
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
                        Source = new[] { nameof(UpdateMaterialSubsAndCustomCostsHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
