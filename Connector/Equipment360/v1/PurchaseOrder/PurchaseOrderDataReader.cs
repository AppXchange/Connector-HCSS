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

namespace Connector.Equipment360.v1.PurchaseOrder;

public class PurchaseOrderDataReader : TypedAsyncDataReaderBase<PurchaseOrderDataObject>
{
    private readonly ILogger<PurchaseOrderDataReader> _logger;
    private int _currentPage = 0;

    public PurchaseOrderDataReader(
        ILogger<PurchaseOrderDataReader> logger)
    {
        _logger = logger;
    }

    public override async IAsyncEnumerable<PurchaseOrderDataObject> GetTypedDataAsync(DataObjectCacheWriteArguments ? dataObjectRunArguments, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = new ApiResponse<PaginatedResponse<PurchaseOrderDataObject>>();
            // If the PurchaseOrderDataObject does not have the same structure as the PurchaseOrder response from the API, create a new class for it and replace PurchaseOrderDataObject with it.
            // Example:
            // var response = new ApiResponse<IEnumerable<PurchaseOrderResponse>>();

            // Make a call to your API/system to retrieve the objects/type for the connector's configuration.
            try
            {
                //response = await _apiClient.GetRecords<PurchaseOrderDataObject>(
                //    relativeUrl: "purchaseOrders",
                //    page: _currentPage,
                //    cancellationToken: cancellationToken)
                //    .ConfigureAwait(false);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while making a read request to data object 'PurchaseOrderDataObject'");
                throw;
            }

            if (!response.IsSuccessful)
            {
                throw new Exception($"Failed to retrieve records for 'PurchaseOrderDataObject'. API StatusCode: {response.StatusCode}");
            }

            if (response.Data == null || !response.Data.Items.Any()) break;

            // Return the data objects to Cache.
            foreach (var item in response.Data.Items)
            {
                // If new class was created to match the API response, create a new PurchaseOrderDataObject object, map the properties and return a PurchaseOrderDataObject.

                // Example:
                //var resource = new PurchaseOrderDataObject
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