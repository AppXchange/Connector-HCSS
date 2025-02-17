using Connector.Client;
using ESR.Hosting.Action;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xchange.Connector.SDK.Action;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Client.AppNetwork;

namespace Connector.HeavyJob.v1.UserAccessGroup.Update;

public class UpdateUserAccessGroupHandler : IActionHandler<UpdateUserAccessGroupAction>
{
    private readonly ILogger<UpdateUserAccessGroupHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdateUserAccessGroupHandler(
        ILogger<UpdateUserAccessGroupHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateUserAccessGroupActionInput[]>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.UpdateUserAccessGroups(
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
                            Source = new[] { nameof(UpdateUserAccessGroupHandler) },
                            Text = $"Failed to update user access groups. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(response.Data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating user access groups");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(UpdateUserAccessGroupHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
