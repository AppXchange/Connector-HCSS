using Connector.Client;
using Connector.Connections;
using ESR.Hosting.Action;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xchange.Connector.SDK.Action;

namespace Connector.HeavyBidPreConstruction.v1.Schema.Update;

public class UpdateSchemaHandler : IActionHandler<UpdateSchemaAction>
{
    private readonly ILogger<UpdateSchemaHandler> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public UpdateSchemaHandler(
        ILogger<UpdateSchemaHandler> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        if (_connectionConfig.BusinessUnitId == default)
        {
            throw new InvalidOperationException("BusinessUnitId must be configured in the connection settings");
        }

        var input = JsonSerializer.Deserialize<UpdateSchemaActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.UpdateSchemaFieldAlias(
                _connectionConfig.BusinessUnitId,
                input.ExistingFieldAlias,
                input.NewFieldAlias,
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
                            Source = new[] { nameof(UpdateSchemaHandler) },
                            Text = $"Failed to update schema field alias. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new UpdateSchemaActionOutput { Success = true });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating schema field alias");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(UpdateSchemaHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
