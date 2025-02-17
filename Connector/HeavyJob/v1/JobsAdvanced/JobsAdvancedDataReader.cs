using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.JobsAdvanced;

public class JobsAdvancedDataReader : TypedAsyncDataReaderBase<JobsAdvancedDataObject>
{
    private readonly ILogger<JobsAdvancedDataReader> _logger;
    private readonly ApiClient _apiClient;

    public JobsAdvancedDataReader(
        ILogger<JobsAdvancedDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<JobsAdvancedDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = await _apiClient.GetJobsAdvanced(
            cancellationToken: cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve jobs. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve jobs. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No jobs found");
            yield break;
        }

        foreach (var job in response.Data)
        {
            yield return job;
        }
    }
}