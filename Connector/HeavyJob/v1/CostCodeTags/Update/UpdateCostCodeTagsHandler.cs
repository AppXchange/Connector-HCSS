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

namespace Connector.HeavyJob.v1.CostCodeTags.Update;

public class UpdateCostCodeTagsHandler : IActionHandler<UpdateCostCodeTagsAction>
{
    private readonly ILogger<UpdateCostCodeTagsHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdateCostCodeTagsHandler(
        ILogger<UpdateCostCodeTagsHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateCostCodeTagsActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.UpdateCostCodeTags(input.Updates, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(UpdateCostCodeTagsHandler) },
                            Text = $"Failed to update cost code tags. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new UpdateCostCodeTagsActionOutput());
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
                        Source = new[] { nameof(UpdateCostCodeTagsHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
