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

namespace Connector.Equipment360.v1.CustomField;

public class CustomFieldDataReader : TypedAsyncDataReaderBase<CustomFieldDataObject>
{
    private readonly ILogger<CustomFieldDataReader> _logger;
    private readonly ApiClient _apiClient;

    public CustomFieldDataReader(
        ILogger<CustomFieldDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<CustomFieldDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        ApiResponse<IEnumerable<CustomFieldDataObject>> response;
        try
        {
            response = await _apiClient.GetCustomFields(cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve custom fields. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve custom fields. API StatusCode: {response.StatusCode}");
            }
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving custom fields");
            throw;
        }

        if (response.Data == null)
            yield break;

        foreach (var customField in response.Data)
        {
            yield return customField;
        }
    }
}