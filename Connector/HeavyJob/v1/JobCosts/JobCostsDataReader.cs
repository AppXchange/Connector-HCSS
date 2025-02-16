using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.JobCosts;

public class JobCostsDataReader : TypedAsyncDataReaderBase<JobCostsDataObject>
{
    private readonly ILogger<JobCostsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public JobCostsDataReader(
        ILogger<JobCostsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<JobCostsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        // Get jobId from arguments
        var jobIdElement = dataObjectRunArguments?.RequestParameterOverrides?.RootElement.GetProperty("jobId");
        if (jobIdElement == null || !Guid.TryParse(jobIdElement.Value.GetString(), out var jobId))
        {
            _logger.LogError("Required parameter 'jobId' is missing or invalid");
            throw new ArgumentException("Required parameter 'jobId' is missing or invalid");
        }

        var response = await _apiClient.GetJobCosts(
            jobId: jobId,
            cancellationToken: cancellationToken);

        if (!response.IsSuccessful || response.Data == null)
        {
            _logger.LogError("Failed to retrieve job costs. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve job costs. API StatusCode: {response.StatusCode}");
        }

        yield return response.Data;
    }
}