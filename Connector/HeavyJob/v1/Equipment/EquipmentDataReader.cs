using Connector.Client;
using Connector.Connections;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.Equipment;

public class EquipmentDataReader : TypedAsyncDataReaderBase<EquipmentDataObject>
{
    private readonly ILogger<EquipmentDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public EquipmentDataReader(
        ILogger<EquipmentDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<EquipmentDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = await _apiClient.GetEquipment(
            _connectionConfig.BusinessUnitId,
            null, // accountingTemplateName
            null, // isActive
            null, // isDeleted
            cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve equipment. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve equipment. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No equipment found");
            yield break;
        }

        foreach (var equipment in response.Data)
        {
            yield return equipment;
        }
    }
}