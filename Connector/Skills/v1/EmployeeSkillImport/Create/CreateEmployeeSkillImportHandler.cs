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

namespace Connector.Skills.v1.EmployeeSkillImport.Create;

public class CreateEmployeeSkillImportHandler : IActionHandler<CreateEmployeeSkillImportAction>
{
    private readonly ILogger<CreateEmployeeSkillImportHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateEmployeeSkillImportHandler(
        ILogger<CreateEmployeeSkillImportHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateEmployeeSkillImportActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.ImportEmployeeSkills(input.Skills, input.UsePayrollCode, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(CreateEmployeeSkillImportHandler) },
                            Text = $"Failed to import employee skills. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new CreateEmployeeSkillImportActionOutput());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error importing employee skills");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(CreateEmployeeSkillImportHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
