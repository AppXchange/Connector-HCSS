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

namespace Connector.Skills.v1.Skill.Update;

public class UpdateSkillHandler : IActionHandler<UpdateSkillAction>
{
    private readonly ILogger<UpdateSkillHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdateSkillHandler(
        ILogger<UpdateSkillHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateSkillActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.UpdateSkill(input.CourseCodeOrName, input, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(UpdateSkillHandler) },
                            Text = $"Failed to update skill. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new UpdateSkillActionOutput());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating skill");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(UpdateSkillHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
