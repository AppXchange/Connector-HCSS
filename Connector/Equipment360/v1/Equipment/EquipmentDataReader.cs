using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;
using System.Threading.Tasks;
using Connector.Client.Equipment360;
using Connector.Equipment360.v1.AllEquipment;

namespace Connector.Equipment360.v1.Equipment;

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
        ApiResponse<Equipment360PaginatedResponse<AllEquipmentDataObject>> response;
        try
        {
            response = await _apiClient.GetEquipment(cancellationToken: cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve equipment. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve equipment. API StatusCode: {response.StatusCode}");
            }
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving equipment");
            throw;
        }

        if (response.Data?.Data == null)
            yield break;

        foreach (var equipment in response.Data.Data)
        {
            yield return new EquipmentDataObject { Id = equipment.Id };
        }
    }

    public async Task<EquipmentDataObject> GetEquipmentById(Guid id, CancellationToken cancellationToken)
    {
        ApiResponse<EquipmentDataObject> response;
        try
        {
            response = await _apiClient.GetEquipmentById(id, cancellationToken);

            if (!response.IsSuccessful || response.Data == null)
            {
                _logger.LogError("Failed to retrieve equipment. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve equipment. API StatusCode: {response.StatusCode}");
            }
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving equipment");
            throw;
        }

        return response.Data;
    }
}