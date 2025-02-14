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
using static Connector.Client.ApiClient;

namespace Connector.HeavyBidEstimate.v1.Activity;

public class ActivityDataReader : TypedAsyncDataReaderBase<ActivityDataObject>
{
    private readonly ILogger<ActivityDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public ActivityDataReader(
        ILogger<ActivityDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<ActivityDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (_connectionConfig.BusinessUnitId == default)
        {
            throw new InvalidOperationException("BusinessUnitId must be configured in the connection settings");
        }

        if (dataObjectRunArguments?.RequestParameterOverrides == null || 
            !dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("activityId", out var activityIdElement) ||
            string.IsNullOrEmpty(activityIdElement.GetString()) ||
            !Guid.TryParse(activityIdElement.GetString(), out var activityId))
        {
            throw new InvalidOperationException("Activity ID must be provided in the parameters");
        }

        ApiResponse<SingleResponse<ActivityDataObject>> response;
        try
        {
            response = await _apiClient.GetActivity(
                id: activityId,
                businessUnitId: _connectionConfig.BusinessUnitId,
                cancellationToken: cancellationToken);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving activity");
            throw;
        }

        if (!response.IsSuccessful || response.Data?.Data == null)
        {
            _logger.LogError("Failed to retrieve activity. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve activity. API StatusCode: {response.StatusCode}");
        }

        yield return response.Data.Data;
    }
}