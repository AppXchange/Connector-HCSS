using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.VendorContracts;

public class VendorContractsDataReader : TypedAsyncDataReaderBase<VendorContractsDataObject>
{
    private readonly ILogger<VendorContractsDataReader> _logger;
    private readonly ApiClient _apiClient;
    private string? _cursor;

    public VendorContractsDataReader(
        ILogger<VendorContractsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<VendorContractsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var jobId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("jobId", out var jobIdElement) 
            && jobIdElement.TryGetGuid(out var jid)
            ? jid
            : (Guid?)null;

        var businessUnitId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("businessUnitId", out var businessUnitIdElement) 
            && businessUnitIdElement.TryGetGuid(out var buid)
            ? buid
            : (Guid?)null;

        var vendorContractId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("vendorContractId", out var vendorContractIdElement) 
            && vendorContractIdElement.TryGetGuid(out var vcid)
            ? vcid
            : (Guid?)null;

        while (true)
        {
            var response = await _apiClient.GetVendorContracts(
                jobId: jobId,
                businessUnitId: businessUnitId,
                vendorContractId: vendorContractId,
                cursor: _cursor,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve vendor contracts. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve vendor contracts. API StatusCode: {response.StatusCode}");
            }

            if (response.Data?.Results == null || response.Data.Results.Length == 0)
            {
                break;
            }

            foreach (var item in response.Data.Results)
            {
                yield return item;
            }

            _cursor = response.Data.Metadata.NextCursor;
            if (string.IsNullOrEmpty(_cursor))
            {
                break;
            }
        }
    }
}