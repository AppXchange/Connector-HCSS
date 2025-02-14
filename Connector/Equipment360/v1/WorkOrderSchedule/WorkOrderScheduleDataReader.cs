using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Equipment360.v1.WorkOrderSchedule;

public class WorkOrderScheduleDataReader : TypedAsyncDataReaderBase<WorkOrderScheduleDataObject>
{
    private readonly ILogger<WorkOrderScheduleDataReader> _logger;
    private readonly ApiClient _apiClient;
    private int _currentPage = 1;

    public WorkOrderScheduleDataReader(
        ILogger<WorkOrderScheduleDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<WorkOrderScheduleDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            ApiResponse<PaginatedResponse<WorkOrderScheduleDataObject>> response;
            try
            {
                response = await _apiClient.GetWorkOrderSchedules(
                    cursor: _currentPage,
                    count: 100,
                    cancellationToken: cancellationToken);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while retrieving work order schedules");
                throw;
            }

            if (!response.IsSuccessful || response.Data?.Items == null)
            {
                _logger.LogError("Failed to retrieve work order schedules. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve work order schedules. API StatusCode: {response.StatusCode}");
            }

            foreach (var schedule in response.Data.Items)
            {
                yield return schedule;
            }

            _currentPage++;
            if (_currentPage >= (response.Data?.TotalPages ?? 0))
            {
                break;
            }
        }
    }
}