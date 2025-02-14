using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Equipment360.v1.WorkOrderPurchase;

public class WorkOrderPurchaseDataReader : TypedAsyncDataReaderBase<WorkOrderPurchaseDataObject>
{
    private readonly ILogger<WorkOrderPurchaseDataReader> _logger;
    private readonly ApiClient _apiClient;
    private int _currentPage = 1;

    public WorkOrderPurchaseDataReader(
        ILogger<WorkOrderPurchaseDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<WorkOrderPurchaseDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            ApiResponse<PaginatedResponse<WorkOrderPurchaseDataObject>> response;
            try
            {
                response = await _apiClient.GetWorkOrderPurchases(
                    cursor: _currentPage,
                    count: 100,
                    cancellationToken: cancellationToken);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while retrieving work order purchases");
                throw;
            }

            if (!response.IsSuccessful || response.Data?.Items == null)
            {
                _logger.LogError("Failed to retrieve work order purchases. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve work order purchases. API StatusCode: {response.StatusCode}");
            }

            foreach (var purchase in response.Data.Items)
            {
                yield return purchase;
            }

            _currentPage++;
            if (_currentPage >= response.Data.TotalPages)
            {
                break;
            }
        }
    }
}