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

namespace Connector.Equipment360.v1.TimeCard;

public class TimeCardDataReader : TypedAsyncDataReaderBase<TimeCardDataObject>
{
    private readonly ILogger<TimeCardDataReader> _logger;
    private readonly ApiClient _apiClient;

    public TimeCardDataReader(
        ILogger<TimeCardDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<TimeCardDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        int? cursor = null;
        const int count = 100; // Default page size

        while (true)
        {
            ApiResponse<PaginatedResponse<TimeCardDataObject>> response;
            try
            {
                response = await _apiClient.GetTimeCards(
                    cursor: cursor,
                    count: count,
                    cancellationToken: cancellationToken);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while retrieving time cards");
                throw;
            }

            if (!response.IsSuccessful || response.Data?.Items == null)
            {
                _logger.LogError("Failed to retrieve time cards or no data returned");
                yield break;
            }

            foreach (var timeCard in response.Data.Items)
            {
                yield return timeCard;
            }

            // Check if there are more pages
            if (response.Data.Page >= response.Data.TotalPages)
            {
                break;
            }

            cursor = response.Data.Page + 1;
        }
    }
}