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

namespace Connector.Setups.v1.PayClass;

public class PayClassDataReader : TypedAsyncDataReaderBase<PayClassDataObject>
{
    private readonly ILogger<PayClassDataReader> _logger;
    private readonly ApiClient _apiClient;

    public PayClassDataReader(
        ILogger<PayClassDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<PayClassDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var businessUnitCode = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("businessUnitCode", out var businessUnitElement)
            ? businessUnitElement.GetString()
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

        var response = await _apiClient.GetSetupsPayClasses(businessUnitCode, accountingTemplateName, cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve pay classes. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve pay classes. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No pay classes found");
            yield break;
        }

        foreach (var payClass in response.Data)
        {
            yield return payClass;
        }
    }
}