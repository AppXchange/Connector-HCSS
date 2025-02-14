using Connector.Client;
using Connector.Client.Equipment360;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;
using System.Linq;

namespace Connector.Equipment360.v1.AllEquipment;

public class AllEquipmentDataReader : TypedAsyncDataReaderBase<AllEquipmentDataObject>
{
    private readonly ILogger<AllEquipmentDataReader> _logger;
    private readonly ApiClient _apiClient;
    private int _cursor = 0;

    public AllEquipmentDataReader(
        ILogger<AllEquipmentDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<AllEquipmentDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            ApiResponse<Equipment360PaginatedResponse<AllEquipmentDataObject>> response;
            try
            {
                response = await _apiClient.GetEquipment(
                    cursor: _cursor,
                    count: 100,
                    cancellationToken: cancellationToken);

                if (!response.IsSuccessful)
                {
                    _logger.LogError("Failed to retrieve equipment. Status code: {StatusCode}", response.StatusCode);
                    throw new Exception($"Failed to retrieve equipment. API StatusCode: {response.StatusCode}");
                }
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while retrieving equipment");
                throw;
            }

            if (response.Data?.Data == null || !response.Data.Data.Any())
                yield break;

            foreach (var equipment in response.Data.Data)
            {
                yield return equipment;
            }

            if (response.Data.Next == null)
                yield break;

            _cursor = response.Data.Next.Value;
        }
    }
}