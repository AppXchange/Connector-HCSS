using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.TimeCardsForEquipment;

public class TimeCardsForEquipmentDataReader : TypedAsyncDataReaderBase<TimeCardsForEquipmentDataObject>
{
    private readonly ILogger<TimeCardsForEquipmentDataReader> _logger;
    private readonly ApiClient _apiClient;

    public TimeCardsForEquipmentDataReader(
        ILogger<TimeCardsForEquipmentDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<TimeCardsForEquipmentDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var equipmentId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("equipmentId", out var equipmentIdElement) 
            && equipmentIdElement.TryGetGuid(out var eid)
            ? eid
            : (Guid?)null;

        var equipmentCode = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("equipmentCode", out var equipmentCodeElement) 
            ? equipmentCodeElement.GetString()
            : null;

        var date = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("date", out var dateElement) 
            && dateElement.TryGetDateTime(out var d)
            ? d
            : (DateTime?)null;

        if (!equipmentId.HasValue && string.IsNullOrEmpty(equipmentCode))
        {
            _logger.LogWarning("Either equipmentId or equipmentCode is required");
            yield break;
        }

        if (!date.HasValue)
        {
            _logger.LogWarning("Date is required");
            yield break;
        }

        var response = await _apiClient.GetTimeCardsForEquipment(
            equipmentId: equipmentId,
            equipmentCode: equipmentCode,
            date: date.Value,
            cancellationToken: cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve time cards for equipment. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve time cards for equipment. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No time cards found for equipment");
            yield break;
        }

        foreach (var timeCard in response.Data)
        {
            yield return timeCard;
        }
    }
}