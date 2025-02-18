using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.Safety.v1.AccessGroups;

public class AccessGroupsDataReader : TypedAsyncDataReaderBase<AccessGroupsDataObject>
{
    private readonly ILogger<AccessGroupsDataReader> _logger;
    private readonly ApiClient _apiClient;
    private string? _cursor;

    public AccessGroupsDataReader(
        ILogger<AccessGroupsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<AccessGroupsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var isDeleted = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("isDeleted", out var isDeletedElement) 
            ? isDeletedElement.GetBoolean()
            : (bool?)null;

        while (true)
        {
            var response = await _apiClient.GetAccessGroups(
                isDeleted: isDeleted,
                cursor: _cursor,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve access groups. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve access groups. API StatusCode: {response.StatusCode}");
            }

            if (response.Data?.Results == null || response.Data.Results.Length == 0)
            {
                break;
            }

            foreach (var group in response.Data.Results)
            {
                yield return group;
            }

            _cursor = response.Data.Metadata.NextCursor;
            if (string.IsNullOrEmpty(_cursor))
            {
                break;
            }
        }
    }
}