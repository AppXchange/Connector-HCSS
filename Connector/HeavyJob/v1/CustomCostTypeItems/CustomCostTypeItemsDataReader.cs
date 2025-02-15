using Connector.Client;
using Connector.Connections;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.CustomCostTypeItems;

public class CustomCostTypeItemsDataReader : TypedAsyncDataReaderBase<CustomCostTypeItemsDataObject>
{
    private readonly ILogger<CustomCostTypeItemsDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public CustomCostTypeItemsDataReader(
        ILogger<CustomCostTypeItemsDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<CustomCostTypeItemsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = await _apiClient.GetCustomCostTypeItems(
            _connectionConfig.BusinessUnitId,
            null, // isDeleted
            cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve custom cost type items. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve custom cost type items. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No custom cost type items found");
            yield break;
        }

        foreach (var item in response.Data)
        {
            yield return item;
        }
    }
}