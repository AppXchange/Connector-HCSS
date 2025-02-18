using Connector.Client;
using ESR.Hosting.Action;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xchange.Connector.SDK.Action;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.Users.v1.User.Create;

public class CreateUserHandler : IActionHandler<CreateUserAction>
{
    private readonly ILogger<CreateUserHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateUserHandler(
        ILogger<CreateUserHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateUserActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.CreateUsersUser(input, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(CreateUserHandler) },
                            Text = $"Failed to create user. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new CreateUserActionOutput { Id = response.Data });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating user");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(CreateUserHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
