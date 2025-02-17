using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.Subcontracts;

public class SubcontractsDataReader : TypedAsyncDataReaderBase<SubcontractsDataObject>
{
    private readonly ILogger<SubcontractsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public SubcontractsDataReader(
        ILogger<SubcontractsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<SubcontractsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var businessUnitId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("businessUnitId", out var businessUnitIdElement) 
            && businessUnitIdElement.TryGetGuid(out var buid)
            ? buid
            : (Guid?)null;

        if (!businessUnitId.HasValue)
        {
            _logger.LogWarning("BusinessUnitId is a required parameter");
            yield break;
        }

        var response = await _apiClient.GetSubcontracts(
            businessUnitId: businessUnitId.Value,
            cancellationToken: cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve subcontracts. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve subcontracts. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No subcontracts found");
            yield break;
        }

        foreach (var subcontract in response.Data)
        {
            yield return subcontract;
        }
    }
}