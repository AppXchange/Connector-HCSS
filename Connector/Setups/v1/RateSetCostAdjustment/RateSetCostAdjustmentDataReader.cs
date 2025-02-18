using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Text.Json;

namespace Connector.Setups.v1.RateSetCostAdjustment;

public class RateSetCostAdjustmentDataReader : TypedAsyncDataReaderBase<RateSetCostAdjustmentDataObject>
{
    private readonly ILogger<RateSetCostAdjustmentDataReader> _logger;
    private readonly ApiClient _apiClient;

    public RateSetCostAdjustmentDataReader(
        ILogger<RateSetCostAdjustmentDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<RateSetCostAdjustmentDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var businessUnitCode = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("businessUnitCode", out var businessUnitElement)
            ? businessUnitElement.GetString()
            : null;

        var costAdjustmentRateSetGroupCode = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("costAdjustmentRateSetGroupCode", out var groupCodeElement)
            ? groupCodeElement.GetString()
            : null;

        if (string.IsNullOrEmpty(businessUnitCode))
        {
            _logger.LogError("BusinessUnitCode is required but was not provided");
            throw new ArgumentException("BusinessUnitCode is required");
        }

        if (string.IsNullOrEmpty(costAdjustmentRateSetGroupCode))
        {
            _logger.LogError("CostAdjustmentRateSetGroupCode is required but was not provided");
            throw new ArgumentException("CostAdjustmentRateSetGroupCode is required");
        }

        var response = await _apiClient.GetCostAdjustmentRateSet(businessUnitCode, costAdjustmentRateSetGroupCode, cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve cost adjustment rate set. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve cost adjustment rate set. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No cost adjustment rate set found");
            yield break;
        }

        yield return response.Data;
    }
}