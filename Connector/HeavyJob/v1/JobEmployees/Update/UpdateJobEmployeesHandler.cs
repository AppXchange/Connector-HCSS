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

namespace Connector.HeavyJob.v1.JobEmployees.Update;

public class UpdateJobEmployeesHandler : IActionHandler<UpdateJobEmployeesAction>
{
    private readonly ILogger<UpdateJobEmployeesHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdateJobEmployeesHandler(
        ILogger<UpdateJobEmployeesHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateJobEmployeesActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.UpdateJobEmployees(
                input.BusinessUnitId,
                input.Relations,
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
                            Source = new[] { nameof(UpdateJobEmployeesHandler) },
                            Text = $"Failed to update job employees. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new UpdateJobEmployeesActionOutput { Success = true });
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
                        Source = new[] { nameof(UpdateJobEmployeesHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
