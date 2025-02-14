using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;
using Connector.Client.Equipment360;
using System.Linq;
using System.Threading.Tasks;
using Connector.Equipment360.v1.BusinessUnit;
using Connector.Equipment360.v1.Parts;

namespace Connector.Equipment360.v1.PartInventory;

public class PartInventoryDataReader : TypedAsyncDataReaderBase<PartInventoryDataObject>
{
    private readonly ILogger<PartInventoryDataReader> _logger;
    private readonly ApiClient _apiClient;

    public PartInventoryDataReader(
        ILogger<PartInventoryDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<PartInventoryDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var businessUnits = await GetBusinessUnits(cancellationToken);
        foreach (var businessUnit in businessUnits)
        {
            // Get all parts using the Parts endpoint
            var parts = await GetParts(cancellationToken);
            
            foreach (var part in parts)
            {
                ApiResponse<Equipment360PaginatedResponse<PartInventoryDataObject>> response;
                try
                {
                    response = await _apiClient.GetPartInventory(
                        businessUnitId: businessUnit.Id,
                        partNum: part.PartNumber,
                        cancellationToken: cancellationToken);
                }
                catch (HttpRequestException exception)
                {
                    _logger.LogError(exception, "Exception while retrieving part inventory for business unit {BusinessUnitId} and part {PartNum}", 
                        businessUnit.Id, part.PartNumber);
                    continue;
                }

                if (!response.IsSuccessful || response.Data?.Data == null)
                {
                    _logger.LogError("Failed to retrieve part inventory for business unit {BusinessUnitId} and part {PartNum}. Status code: {StatusCode}", 
                        businessUnit.Id, part.PartNumber, response.StatusCode);
                    continue;
                }

                foreach (var inventory in response.Data.Data)
                {
                    yield return inventory;
                }
            }
        }
    }

    private async Task<IEnumerable<BusinessUnitDataObject>> GetBusinessUnits(CancellationToken cancellationToken)
    {
        var response = await _apiClient.GetBusinessUnits(cancellationToken);
        if (!response.IsSuccessful || response.Data == null)
        {
            _logger.LogError("Failed to retrieve business units. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve business units. API StatusCode: {response.StatusCode}");
        }
        return response.Data;
    }

    private async Task<IEnumerable<PartsDataObject>> GetParts(CancellationToken cancellationToken)
    {
        var response = await _apiClient.GetParts(
            partNumber: null, 
            cancellationToken: cancellationToken);
        if (!response.IsSuccessful || response.Data == null)
        {
            _logger.LogError("Failed to retrieve parts. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve parts. API StatusCode: {response.StatusCode}");
        }
        return response.Data;
    }
}