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

namespace Connector.Equipment360.v1.PartInventory.Create;

public class CreatePartInventoryHandler : IActionHandler<CreatePartInventoryAction>
{
    private readonly ILogger<CreatePartInventoryHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreatePartInventoryHandler(
        ILogger<CreatePartInventoryHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance,
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreatePartInventoryActionInput>(actionInstance.InputJson)!;
        try
        {
            var response = await _apiClient.CreatePartInventory(input, cancellationToken);

            if (!response.IsSuccessful || response.Data == null)
            {
                _logger.LogError("Failed to create part inventory. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to create part inventory. API StatusCode: {response.StatusCode}");
            }

            return ActionHandlerOutcome.Successful(response.Data);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while creating part inventory");
            
            var errorSource = new List<string> { nameof(CreatePartInventoryHandler) };
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
