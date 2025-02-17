using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.TimeCardApproval;

public class TimeCardApprovalDataReader : TypedAsyncDataReaderBase<TimeCardApprovalDataObject>
{
    private readonly ILogger<TimeCardApprovalDataReader> _logger;
    private readonly ApiClient _apiClient;

    public TimeCardApprovalDataReader(
        ILogger<TimeCardApprovalDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<TimeCardApprovalDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = await _apiClient.GetTimeCardApprovals(
            limit: 1000,
            cancellationToken: cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve time card approvals. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve time card approvals. API StatusCode: {response.StatusCode}");
        }

        if (response.Data?.Results == null)
        {
            _logger.LogWarning("No time card approvals found");
            yield break;
        }

        foreach (var approval in response.Data.Results)
        {
            yield return approval;
        }

        while (!string.IsNullOrEmpty(response.Data.Metadata?.NextCursor))
        {
            response = await _apiClient.GetTimeCardApprovals(
                limit: 1000,
                cursor: response.Data.Metadata.NextCursor,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful || response.Data?.Results == null)
                break;

            foreach (var approval in response.Data.Results)
            {
                yield return approval;
            }
        }
    }
}