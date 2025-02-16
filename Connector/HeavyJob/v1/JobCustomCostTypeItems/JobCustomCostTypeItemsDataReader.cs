using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.JobCustomCostTypeItems;

public class JobCustomCostTypeItemsDataReader : TypedAsyncDataReaderBase<JobCustomCostTypeItemsDataObject>
{
    private readonly ILogger<JobCustomCostTypeItemsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public JobCustomCostTypeItemsDataReader(
        ILogger<JobCustomCostTypeItemsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<JobCustomCostTypeItemsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        // Get jobId from arguments
        var jobIdElement = dataObjectRunArguments?.RequestParameterOverrides?.RootElement.GetProperty("jobId");
        if (jobIdElement == null || !Guid.TryParse(jobIdElement.Value.GetString(), out var jobId))
        {
            _logger.LogError("Required parameter 'jobId' is missing or invalid");
            throw new ArgumentException("Required parameter 'jobId' is missing or invalid");
        }

        var response = await _apiClient.GetJobCustomCostTypeItems(
            jobId: jobId,
            isDeleted: null,
            isDiscontinued: null,
            cancellationToken: cancellationToken);

        if (!response.IsSuccessful || response.Data == null)
        {
            _logger.LogError("Failed to retrieve job custom cost type items. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve job custom cost type items. API StatusCode: {response.StatusCode}");
        }

        foreach (var item in response.Data)
        {
            yield return item;
        }
    }
}