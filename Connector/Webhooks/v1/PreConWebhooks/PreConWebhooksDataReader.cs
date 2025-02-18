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

namespace Connector.Webhooks.v1.PreConWebhooks;

public class PreConWebhooksDataReader : TypedAsyncDataReaderBase<PreConWebhooksDataObject>
{
    private readonly ILogger<PreConWebhooksDataReader> _logger;
    private readonly ApiClient _apiClient;

    public PreConWebhooksDataReader(
        ILogger<PreConWebhooksDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<PreConWebhooksDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var businessUnitId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement.GetProperty("businessUnitId").GetString();
        if (string.IsNullOrEmpty(businessUnitId))
        {
            _logger.LogError("BusinessUnitId is required but was not provided");
            throw new ArgumentException("BusinessUnitId is required");
        }

        var response = await _apiClient.GetPreConWebhooks(Guid.Parse(businessUnitId), cancellationToken);

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