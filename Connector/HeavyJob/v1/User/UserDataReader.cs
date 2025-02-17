using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.User;

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
        var userId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("userId", out var userIdElement) 
            && userIdElement.TryGetGuid(out var uid)
            ? uid
            : (Guid?)null;

        if (!userId.HasValue)
        {
            _logger.LogWarning("UserId is a required parameter");
            yield break;
        }

        var response = await _apiClient.GetUser(
            userId: userId.Value,
            cancellationToken: cancellationToken);

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