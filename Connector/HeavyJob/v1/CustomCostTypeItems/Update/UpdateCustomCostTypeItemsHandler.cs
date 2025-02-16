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

namespace Connector.HeavyJob.v1.CustomCostTypeItems.Update;

public class UpdateCustomCostTypeItemsHandler : IActionHandler<UpdateCustomCostTypeItemsAction>
{
    private readonly ILogger<UpdateCustomCostTypeItemsHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdateCustomCostTypeItemsHandler(
        ILogger<UpdateCustomCostTypeItemsHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateCustomCostTypeItemsActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.UpdateCustomCostTypeItem(input, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(UpdateCustomCostTypeItemsHandler) },
                            Text = $"Failed to update custom cost type item. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new UpdateCustomCostTypeItemsActionOutput());
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
                        Source = new[] { nameof(UpdateCustomCostTypeItemsHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
