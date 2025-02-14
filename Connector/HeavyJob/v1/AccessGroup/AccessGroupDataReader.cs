using Connector.Client;
using Connector.Connections;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.AccessGroup;

public class AccessGroupDataReader : TypedAsyncDataReaderBase<AccessGroupDataObject>
{
    private readonly ILogger<AccessGroupDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public AccessGroupDataReader(
        ILogger<AccessGroupDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<AccessGroupDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = await _apiClient.GetAccessGroups(
            includeDeleted: true,
            cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve access groups. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve access groups. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No access groups found");
            yield break;
        }

        foreach (var accessGroup in response.Data)
        {
            yield return accessGroup;
        }
    }
}