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

namespace Connector.HeavyJob.v1.JobCustomCostTypeItem.Update;

public class UpdateJobCustomCostTypeItemHandler : IActionHandler<UpdateJobCustomCostTypeItemAction>
{
    private readonly ILogger<UpdateJobCustomCostTypeItemHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdateJobCustomCostTypeItemHandler(
        ILogger<UpdateJobCustomCostTypeItemHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateJobCustomCostTypeItemActionInput>(actionInstance.InputJson)!;

        try
        {
            var response = await _apiClient.UpdateJobCustomCostTypeItem(
                id: input.Id,
                input: input,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(UpdateJobCustomCostTypeItemHandler) },
                            Text = $"Failed to update job custom cost type item. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new UpdateJobCustomCostTypeItemActionOutput { Id = input.Id });
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
                        Source = new[] { nameof(UpdateJobCustomCostTypeItemHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
