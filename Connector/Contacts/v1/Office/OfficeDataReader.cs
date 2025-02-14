using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Contacts.v1.Office;

public class OfficeDataReader : TypedAsyncDataReaderBase<OfficeDataObject>
{
    private readonly ILogger<OfficeDataReader> _logger;
    private readonly ApiClient _apiClient;

    public OfficeDataReader(
        ILogger<OfficeDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<OfficeDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (dataObjectRunArguments == null)
        {
            _logger.LogError("DataObjectRunArguments is required");
            throw new ArgumentNullException(nameof(dataObjectRunArguments));
        }

        var officeIdElement = dataObjectRunArguments.RequestParameterOverrides?.RootElement
            .GetProperty("officeId");

        if (officeIdElement == null || !Guid.TryParse(officeIdElement.Value.GetString(), out var officeId))
        {
            _logger.LogError("Valid officeId (GUID) is required");
            throw new ArgumentException("Valid officeId (GUID) is required");
        }

        var businessUnitIdElement = dataObjectRunArguments.RequestParameterOverrides?.RootElement
            .GetProperty("businessUnitId");
        
        Guid? businessUnitId = null;
        if (businessUnitIdElement != null && Guid.TryParse(businessUnitIdElement.Value.GetString(), out var buid))
        {
            businessUnitId = buid;
        }

        OfficeDataObject? office = null;
        try
        {
            var response = await _apiClient.GetOffice(officeId, businessUnitId, cancellationToken);
            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve office. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve office. API StatusCode: {response.StatusCode}");
            }
            office = response.Data;
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving office");
            throw;
        }

        if (office != null)
        {
            yield return office;
        }
    }
}