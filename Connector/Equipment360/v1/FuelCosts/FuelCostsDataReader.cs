using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Equipment360.v1.FuelCosts;

public class FuelCostsDataReader : TypedAsyncDataReaderBase<FuelCostsDataObject>
{
    private readonly ILogger<FuelCostsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public FuelCostsDataReader(
        ILogger<FuelCostsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<FuelCostsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        ApiResponse<IEnumerable<FuelCostsDataObject>> response;
        try
        {
            response = await _apiClient.GetFuelCosts(cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve fuel costs. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve fuel costs. API StatusCode: {response.StatusCode}");
            }
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving fuel costs");
            throw;
        }

        if (response.Data == null)
            yield break;

        foreach (var fuelCost in response.Data)
        {
            yield return fuelCost;
        }
    }
}