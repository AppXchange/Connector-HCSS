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

namespace Connector.Users.v1.User.Update;

public class UpdateUserHandler : IActionHandler<UpdateUserAction>
{
    private readonly ILogger<UpdateUserHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdateUserHandler(
        ILogger<UpdateUserHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = System.Text.Json.JsonSerializer.Deserialize<UpdateUserActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.UpdateUsersUser(input.Id, input, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(UpdateUserHandler) },
                            Text = $"Failed to update user. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new UpdateUserActionOutput());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating user");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(UpdateUserHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
