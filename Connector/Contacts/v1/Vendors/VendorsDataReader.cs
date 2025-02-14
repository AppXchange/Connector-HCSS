using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Contacts.v1.Vendors;

public class VendorsDataReader : TypedAsyncDataReaderBase<VendorsDataObject>
{
    private readonly ILogger<VendorsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public VendorsDataReader(
        ILogger<VendorsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<VendorsDataObject> GetTypedDataAsync(
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

        IEnumerable<VendorsDataObject>? vendors;
        try
        {
            var response = await _apiClient.GetVendors(businessUnitId, cancellationToken);
            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve vendors. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve vendors. API StatusCode: {response.StatusCode}");
            }
            vendors = response.Data;
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving vendors");
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