using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.TimeCardInfo;

public class TimeCardInfoDataReader : TypedAsyncDataReaderBase<TimeCardInfoDataObject>
{
    private readonly ILogger<TimeCardInfoDataReader> _logger;
    private readonly ApiClient _apiClient;

    public TimeCardInfoDataReader(
        ILogger<TimeCardInfoDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<TimeCardInfoDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = await _apiClient.GetTimeCardInfo(
            limit: 1000,
            cancellationToken: cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve time card info. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve time card info. API StatusCode: {response.StatusCode}");
        }

        if (response.Data?.Results == null)
        {
            _logger.LogWarning("No time card info found");
            yield break;
        }

        foreach (var info in response.Data.Results)
        {
            yield return info;
        }

        while (!string.IsNullOrEmpty(response.Data.Metadata?.NextCursor))
        {
            response = await _apiClient.GetTimeCardInfo(
                limit: 1000,
                cursor: response.Data.Metadata.NextCursor,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful || response.Data?.Results == null)
                break;

            foreach (var info in response.Data.Results)
            {
                yield return info;
            }
        }
    }
}