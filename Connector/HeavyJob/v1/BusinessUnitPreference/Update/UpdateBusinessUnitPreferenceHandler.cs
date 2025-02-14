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

namespace Connector.HeavyJob.v1.BusinessUnitPreference.Update;

public class UpdateBusinessUnitPreferenceHandler : IActionHandler<UpdateBusinessUnitPreferenceAction>
{
    private readonly ILogger<UpdateBusinessUnitPreferenceHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdateBusinessUnitPreferenceHandler(
        ILogger<UpdateBusinessUnitPreferenceHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateBusinessUnitPreferenceActionInput>(actionInstance.InputJson);
        if (input == null)
        {
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "400",
                Errors = new[] { new Error { Source = new[] { "UpdateBusinessUnitPreferenceHandler" }, Text = "Invalid input" } }
            });
        }

        try
        {
            var response = await _apiClient.UpdateBusinessUnitPreferences(
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
                            Source = new[] { "UpdateBusinessUnitPreferenceHandler" },
                            Text = $"Failed to update business unit preferences. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            // Get updated preferences to return
            var updatedPreferences = await _apiClient.GetBusinessUnitPreferences(
                input.BusinessUnitId,
                cancellationToken);

            if (!updatedPreferences.IsSuccessful || updatedPreferences.Data == null)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = updatedPreferences.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { "UpdateBusinessUnitPreferenceHandler" },
                            Text = $"Failed to retrieve updated business unit preferences. Status code: {updatedPreferences.StatusCode}"
                        }
                    }
                });
            }

            var operations = new List<SyncOperation>();
            var keyResolver = new DefaultDataObjectKey();
            var key = keyResolver.BuildKeyResolver()(updatedPreferences.Data);
            operations.Add(SyncOperation.CreateSyncOperation(UpdateOperation.Upsert.ToString(), key.UrlPart, key.PropertyNames, updatedPreferences.Data));

            var resultList = new List<CacheSyncCollection>
            {
                new() { DataObjectType = typeof(BusinessUnitPreferenceDataObject), CacheChanges = operations.ToArray() }
            };

            return ActionHandlerOutcome.Successful(updatedPreferences.Data, resultList);
        }
        catch (HttpRequestException exception)
        {
            var errorSource = new List<string> { "UpdateBusinessUnitPreferenceHandler" };
            if (!string.IsNullOrEmpty(exception.Source)) errorSource.Add(exception.Source);
            
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = exception.StatusCode?.ToString() ?? "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = errorSource.ToArray(),
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
