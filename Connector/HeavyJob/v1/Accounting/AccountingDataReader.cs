using Connector.Client;
using Connector.Connections;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.Accounting;

public class AccountingDataReader : TypedAsyncDataReaderBase<AccountingDataObject>
{
    private readonly ILogger<AccountingDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;
    private readonly int _limit = 100;

    public AccountingDataReader(
        ILogger<AccountingDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<AccountingDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (_connectionConfig.BusinessUnitId == default)
        {
            throw new InvalidOperationException("BusinessUnitId must be configured in the connection settings");
        }

        string? cursor = null;
        do
        {
            var response = await _apiClient.SearchAccountingValues(
                _connectionConfig.BusinessUnitId,
                entityIds: null,
                cursor,
                _limit,
                entityType: AccountingEntityType.Unknown,
                cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve accounting values. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve accounting values. API StatusCode: {response.StatusCode}");
            }

            if (response.Data?.Results == null)
            {
                _logger.LogWarning("No accounting values found");
                yield break;
            }

            foreach (var value in response.Data.Results)
            {
                yield return value;
            }

            cursor = response.Data.Metadata?.NextCursor;

        } while (!string.IsNullOrEmpty(cursor));
    }
}