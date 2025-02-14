using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Equipment360.v1.EquipmentTransfer;

public class EquipmentTransferDataReader : TypedAsyncDataReaderBase<EquipmentTransferDataObject>
{
    private readonly ILogger<EquipmentTransferDataReader> _logger;
    private readonly ApiClient _apiClient;

    public EquipmentTransferDataReader(
        ILogger<EquipmentTransferDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<EquipmentTransferDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        ApiResponse<IEnumerable<EquipmentTransferDataObject>> response;
        try
        {
            response = await _apiClient.GetEquipmentTransfers(cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve equipment transfers. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve equipment transfers. API StatusCode: {response.StatusCode}");
            }
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving equipment transfers");
            throw;
        }

        if (response.Data == null)
            yield break;

        foreach (var transfer in response.Data)
        {
            yield return transfer;
        }
    }
}