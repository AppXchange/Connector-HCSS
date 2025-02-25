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

namespace Connector.Setups.v1.BusinessUnit;

public class BusinessUnitDataReader : TypedAsyncDataReaderBase<BusinessUnitDataObject>
{
    private readonly ILogger<BusinessUnitDataReader> _logger;
    private readonly ApiClient _apiClient;

    public BusinessUnitDataReader(
        ILogger<BusinessUnitDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<BusinessUnitDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var response = await _apiClient.GetSetupsBusinessUnits(cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve business units. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve business units. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No business units found");
            yield break;
        }

        foreach (var businessUnit in response.Data)
        {
            yield return businessUnit;
        }
    }
}