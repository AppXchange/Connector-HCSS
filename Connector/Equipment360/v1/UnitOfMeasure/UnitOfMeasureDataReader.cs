using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Equipment360.v1.UnitOfMeasure;

public class UnitOfMeasureDataReader : TypedAsyncDataReaderBase<UnitOfMeasureDataObject>
{
    private readonly ILogger<UnitOfMeasureDataReader> _logger;
    private readonly ApiClient _apiClient;

    public UnitOfMeasureDataReader(
        ILogger<UnitOfMeasureDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<UnitOfMeasureDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        ApiResponse<IEnumerable<UnitOfMeasureDataObject>> response;
        try
        {
            response = await _apiClient.GetUnitOfMeasures(cancellationToken);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving units of measure");
            throw;
        }

        if (!response.IsSuccessful || response.Data == null)
        {
            _logger.LogError("Failed to retrieve units of measure. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve units of measure. API StatusCode: {response.StatusCode}");
        }

        foreach (var uom in response.Data)
        {
            yield return uom;
        }
    }
}