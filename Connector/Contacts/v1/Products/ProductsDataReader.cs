using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Contacts.v1.Products;

public class ProductsDataReader : TypedAsyncDataReaderBase<ProductsDataObject>
{
    private readonly ILogger<ProductsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public ProductsDataReader(
        ILogger<ProductsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<ProductsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (dataObjectRunArguments == null)
        {
            _logger.LogError("DataObjectRunArguments is required");
            throw new ArgumentNullException(nameof(dataObjectRunArguments));
        }

        var businessUnitIdElement = dataObjectRunArguments.RequestParameterOverrides?.RootElement
            .GetProperty("businessUnitId");
        
        Guid? businessUnitId = null;
        if (businessUnitIdElement != null && Guid.TryParse(businessUnitIdElement.Value.GetString(), out var buid))
        {
            businessUnitId = buid;
        }

        IEnumerable<ProductsDataObject>? products = null;
        try
        {
            var response = await _apiClient.GetProducts(businessUnitId, cancellationToken);
            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve products. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve products. API StatusCode: {response.StatusCode}");
            }
            products = response.Data;
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving products");
            throw;
        }

        if (products != null)
        {
            foreach (var product in products)
            {
                yield return product;
            }
        }
    }
}