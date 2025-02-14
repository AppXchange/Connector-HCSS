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

namespace Connector.HeavyBidEstimate.v1.BusinessUnits;

public class BusinessUnitsDataReader : TypedAsyncDataReaderBase<BusinessUnitsDataObject>
{
    private readonly ILogger<BusinessUnitsDataReader> _logger;
    private readonly ApiClient _apiClient;
    private int _skipValue = 0;
    private readonly int _topValue = 100;

    public BusinessUnitsDataReader(
        ILogger<BusinessUnitsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<BusinessUnitsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            ApiResponse<HeavyBidResponse<BusinessUnitsDataObject>> response;
            try
            {
                response = await _apiClient.GetBusinessUnits(
                    top: _topValue,
                    skip: _skipValue,
                    cancellationToken: cancellationToken);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while retrieving business units");
                throw;
            }

            if (!response.IsSuccessful || response.Data?.Data == null)
            {
                _logger.LogError("Failed to retrieve business units. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve business units. API StatusCode: {response.StatusCode}");
            }

            foreach (var businessUnit in response.Data.Data)
            {
                yield return businessUnit;
            }

            if (response.Data.NextSkipValue == null || response.Data.NextSkipValue <= _skipValue)
            {
                break;
            }

            _skipValue = response.Data.NextSkipValue.Value;
        }
    }
}