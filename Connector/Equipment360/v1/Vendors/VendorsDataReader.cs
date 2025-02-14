using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Equipment360.v1.Vendors;

public class VendorsDataReader : TypedAsyncDataReaderBase<VendorsDataObject>
{
    private readonly ILogger<VendorsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public VendorsDataReader(
        ILogger<VendorsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<VendorsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        ApiResponse<IEnumerable<VendorsDataObject>> response;
        try
        {
            response = await _apiClient.GetEquipment360Vendors(cancellationToken);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving vendors");
            throw;
        }

        if (!response.IsSuccessful || response.Data == null)
        {
            _logger.LogError("Failed to retrieve vendors. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve vendors. API StatusCode: {response.StatusCode}");
        }

        foreach (var vendor in response.Data)
        {
            yield return vendor;
        }
    }
}