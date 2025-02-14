using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Equipment360.v1.PurchaseOrders;

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
        // Get approval status from arguments if provided
        string? approvalStatus = null;
        if (dataObjectRunArguments != null)
        {
            approvalStatus = dataObjectRunArguments.ToString();
        }

        ApiResponse<IEnumerable<PurchaseOrdersDataObject>> response;
        try
        {
            response = await _apiClient.GetPurchaseOrders(
                approvalStatus: approvalStatus,
                cancellationToken: cancellationToken);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving purchase orders");
            throw;
        }

        if (!response.IsSuccessful || response.Data == null)
        {
            _logger.LogError("Failed to retrieve purchase orders. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve purchase orders. API StatusCode: {response.StatusCode}");
        }

        foreach (var order in response.Data)
        {
            yield return order;
        }
    }
}