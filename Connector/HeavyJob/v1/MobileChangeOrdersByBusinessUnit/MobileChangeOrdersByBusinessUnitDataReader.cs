using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.MobileChangeOrdersByBusinessUnit;

public class MobileChangeOrdersByBusinessUnitDataReader : TypedAsyncDataReaderBase<MobileChangeOrdersByBusinessUnitDataObject>
{
    private readonly ILogger<MobileChangeOrdersByBusinessUnitDataReader> _logger;
    private readonly ApiClient _apiClient;

    public MobileChangeOrdersByBusinessUnitDataReader(
        ILogger<MobileChangeOrdersByBusinessUnitDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<MobileChangeOrdersByBusinessUnitDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (dataObjectRunArguments?.RequestParameterOverrides?.RootElement.TryGetProperty("businessUnitId", out var businessUnitIdElement) != true 
            || !businessUnitIdElement.TryGetGuid(out var businessUnitId))
        {
            throw new Exception("BusinessUnitId is required but was not provided in the arguments");
        }

        var response = await _apiClient.GetMobileChangeOrdersByBusinessUnit(
            businessUnitId,
            DateTime.UtcNow.AddDays(-30), // Example: Look back 30 days
            cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve mobile change orders. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve mobile change orders. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No mobile change orders found");
            yield break;
        }

        foreach (var order in response.Data)
        {
            yield return order;
        }
    }
}