using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;
using static Connector.Client.ApiClient;
using Xchange.Connector.SDK.Client.ConnectivityApi.Models;

namespace Connector.HeavyBidEstimate.v1.DownloadEstimateAttachment;

public class DownloadEstimateAttachmentDataReader : TypedAsyncDataReaderBase<DownloadEstimateAttachmentDataObject>
{
    private readonly ILogger<DownloadEstimateAttachmentDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;
    private int _skipValue = 0;
    private readonly int _topValue = 100;

    public DownloadEstimateAttachmentDataReader(
        ILogger<DownloadEstimateAttachmentDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<DownloadEstimateAttachmentDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (_connectionConfig.BusinessUnitId == default)
        {
            throw new InvalidOperationException("BusinessUnitId must be configured in the connection settings");
        }
        var requestParams = dataObjectRunArguments?.RequestParameterOverrides;
        string? estimateIdStr, attachmentIdStr;
        if (requestParams == null ||
            !requestParams.RootElement.TryGetProperty("estimateId", out var estimateIdElement) ||
            string.IsNullOrEmpty(estimateIdStr = estimateIdElement.GetString()) ||
            !Guid.TryParse(estimateIdStr, out var estimateId) ||
            !requestParams.RootElement.TryGetProperty("attachmentId", out var attachmentIdElement) ||
            string.IsNullOrEmpty(attachmentIdStr = attachmentIdElement.GetString()) ||
            !Guid.TryParse(attachmentIdStr, out var attachmentId))
        {
            throw new InvalidOperationException("estimateId and attachmentId arguments are required");
        }

        var response = await _apiClient.DownloadEstimateAttachment(
            businessUnitId: _connectionConfig.BusinessUnitId,
            estimateId: estimateId,
            attachmentId: attachmentId,
            cancellationToken: cancellationToken);

        if (!response.IsSuccessful || response.Data == null)
        {
            _logger.LogError("Failed to download estimate attachment. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to download estimate attachment. API StatusCode: {response.StatusCode}");
        }

        yield return new DownloadEstimateAttachmentDataObject
        {
            Id = attachmentId,
            BusinessUnitId = _connectionConfig.BusinessUnitId,
            EstimateId = estimateId,
            FileContent = response.Data
        };
    }
}