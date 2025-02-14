using Connector.Client;
using ESR.Hosting;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.CostCategories;

public class CostCategoriesDataReader : TypedAsyncDataReaderBase<CostCategoriesDataObject>
{
    private readonly ILogger<CostCategoriesDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public CostCategoriesDataReader(
        ILogger<CostCategoriesDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<CostCategoriesDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var businessUnitId = _connectionConfig.BusinessUnitId;

        var response = await _apiClient.GetCostCategories(businessUnitId, cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError(
                "Failed to retrieve cost categories. Status code: {StatusCode}",
                response.StatusCode);
            yield break;
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No cost categories found");
            yield break;
        }

        foreach (var category in response.Data)
        {
            yield return category;
        }
    }
}