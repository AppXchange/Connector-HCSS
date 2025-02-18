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
using System.Text.Json;

namespace Connector.Setups.v1.CostCode;

public class CostCodeDataReader : TypedAsyncDataReaderBase<CostCodeDataObject>
{
    private readonly ILogger<CostCodeDataReader> _logger;
    private readonly ApiClient _apiClient;

    public CostCodeDataReader(
        ILogger<CostCodeDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<CostCodeDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var businessUnitCode = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("businessUnitCode", out var businessUnitElement)
            ? businessUnitElement.GetString()
            : null;

        var jobCode = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("jobCode", out var jobCodeElement)
            ? jobCodeElement.GetString()
            : null;

        var accountingTemplateName = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("accountingTemplateName", out var templateElement)
            ? templateElement.GetString()
            : null;

        if (string.IsNullOrEmpty(businessUnitCode))
        {
            _logger.LogError("BusinessUnitCode is required but was not provided");
            throw new ArgumentException("BusinessUnitCode is required");
        }

        if (string.IsNullOrEmpty(jobCode))
        {
            _logger.LogError("JobCode is required but was not provided");
            throw new ArgumentException("JobCode is required");
        }

        var response = await _apiClient.GetSetupsCostCodes(businessUnitCode, jobCode, accountingTemplateName, cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve cost codes. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve cost codes. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No cost codes found");
            yield break;
        }

        foreach (var costCode in response.Data)
        {
            yield return costCode;
        }
    }
}