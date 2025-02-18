using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Setups.v1.BusinessUnitDefault;

public class BusinessUnitDefaultDataReader : TypedAsyncDataReaderBase<BusinessUnitDefaultDataObject>
{
    private readonly ILogger<BusinessUnitDefaultDataReader> _logger;
    private readonly ApiClient _apiClient;

    public BusinessUnitDefaultDataReader(
        ILogger<BusinessUnitDefaultDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<BusinessUnitDefaultDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = await _apiClient.GetSetupsDefaultBusinessUnit(cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve default business unit. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve default business unit. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No default business unit found");
            yield break;
        }

        yield return response.Data;
    }
}