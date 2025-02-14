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

namespace Connector.HeavyBidEstimate.v1.ActivityCodeBook;

public class ActivityCodeBookDataReader : TypedAsyncDataReaderBase<ActivityCodeBookDataObject>
{
    private readonly ILogger<ActivityCodeBookDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public ActivityCodeBookDataReader(
        ILogger<ActivityCodeBookDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<ActivityCodeBookDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (_connectionConfig.BusinessUnitId == default)
        {
            throw new InvalidOperationException("BusinessUnitId must be configured in the connection settings");
        }

        if (dataObjectRunArguments?.RequestParameterOverrides == null || 
            !dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("activityCodeBookId", out var activityIdElement) ||
            string.IsNullOrEmpty(activityIdElement.GetString()) ||
            !Guid.TryParse(activityIdElement.GetString(), out var activityCodeBookId))
        {
            throw new InvalidOperationException("Activity Codebook ID must be provided in the parameters");
        }

        ApiResponse<SingleResponse<ActivityCodeBookDataObject>> response;
        try
        {
            response = await _apiClient.GetActivityCodeBook(
                id: activityCodeBookId,
                businessUnitId: _connectionConfig.BusinessUnitId,
                cancellationToken: cancellationToken);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving activity codebook");
            throw;
        }

        if (!response.IsSuccessful || response.Data?.Data == null)
        {
            _logger.LogError("Failed to retrieve activity codebook. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve activity codebook. API StatusCode: {response.StatusCode}");
        }

        yield return response.Data.Data;
    }
}