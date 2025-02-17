using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Text.Json;

namespace Connector.HeavyJob.v1.Vendors;

public class VendorsDataReader : TypedAsyncDataReaderBase<VendorsDataObject>
{
    private readonly ILogger<VendorsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public VendorsDataReader(
        ILogger<VendorsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<VendorsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var isDeleted = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("isDeleted", out var isDeletedElement) 
            ? (bool?)isDeletedElement.GetBoolean()
            : null;

        var modifiedSince = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("modifiedSince", out var modifiedSinceElement) 
            ? (DateTime?)modifiedSinceElement.GetDateTime()
            : null;

        var response = await _apiClient.GetVendors(
            isDeleted: isDeleted,
            modifiedSince: modifiedSince,
            cancellationToken: cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve vendors. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve vendors. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No vendors found");
            yield break;
        }

        foreach (var vendor in response.Data)
        {
            yield return vendor;
        }
    }
}