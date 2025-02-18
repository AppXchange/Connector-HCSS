using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.Safety.v1.Providers;

public class ProvidersDataReader : TypedAsyncDataReaderBase<ProvidersDataObject>
{
    private readonly ILogger<ProvidersDataReader> _logger;
    private readonly ApiClient _apiClient;

    public ProvidersDataReader(
        ILogger<ProvidersDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<ProvidersDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = await _apiClient.GetProviders(cancellationToken);

        if (!response.IsSuccessful || response.Data == null)
        {
            _logger.LogError("Failed to retrieve providers. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve providers. API StatusCode: {response.StatusCode}");
        }

        foreach (var provider in response.Data)
        {
            yield return provider;
        }
    }
}