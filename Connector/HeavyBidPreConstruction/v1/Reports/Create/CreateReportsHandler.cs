using Connector.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using Xchange.Connector.SDK.Action;
using ESR.Hosting.Action;

namespace Connector.HeavyBidPreConstruction.v1.Reports.Create;

public class CreateReportsHandler : IActionHandler<CreateReportsAction>
{
    private readonly ILogger<CreateReportsHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateReportsHandler(
        ILogger<CreateReportsHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateReportsActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.GenerateProjectReport(
                input.BusinessUnitId,
                input.ProjectId,
                input.HiddenProjectFields,
                input.HiddenEstimateColumns,
                input.Settings,
                cancellationToken);

            if (!response.IsSuccessful || response.Data == null)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(CreateReportsHandler) },
                            Text = $"Failed to generate report. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(response.Data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating report");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(CreateReportsHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
