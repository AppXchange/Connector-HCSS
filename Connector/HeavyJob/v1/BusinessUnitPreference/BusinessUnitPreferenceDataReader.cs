using Connector.Client;
using Connector.Connections;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.BusinessUnitPreference;

public class BusinessUnitPreferenceDataReader : TypedAsyncDataReaderBase<BusinessUnitPreferenceDataObject>
{
    private readonly ILogger<BusinessUnitPreferenceDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public BusinessUnitPreferenceDataReader(
        ILogger<BusinessUnitPreferenceDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<BusinessUnitPreferenceDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = await _apiClient.GetBusinessUnitPreferences(
            _connectionConfig.BusinessUnitId,
            cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve business unit preferences. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve business unit preferences. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No business unit preferences found");
            yield break;
        }

        yield return new BusinessUnitPreferenceDataObject
        {
            BusinessUnitId = _connectionConfig.BusinessUnitId,
            DefaultLaborRateSetId = response.Data.DefaultLaborRateSetId,
            DefaultPayClassId = response.Data.DefaultPayClassId,
            DefaultEquipmentRateSetId = response.Data.DefaultEquipmentRateSetId,
            StartOfPayWeek = response.Data.StartOfPayWeek,
            TruckingCostTypeId = response.Data.TruckingCostTypeId
        };
    }
}