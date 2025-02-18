using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Text.Json;

namespace Connector.Users.v1.Users;

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
        var businessUnitId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("businessUnitId", out var businessUnitElement)
            ? businessUnitElement.GetString()
            : null;

        var page = 0;
        var pageSize = 50;
        bool hasMorePages;

        do
        {
            var response = await _apiClient.GetUsers(
                page,
                pageSize,
                businessUnitId != null ? Guid.Parse(businessUnitId) : null,
                cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve users. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve users. API StatusCode: {response.StatusCode}");
            }

            if (response.Data?.Results == null)
            {
                _logger.LogWarning("No users found");
                yield break;
            }

            foreach (var item in response.Data.Results)
            {
                yield return item;
            }

            page++;
            hasMorePages = page < response.Data.TotalPages;

        } while (hasMorePages);
    }
}