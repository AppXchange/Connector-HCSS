using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.SubcontractWorkQuantities;

public class SubcontractWorkQuantitiesDataReader : TypedAsyncDataReaderBase<SubcontractWorkQuantitiesDataObject>
{
    private readonly ILogger<SubcontractWorkQuantitiesDataReader> _logger;
    private readonly ApiClient _apiClient;

    public SubcontractWorkQuantitiesDataReader(
        ILogger<SubcontractWorkQuantitiesDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<SubcontractWorkQuantitiesDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = await _apiClient.GetSubcontractWorkQuantities(
            limit: 1000,
            cancellationToken: cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve subcontract work quantities. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve subcontract work quantities. API StatusCode: {response.StatusCode}");
        }

        if (response.Data?.Results == null)
        {
            _logger.LogWarning("No subcontract work quantities found");
            yield break;
        }

        foreach (var quantity in response.Data.Results)
        {
            yield return quantity;
        }

        while (!string.IsNullOrEmpty(response.Data.Metadata?.NextCursor))
        {
            response = await _apiClient.GetSubcontractWorkQuantities(
                limit: 1000,
                cursor: response.Data.Metadata.NextCursor,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful || response.Data?.Results == null)
                break;

            foreach (var quantity in response.Data.Results)
            {
                yield return quantity;
            }
        }
    }
}