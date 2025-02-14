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

namespace Connector.Equipment360.v1.WorkOrder;

public class WorkOrderDataReader : TypedAsyncDataReaderBase<WorkOrderDataObject>
{
    private readonly ILogger<WorkOrderDataReader> _logger;
    private readonly ApiClient _apiClient;
    private int _currentPage = 1;

    public WorkOrderDataReader(
        ILogger<WorkOrderDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<WorkOrderDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            ApiResponse<PaginatedResponse<WorkOrderDataObject>> response;
            try
            {
                response = await _apiClient.GetWorkOrders(
                    cursor: _currentPage,
                    count: 100,
                    cancellationToken: cancellationToken);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while retrieving work orders");
                throw;
            }

            if (!response.IsSuccessful || response.Data?.Items == null)
            {
                _logger.LogError("Failed to retrieve work orders. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve work orders. API StatusCode: {response.StatusCode}");
            }

            foreach (var workOrder in response.Data.Items)
            {
                yield return workOrder;
            }

            _currentPage++;
            if (_currentPage >= response.Data.TotalPages)
            {
                break;
            }
        }
    }
}