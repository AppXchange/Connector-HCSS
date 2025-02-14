using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;
using System.Linq;

namespace Connector.Equipment360.v1.CustomFieldCategories;

public class CustomFieldCategoriesDataReader : TypedAsyncDataReaderBase<CustomFieldCategoriesDataObject>
{
    private readonly ILogger<CustomFieldCategoriesDataReader> _logger;
    private readonly ApiClient _apiClient;

    public CustomFieldCategoriesDataReader(
        ILogger<CustomFieldCategoriesDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<CustomFieldCategoriesDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        ApiResponse<IEnumerable<CustomFieldCategoriesDataObject>> response;
        try
        {
            response = await _apiClient.GetCustomFieldCategories(cancellationToken: cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve custom field categories. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve custom field categories. API StatusCode: {response.StatusCode}");
            }
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving custom field categories");
            throw;
        }

        if (response.Data == null)
            yield break;

        foreach (var category in response.Data)
        {
            yield return category;
        }
    }
}