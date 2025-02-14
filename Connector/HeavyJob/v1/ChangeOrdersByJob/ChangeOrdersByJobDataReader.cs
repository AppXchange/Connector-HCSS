using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.ChangeOrdersByJob;

public class ChangeOrdersByJobDataReader : TypedAsyncDataReaderBase<ChangeOrdersByJobDataObject>
{
    private readonly ILogger<ChangeOrdersByJobDataReader> _logger;
    private readonly ApiClient _apiClient;

    public ChangeOrdersByJobDataReader(
        ILogger<ChangeOrdersByJobDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<ChangeOrdersByJobDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments, 
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var jobId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement
            .GetProperty("jobId").GetString();
        if (jobId == null)
        {
            throw new ArgumentException("Job ID is required");
        }

        ApiResponse<IEnumerable<ChangeOrdersByJobDataObject>> response;
        try
        {
            response = await _apiClient.GetChangeOrdersByJob(
                Guid.Parse(jobId), 
                cancellationToken);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while making a read request to data object 'ChangeOrdersByJobDataObject'");
            throw;
        }

        if (!response.IsSuccessful)
        {
            throw new Exception($"Failed to retrieve records for 'ChangeOrdersByJobDataObject'. API StatusCode: {response.StatusCode}");
        }

        if (response.Data != null)
        {
            foreach (var item in response.Data)
            {
                yield return item;
            }
        }
    }
}