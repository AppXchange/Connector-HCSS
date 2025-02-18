using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Text.Json;

namespace Connector.Telematics.v1.Equipment;

public class EquipmentDataReader : TypedAsyncDataReaderBase<EquipmentDataObject>
{
    private readonly ILogger<EquipmentDataReader> _logger;
    private readonly ApiClient _apiClient;

    public EquipmentDataReader(
        ILogger<EquipmentDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<EquipmentDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var limit = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("limit", out var limitElement)
            ? limitElement.GetInt32()
            : 1000;

        var isRegistered = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("isRegistered", out var registeredElement)
            ? registeredElement.GetBoolean()
            : (bool?)null;

        string? cursor = null;
        bool hasMorePages;

        do
        {
            var response = await _apiClient.GetEquipment(
                limit,
                cursor,
                isRegistered,
                cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve equipment. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve equipment. API StatusCode: {response.StatusCode}");
            }

            if (response.Data?.Results == null)
            {
                _logger.LogWarning("No equipment found");
                yield break;
            }

            foreach (var item in response.Data.Results)
            {
                yield return item;
            }

            cursor = response.Data.Metadata.NextCursor;
            hasMorePages = !string.IsNullOrEmpty(cursor);

        } while (hasMorePages);
    }
}