using Connector.Client;
using Connector.Connections;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.CostCodeTags;

public class CostCodeTagsDataReader : TypedAsyncDataReaderBase<CostCodeTagsDataObject>
{
    private readonly ILogger<CostCodeTagsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public CostCodeTagsDataReader(
        ILogger<CostCodeTagsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<CostCodeTagsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        string? cursor = null;

        while (true)
        {
            var response = await _apiClient.GetCostCodeTags(
                null, // jobId
                null, // costCodeId
                null, // tagId
                null, // modifiedSince
                1000, // limit
                cursor,
                cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve cost code tags. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve cost code tags. API StatusCode: {response.StatusCode}");
            }

            if (response.Data?.Results == null)
            {
                _logger.LogWarning("No cost code tags found");
                yield break;
            }

            foreach (var tag in response.Data.Results)
            {
                yield return tag;
            }

            if (string.IsNullOrEmpty(response.Data.Metadata.NextCursor))
            {
                break;
            }

            cursor = response.Data.Metadata.NextCursor;
        }
    }
}