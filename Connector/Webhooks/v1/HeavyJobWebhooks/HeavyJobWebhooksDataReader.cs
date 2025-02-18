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

namespace Connector.Webhooks.v1.HeavyJobWebhooks;

public class HeavyJobWebhooksDataReader : TypedAsyncDataReaderBase<HeavyJobWebhooksDataObject>
{
    private readonly ILogger<HeavyJobWebhooksDataReader> _logger;
    private readonly ApiClient _apiClient;

    public HeavyJobWebhooksDataReader(
        ILogger<HeavyJobWebhooksDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<HeavyJobWebhooksDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = await _apiClient.GetHeavyJobWebhooks(cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve webhook subscriptions. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve webhook subscriptions. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No webhook subscriptions found");
            yield break;
        }

        foreach (var webhook in response.Data)
        {
            yield return webhook;
        }
    }
}