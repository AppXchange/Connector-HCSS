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

namespace Connector.HeavyJob.v1.MaterialPurchaseOrderDetails.Create;

public class CreateMaterialPurchaseOrderDetailsHandler : IActionHandler<CreateMaterialPurchaseOrderDetailsAction>
{
    private readonly ILogger<CreateMaterialPurchaseOrderDetailsHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateMaterialPurchaseOrderDetailsHandler(
        ILogger<CreateMaterialPurchaseOrderDetailsHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateMaterialPurchaseOrderDetailsActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.CreateMaterialPurchaseOrderDetail(
                input.PurchaseOrderId,
                input,
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
                            Source = new[] { nameof(CreateMaterialPurchaseOrderDetailsHandler) },
                            Text = $"Failed to create material purchase order detail. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new CreateMaterialPurchaseOrderDetailsActionOutput 
            { 
                Success = true,
                MaterialPurchaseOrderDetail = response.Data
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
                        Source = new[] { nameof(CreateMaterialPurchaseOrderDetailsHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
