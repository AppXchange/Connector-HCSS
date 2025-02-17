using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.PurchaseOrderItems;

public class PurchaseOrderItemsDataReader : TypedAsyncDataReaderBase<PurchaseOrderItemsDataObject>
{
    private readonly ILogger<PurchaseOrderItemsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public PurchaseOrderItemsDataReader(
        ILogger<PurchaseOrderItemsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<PurchaseOrderItemsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var businessUnitId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement
            .TryGetProperty("businessUnitId", out var businessUnitIdElement) == true && businessUnitIdElement.TryGetGuid(out var id)
            ? id
            : (Guid?)null;

        var response = await _apiClient.GetPurchaseOrderItems(
            businessUnitId,
            null,
            null,
            null,
            null,
            1000,
            null,
            cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve purchase order items. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve purchase order items. API StatusCode: {response.StatusCode}");
        }

        if (response.Data?.Results == null)
        {
            _logger.LogWarning("No purchase order items found");
            yield break;
        }

        foreach (var item in response.Data.Results)
        {
            yield return item;
        }

        while (!string.IsNullOrEmpty(response.Data.Metadata?.NextCursor))
        {
            response = await _apiClient.GetPurchaseOrderItems(
                businessUnitId,
                null,
                null,
                null,
                null,
                1000,
                response.Data.Metadata.NextCursor,
                cancellationToken);

            if (!response.IsSuccessful || response.Data?.Results == null)
                break;

            foreach (var item in response.Data.Results)
            {
                yield return item;
            }
        }
    }
}