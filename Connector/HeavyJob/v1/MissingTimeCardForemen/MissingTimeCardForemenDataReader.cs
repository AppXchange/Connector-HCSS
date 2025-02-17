using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.MissingTimeCardForemen;

public class MissingTimeCardForemenDataReader : TypedAsyncDataReaderBase<MissingTimeCardForemenDataObject>
{
    private readonly ILogger<MissingTimeCardForemenDataReader> _logger;
    private readonly ApiClient _apiClient;

    public MissingTimeCardForemenDataReader(
        ILogger<MissingTimeCardForemenDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<MissingTimeCardForemenDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (dataObjectRunArguments?.RequestParameterOverrides?.RootElement.TryGetProperty("businessUnitId", out var businessUnitIdElement) != true 
            || !businessUnitIdElement.TryGetGuid(out var businessUnitId))
        {
            throw new Exception("BusinessUnitId is required but was not provided in the arguments");
        }

        var response = await _apiClient.GetMissingTimeCardForemen(
            businessUnitId,
            DateTime.UtcNow.AddDays(-30), // Example: Look back 30 days
            DateTime.UtcNow,
            DateTime.UtcNow.Date,
            cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve missing time card foremen. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve missing time card foremen. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No missing time card foremen found");
            yield break;
        }

        foreach (var foreman in response.Data)
        {
            yield return foreman;
        }
    }
}