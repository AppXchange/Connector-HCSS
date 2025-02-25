using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.ForecastInfo;

public class ForecastInfoDataReader : TypedAsyncDataReaderBase<ForecastInfoDataObject>
{
    private readonly ILogger<ForecastInfoDataReader> _logger;
    private readonly ApiClient _apiClient;
    private string? _cursor;

    public ForecastInfoDataReader(
        ILogger<ForecastInfoDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<ForecastInfoDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = await _apiClient.GetForecastInfo(
                cursor: _cursor,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful || response.Data == null)
            {
                _logger.LogError("Failed to retrieve forecast info. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve forecast info. API StatusCode: {response.StatusCode}");
            }

            foreach (var forecast in response.Data.Results)
            {
                yield return forecast;
            }

            // Check if we have more pages to fetch
            _cursor = response.Data.Metadata.NextCursor;
            if (string.IsNullOrEmpty(_cursor))
            {
                break;
            }
        }
    }
}