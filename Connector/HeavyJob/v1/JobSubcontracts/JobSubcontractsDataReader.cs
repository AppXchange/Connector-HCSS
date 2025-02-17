using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.JobSubcontracts;

public class JobSubcontractsDataReader : TypedAsyncDataReaderBase<JobSubcontractsDataObject>
{
    private readonly ILogger<JobSubcontractsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public JobSubcontractsDataReader(
        ILogger<JobSubcontractsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<JobSubcontractsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (dataObjectRunArguments?.RequestParameterOverrides?.RootElement.TryGetProperty("jobId", out var element) != true 
            || !element.TryGetGuid(out var guid))
        {
            throw new Exception("JobId is required but was not provided in the arguments");
        }

        var response = await _apiClient.GetJobSubcontracts(
            jobId: guid,
            cancellationToken: cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve job subcontracts. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve job subcontracts. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No job subcontracts found");
            yield break;
        }

        foreach (var jobSubcontract in response.Data)
        {
            yield return jobSubcontract;
        }
    }
}