using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Equipment360.v1.Parts;

public class PartsDataReader : TypedAsyncDataReaderBase<PartsDataObject>
{
    private readonly ILogger<PartsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public PartsDataReader(
        ILogger<PartsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<PartsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        ApiResponse<IEnumerable<PartsDataObject>> response;
        try
        {
            response = await _apiClient.GetParts(
                partNumber: null,
                cancellationToken: cancellationToken);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving parts");
            throw;
        }

        if (!response.IsSuccessful || response.Data == null)
        {
            _logger.LogError("Failed to retrieve parts. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve parts. API StatusCode: {response.StatusCode}");
        }

        foreach (var part in response.Data)
        {
            yield return part;
        }
    }
}