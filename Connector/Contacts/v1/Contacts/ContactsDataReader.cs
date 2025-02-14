using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Contacts.v1.Contacts;

public class ContactsDataReader : TypedAsyncDataReaderBase<ContactsDataObject>
{
    private readonly ILogger<ContactsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public ContactsDataReader(
        ILogger<ContactsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<ContactsDataObject> GetTypedDataAsync(
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

        ApiResponse<IEnumerable<ContactsDataObject>> response;
        try
        {
            response = await _apiClient.GetContacts(vendorId, businessUnitId, cancellationToken);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving contacts");
            throw;
        }

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve contacts. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve contacts. API StatusCode: {response.StatusCode}");
        }

        if (response.Data != null)
        {
            foreach (var contact in response.Data)
            {
                yield return contact;
            }
        }
    }
}