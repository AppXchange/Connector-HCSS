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

namespace Connector.Contacts.v1.ContactProducts;

public class ContactProductsDataReader : TypedAsyncDataReaderBase<ContactProductsDataObject>
{
    private readonly ILogger<ContactProductsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public ContactProductsDataReader(
        ILogger<ContactProductsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<ContactProductsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (dataObjectRunArguments == null)
        {
            _logger.LogError("DataObjectRunArguments is required");
            throw new ArgumentNullException(nameof(dataObjectRunArguments));
        }

        var contactIdElement = dataObjectRunArguments.RequestParameterOverrides?.RootElement
            .GetProperty("contactId");

        if (contactIdElement == null || !Guid.TryParse(contactIdElement.Value.GetString(), out var contactId))
        {
            _logger.LogError("Valid contactId (GUID) is required");
            throw new ArgumentException("Valid contactId (GUID) is required");
        }

        var businessUnitIdElement = dataObjectRunArguments.RequestParameterOverrides?.RootElement
            .GetProperty("businessUnitId");
        
        Guid? businessUnitId = null;
        if (businessUnitIdElement != null && Guid.TryParse(businessUnitIdElement.Value.GetString(), out var buid))
        {
            businessUnitId = buid;
        }

        ApiResponse<IEnumerable<ContactProductsDataObject>> response;
        try
        {
            response = await _apiClient.GetContactProducts(contactId, businessUnitId, cancellationToken);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving contact products");
            throw;
        }

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve contact products. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve contact products. API StatusCode: {response.StatusCode}");
        }

        if (response.Data != null)
        {
            foreach (var product in response.Data)
            {
                yield return product;
            }
        }
    }
}