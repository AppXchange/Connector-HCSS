using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;
using static Connector.Client.ApiClient;

namespace Connector.HeavyBidEstimate.v1.ActivityCodebookResource;

public class ActivityCodebookResourceDataReader : TypedAsyncDataReaderBase<ActivityCodebookResourceDataObject>
{
    private readonly ILogger<ActivityCodebookResourceDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public ActivityCodebookResourceDataReader(
        ILogger<ActivityCodebookResourceDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<ActivityCodebookResourceDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (_connectionConfig.BusinessUnitId == default)
        {
            throw new InvalidOperationException("BusinessUnitId must be configured in the connection settings");
        }

        if (dataObjectRunArguments?.RequestParameterOverrides == null || 
            !dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("activityCodebookResourceId", out var resourceIdElement) ||
            string.IsNullOrEmpty(resourceIdElement.GetString()) ||
            !Guid.TryParse(resourceIdElement.GetString(), out var resourceId))
        {
            throw new InvalidOperationException("Activity Codebook Resource ID must be provided in the parameters");
        }

        ApiResponse<SingleResponse<ActivityCodebookResourceDataObject>> response;
        try
        {
            response = await _apiClient.GetActivityCodebookResource(
                id: resourceId,
                businessUnitId: _connectionConfig.BusinessUnitId,
                cancellationToken: cancellationToken);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving activity codebook resource");
            throw;
        }

        if (!response.IsSuccessful || response.Data?.Data == null)
        {
            _logger.LogError("Failed to retrieve activity codebook resource. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve activity codebook resource. API StatusCode: {response.StatusCode}");
        }

        yield return response.Data.Data;
    }
}