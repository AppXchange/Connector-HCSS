using Connector.Client;
using Connector.Connections;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.CustomCostTypeItemReceived;

public class CustomCostTypeItemReceivedDataReader : TypedAsyncDataReaderBase<CustomCostTypeItemReceivedDataObject>
{
    private readonly ILogger<CustomCostTypeItemReceivedDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public CustomCostTypeItemReceivedDataReader(
        ILogger<CustomCostTypeItemReceivedDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<CustomCostTypeItemReceivedDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        string? cursor = null;

        while (true)
        {
            var response = await _apiClient.GetCustomCostTypeItemReceived(
                _connectionConfig.BusinessUnitId,
                null, // jobIds
                null, // jobTagIds
                null, // foremanIds
                null, // startDate
                null, // endDate
                cursor,
                1000, // limit
                null, // modifiedSince
                cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve custom cost type received items. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve custom cost type received items. API StatusCode: {response.StatusCode}");
            }

            if (response.Data?.Results == null)
            {
                _logger.LogWarning("No custom cost type received items found");
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