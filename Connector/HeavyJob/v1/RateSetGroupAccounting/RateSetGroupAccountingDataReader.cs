using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.RateSetGroupAccounting;

public class RateSetGroupAccountingDataReader : TypedAsyncDataReaderBase<RateSetGroupAccountingDataObject>
{
    private readonly ILogger<RateSetGroupAccountingDataReader> _logger;
    private readonly ApiClient _apiClient;

    public RateSetGroupAccountingDataReader(
        ILogger<RateSetGroupAccountingDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<RateSetGroupAccountingDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var businessUnitId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("businessUnitId", out var businessUnitIdElement) 
            && businessUnitIdElement.TryGetGuid(out var buid)
            ? buid
            : (Guid?)null;

        var rateSetGroupId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("rateSetGroupId", out var rateSetGroupIdElement)
            && rateSetGroupIdElement.TryGetGuid(out var rsid)
            ? rsid
            : (Guid?)null;

        if (!businessUnitId.HasValue || !rateSetGroupId.HasValue)
        {
            _logger.LogWarning("BusinessUnitId and RateSetGroupId are required parameters");
            yield break;
        }

        var response = await _apiClient.GetRateSetGroupAccountingValues(
            businessUnitId: businessUnitId.Value,
            rateSetGroupId: rateSetGroupId.Value,
            limit: 1000,
            cancellationToken: cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve rate set group accounting values. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve rate set group accounting values. API StatusCode: {response.StatusCode}");
        }

        if (response.Data?.Results == null)
        {
            _logger.LogWarning("No rate set group accounting values found");
            yield break;
        }

        foreach (var value in response.Data.Results)
        {
            yield return value;
        }

        while (!string.IsNullOrEmpty(response.Data.Metadata?.NextCursor))
        {
            response = await _apiClient.GetRateSetGroupAccountingValues(
                businessUnitId: businessUnitId.Value,
                rateSetGroupId: rateSetGroupId.Value,
                limit: 1000,
                cursor: response.Data.Metadata.NextCursor,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful || response.Data?.Results == null)
                break;

            foreach (var value in response.Data.Results)
            {
                yield return value;
            }
        }
    }
}