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

namespace Connector.Equipment360.v1.CustomFieldList;

public class CustomFieldListDataReader : TypedAsyncDataReaderBase<CustomFieldListDataObject>
{
    private readonly ILogger<CustomFieldListDataReader> _logger;
    private readonly ApiClient _apiClient;

    public CustomFieldListDataReader(
        ILogger<CustomFieldListDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<CustomFieldListDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        ApiResponse<IEnumerable<CustomFieldListDataObject>> response;
        try
        {
            response = await _apiClient.GetCustomFieldList(cancellationToken: cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve custom field list. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve custom field list. API StatusCode: {response.StatusCode}");
            }
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving custom field list");
            throw;
        }

        if (response.Data == null)
            yield break;

        foreach (var listItem in response.Data)
        {
            yield return listItem;
        }
    }
}