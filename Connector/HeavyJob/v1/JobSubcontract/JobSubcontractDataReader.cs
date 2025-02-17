using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.JobSubcontract;

public class JobSubcontractDataReader : TypedAsyncDataReaderBase<JobSubcontractDataObject>
{
    private readonly ILogger<JobSubcontractDataReader> _logger;
    private readonly ApiClient _apiClient;

    public JobSubcontractDataReader(
        ILogger<JobSubcontractDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<JobSubcontractDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (dataObjectRunArguments?.RequestParameterOverrides?.RootElement.TryGetProperty("id", out var element) != true 
            || !element.TryGetGuid(out var guid))
        {
            throw new Exception("Id is required but was not provided in the arguments");
        }

        var response = await _apiClient.GetJobSubcontract(
            id: guid,
            cancellationToken: cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve job subcontract. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve job subcontract. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No job subcontract found");
            yield break;
        }

        yield return response.Data;
    }
}