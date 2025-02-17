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

namespace Connector.HeavyJob.v1.ReleaseOrderApprovalRule.Delete;

public class DeleteReleaseOrderApprovalRuleHandler : IActionHandler<DeleteReleaseOrderApprovalRuleAction>
{
    private readonly ILogger<DeleteReleaseOrderApprovalRuleHandler> _logger;
    private readonly ApiClient _apiClient;

    public DeleteReleaseOrderApprovalRuleHandler(
        ILogger<DeleteReleaseOrderApprovalRuleHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<DeleteReleaseOrderApprovalRuleActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.DeleteReleaseOrderApprovalRuleApprovers(
                input.ApproverIds,
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
                            Source = new[] { nameof(DeleteReleaseOrderApprovalRuleHandler) },
                            Text = $"Failed to delete approvers. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new DeleteReleaseOrderApprovalRuleActionOutput { Success = true });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting approvers");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(DeleteReleaseOrderApprovalRuleHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
