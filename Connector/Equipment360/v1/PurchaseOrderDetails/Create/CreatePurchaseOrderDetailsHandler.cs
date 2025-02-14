using Connector.Client;
using ESR.Hosting.Action;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xchange.Connector.SDK.Action;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Client.AppNetwork;

namespace Connector.Equipment360.v1.PurchaseOrderDetails.Create;

public class CreatePurchaseOrderDetailsHandler : IActionHandler<CreatePurchaseOrderDetailsAction>
{
    private readonly ILogger<CreatePurchaseOrderDetailsHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreatePurchaseOrderDetailsHandler(
        ILogger<CreatePurchaseOrderDetailsHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance,
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreatePurchaseOrderDetailsActionInput>(actionInstance.InputJson)!;
        try
        {
            var response = await _apiClient.CreatePurchaseOrderDetail(input.PurchaseOrderId, input, cancellationToken);

            if (!response.IsSuccessful || response.Data == null)
            {
                _logger.LogError("Failed to create purchase order detail. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to create purchase order detail. API StatusCode: {response.StatusCode}");
            }

            return ActionHandlerOutcome.Successful(response.Data);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while creating purchase order detail");
            
            var errorSource = new List<string> { nameof(CreatePurchaseOrderDetailsHandler) };
            if (!string.IsNullOrEmpty(exception.Source)) 
                errorSource.Add(exception.Source);
            
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = exception.StatusCode?.ToString() ?? "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = errorSource.ToArray(),
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
