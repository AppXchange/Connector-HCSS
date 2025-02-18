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

namespace Connector.Skills.v1.Skillsimport.Create;

public class CreateSkillsimportHandler : IActionHandler<CreateSkillsimportAction>
{
    private readonly ILogger<CreateSkillsimportHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateSkillsimportHandler(
        ILogger<CreateSkillsimportHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateSkillsimportActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.ImportSkills(input.Skills, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(CreateSkillsimportHandler) },
                            Text = $"Failed to import skills. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new CreateSkillsimportActionOutput { Results = response.Data });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error importing skills");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(CreateSkillsimportHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
