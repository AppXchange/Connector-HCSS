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

namespace Connector.Setups.v1.BulkCostCode.Create;

public class CreateBulkCostCodeHandler : IActionHandler<CreateBulkCostCodeAction>
{
    private readonly ILogger<CreateBulkCostCodeHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateBulkCostCodeHandler(
        ILogger<CreateBulkCostCodeHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateBulkCostCodeActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.CreateBulkCostCodes(input.CostCodes, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(CreateBulkCostCodeHandler) },
                            Text = $"Failed to create bulk cost codes. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            // Since this is a 204 response with no content, we return success with empty output
            return ActionHandlerOutcome.Successful(new CreateBulkCostCodeActionOutput());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating bulk cost codes");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(CreateBulkCostCodeHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
