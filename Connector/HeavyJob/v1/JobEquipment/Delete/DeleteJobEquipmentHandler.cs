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

namespace Connector.HeavyJob.v1.JobEquipment.Delete;

public class DeleteJobEquipmentHandler : IActionHandler<DeleteJobEquipmentAction>
{
    private readonly ILogger<DeleteJobEquipmentHandler> _logger;
    private readonly ApiClient _apiClient;

    public DeleteJobEquipmentHandler(
        ILogger<DeleteJobEquipmentHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<DeleteJobEquipmentActionInput>(actionInstance.InputJson)!;

        if (input.JobId == null && input.EquipmentId == null)
        {
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "400",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(DeleteJobEquipmentHandler) },
                        Text = "Either jobId or equipmentId must be provided"
                    }
                }
            });
        }
        
        try
        {
            var response = await _apiClient.DeleteJobEquipment(
                input.BusinessUnitId,
                input.JobId,
                input.EquipmentId,
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
                            Source = new[] { nameof(DeleteJobEquipmentHandler) },
                            Text = $"Failed to delete job equipment. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new DeleteJobEquipmentActionOutput { Success = true });
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
                        Source = new[] { nameof(DeleteJobEquipmentHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
