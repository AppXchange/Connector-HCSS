using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.JobCostByCostCode;

public class JobCostByCostCodeDataReader : TypedAsyncDataReaderBase<JobCostByCostCodeDataObject>
{
    private readonly ILogger<JobCostByCostCodeDataReader> _logger;
    private readonly ApiClient _apiClient;
    private string? _cursor;

    public JobCostByCostCodeDataReader(
        ILogger<JobCostByCostCodeDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<JobCostByCostCodeDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        // Get costCodeId from arguments
        var costCodeIdElement = dataObjectRunArguments?.RequestParameterOverrides?.RootElement.GetProperty("costCodeId");
        if (costCodeIdElement == null || !Guid.TryParse(costCodeIdElement.Value.GetString(), out var costCodeId))
        {
            _logger.LogError("Required parameter 'costCodeId' is missing or invalid");
            throw new ArgumentException("Required parameter 'costCodeId' is missing or invalid");
        }

        while (true)
        {
            var response = await _apiClient.GetJobCostByCostCode(
                costCodeId: costCodeId,
                cursor: _cursor,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful || response.Data == null)
            {
                _logger.LogError("Failed to retrieve job costs. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve job costs. API StatusCode: {response.StatusCode}");
            }

            foreach (var cost in response.Data.Results)
            {
                yield return cost;
            }

            // Check if we have more pages to fetch
            _cursor = response.Data.Metadata.NextCursor;
            if (string.IsNullOrEmpty(_cursor))
            {
                break;
            }
        }
    }
}