using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Equipment360.v1.EquipmentType;

public class EquipmentTypeDataReader : TypedAsyncDataReaderBase<EquipmentTypeDataObject>
{
    private readonly ILogger<EquipmentTypeDataReader> _logger;
    private readonly ApiClient _apiClient;

    public EquipmentTypeDataReader(
        ILogger<EquipmentTypeDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<EquipmentTypeDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = await _apiClient.GetEquipment360Types(cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve equipment types. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve equipment types. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
            yield break;

        foreach (var equipmentType in response.Data)
        {
            yield return equipmentType;
        }
    }
}