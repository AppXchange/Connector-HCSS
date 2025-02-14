using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.CostCodeCosts;

public class CostCodeCostsDataReader : TypedAsyncDataReaderBase<CostCodeCostsDataObject>
{
    private readonly ILogger<CostCodeCostsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public CostCodeCostsDataReader(
        ILogger<CostCodeCostsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<CostCodeCostsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (dataObjectRunArguments?.RequestParameterOverrides == null || 
            !dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("costCodeId", out var costCodeIdElement))
        {
            throw new InvalidOperationException("Cost Code ID must be provided in request parameters");
        }

        var response = await _apiClient.GetCostCodeCosts(
            Guid.Parse(costCodeIdElement.GetString()!),
            null,
            null,
            cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve cost code costs. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve cost code costs. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No cost code costs found");
            yield break;
        }

        yield return response.Data;
    }
}