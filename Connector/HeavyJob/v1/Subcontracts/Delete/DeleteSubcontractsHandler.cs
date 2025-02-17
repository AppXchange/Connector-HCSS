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

namespace Connector.HeavyJob.v1.Subcontracts.Delete;

public class DeleteSubcontractsHandler : IActionHandler<DeleteSubcontractsAction>
{
    private readonly ILogger<DeleteSubcontractsHandler> _logger;
    private readonly ApiClient _apiClient;

    public DeleteSubcontractsHandler(
        ILogger<DeleteSubcontractsHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<DeleteSubcontractsActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.DeleteSubcontract(
                input.Id,
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
                            Source = new[] { nameof(DeleteSubcontractsHandler) },
                            Text = $"Failed to delete subcontract. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new DeleteSubcontractsActionOutput { Success = true });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting subcontract");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(DeleteSubcontractsHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
