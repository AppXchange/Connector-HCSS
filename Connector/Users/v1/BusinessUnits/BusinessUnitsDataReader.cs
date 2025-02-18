using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Text.Json;

namespace Connector.Users.v1.BusinessUnits;

public class BusinessUnitsDataReader : TypedAsyncDataReaderBase<BusinessUnitsDataObject>
{
    private readonly ILogger<BusinessUnitsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public BusinessUnitsDataReader(
        ILogger<BusinessUnitsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<BusinessUnitsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = await _apiClient.GetUsersBusinessUnits(cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve business units. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve business units. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No business units found");
            yield break;
        }

        foreach (var item in response.Data)
        {
            yield return item;
        }
    }
}