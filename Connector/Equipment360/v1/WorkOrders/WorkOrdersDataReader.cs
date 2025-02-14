using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;
using System.Linq;

namespace Connector.Equipment360.v1.WorkOrders;

public class WorkOrdersDataReader : TypedAsyncDataReaderBase<WorkOrdersDataObject>
{
    private readonly ILogger<WorkOrdersDataReader> _logger;
    private readonly ApiClient _apiClient;
    private int _currentPage = 1;

    public WorkOrdersDataReader(
        ILogger<WorkOrdersDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<WorkOrdersDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            ApiResponse<PaginatedResponse<WorkOrdersDataObject>> response;
            try
            {
                var responseData = await _apiClient.GetWorkOrdersList(
                    cursor: _currentPage,
                    count: 100,
                    includeNotes: true,
                    cancellationToken: cancellationToken);

                // Map the response to our WorkOrdersDataObject
                if (responseData.IsSuccessful && responseData.Data?.Items != null)
                {
                    response = new ApiResponse<PaginatedResponse<WorkOrdersDataObject>>
                    {
                        IsSuccessful = responseData.IsSuccessful,
                        StatusCode = responseData.StatusCode,
                        Data = new PaginatedResponse<WorkOrdersDataObject>
                        {
                            Page = responseData.Data.Page,
                            PageSize = responseData.Data.PageSize,
                            TotalRecords = responseData.Data.TotalRecords,
                            TotalPages = responseData.Data.TotalPages,
                            Items = responseData.Data.Items.Select(wo => new WorkOrdersDataObject
                            {
                                Id = wo.Id,
                                BusinessUnitId = wo.BusinessUnitId,
                                WorkOrderNumber = wo.WorkOrderNumber,
                                EquipmentJobId = wo.EquipmentJobId,
                                Tags = wo.Tags,
                                Notes = wo.Notes?.Select(n => new WorkOrderNoteRead
                                {
                                    Id = n.Id,
                                    CreatedBy = n.CreatedBy,
                                    CreatedDate = n.CreatedDate,
                                    ModifiedBy = n.ModifiedBy,
                                    ModifiedDate = n.ModifiedDate,
                                    Note = n.Note
                                }),
                                StatusDate = wo.StatusDate,
                                IsPreventiveMaintenance = wo.IsPreventiveMaintenance,
                                EquipmentId = wo.EquipmentId,
                                JobId = wo.JobId,
                                Description = wo.Description,
                                Status = wo.Status,
                                Priority = wo.Priority
                            })
                        }
                    };
                }
                else
                {
                    response = new ApiResponse<PaginatedResponse<WorkOrdersDataObject>>
                    {
                        IsSuccessful = responseData.IsSuccessful,
                        StatusCode = responseData.StatusCode,
                        Data = null,
                        RawResult = responseData.RawResult
                    };
                }
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
            if (_currentPage >= (response.Data?.TotalPages ?? 0))
            {
                break;
            }
        }
    }
}