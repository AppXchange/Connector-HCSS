using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.Forecast;

public class ForecastDataReader : TypedAsyncDataReaderBase<ForecastDataObject>
{
    private readonly ILogger<ForecastDataReader> _logger;
    private readonly ApiClient _apiClient;

    public ForecastDataReader(
        ILogger<ForecastDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<ForecastDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        // First get the forecast summary info
        var summaryResponse = await _apiClient.GetForecastSummary(cancellationToken: cancellationToken);

        if (!summaryResponse.IsSuccessful || summaryResponse.Data == null)
        {
            _logger.LogError("Failed to retrieve forecast summary. Status code: {StatusCode}", summaryResponse.StatusCode);
            throw new Exception($"Failed to retrieve forecast summary. API StatusCode: {summaryResponse.StatusCode}");
        }

        foreach (var summary in summaryResponse.Data)
        {
            // Get details for each forecast
            var detailsResponse = await _apiClient.GetForecastDetails(summary.Id, cancellationToken);

            if (!detailsResponse.IsSuccessful || detailsResponse.Data == null)
            {
                _logger.LogError("Failed to retrieve forecast details for ID {Id}. Status code: {StatusCode}", 
                    summary.Id, detailsResponse.StatusCode);
                continue;
            }

            yield return detailsResponse.Data;
        }
    }
}