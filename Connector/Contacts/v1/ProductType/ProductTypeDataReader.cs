using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Contacts.v1.ProductType;

public class ProductTypeDataReader : TypedAsyncDataReaderBase<ProductTypeDataObject>
{
    private readonly ILogger<ProductTypeDataReader> _logger;
    private readonly ApiClient _apiClient;

    public ProductTypeDataReader(
        ILogger<ProductTypeDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<ProductTypeDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (dataObjectRunArguments == null)
        {
            _logger.LogError("DataObjectRunArguments is required");
            throw new ArgumentNullException(nameof(dataObjectRunArguments));
        }

        var productTypeIdElement = dataObjectRunArguments.RequestParameterOverrides?.RootElement
            .GetProperty("productTypeId");

        if (productTypeIdElement == null || !Guid.TryParse(productTypeIdElement.Value.GetString(), out var productTypeId))
        {
            _logger.LogError("Valid productTypeId (GUID) is required");
            throw new ArgumentException("Valid productTypeId (GUID) is required");
        }

        var businessUnitIdElement = dataObjectRunArguments.RequestParameterOverrides?.RootElement
            .GetProperty("businessUnitId");
        
        Guid? businessUnitId = null;
        if (businessUnitIdElement != null && Guid.TryParse(businessUnitIdElement.Value.GetString(), out var buid))
        {
            businessUnitId = buid;
        }

        ProductTypeDataObject? productType = null;
        try
        {
            var response = await _apiClient.GetProductType(productTypeId, businessUnitId, cancellationToken);
            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve product type. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve product type. API StatusCode: {response.StatusCode}");
            }
            productType = response.Data;
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving product type");
            throw;
        }

        if (productType != null)
        {
            yield return productType;
        }
    }
}