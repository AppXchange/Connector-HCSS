using Connector.Client;
using ESR.Hosting.Action;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xchange.Connector.SDK.Action;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Client.AppNetwork;

namespace Connector.HeavyJob.v1.Employees.Delete;

public class DeleteEmployeesHandler : IActionHandler<DeleteEmployeesAction>
{
    private readonly ILogger<DeleteEmployeesHandler> _logger;
    private readonly ApiClient _apiClient;

    public DeleteEmployeesHandler(
        ILogger<DeleteEmployeesHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<DeleteEmployeesActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.DeleteEmployees(input.EmployeeIds, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(DeleteEmployeesHandler) },
                            Text = $"Failed to delete employees. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new DeleteEmployeesActionOutput 
            { 
                Success = true 
            });
        }
        catch (ApiException exception)
        {
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = exception.StatusCode.ToString(),
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(DeleteEmployeesHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
