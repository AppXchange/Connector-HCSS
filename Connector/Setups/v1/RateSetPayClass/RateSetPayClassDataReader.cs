using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Text.Json;

namespace Connector.Setups.v1.RateSetPayClass;

public class RateSetPayClassDataReader : TypedAsyncDataReaderBase<RateSetPayClassDataObject>
{
    private readonly ILogger<RateSetPayClassDataReader> _logger;
    private readonly ApiClient _apiClient;

    public RateSetPayClassDataReader(
        ILogger<RateSetPayClassDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<RateSetPayClassDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var businessUnitCode = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("businessUnitCode", out var businessUnitElement)
            ? businessUnitElement.GetString()
            : null;

        var payClassRateSetGroupCode = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("payClassRateSetGroupCode", out var groupCodeElement)
            ? groupCodeElement.GetString()
            : null;

        if (string.IsNullOrEmpty(businessUnitCode))
        {
            _logger.LogError("BusinessUnitCode is required but was not provided");
            throw new ArgumentException("BusinessUnitCode is required");
        }

        if (string.IsNullOrEmpty(payClassRateSetGroupCode))
        {
            _logger.LogError("PayClassRateSetGroupCode is required but was not provided");
            throw new ArgumentException("PayClassRateSetGroupCode is required");
        }

        var response = await _apiClient.GetPayClassRateSet(businessUnitCode, payClassRateSetGroupCode, cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve pay class rate set. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve pay class rate set. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No pay class rate set found");
            yield break;
        }

        yield return response.Data;
    }
}