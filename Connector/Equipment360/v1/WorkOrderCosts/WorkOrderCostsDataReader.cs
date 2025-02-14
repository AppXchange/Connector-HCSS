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

namespace Connector.Equipment360.v1.WorkOrderCosts;

public class WorkOrderCostsDataReader : TypedAsyncDataReaderBase<WorkOrderCostsDataObject>
{
    private readonly ILogger<WorkOrderCostsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public WorkOrderCostsDataReader(
        ILogger<WorkOrderCostsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<WorkOrderCostsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var businessUnitIdStr = dataObjectRunArguments?.RequestParameterOverrides?.RootElement.GetProperty("businessUnitId").GetString();
        if (businessUnitIdStr == null || !Guid.TryParse(businessUnitIdStr, out var businessUnitGuid))
        {
            _logger.LogError("BusinessUnitId is required for work order costs");
            throw new ArgumentException("BusinessUnitId is required for work order costs");
        }

        ApiResponse<WorkOrderCostsDataObject> response;
        try
        {
            response = await _apiClient.GetWorkOrderCosts(
                businessUnitId: businessUnitGuid,
                cancellationToken: cancellationToken);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving work order costs");
            throw;
        }

        if (!response.IsSuccessful || response.Data == null)
        {
            _logger.LogError("Failed to retrieve work order costs. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve work order costs. API StatusCode: {response.StatusCode}");
        }

        yield return response.Data;
    }
}