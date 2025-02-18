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

namespace Connector.Webhooks.v1.HeavyJobSubscription;

public class HeavyJobSubscriptionDataReader : TypedAsyncDataReaderBase<HeavyJobSubscriptionDataObject>
{
    private readonly ILogger<HeavyJobSubscriptionDataReader> _logger;
    private readonly ApiClient _apiClient;

    public HeavyJobSubscriptionDataReader(
        ILogger<HeavyJobSubscriptionDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<HeavyJobSubscriptionDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = await _apiClient.GetHeavyJobSubscriptions(cancellationToken);

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

        foreach (var subscription in response.Data)
        {
            yield return subscription;
        }
    }
}