using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Equipment360.v1.PurchaseOrder;

public class PurchaseOrderDataReader : TypedAsyncDataReaderBase<PurchaseOrderDataObject>
{
    private readonly ILogger<PurchaseOrderDataReader> _logger;
    private readonly ApiClient _apiClient;

    public PurchaseOrderDataReader(
        ILogger<PurchaseOrderDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<PurchaseOrderDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        // Get purchase order ID from arguments
        Guid? purchaseOrderId = null;
        if (dataObjectRunArguments != null && Guid.TryParse(dataObjectRunArguments.ToString(), out var id))
        {
            purchaseOrderId = id;
        }

        if (!purchaseOrderId.HasValue)
        {
            _logger.LogError("Purchase order ID is required but was not provided in arguments");
            yield break;
        }

        ApiResponse<IEnumerable<PurchaseOrderDataObject>> response;
        try
        {
            response = await _apiClient.GetPurchaseOrderDetails(purchaseOrderId.Value, cancellationToken);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving purchase order details for order {PurchaseOrderId}", purchaseOrderId);
            throw;
        }

        if (!response.IsSuccessful || response.Data == null)
        {
            _logger.LogError("Failed to retrieve purchase order details. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve purchase order details. API StatusCode: {response.StatusCode}");
        }

        foreach (var detail in response.Data)
        {
            yield return detail;
        }
    }
}