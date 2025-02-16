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

namespace Connector.HeavyJob.v1.Equipment.Update;

public class UpdateEquipmentHandler : IActionHandler<UpdateEquipmentAction>
{
    private readonly ILogger<UpdateEquipmentHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdateEquipmentHandler(
        ILogger<UpdateEquipmentHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateEquipmentActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.UpdateEquipment(
                input.BusinessUnitId,
                input.EquipmentId,
                input,
                input.AccountingTemplateName,
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
                            Source = new[] { nameof(UpdateEquipmentHandler) },
                            Text = $"Failed to update equipment. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new UpdateEquipmentActionOutput { Success = true });
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
                        Source = new[] { nameof(UpdateEquipmentHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
