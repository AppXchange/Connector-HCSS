using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Equipment360.v1.MeterReading;

public class MeterReadingDataReader : TypedAsyncDataReaderBase<MeterReadingDataObject>
{
    private readonly ILogger<MeterReadingDataReader> _logger;
    private readonly ApiClient _apiClient;

    public MeterReadingDataReader(
        ILogger<MeterReadingDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<MeterReadingDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        ApiResponse<IEnumerable<MeterReadingDataObject>> response;
        try
        {
            response = await _apiClient.GetMeterReadings(cancellationToken: cancellationToken);

            if (!response.IsSuccessful || response.Data == null)
            {
                _logger.LogError("Failed to retrieve meter readings. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve meter readings. API StatusCode: {response.StatusCode}");
            }
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving meter readings");
            throw;
        }

        foreach (var reading in response.Data)
        {
            yield return reading;
        }
    }
}