using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.NonuseHourTags;

public class NonuseHourTagsDataReader : TypedAsyncDataReaderBase<NonuseHourTagsDataObject>
{
    private readonly ILogger<NonuseHourTagsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public NonuseHourTagsDataReader(
        ILogger<NonuseHourTagsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<NonuseHourTagsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (dataObjectRunArguments?.RequestParameterOverrides?.RootElement.TryGetProperty("businessUnitId", out var businessUnitIdElement) != true 
            || !businessUnitIdElement.TryGetGuid(out var businessUnitId))
        {
            throw new Exception("BusinessUnitId is required but was not provided in the arguments");
        }

        var response = await _apiClient.GetNonuseHourTags(
            businessUnitId,
            cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve nonuse hour tags. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve nonuse hour tags. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No nonuse hour tags found");
            yield break;
        }

        foreach (var tag in response.Data)
        {
            yield return tag;
        }
    }
}