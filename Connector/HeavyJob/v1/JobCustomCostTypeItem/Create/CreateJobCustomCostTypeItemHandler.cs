using Connector.Client;
using ESR.Hosting.Action;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xchange.Connector.SDK.Action;
using Xchange.Connector.SDK.Client.AppNetwork;

namespace Connector.HeavyJob.v1.JobCustomCostTypeItem.Create;

public class CreateJobCustomCostTypeItemHandler : IActionHandler<CreateJobCustomCostTypeItemAction>
{
    private readonly ILogger<CreateJobCustomCostTypeItemHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateJobCustomCostTypeItemHandler(
        ILogger<CreateJobCustomCostTypeItemHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateJobCustomCostTypeItemActionInput>(actionInstance.InputJson)!;

        try
        {
            var response = await _apiClient.CreateJobCustomCostTypeItem(
                jobId: input.JobId,
                input: input,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful || response.Data == null)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(CreateJobCustomCostTypeItemHandler) },
                            Text = $"Failed to create job custom cost type item. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(response.Data);
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
                        Source = new[] { nameof(CreateJobCustomCostTypeItemHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
