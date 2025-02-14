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

namespace Connector.Equipment360.v1.PurchaseOrder.Create;

public class CreatePurchaseOrderHandler : IActionHandler<CreatePurchaseOrderAction>
{
    private readonly ILogger<CreatePurchaseOrderHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreatePurchaseOrderHandler(
        ILogger<CreatePurchaseOrderHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance,
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreatePurchaseOrderActionInput>(actionInstance.InputJson)!;
        try
        {
            var response = await _apiClient.CreatePurchaseOrder(input, cancellationToken);

            if (!response.IsSuccessful || response.Data == null)
            {
                _logger.LogError("Failed to create purchase order. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to create purchase order. API StatusCode: {response.StatusCode}");
            }

            return ActionHandlerOutcome.Successful(response.Data);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while creating purchase order");
            
            var errorSource = new List<string> { nameof(CreatePurchaseOrderHandler) };
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
