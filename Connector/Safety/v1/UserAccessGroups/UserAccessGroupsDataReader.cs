using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.Safety.v1.UserAccessGroups;

public class UserAccessGroupsDataReader : TypedAsyncDataReaderBase<UserAccessGroupsDataObject>
{
    private readonly ILogger<UserAccessGroupsDataReader> _logger;
    private readonly ApiClient _apiClient;
    private string? _nextCursor;

    public UserAccessGroupsDataReader(
        ILogger<UserAccessGroupsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<UserAccessGroupsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        do
        {
            var response = await _apiClient.SearchUserAccessGroups(
                limit: 1000,
                cursor: _nextCursor,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful || response.Data == null)
            {
                _logger.LogError("Failed to retrieve user access groups. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve user access groups. API StatusCode: {response.StatusCode}");
            }

            foreach (var userAccessGroup in response.Data.Results)
            {
                yield return userAccessGroup;
            }

            _nextCursor = response.Data.Metadata?.NextCursor;

        } while (!string.IsNullOrEmpty(_nextCursor));
    }
}