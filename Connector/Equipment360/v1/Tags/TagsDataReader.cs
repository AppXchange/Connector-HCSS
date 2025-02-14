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

namespace Connector.Equipment360.v1.Tags;

public class TagsDataReader : TypedAsyncDataReaderBase<TagsDataObject>
{
    private readonly ILogger<TagsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public TagsDataReader(
        ILogger<TagsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<TagsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        ApiResponse<IEnumerable<TagsDataObject>> response;
        try
        {
            response = await _apiClient.GetTags(cancellationToken);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving tags");
            throw;
        }

        if (!response.IsSuccessful || response.Data == null)
        {
            _logger.LogError("Failed to retrieve tags. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve tags. API StatusCode: {response.StatusCode}");
        }

        foreach (var tag in response.Data)
        {
            yield return tag;
        }
    }
}