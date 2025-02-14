using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using Namotion.Reflection;
using System.Text.Json;

namespace Connector.Attachments.v1.File;

public class FileDataReader : TypedAsyncDataReaderBase<FileDataObject>
{
    private readonly ILogger<FileDataReader> _logger;
    private readonly ApiClient _apiClient;

    public FileDataReader(
        ILogger<FileDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<FileDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments, 
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (dataObjectRunArguments == null)
        {
            _logger.LogError("DataObjectRunArguments is required");
            throw new ArgumentNullException(nameof(dataObjectRunArguments));
        }

        var fileIdElement = dataObjectRunArguments.RequestParameterOverrides?.RootElement
            .GetProperty("fileId");

        if (fileIdElement == null || !Guid.TryParse(fileIdElement.Value.GetString(), out var fileId))
        {
            _logger.LogError("Valid fileId (GUID) is required for fetching file metadata");
            throw new ArgumentException("Valid fileId (GUID) is required for fetching file metadata");
        }

        var response = await _apiClient.GetFileMetadata(fileId, cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve file metadata. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve file metadata. API StatusCode: {response.StatusCode}");
        }

        if (response.Data != null)
        {
            yield return response.Data;
        }
    }
}