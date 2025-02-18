using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Text.Json;

namespace Connector.Users.v1.Username;

public class UsernameDataReader : TypedAsyncDataReaderBase<UsernameDataObject>
{
    private readonly ILogger<UsernameDataReader> _logger;
    private readonly ApiClient _apiClient;

    public UsernameDataReader(
        ILogger<UsernameDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<UsernameDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var userName = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("userName", out var userNameElement)
            ? userNameElement.GetString()
            : null;

        if (string.IsNullOrEmpty(userName))
        {
            _logger.LogError("Username is required but was not provided");
            throw new ArgumentException("Username is required");
        }

        var response = await _apiClient.GetUsersUsername(userName, cancellationToken);

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