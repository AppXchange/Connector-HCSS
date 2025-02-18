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

namespace Connector.Skills.v1.EmployeeSkills.Create;

public class CreateEmployeeSkillsHandler : IActionHandler<CreateEmployeeSkillsAction>
{
    private readonly ILogger<CreateEmployeeSkillsHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateEmployeeSkillsHandler(
        ILogger<CreateEmployeeSkillsHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateEmployeeSkillsActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.CreateEmployeeSkill(input, input.UsePayrollCode, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(CreateEmployeeSkillsHandler) },
                            Text = $"Failed to create employee skill. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new CreateEmployeeSkillsActionOutput { Id = response.Data ?? string.Empty });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating employee skill");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(CreateEmployeeSkillsHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
