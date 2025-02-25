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

namespace Connector.Skills.v1.Skill.Delete;

public class DeleteSkillHandler : IActionHandler<DeleteSkillAction>
{
    private readonly ILogger<DeleteSkillHandler> _logger;
    private readonly ApiClient _apiClient;

    public DeleteSkillHandler(
        ILogger<DeleteSkillHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<DeleteSkillActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.DeleteSkill(input.CourseCodeOrName, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(DeleteSkillHandler) },
                            Text = $"Failed to delete skill. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new DeleteSkillActionOutput());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting skill");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(DeleteSkillHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
