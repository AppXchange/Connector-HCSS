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

namespace Connector.HeavyBidEstimate.v1.AllBiditemCodebook;

public class AllBiditemCodebookDataReader : TypedAsyncDataReaderBase<AllBiditemCodebookDataObject>
{
    private readonly ILogger<AllBiditemCodebookDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;
    private int _skipValue = 0;
    private readonly int _topValue = 100;

    public AllBiditemCodebookDataReader(
        ILogger<AllBiditemCodebookDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<AllBiditemCodebookDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (_connectionConfig.BusinessUnitId == default)
        {
            throw new InvalidOperationException("BusinessUnitId must be configured in the connection settings");
        }

        while (true)
        {
            ApiResponse<HeavyBidResponse<AllBiditemCodebookDataObject>> response;
            try
            {
                response = await _apiClient.GetAllBiditemCodebooks(
                    businessUnitId: _connectionConfig.BusinessUnitId,
                    top: _topValue,
                    skip: _skipValue,
                    cancellationToken: cancellationToken);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while retrieving biditem codebooks");
                throw;
            }

            if (!response.IsSuccessful || response.Data?.Data == null)
            {
                _logger.LogError("Failed to retrieve biditem codebooks. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve biditem codebooks. API StatusCode: {response.StatusCode}");
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