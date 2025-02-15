using Connector.Client;
using Connector.Connections;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.Diary;

public class DiaryDataReader : TypedAsyncDataReaderBase<DiaryDataObject>
{
    private readonly ILogger<DiaryDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public DiaryDataReader(
        ILogger<DiaryDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<DiaryDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = await _apiClient.UpsertDiary(new DiaryDataObject
        {
            // Example values for testing
            JobId = Guid.NewGuid(),
            ForemanId = Guid.NewGuid(),
            Date = DateTime.UtcNow,
            Revision = 1
        }, cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to create/update diary. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to create/update diary. API StatusCode: {response.StatusCode}");
        }

        if (response.Data != null)
        {
            yield return response.Data;
        }
    }
}