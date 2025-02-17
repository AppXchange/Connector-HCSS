using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.VendorContractDetails;

public class VendorContractDetailsDataReader : TypedAsyncDataReaderBase<VendorContractDetailsDataObject>
{
    private readonly ILogger<VendorContractDetailsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public VendorContractDetailsDataReader(
        ILogger<VendorContractDetailsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<VendorContractDetailsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var vendorContractId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("vendorContractId", out var vendorContractIdElement) 
            && vendorContractIdElement.TryGetGuid(out var vcid)
            ? vcid
            : (Guid?)null;

        if (!vendorContractId.HasValue)
        {
            _logger.LogWarning("VendorContractId is a required parameter");
            yield break;
        }

        var response = await _apiClient.GetVendorContractDetails(
            vendorContractId: vendorContractId.Value,
            cancellationToken: cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve vendor contract details. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve vendor contract details. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No vendor contract details found");
            yield break;
        }

        foreach (var detail in response.Data)
        {
            yield return detail;
        }
    }
}