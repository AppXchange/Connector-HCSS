using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.Safety.v1.IncidentFormTypes;

public class IncidentFormTypesDataReader : TypedAsyncDataReaderBase<IncidentFormTypesDataObject>
{
    private readonly ILogger<IncidentFormTypesDataReader> _logger;
    private readonly ApiClient _apiClient;
    private string? _cursor;

    public IncidentFormTypesDataReader(
        ILogger<IncidentFormTypesDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<IncidentFormTypesDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = await _apiClient.GetIncidentFormTypes(
                limit: 1000,
                cursor: _cursor,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful || response.Data == null)
            {
                _logger.LogError("Failed to retrieve incident form types. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve incident form types. API StatusCode: {response.StatusCode}");
            }

            foreach (var formType in response.Data.Results)
            {
                yield return formType;
            }

            _cursor = response.Data.Metadata.NextCursor;
            if (string.IsNullOrEmpty(_cursor))
            {
                break;
            }
        }
    }
}