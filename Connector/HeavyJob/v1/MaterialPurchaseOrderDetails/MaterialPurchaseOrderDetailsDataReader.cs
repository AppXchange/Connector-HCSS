using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.MaterialPurchaseOrderDetails;

public class MaterialPurchaseOrderDetailsDataReader : TypedAsyncDataReaderBase<MaterialPurchaseOrderDetailsDataObject>
{
    private readonly ILogger<MaterialPurchaseOrderDetailsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public MaterialPurchaseOrderDetailsDataReader(
        ILogger<MaterialPurchaseOrderDetailsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<MaterialPurchaseOrderDetailsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (dataObjectRunArguments?.RequestParameterOverrides?.RootElement.TryGetProperty("purchaseOrderId", out var element) != true 
            || !element.TryGetGuid(out var guid))
        {
            throw new Exception("PurchaseOrderId is required but was not provided in the arguments");
        }

        var response = await _apiClient.GetMaterialPurchaseOrderDetails(
            purchaseOrderId: guid,
            cancellationToken: cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve material purchase order details. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve material purchase order details. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No material purchase order details found");
            yield break;
        }

        foreach (var detail in response.Data)
        {
            yield return detail;
        }
    }
}