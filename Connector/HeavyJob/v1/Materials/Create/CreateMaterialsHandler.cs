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

namespace Connector.HeavyJob.v1.Materials.Create;

public class CreateMaterialsHandler : IActionHandler<CreateMaterialsAction>
{
    private readonly ILogger<CreateMaterialsHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateMaterialsHandler(
        ILogger<CreateMaterialsHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateMaterialsActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.CreateMaterial(
                input.BusinessUnitId,
                input,
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
                            Source = new[] { nameof(CreateMaterialsHandler) },
                            Text = $"Failed to create material. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new CreateMaterialsActionOutput 
            { 
                Success = true,
                Material = response.Data
            });
        }
        catch (ApiException exception)
        {
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = exception.StatusCode.ToString(),
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(CreateMaterialsHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
