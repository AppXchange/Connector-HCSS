using Connector.Client;
using Connector.Connections;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.EquipmentHours;

public class EquipmentHoursDataReader : TypedAsyncDataReaderBase<EquipmentHoursDataObject>
{
    private readonly ILogger<EquipmentHoursDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public EquipmentHoursDataReader(
        ILogger<EquipmentHoursDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<EquipmentHoursDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        string? cursor = null;

        while (true)
        {
            var response = await _apiClient.GetEquipmentHours(
                _connectionConfig.BusinessUnitId,
                null, // jobIds
                null, // jobTagIds
                null, // foremanIds
                null, // startDate
                null, // endDate
                cursor,
                1000, // limit
                false, // includeAllJobs
                false, // includeInactiveEquipment
                null, // modifiedSince
                null, // equipmentIds
                null, // linkedEmployeeIds
                cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve equipment hours. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve equipment hours. API StatusCode: {response.StatusCode}");
            }

            if (response.Data?.Results == null)
            {
                _logger.LogWarning("No equipment hours found");
                yield break;
            }

            foreach (var hours in response.Data.Results)
            {
                yield return hours;
            }

            if (string.IsNullOrEmpty(response.Data.Metadata.NextCursor))
            {
                break;
            }

            cursor = response.Data.Metadata.NextCursor;
        }
    }
}