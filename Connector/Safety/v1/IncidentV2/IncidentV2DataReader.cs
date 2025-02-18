using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.Safety.v1.IncidentV2;

public class IncidentV2DataReader : TypedAsyncDataReaderBase<IncidentV2DataObject>
{
    private readonly ILogger<IncidentV2DataReader> _logger;
    private readonly ApiClient _apiClient;

    public IncidentV2DataReader(
        ILogger<IncidentV2DataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<IncidentV2DataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = await _apiClient.GetIncidentV2(
            Guid.Parse(dataObjectRunArguments?.RequestParameterOverrides?.RootElement.GetProperty("id").GetString() 
                ?? throw new ArgumentException("Incident ID is required")),
            excludeForms: false,
            cancellationToken: cancellationToken);

        if (!response.IsSuccessful || response.Data == null)
        {
            _logger.LogError("Failed to retrieve incident. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve incident. API StatusCode: {response.StatusCode}");
        }

        yield return response.Data;
    }
}