using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.JobMaterial;

public class JobMaterialDataReader : TypedAsyncDataReaderBase<JobMaterialDataObject>
{
    private readonly ILogger<JobMaterialDataReader> _logger;
    private readonly ApiClient _apiClient;
    private string? _cursor;

    public JobMaterialDataReader(
        ILogger<JobMaterialDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<JobMaterialDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = await _apiClient.GetJobMaterial(
                cursor: _cursor,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve job material. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve job material. API StatusCode: {response.StatusCode}");
            }

            if (response.Data?.Results == null || response.Data.Results.Length == 0)
            {
                break;
            }

            foreach (var jobMaterial in response.Data.Results)
            {
                yield return jobMaterial;
            }

            if (string.IsNullOrEmpty(response.Data.Metadata?.NextCursor))
            {
                break;
            }

            _cursor = response.Data.Metadata.NextCursor;
        }
    }
}