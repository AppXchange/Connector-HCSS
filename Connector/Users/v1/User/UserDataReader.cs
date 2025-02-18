using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Text.Json;

namespace Connector.Users.v1.User;

public class UserDataReader : TypedAsyncDataReaderBase<UserDataObject>
{
    private readonly ILogger<UserDataReader> _logger;
    private readonly ApiClient _apiClient;

    public UserDataReader(
        ILogger<UserDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<UserDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var id = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("id", out var idElement)
            ? idElement.GetString()
            : null;

        if (string.IsNullOrEmpty(id))
        {
            _logger.LogError("User Id is required but was not provided");
            throw new ArgumentException("User Id is required");
        }

        var response = await _apiClient.GetUsersUser(Guid.Parse(id), cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve user. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve user. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No user found");
            yield break;
        }

        yield return response.Data;
    }
}