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

namespace Connector.Equipment360.v1.EquipmentTransfer;

public class EquipmentTransferDataReader : TypedAsyncDataReaderBase<EquipmentTransferDataObject>
{
    private readonly ILogger<EquipmentTransferDataReader> _logger;
    private int _currentPage = 0;

    public EquipmentTransferDataReader(
        ILogger<EquipmentTransferDataReader> logger)
    {
        _logger = logger;
    }

    public override async IAsyncEnumerable<EquipmentTransferDataObject> GetTypedDataAsync(DataObjectCacheWriteArguments ? dataObjectRunArguments, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = new ApiResponse<PaginatedResponse<EquipmentTransferDataObject>>();
            // If the EquipmentTransferDataObject does not have the same structure as the EquipmentTransfer response from the API, create a new class for it and replace EquipmentTransferDataObject with it.
            // Example:
            // var response = new ApiResponse<IEnumerable<EquipmentTransferResponse>>();

            // Make a call to your API/system to retrieve the objects/type for the connector's configuration.
            try
            {
                //response = await _apiClient.GetRecords<EquipmentTransferDataObject>(
                //    relativeUrl: "equipmentTransfers",
                //    page: _currentPage,
                //    cancellationToken: cancellationToken)
                //    .ConfigureAwait(false);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while making a read request to data object 'EquipmentTransferDataObject'");
                throw;
            }

            if (!response.IsSuccessful)
            {
                throw new Exception($"Failed to retrieve records for 'EquipmentTransferDataObject'. API StatusCode: {response.StatusCode}");
            }

            if (response.Data == null || !response.Data.Items.Any()) break;

            // Return the data objects to Cache.
            foreach (var item in response.Data.Items)
            {
                // If new class was created to match the API response, create a new EquipmentTransferDataObject object, map the properties and return a EquipmentTransferDataObject.

                // Example:
                //var resource = new EquipmentTransferDataObject
                //{
                //// TODO: Map properties.      
                //};
                //yield return resource;
                yield return item;
            }

            // Handle pagination per API client design
            _currentPage++;
            if (_currentPage >= response.Data.TotalPages)
            {
                break;
            }
        }
    }
}