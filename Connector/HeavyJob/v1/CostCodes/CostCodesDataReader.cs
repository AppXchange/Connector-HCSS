using Connector.Client;
using Connector.Connections;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.CostCodes;

public class CostCodesDataReader : TypedAsyncDataReaderBase<CostCodesDataObject>
{
    private readonly ILogger<CostCodesDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public CostCodesDataReader(
        ILogger<CostCodesDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<CostCodesDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        string? cursor = null;

        while (true)
        {
            var response = await _apiClient.GetCostCodes(
                null, // accountingTemplateName
                null, // jobId
                _connectionConfig.BusinessUnitId,
                null, // costCodeId
                null, // isDeleted
                1000, // limit
                cursor,
                null, // modifiedSince
                cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve cost codes. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve cost codes. API StatusCode: {response.StatusCode}");
            }

            if (response.Data?.Results == null)
            {
                _logger.LogWarning("No cost codes found");
                yield break;
            }

            foreach (var costCode in response.Data.Results)
            {
                yield return costCode;
            }

            if (string.IsNullOrEmpty(response.Data.Metadata.NextCursor))
            {
                break;
            }

            cursor = response.Data.Metadata.NextCursor;
        }
    }
}