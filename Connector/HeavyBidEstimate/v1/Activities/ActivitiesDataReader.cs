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

namespace Connector.HeavyBidEstimate.v1.Activities;

public class ActivitiesDataReader : TypedAsyncDataReaderBase<ActivitiesDataObject>
{
    private readonly ILogger<ActivitiesDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;
    private int _skipValue = 0;
    private readonly int _topValue = 100;

    public ActivitiesDataReader(
        ILogger<ActivitiesDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<ActivitiesDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (_connectionConfig.BusinessUnitId == default)
        {
            throw new InvalidOperationException("BusinessUnitId must be configured in the connection settings");
        }

        while (true)
        {
            ApiResponse<HeavyBidResponse<ActivitiesDataObject>> response;
            try
            {
                response = await _apiClient.GetActivities(
                    businessUnitId: _connectionConfig.BusinessUnitId,
                    top: _topValue,
                    skip: _skipValue,
                    cancellationToken: cancellationToken);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while retrieving activities");
                throw;
            }

            if (!response.IsSuccessful || response.Data?.Data == null)
            {
                _logger.LogError("Failed to retrieve activities. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve activities. API StatusCode: {response.StatusCode}");
            }

            foreach (var activity in response.Data.Data)
            {
                yield return activity;
            }

            if (response.Data.NextSkipValue == null || response.Data.NextSkipValue <= _skipValue)
            {
                break;
            }

            _skipValue = response.Data.NextSkipValue.Value;
        }
    }
}