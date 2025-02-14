using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.ChangeOrderIncrementor;

public class ChangeOrderIncrementorDataReader : TypedAsyncDataReaderBase<ChangeOrderIncrementorDataObject>
{
    private readonly ILogger<ChangeOrderIncrementorDataReader> _logger;
    private readonly ApiClient _apiClient;

    public ChangeOrderIncrementorDataReader(
        ILogger<ChangeOrderIncrementorDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<ChangeOrderIncrementorDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments, 
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var businessUnitId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement
            .GetProperty("businessUnitId").GetString();
        if (businessUnitId == null)
        {
            throw new ArgumentException("Business Unit ID is required");
        }

        ApiResponse<IEnumerable<ChangeOrderIncrementorDataObject>> response;
        try
        {
            response = await _apiClient.GetChangeOrderIncrementor(
                Guid.Parse(businessUnitId), 
                cancellationToken);
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while making a read request to data object 'ChangeOrderIncrementorDataObject'");
            throw;
        }

        if (!response.IsSuccessful)
        {
            throw new Exception($"Failed to retrieve records for 'ChangeOrderIncrementorDataObject'. API StatusCode: {response.StatusCode}");
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