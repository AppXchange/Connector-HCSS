using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.PayClass;

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
        if (dataObjectRunArguments?.RequestParameterOverrides?.RootElement.TryGetProperty("businessUnitId", out var businessUnitIdElement) != true 
            || !businessUnitIdElement.TryGetGuid(out var businessUnitId))
        {
            throw new Exception("BusinessUnitId is required but was not provided in the arguments");
        }

        var response = await _apiClient.GetPayClasses(
            businessUnitId,
            isActive: true, // Default to only active pay classes
            cancellationToken);

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