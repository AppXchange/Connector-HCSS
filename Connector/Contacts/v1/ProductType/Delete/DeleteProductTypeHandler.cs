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

namespace Connector.Contacts.v1.ProductType.Delete;

public class DeleteProductTypeHandler : IActionHandler<DeleteProductTypeAction>
{
    private readonly ILogger<DeleteProductTypeHandler> _logger;
    private readonly ApiClient _apiClient;

    public DeleteProductTypeHandler(
        ILogger<DeleteProductTypeHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance,
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<DeleteProductTypeActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.DeleteProductType(input, cancellationToken);
            
            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(DeleteProductTypeHandler) },
                            Text = $"Failed to delete product type with status code {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new DeleteProductTypeActionOutput());
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Failed to delete product type");
            
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = exception.StatusCode?.ToString() ?? "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(DeleteProductTypeHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
