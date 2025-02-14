using Connector.Client;
using Connector.Connections;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.Attachment;

public class AttachmentDataReader : TypedAsyncDataReaderBase<AttachmentDataObject>
{
    private readonly ILogger<AttachmentDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public AttachmentDataReader(
        ILogger<AttachmentDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<AttachmentDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (dataObjectRunArguments?.RequestParameterOverrides == null || 
            !dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("jobId", out var jobIdElement))
        {
            throw new InvalidOperationException("Job ID must be provided in request parameters");
        }

        var response = await _apiClient.GetAttachments(
            Guid.Parse(jobIdElement.GetString()!),
            cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve attachments. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve attachments. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No attachments found");
            yield break;
        }

        foreach (var item in response.Data)
        {
            yield return item;
        }
    }
}