using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Equipment360.v1.Locations;

public class LocationsDataReader : TypedAsyncDataReaderBase<LocationsDataObject>
{
    private readonly ILogger<LocationsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public LocationsDataReader(
        ILogger<LocationsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<LocationsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        ApiResponse<IEnumerable<LocationsDataObject>> response;
        try
        {
            response = await _apiClient.GetLocations(cancellationToken: cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve locations. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve locations. API StatusCode: {response.StatusCode}");
            }
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving locations");
            throw;
        }

        if (response.Data == null)
            yield break;

        foreach (var location in response.Data)
        {
            yield return location;
        }
    }
}