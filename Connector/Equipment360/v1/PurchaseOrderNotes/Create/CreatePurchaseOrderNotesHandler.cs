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

namespace Connector.Equipment360.v1.PurchaseOrderNotes.Create;

public class CreatePurchaseOrderNotesHandler : IActionHandler<CreatePurchaseOrderNotesAction>
{
    private readonly ILogger<CreatePurchaseOrderNotesHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreatePurchaseOrderNotesHandler(
        ILogger<CreatePurchaseOrderNotesHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance,
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreatePurchaseOrderNotesActionInput>(actionInstance.InputJson)!;
        try
        {
            var response = await _apiClient.CreatePurchaseOrderNote(input.PurchaseOrderId, input, cancellationToken);

            if (!response.IsSuccessful || response.Data == null)
            {
                _logger.LogError("Failed to create purchase order note. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to create purchase order note. API StatusCode: {response.StatusCode}");
            }

            return ActionHandlerOutcome.Successful(response.Data);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while creating purchase order note");
            
            var errorSource = new List<string> { nameof(CreatePurchaseOrderNotesHandler) };
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
