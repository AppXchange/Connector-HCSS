using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Text.Json;

namespace Connector.Setups.v1.RateSetEquipment;

public class RateSetEquipmentDataReader : TypedAsyncDataReaderBase<RateSetEquipmentDataObject>
{
    private readonly ILogger<RateSetEquipmentDataReader> _logger;
    private readonly ApiClient _apiClient;

    public RateSetEquipmentDataReader(
        ILogger<RateSetEquipmentDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<RateSetEquipmentDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var businessUnitCode = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("businessUnitCode", out var businessUnitElement)
            ? businessUnitElement.GetString()
            : null;

        var equipmentRateSetGroupCode = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("equipmentRateSetGroupCode", out var groupCodeElement)
            ? groupCodeElement.GetString()
            : null;

        if (string.IsNullOrEmpty(businessUnitCode))
        {
            _logger.LogError("BusinessUnitCode is required but was not provided");
            throw new ArgumentException("BusinessUnitCode is required");
        }

        if (string.IsNullOrEmpty(equipmentRateSetGroupCode))
        {
            _logger.LogError("EquipmentRateSetGroupCode is required but was not provided");
            throw new ArgumentException("EquipmentRateSetGroupCode is required");
        }

        var response = await _apiClient.GetEquipmentRateSet(businessUnitCode, equipmentRateSetGroupCode, cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve equipment rate set. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve equipment rate set. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No equipment rate set found");
            yield break;
        }

        yield return response.Data;
    }
}