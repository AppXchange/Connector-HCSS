using Connector.Client;
using Connector.Connections;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.AttendanceHourTags;

public class AttendanceHourTagsDataReader : TypedAsyncDataReaderBase<AttendanceHourTagsDataObject>
{
    private readonly ILogger<AttendanceHourTagsDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public AttendanceHourTagsDataReader(
        ILogger<AttendanceHourTagsDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<AttendanceHourTagsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = await _apiClient.GetAttendanceHourTags(
            _connectionConfig.BusinessUnitId,
            cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve attendance hour tags. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve attendance hour tags. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No attendance hour tags found");
            yield break;
        }

        foreach (var item in response.Data)
        {
            yield return item;
        }
    }
}