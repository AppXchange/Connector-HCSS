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
using Xchange.Connector.SDK.Client.AppNetwork;

namespace Connector.Skills.v1.Skill.Create;

public class CreateSkillHandler : IActionHandler<CreateSkillAction>
{
    private readonly ILogger<CreateSkillHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateSkillHandler(
        ILogger<CreateSkillHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateSkillActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.CreateSkill(input, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(CreateSkillHandler) },
                            Text = $"Failed to create skill. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new CreateSkillActionOutput());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating skill");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(CreateSkillHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
