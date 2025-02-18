using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Text.Json;

namespace Connector.Users.v1.Jobs;

public class JobsDataReader : TypedAsyncDataReaderBase<JobsDataObject>
{
    private readonly ILogger<JobsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public JobsDataReader(
        ILogger<JobsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<JobsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var businessUnitId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("businessUnitId", out var businessUnitElement)
            ? businessUnitElement.GetString()
            : null;

        if (string.IsNullOrEmpty(businessUnitId))
        {
            _logger.LogError("BusinessUnitId is required but was not provided");
            throw new ArgumentException("BusinessUnitId is required");
        }

        var response = await _apiClient.GetUsersJobs(Guid.Parse(businessUnitId), cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve jobs. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve jobs. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No jobs found");
            yield break;
        }

        foreach (var item in response.Data)
        {
            yield return item;
        }
    }
}