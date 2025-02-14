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

namespace Connector.HeavyJob.v1.CostCodeTags.Delete;

public class DeleteCostCodeTagsHandler : IActionHandler<DeleteCostCodeTagsAction>
{
    private readonly ILogger<DeleteCostCodeTagsHandler> _logger;
    private readonly ApiClient _apiClient;

    public DeleteCostCodeTagsHandler(
        ILogger<DeleteCostCodeTagsHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<DeleteCostCodeTagsActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.DeleteCostCodeTags(input, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(DeleteCostCodeTagsHandler) },
                            Text = $"Failed to delete cost code tags. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new DeleteCostCodeTagsActionOutput());
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
                        Source = new[] { nameof(DeleteCostCodeTagsHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
