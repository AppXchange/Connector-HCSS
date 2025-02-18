using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Text.Json;

namespace Connector.Users.v1.Roles;

public class RolesDataReader : TypedAsyncDataReaderBase<RolesDataObject>
{
    private readonly ILogger<RolesDataReader> _logger;
    private readonly ApiClient _apiClient;

    public RolesDataReader(
        ILogger<RolesDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<RolesDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = await _apiClient.GetUsersRoles(cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve roles. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve roles. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No roles found");
            yield break;
        }

        foreach (var item in response.Data)
        {
            yield return item;
        }
    }
}