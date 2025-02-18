using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.Safety.v1.Jobs;

public class JobsDataReader : TypedAsyncDataReaderBase<JobsDataObject>
{
    private readonly ILogger<JobsDataReader> _logger;
    private readonly ApiClient _apiClient;
    private string? _nextCursor;

    public JobsDataReader(
        ILogger<JobsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<JobsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        do
        {
            var response = await _apiClient.GetJobs(
                limit: 1000,
                cursor: _nextCursor,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful || response.Data == null)
            {
                _logger.LogError("Failed to retrieve jobs. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve jobs. API StatusCode: {response.StatusCode}");
            }

            foreach (var job in response.Data.Results)
            {
                yield return job;
            }

            _nextCursor = response.Data.Metadata?.NextCursor;

        } while (!string.IsNullOrEmpty(_nextCursor));
    }
}