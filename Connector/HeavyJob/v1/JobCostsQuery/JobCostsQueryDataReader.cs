using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.JobCostsQuery;

public class JobCostsQueryDataReader : TypedAsyncDataReaderBase<JobCostsQueryDataObject>
{
    private readonly ILogger<JobCostsQueryDataReader> _logger;
    private readonly ApiClient _apiClient;
    private string? _cursor;

    public JobCostsQueryDataReader(
        ILogger<JobCostsQueryDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<JobCostsQueryDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = await _apiClient.GetJobCostsQuery(
                cursor: _cursor,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful || response.Data == null)
            {
                _logger.LogError("Failed to retrieve job costs query. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve job costs query. API StatusCode: {response.StatusCode}");
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