using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Text.Json;

namespace Connector.Users.v1.SubscriptionGroups;

public class SubscriptionGroupsDataReader : TypedAsyncDataReaderBase<SubscriptionGroupsDataObject>
{
    private readonly ILogger<SubscriptionGroupsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public SubscriptionGroupsDataReader(
        ILogger<SubscriptionGroupsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<SubscriptionGroupsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = await _apiClient.GetUsersSubscriptionGroups(cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve subscription groups. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve subscription groups. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No subscription groups found");
            yield break;
        }

        foreach (var item in response.Data)
        {
            yield return item;
        }
    }
}