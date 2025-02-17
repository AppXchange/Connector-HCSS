using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.UserAccessGroup;

public class UserAccessGroupDataReader : TypedAsyncDataReaderBase<UserAccessGroupDataObject>
{
    private readonly ILogger<UserAccessGroupDataReader> _logger;
    private readonly ApiClient _apiClient;

    public UserAccessGroupDataReader(
        ILogger<UserAccessGroupDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<UserAccessGroupDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var userIds = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("userIds", out var userIdsElement)
            ? userIdsElement.EnumerateArray().Select(x => x.GetGuid()).ToArray()
            : null;

        if (userIds == null || !userIds.Any())
        {
            _logger.LogWarning("UserIds is a required parameter");
            yield break;
        }

        var response = await _apiClient.GetUserAccessGroups(
            userIds: userIds,
            cancellationToken: cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve user access groups. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve user access groups. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No user access groups found");
            yield break;
        }

        foreach (var accessGroup in response.Data)
        {
            yield return accessGroup;
        }
    }
}