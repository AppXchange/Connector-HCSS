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

namespace Connector.Contacts.v1.ProductType.Update;

public class UpdateProductTypeHandler : IActionHandler<UpdateProductTypeAction>
{
    private readonly ILogger<UpdateProductTypeHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdateProductTypeHandler(
        ILogger<UpdateProductTypeHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance,
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateProductTypeActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.UpdateProductType(input, cancellationToken);
            
            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(UpdateProductTypeHandler) },
                            Text = $"Failed to update product type with status code {response.StatusCode}"
                        }
                    }
                });
            }

            var output = new UpdateProductTypeActionOutput { Id = response.Data!.Id };
            return ActionHandlerOutcome.Successful(output);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Failed to update product type");
            
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = exception.StatusCode?.ToString() ?? "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(UpdateProductTypeHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
