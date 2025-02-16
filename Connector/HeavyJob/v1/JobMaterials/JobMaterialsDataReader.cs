using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.JobMaterials;

public class JobMaterialsDataReader : TypedAsyncDataReaderBase<JobMaterialsDataObject>
{
    private readonly ILogger<JobMaterialsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public JobMaterialsDataReader(
        ILogger<JobMaterialsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<JobMaterialsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {

        JsonElement element;
        var jobId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement.TryGetProperty("jobId", out element) == true 
            ? element.GetString() 
            : null;
        if (string.IsNullOrEmpty(jobId))
        {
            _logger.LogError("JobId is required but was not provided in the arguments");
            yield break;
        }

        var response = await _apiClient.GetJobMaterials(
            Guid.Parse(jobId),
            cancellationToken: cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve job materials. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve job materials. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No job materials found");
            yield break;
        }

        foreach (var jobMaterial in response.Data)
        {
            yield return jobMaterial;
        }
    }
}