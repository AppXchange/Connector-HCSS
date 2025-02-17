using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.PayItems;

public class PayItemsDataReader : TypedAsyncDataReaderBase<PayItemsDataObject>
{
    private readonly ILogger<PayItemsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public PayItemsDataReader(
        ILogger<PayItemsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<PayItemsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var jobId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement
            .TryGetProperty("jobId", out var jobIdElement) == true && jobIdElement.TryGetGuid(out var id) 
            ? id 
            : (Guid?)null;

        var response = await _apiClient.GetPayItems(
            jobId,
            isDeleted: null,
            limit: 1000,
            cursor: null,
            cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve pay items. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve pay items. API StatusCode: {response.StatusCode}");
        }

        if (response.Data?.Results == null)
        {
            _logger.LogWarning("No pay items found");
            yield break;
        }

        foreach (var payItem in response.Data.Results)
        {
            yield return payItem;
        }

        while (!string.IsNullOrEmpty(response.Data.Metadata?.NextCursor))
        {
            response = await _apiClient.GetPayItems(
                jobId,
                isDeleted: null,
                limit: 1000,
                cursor: response.Data.Metadata.NextCursor,
                cancellationToken);

            if (!response.IsSuccessful || response.Data?.Results == null)
                break;

            foreach (var payItem in response.Data.Results)
            {
                yield return payItem;
            }
        }
    }
}