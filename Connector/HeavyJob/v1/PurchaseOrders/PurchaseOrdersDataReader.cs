using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.PurchaseOrders;

public class PurchaseOrdersDataReader : TypedAsyncDataReaderBase<PurchaseOrdersDataObject>
{
    private readonly ILogger<PurchaseOrdersDataReader> _logger;
    private readonly ApiClient _apiClient;

    public PurchaseOrdersDataReader(
        ILogger<PurchaseOrdersDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<PurchaseOrdersDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var businessUnitId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("businessUnitId", out var businessUnitIdElement) 
            && businessUnitIdElement.TryGetGuid(out var buid)
            ? buid
            : (Guid?)null;

        var jobId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("jobId", out var jobIdElement)
            && jobIdElement.TryGetGuid(out var jid)
            ? jid
            : (Guid?)null;

        var response = await _apiClient.GetPurchaseOrders(
            businessUnitId: businessUnitId,
            jobId: jobId,
            limit: 1000,
            cancellationToken: cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve purchase orders. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve purchase orders. API StatusCode: {response.StatusCode}");
        }

        if (response.Data?.Results == null)
        {
            _logger.LogWarning("No purchase orders found");
            yield break;
        }

        foreach (var purchaseOrder in response.Data.Results)
        {
            yield return purchaseOrder;
        }

        while (!string.IsNullOrEmpty(response.Data.Metadata?.NextCursor))
        {
            response = await _apiClient.GetPurchaseOrders(
                businessUnitId: businessUnitId,
                jobId: jobId,
                limit: 1000,
                cursor: response.Data.Metadata.NextCursor,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful || response.Data?.Results == null)
                break;

            foreach (var purchaseOrder in response.Data.Results)
            {
                yield return purchaseOrder;
            }
        }
    }
}