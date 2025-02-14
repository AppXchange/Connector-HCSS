using Connector.Client;
using Connector.Connections;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Text.Json;

namespace Connector.HeavyBidPreConstruction.v1.Schema;

public class SchemaDataReader : TypedAsyncDataReaderBase<SchemaDataObject>
{
    private readonly ILogger<SchemaDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public SchemaDataReader(
        ILogger<SchemaDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<SchemaDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (_connectionConfig.BusinessUnitId == default)
        {
            throw new InvalidOperationException("BusinessUnitId must be configured in the connection settings");
        }
        if (dataObjectRunArguments?.RequestParameterOverrides == null || 
            !dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("id", out var idElement))
        {
            throw new InvalidOperationException("Schema ID must be provided");
        }

        var response = await _apiClient.GetSchema(
            _connectionConfig.BusinessUnitId,
            Guid.Parse(idElement.GetString()!),
            cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve schema. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve schema. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No schema found");
            yield break;
        }

        yield return response.Data;
    }
}