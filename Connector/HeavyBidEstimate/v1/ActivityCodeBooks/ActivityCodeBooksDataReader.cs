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

namespace Connector.HeavyBidEstimate.v1.ActivityCodeBooks;

public class ActivityCodeBooksDataReader : TypedAsyncDataReaderBase<ActivityCodeBooksDataObject>
{
    private readonly ILogger<ActivityCodeBooksDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;
    private int _skipValue = 0;
    private readonly int _topValue = 100;

    public ActivityCodeBooksDataReader(
        ILogger<ActivityCodeBooksDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<ActivityCodeBooksDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (_connectionConfig.BusinessUnitId == default)
        {
            throw new InvalidOperationException("BusinessUnitId must be configured in the connection settings");
        }

        while (true)
        {
            ApiResponse<HeavyBidResponse<ActivityCodeBooksDataObject>> response;
            try
            {
                response = await _apiClient.GetActivityCodeBooks(
                    businessUnitId: _connectionConfig.BusinessUnitId,
                    top: _topValue,
                    skip: _skipValue,
                    cancellationToken: cancellationToken);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while retrieving activity codebooks");
                throw;
            }

            if (!response.IsSuccessful || response.Data?.Data == null)
            {
                _logger.LogError("Failed to retrieve activity codebooks. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve activity codebooks. API StatusCode: {response.StatusCode}");
            }

            foreach (var codebook in response.Data.Data)
            {
                yield return codebook;
            }

            if (response.Data.NextSkipValue == null || response.Data.NextSkipValue <= _skipValue)
            {
                break;
            }

            _skipValue = response.Data.NextSkipValue.Value;
        }
    }
}