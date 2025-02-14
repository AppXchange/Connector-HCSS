using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;
using Connector.Client.Equipment360;
using System.Linq;

namespace Connector.Equipment360.v1.MaintenanceRequest;

public class MaintenanceRequestDataReader : TypedAsyncDataReaderBase<MaintenanceRequestDataObject>
{
    private readonly ILogger<MaintenanceRequestDataReader> _logger;
    private readonly ApiClient _apiClient;
    private int _cursor = 1;
    private const int PageSize = 100;

    public MaintenanceRequestDataReader(
        ILogger<MaintenanceRequestDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<MaintenanceRequestDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            ApiResponse<Equipment360PaginatedResponse<MaintenanceRequestDataObject>> response;
            try
            {
                response = await _apiClient.GetMaintenanceRequests(
                    count: PageSize,
                    cursor: _cursor,
                    cancellationToken: cancellationToken);

                if (!response.IsSuccessful || response.Data == null)
                {
                    _logger.LogError("Failed to retrieve maintenance requests. Status code: {StatusCode}", response.StatusCode);
                    throw new Exception($"Failed to retrieve maintenance requests. API StatusCode: {response.StatusCode}");
                }
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while retrieving maintenance requests");
                throw;
            }

            if (response.Data.Data == null || !response.Data.Data.Any())
                break;

            foreach (var request in response.Data.Data)
            {
                yield return request;
            }

            if (!response.Data.Next.HasValue)
                break;

            _cursor = response.Data.Next.Value;
        }
    }
}