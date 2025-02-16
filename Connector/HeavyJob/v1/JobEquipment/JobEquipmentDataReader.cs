using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.JobEquipment;

public class JobEquipmentDataReader : TypedAsyncDataReaderBase<JobEquipmentDataObject>
{
    private readonly ILogger<JobEquipmentDataReader> _logger;
    private readonly ApiClient _apiClient;
    private string? _cursor;

    public JobEquipmentDataReader(
        ILogger<JobEquipmentDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<JobEquipmentDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = await _apiClient.GetJobEquipment(
                cursor: _cursor,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve job equipment. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve job equipment. API StatusCode: {response.StatusCode}");
            }

            if (response.Data?.Results == null || response.Data.Results.Length == 0)
            {
                break;
            }

            foreach (var jobEquipment in response.Data.Results)
            {
                yield return jobEquipment;
            }

            if (string.IsNullOrEmpty(response.Data.Metadata?.NextCursor))
            {
                break;
            }

            _cursor = response.Data.Metadata.NextCursor;
        }
    }
}