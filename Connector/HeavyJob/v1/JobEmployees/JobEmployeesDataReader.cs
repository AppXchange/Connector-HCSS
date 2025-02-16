using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.JobEmployees;

public class JobEmployeesDataReader : TypedAsyncDataReaderBase<JobEmployeesDataObject>
{
    private readonly ILogger<JobEmployeesDataReader> _logger;
    private readonly ApiClient _apiClient;
    private string? _cursor;

    public JobEmployeesDataReader(
        ILogger<JobEmployeesDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<JobEmployeesDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = await _apiClient.GetJobEmployees(
                cursor: _cursor,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve job employees. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve job employees. API StatusCode: {response.StatusCode}");
            }

            if (response.Data?.Results == null || response.Data.Results.Length == 0)
            {
                break;
            }

            foreach (var jobEmployee in response.Data.Results)
            {
                yield return jobEmployee;
            }

            if (string.IsNullOrEmpty(response.Data.Metadata?.NextCursor))
            {
                break;
            }

            _cursor = response.Data.Metadata.NextCursor;
        }
    }
}