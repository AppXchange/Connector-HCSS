using Connector.Client;
using Connector.Connections;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.CostCodeProgress;

public class CostCodeProgressDataReader : TypedAsyncDataReaderBase<CostCodeProgressDataObject>
{
    private readonly ILogger<CostCodeProgressDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public CostCodeProgressDataReader(
        ILogger<CostCodeProgressDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<CostCodeProgressDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (dataObjectRunArguments?.RequestParameterOverrides == null || 
            !dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("jobId", out var jobIdElement))
        {
            throw new InvalidOperationException("Job ID must be provided in request parameters");
        }

        var jobId = Guid.Parse(jobIdElement.GetString()!);
        string? cursor = null;

        while (true)
        {
            var response = await _apiClient.GetCostCodeProgress(
                jobId,
                cursor,
                null, // limit
                null, // startDate
                null, // endDate
                null, // costCodeIds
                null, // costCodeTagIds
                null, // costCodeTransactionTagIds
                cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve cost code progress. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve cost code progress. API StatusCode: {response.StatusCode}");
            }

            if (response.Data?.Results == null)
            {
                _logger.LogWarning("No cost code progress found");
                yield break;
            }

            foreach (var progress in response.Data.Results)
            {
                yield return progress;
            }

            if (string.IsNullOrEmpty(response.Data.Metadata.NextCursor))
            {
                break;
            }

            cursor = response.Data.Metadata.NextCursor;
        }
    }
}