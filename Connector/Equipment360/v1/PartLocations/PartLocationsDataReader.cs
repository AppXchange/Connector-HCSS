using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Equipment360.v1.PartLocations;

public class PartLocationsDataReader : TypedAsyncDataReaderBase<PartLocationsDataObject>
{
    private readonly ILogger<PartLocationsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public PartLocationsDataReader(
        ILogger<PartLocationsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<PartLocationsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        ApiResponse<IEnumerable<PartLocationsDataObject>> response;
        try
        {
            response = await _apiClient.GetPartLocations(cancellationToken: cancellationToken);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving part locations");
            throw;
        }

        if (!response.IsSuccessful || response.Data == null)
        {
            _logger.LogError("Failed to retrieve part locations. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve part locations. API StatusCode: {response.StatusCode}");
        }

        foreach (var location in response.Data)
        {
            yield return location;
        }
    }
}