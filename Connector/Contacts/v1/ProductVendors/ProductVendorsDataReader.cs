using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Contacts.v1.ProductVendors;

public class ProductVendorsDataReader : TypedAsyncDataReaderBase<ProductVendorsDataObject>
{
    private readonly ILogger<ProductVendorsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public ProductVendorsDataReader(
        ILogger<ProductVendorsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<ProductVendorsDataObject> GetTypedDataAsync(
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

        IEnumerable<ProductVendorsDataObject>? vendors = null;
        try
        {
            var response = await _apiClient.GetProductVendors(productTypeId, businessUnitId, cancellationToken);
            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve product vendors. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve product vendors. API StatusCode: {response.StatusCode}");
            }
            vendors = response.Data;
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving product vendors");
            throw;
        }

        if (vendors != null)
        {
            foreach (var vendor in vendors)
            {
                yield return vendor;
            }
        }
    }
}