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

namespace Connector.HeavyJob.v1.VendorContractDetails.Update;

public class UpdateVendorContractDetailsHandler : IActionHandler<UpdateVendorContractDetailsAction>
{
    private readonly ILogger<UpdateVendorContractDetailsHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdateVendorContractDetailsHandler(
        ILogger<UpdateVendorContractDetailsHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateVendorContractDetailsActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.UpdateVendorContractDetails(input, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(UpdateVendorContractDetailsHandler) },
                            Text = $"Failed to update vendor contract details. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            // Since this is a 204 response with no content, we return success with empty output
            return ActionHandlerOutcome.Successful(new UpdateVendorContractDetailsActionOutput());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating vendor contract details");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(UpdateVendorContractDetailsHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
