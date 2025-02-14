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

namespace Connector.Equipment360.v1.WorkOrderCostsDetails;

public class WorkOrderCostsDetailsDataReader : TypedAsyncDataReaderBase<WorkOrderCostsDetailsDataObject>
{
    private readonly ILogger<WorkOrderCostsDetailsDataReader> _logger;
    private readonly ApiClient _apiClient;
    private int _currentPage = 1;

    public WorkOrderCostsDetailsDataReader(
        ILogger<WorkOrderCostsDetailsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<WorkOrderCostsDetailsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var businessUnitIdStr = dataObjectRunArguments?.RequestParameterOverrides?.RootElement.GetProperty("businessUnitId").GetString();
        if (businessUnitIdStr == null || !Guid.TryParse(businessUnitIdStr, out var businessUnitGuid))
        {
            _logger.LogError("BusinessUnitId is required for work order costs details");
            throw new ArgumentException("BusinessUnitId is required for work order costs details");
        }

        while (true)
        {
            ApiResponse<PaginatedResponse<WorkOrderCostsDetailsDataObject>> response;
            try
            {
                response = await _apiClient.GetWorkOrderCostsDetails(
                    businessUnitId: businessUnitGuid,
                    cursor: _currentPage,
                    count: 100,
                    cancellationToken: cancellationToken);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while retrieving work order costs details");
                throw;
            }

            if (!response.IsSuccessful || response.Data?.Items == null)
            {
                _logger.LogError("Failed to retrieve work order costs details. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve work order costs details. API StatusCode: {response.StatusCode}");
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