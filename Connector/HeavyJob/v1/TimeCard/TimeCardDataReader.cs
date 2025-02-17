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

namespace Connector.HeavyJob.v1.TimeCard;

public class TimeCardDataReader : TypedAsyncDataReaderBase<TimeCardDataObject>
{
    private readonly ILogger<TimeCardDataReader> _logger;
    private readonly ApiClient _apiClient;

    public TimeCardDataReader(
        ILogger<TimeCardDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<TimeCardDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var timeCardId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("timeCardId", out var timeCardIdElement) 
            && timeCardIdElement.TryGetGuid(out var tcid)
            ? tcid
            : (Guid?)null;

        if (!timeCardId.HasValue)
        {
            _logger.LogWarning("TimeCardId is a required parameter");
            yield break;
        }

        var response = await _apiClient.GetTimeCard(
            timeCardId: timeCardId.Value,
            cancellationToken: cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve time card. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve time card. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No time card found");
            yield break;
        }

        yield return response.Data;
    }
}