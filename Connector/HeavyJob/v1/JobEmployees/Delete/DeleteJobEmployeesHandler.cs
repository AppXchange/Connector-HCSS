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

namespace Connector.HeavyJob.v1.JobEmployees.Delete;

public class DeleteJobEmployeesHandler : IActionHandler<DeleteJobEmployeesAction>
{
    private readonly ILogger<DeleteJobEmployeesHandler> _logger;
    private readonly ApiClient _apiClient;

    public DeleteJobEmployeesHandler(
        ILogger<DeleteJobEmployeesHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<DeleteJobEmployeesActionInput>(actionInstance.InputJson)!;

        if (input.JobId == null && input.EmployeeId == null)
        {
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "400",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(DeleteJobEmployeesHandler) },
                        Text = "Either jobId or employeeId must be provided"
                    }
                }
            });
        }
        
        try
        {
            var response = await _apiClient.DeleteJobEmployees(
                input.BusinessUnitId,
                input.JobId,
                input.EmployeeId,
                cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(DeleteJobEmployeesHandler) },
                            Text = $"Failed to delete job employees. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new DeleteJobEmployeesActionOutput { Success = true });
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
                        Source = new[] { nameof(DeleteJobEmployeesHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
