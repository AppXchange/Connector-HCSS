using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Text.Json;

namespace Connector.Setups.v1.RateSetGroup;

public class RateSetGroupDataReader : TypedAsyncDataReaderBase<RateSetGroupDataObject>
{
    private readonly ILogger<RateSetGroupDataReader> _logger;
    private readonly ApiClient _apiClient;

    public RateSetGroupDataReader(
        ILogger<RateSetGroupDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<RateSetGroupDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var businessUnitCode = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("businessUnitCode", out var businessUnitElement)
            ? businessUnitElement.GetString()
            : null;

        var type = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("type", out var typeElement)
            ? typeElement.GetString()
            : null;

        if (string.IsNullOrEmpty(businessUnitCode))
        {
            _logger.LogError("BusinessUnitCode is required but was not provided");
            throw new ArgumentException("BusinessUnitCode is required");
        }

        var response = await _apiClient.GetRateSetGroups(businessUnitCode, type, cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve rate set groups. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve rate set groups. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No rate set groups found");
            yield break;
        }

        foreach (var item in response.Data)
        {
            yield return item;
        }
    }
}