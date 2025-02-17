using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.SubcontractTransactions;

public class SubcontractTransactionsDataReader : TypedAsyncDataReaderBase<SubcontractTransactionsDataObject>
{
    private readonly ILogger<SubcontractTransactionsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public SubcontractTransactionsDataReader(
        ILogger<SubcontractTransactionsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<SubcontractTransactionsDataObject> GetTypedDataAsync(
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

        var response = await _apiClient.GetSubcontractTransactions(
            businessUnitId: businessUnitId.Value,
            limit: 1000,
            cancellationToken: cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve subcontract transactions. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve subcontract transactions. API StatusCode: {response.StatusCode}");
        }

        if (response.Data?.Results == null)
        {
            _logger.LogWarning("No subcontract transactions found");
            yield break;
        }

        foreach (var transaction in response.Data.Results)
        {
            yield return transaction;
        }

        while (!string.IsNullOrEmpty(response.Data.Metadata?.NextCursor))
        {
            response = await _apiClient.GetSubcontractTransactions(
                businessUnitId: businessUnitId.Value,
                limit: 1000,
                cursor: response.Data.Metadata.NextCursor,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful || response.Data?.Results == null)
                break;

            foreach (var transaction in response.Data.Results)
            {
                yield return transaction;
            }
        }
    }
}