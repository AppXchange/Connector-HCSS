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

namespace Connector.Contacts.v1.Vendor.Update;

public class UpdateVendorHandler : IActionHandler<UpdateVendorAction>
{
    private readonly ILogger<UpdateVendorHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdateVendorHandler(
        ILogger<UpdateVendorHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance,
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateVendorActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.UpdateVendor(input, cancellationToken);
            
            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(UpdateVendorHandler) },
                            Text = $"Failed to update vendor with status code {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new UpdateVendorActionOutput { Id = response.Data!.Id });
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Failed to update vendor");
            
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = exception.StatusCode?.ToString() ?? "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(UpdateVendorHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
