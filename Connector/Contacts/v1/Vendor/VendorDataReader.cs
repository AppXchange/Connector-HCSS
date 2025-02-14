using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Contacts.v1.Vendor;

public class VendorDataReader : TypedAsyncDataReaderBase<VendorDataObject>
{
    private readonly ILogger<VendorDataReader> _logger;
    private readonly ApiClient _apiClient;

    public VendorDataReader(
        ILogger<VendorDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<VendorDataObject> GetTypedDataAsync(
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

        VendorDataObject? vendor = null;
        try
        {
            var response = await _apiClient.GetVendor(vendorId, businessUnitId, cancellationToken);
            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve vendor. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve vendor. API StatusCode: {response.StatusCode}");
            }
            vendor = response.Data;
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving vendor");
            throw;
        }

        if (vendor != null)
        {
            yield return vendor;
        }
    }
}