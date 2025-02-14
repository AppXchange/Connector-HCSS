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

namespace Connector.Contacts.v1.VendorProducts.Create;

public class CreateVendorProductsHandler : IActionHandler<CreateVendorProductsAction>
{
    private readonly ILogger<CreateVendorProductsHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateVendorProductsHandler(
        ILogger<CreateVendorProductsHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance,
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateVendorProductsActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.CreateVendorProduct(input, cancellationToken);
            
            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(CreateVendorProductsHandler) },
                            Text = $"Failed to create vendor product with status code {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new CreateVendorProductsActionOutput { Id = response.Data });
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Failed to create vendor product");
            
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = exception.StatusCode?.ToString() ?? "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(CreateVendorProductsHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
