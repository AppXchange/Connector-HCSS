using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.CostAdjustments;

public class CostAdjustmentsDataReader : TypedAsyncDataReaderBase<CostAdjustmentsDataObject>
{
    private readonly ILogger<CostAdjustmentsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public CostAdjustmentsDataReader(
        ILogger<CostAdjustmentsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<CostAdjustmentsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments, 
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var businessUnitId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement
            .GetProperty("businessUnitId").GetString();
        if (businessUnitId == null)
        {
            throw new ArgumentException("Business Unit ID is required");
        }

        ApiResponse<IEnumerable<CostAdjustmentsDataObject>> response;
        try
        {
            response = await _apiClient.GetCostAdjustments(
                Guid.Parse(businessUnitId), 
                cancellationToken);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while making a read request to data object 'CostAdjustmentsDataObject'");
            throw;
        }

        if (!response.IsSuccessful)
        {
            throw new Exception($"Failed to retrieve records for 'CostAdjustmentsDataObject'. API StatusCode: {response.StatusCode}");
        }

        if (response.Data != null)
        {
            foreach (var item in response.Data)
            {
                yield return item;
            }
        }
    }
}