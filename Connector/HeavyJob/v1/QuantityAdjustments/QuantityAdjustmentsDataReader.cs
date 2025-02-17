using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.QuantityAdjustments;

public class QuantityAdjustmentsDataReader : TypedAsyncDataReaderBase<QuantityAdjustmentsDataObject>
{
    private readonly ILogger<QuantityAdjustmentsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public QuantityAdjustmentsDataReader(
        ILogger<QuantityAdjustmentsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<QuantityAdjustmentsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var jobId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("jobId", out var jobIdElement) 
            && jobIdElement.TryGetGuid(out var jid)
            ? jid
            : (Guid?)null;

        var foremanId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("foremanId", out var foremanIdElement)
            && foremanIdElement.TryGetGuid(out var fid)
            ? fid
            : (Guid?)null;

        var response = await _apiClient.GetQuantityAdjustments(
            jobId: jobId,
            foremanId: foremanId,
            limit: 1000,
            cancellationToken: cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve quantity adjustments. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve quantity adjustments. API StatusCode: {response.StatusCode}");
        }

        if (response.Data?.Results == null)
        {
            _logger.LogWarning("No quantity adjustments found");
            yield break;
        }

        foreach (var adjustment in response.Data.Results)
        {
            yield return adjustment;
        }

        while (!string.IsNullOrEmpty(response.Data.Metadata?.NextCursor))
        {
            response = await _apiClient.GetQuantityAdjustments(
                jobId: jobId,
                foremanId: foremanId,
                limit: 1000,
                cursor: response.Data.Metadata.NextCursor,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful || response.Data?.Results == null)
                break;

            foreach (var adjustment in response.Data.Results)
            {
                yield return adjustment;
            }
        }
    }
}