using Connector.Client;
using Connector.Connections;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.CustomCostTypeInstalled;

public class CustomCostTypeInstalledDataReader : TypedAsyncDataReaderBase<CustomCostTypeInstalledDataObject>
{
    private readonly ILogger<CustomCostTypeInstalledDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public CustomCostTypeInstalledDataReader(
        ILogger<CustomCostTypeInstalledDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<CustomCostTypeInstalledDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        string? cursor = null;

        while (true)
        {
            var response = await _apiClient.GetCustomCostTypeInstalled(
                _connectionConfig.BusinessUnitId,
                null, // jobIds
                null, // jobTagIds
                null, // foremanIds
                null, // startDate
                null, // endDate
                cursor,
                1000, // limit
                null, // costCodeIds
                null, // modifiedSince
                null, // onlyTM
                cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve custom cost type installed items. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve custom cost type installed items. API StatusCode: {response.StatusCode}");
            }

            if (response.Data?.Results == null)
            {
                _logger.LogWarning("No custom cost type installed items found");
                yield break;
            }

            foreach (var item in response.Data.Results)
            {
                yield return item;
            }

            if (string.IsNullOrEmpty(response.Data.Metadata.NextCursor))
            {
                break;
            }

            cursor = response.Data.Metadata.NextCursor;
        }
    }
}