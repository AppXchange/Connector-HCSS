using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.JobCustomCostTypeItem;

public class JobCustomCostTypeItemDataReader : TypedAsyncDataReaderBase<JobCustomCostTypeItemDataObject>
{
    private readonly ILogger<JobCustomCostTypeItemDataReader> _logger;
    private readonly ApiClient _apiClient;

    public JobCustomCostTypeItemDataReader(
        ILogger<JobCustomCostTypeItemDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<JobCustomCostTypeItemDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        // Get id from arguments
        var idElement = dataObjectRunArguments?.RequestParameterOverrides?.RootElement.GetProperty("id");
        if (idElement == null || !Guid.TryParse(idElement.Value.GetString(), out var id))
        {
            _logger.LogError("Required parameter 'id' is missing or invalid");
            throw new ArgumentException("Required parameter 'id' is missing or invalid");
        }

        var response = await _apiClient.GetJobCustomCostTypeItem(
            id: id,
            cancellationToken: cancellationToken);

        if (!response.IsSuccessful || response.Data == null)
        {
            _logger.LogError("Failed to retrieve job custom cost type item. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve job custom cost type item. API StatusCode: {response.StatusCode}");
        }

        yield return response.Data;
    }
}