using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Contacts.v1.VendorProducts;

public class VendorProductsDataReader : TypedAsyncDataReaderBase<VendorProductsDataObject>
{
    private readonly ILogger<VendorProductsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public VendorProductsDataReader(
        ILogger<VendorProductsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<VendorProductsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (dataObjectRunArguments == null)
        {
            _logger.LogError("DataObjectRunArguments is required");
            throw new ArgumentNullException(nameof(dataObjectRunArguments));
        }

        var vendorIdElement = dataObjectRunArguments.RequestParameterOverrides?.RootElement
            .GetProperty("vendorId");

        if (vendorIdElement == null || !Guid.TryParse(vendorIdElement.Value.GetString(), out var vendorId))
        {
            _logger.LogError("Valid vendorId (GUID) is required");
            throw new ArgumentException("Valid vendorId (GUID) is required");
        }

        var businessUnitIdElement = dataObjectRunArguments.RequestParameterOverrides?.RootElement
            .GetProperty("businessUnitId");
        
        Guid? businessUnitId = null;
        if (businessUnitIdElement != null && Guid.TryParse(businessUnitIdElement.Value.GetString(), out var buid))
        {
            businessUnitId = buid;
        }

        IEnumerable<VendorProductsDataObject>? products = null;
        try
        {
            var response = await _apiClient.GetVendorProducts(vendorId, businessUnitId, cancellationToken);
            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve vendor products. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve vendor products. API StatusCode: {response.StatusCode}");
            }
            products = response.Data;
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving vendor products");
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