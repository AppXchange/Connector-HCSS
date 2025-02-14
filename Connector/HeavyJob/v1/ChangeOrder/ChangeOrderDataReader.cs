using Connector.Client;
using Connector.Connections;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.ChangeOrder;

public class ChangeOrderDataReader : TypedAsyncDataReaderBase<ChangeOrderDataObject>
{
    private readonly ILogger<ChangeOrderDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public ChangeOrderDataReader(
        ILogger<ChangeOrderDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<ChangeOrderDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = await _apiClient.GetChangeOrder(
            _connectionConfig.BusinessUnitId,
            cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve change orders. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve change orders. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No change orders found");
            yield break;
        }

        foreach (var item in response.Data)
        {
            yield return item;
        }
    }
}