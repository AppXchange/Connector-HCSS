using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;
using Namotion.Reflection;

namespace Connector.Contacts.v1.Contact;

public class ContactDataReader : TypedAsyncDataReaderBase<ContactDataObject>
{
    private readonly ILogger<ContactDataReader> _logger;
    private readonly ApiClient _apiClient;

    public ContactDataReader(
        ILogger<ContactDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<ContactDataObject> GetTypedDataAsync(
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

        // Get BusinessUnitId if provided
        var businessUnitIdElement = dataObjectRunArguments.RequestParameterOverrides?.RootElement
            .GetProperty("businessUnitId");
        
        Guid? businessUnitId = null;
        if (businessUnitIdElement != null && Guid.TryParse(businessUnitIdElement.Value.GetString(), out var buid))
        {
            businessUnitId = buid;
        }

        var response = await _apiClient.GetContact(contactId, businessUnitId, cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve contact. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve contact. API StatusCode: {response.StatusCode}");
        }

        if (response.Data != null)
        {
            yield return response.Data;
        }
    }
}