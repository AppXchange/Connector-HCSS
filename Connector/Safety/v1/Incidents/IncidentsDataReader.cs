using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.Safety.v1.Incidents;

public class IncidentsDataReader : TypedAsyncDataReaderBase<IncidentsDataObject>
{
    private readonly ILogger<IncidentsDataReader> _logger;
    private readonly ApiClient _apiClient;
    private int _offset = 0;

    public IncidentsDataReader(
        ILogger<IncidentsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<IncidentsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = await _apiClient.GetIncidentsList(
                limit: 1000,
                offset: _offset,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful || response.Data == null)
            {
                _logger.LogError("Failed to retrieve incidents. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve incidents. API StatusCode: {response.StatusCode}");
            }

            if (response.Data.Length == 0)
            {
                break;
            }

            foreach (var incident in response.Data)
            {
                yield return incident;
            }

            if (!response.HasMorePages)
            {
                break;
            }

            _offset += 1000; // Increment by limit
        }
    }
}