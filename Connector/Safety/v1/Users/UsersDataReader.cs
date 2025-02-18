using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.Safety.v1.Users;

public class UsersDataReader : TypedAsyncDataReaderBase<UsersDataObject>
{
    private readonly ILogger<UsersDataReader> _logger;
    private readonly ApiClient _apiClient;

    public UsersDataReader(
        ILogger<UsersDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<UsersDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = await _apiClient.GetSafetyUser(
            Guid.Parse(dataObjectRunArguments?.RequestParameterOverrides?.RootElement.GetProperty("id").GetString() 
                ?? throw new ArgumentException("User ID is required")),
            cancellationToken);

        if (!response.IsSuccessful || response.Data == null)
        {
            _logger.LogError("Failed to retrieve user. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve user. API StatusCode: {response.StatusCode}");
        }

        yield return response.Data;
    }
}