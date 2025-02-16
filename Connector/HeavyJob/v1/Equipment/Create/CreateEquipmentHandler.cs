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

namespace Connector.HeavyJob.v1.Equipment.Create;

public class CreateEquipmentHandler : IActionHandler<CreateEquipmentAction>
{
    private readonly ILogger<CreateEquipmentHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateEquipmentHandler(
        ILogger<CreateEquipmentHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateEquipmentActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.GetEquipmentAdvanced(
                input.BusinessUnitId,
                input.EquipmentCodes,
                input.EquipmentIds,
                input.JobIds,
                input.JobTagIds,
                input.AccountingTemplateName,
                input.IsActive,
                input.IsActiveInAnyActiveJobs,
                input.IsDeleted,
                input.Cursor,
                input.Limit,
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
                            Source = new[] { nameof(CreateEquipmentHandler) },
                            Text = $"Failed to get equipment. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(response.Data);
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
                        Source = new[] { nameof(CreateEquipmentHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
