using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Text.Json;

namespace Connector.Setups.v1.RateSet;

public class RateSetDataReader : TypedAsyncDataReaderBase<RateSetDataObject>
{
    private readonly ILogger<RateSetDataReader> _logger;
    private readonly ApiClient _apiClient;

    public RateSetDataReader(
        ILogger<RateSetDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<RateSetDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var businessUnitCode = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("businessUnitCode", out var businessUnitElement)
            ? businessUnitElement.GetString()
            : null;

        var employeeRateSetGroupCode = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("employeeRateSetGroupCode", out var groupCodeElement)
            ? groupCodeElement.GetString()
            : null;

        if (string.IsNullOrEmpty(businessUnitCode))
        {
            _logger.LogError("BusinessUnitCode is required but was not provided");
            throw new ArgumentException("BusinessUnitCode is required");
        }

        if (string.IsNullOrEmpty(employeeRateSetGroupCode))
        {
            _logger.LogError("EmployeeRateSetGroupCode is required but was not provided");
            throw new ArgumentException("EmployeeRateSetGroupCode is required");
        }

        var response = await _apiClient.GetEmployeeRateSet(businessUnitCode, employeeRateSetGroupCode, cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve rate set. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve rate set. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No rate set found");
            yield break;
        }

        yield return response.Data;
    }
}