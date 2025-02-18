using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.Safety.v1.Alerts;

public class AlertsDataReader : TypedAsyncDataReaderBase<AlertsDataObject>
{
    private readonly ILogger<AlertsDataReader> _logger;
    private readonly ApiClient _apiClient;
    private string? _cursor;

    public AlertsDataReader(
        ILogger<AlertsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<AlertsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var businessUnitId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("businessUnitId", out var businessUnitIdElement) 
            ? businessUnitIdElement.GetString()
            : null;

        while (true)
        {
            var response = await _apiClient.GetAlerts(
                businessUnitId: businessUnitId,
                cursor: _cursor,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve alerts. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve alerts. API StatusCode: {response.StatusCode}");
            }

            if (response.Data?.Results == null || response.Data.Results.Length == 0)
            {
                break;
            }

            foreach (var alert in response.Data.Results)
            {
                yield return alert;
            }

            _cursor = response.Data.Metadata.NextCursor;
            if (string.IsNullOrEmpty(_cursor))
            {
                break;
            }
        }
    }
}