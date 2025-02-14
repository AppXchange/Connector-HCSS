using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Equipment360.v1.Jobs;

public class JobsDataReader : TypedAsyncDataReaderBase<JobsDataObject>
{
    private readonly ILogger<JobsDataReader> _logger;
    private readonly ApiClient _apiClient;

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
        ApiResponse<IEnumerable<JobsDataObject>> response;
        try
        {
            response = await _apiClient.GetJobs(cancellationToken: cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve jobs. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve jobs. API StatusCode: {response.StatusCode}");
            }
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving jobs");
            throw;
        }

        if (response.Data == null)
            yield break;

        foreach (var job in response.Data)
        {
            yield return job;
        }
    }
}