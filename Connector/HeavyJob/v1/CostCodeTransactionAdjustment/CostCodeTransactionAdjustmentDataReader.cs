using Connector.Client;
using Connector.Connections;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.CostCodeTransactionAdjustment;

public class CostCodeTransactionAdjustmentDataReader : TypedAsyncDataReaderBase<CostCodeTransactionAdjustmentDataObject>
{
    private readonly ILogger<CostCodeTransactionAdjustmentDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public CostCodeTransactionAdjustmentDataReader(
        ILogger<CostCodeTransactionAdjustmentDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<CostCodeTransactionAdjustmentDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        string? cursor = null;

        while (true)
        {
            var response = await _apiClient.GetCostCodeTransactionAdjustments(
                _connectionConfig.BusinessUnitId,
                null, // jobIds
                null, // jobTagIds
                null, // foremanIds
                null, // startDate
                null, // endDate
                cursor,
                1000, // limit
                null, // costCodeIds
                false, // includeCostsAndHours
                cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve cost code transaction adjustments. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve cost code transaction adjustments. API StatusCode: {response.StatusCode}");
            }

            if (response.Data?.Results == null)
            {
                _logger.LogWarning("No cost code transaction adjustments found");
                yield break;
            }

            foreach (var adjustment in response.Data.Results)
            {
                yield return adjustment;
            }

            if (string.IsNullOrEmpty(response.Data.Metadata.NextCursor))
            {
                break;
            }

            cursor = response.Data.Metadata.NextCursor;
        }
    }
}