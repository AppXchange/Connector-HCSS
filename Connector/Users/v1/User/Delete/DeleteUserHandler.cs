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

namespace Connector.Users.v1.User.Delete;

public class DeleteUserHandler : IActionHandler<DeleteUserAction>
{
    private readonly ILogger<DeleteUserHandler> _logger;
    private readonly ApiClient _apiClient;

    public DeleteUserHandler(
        ILogger<DeleteUserHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = System.Text.Json.JsonSerializer.Deserialize<DeleteUserActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.DeleteUsersUser(input.Id, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(DeleteUserHandler) },
                            Text = $"Failed to delete user. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new DeleteUserActionOutput());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting user");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(DeleteUserHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
