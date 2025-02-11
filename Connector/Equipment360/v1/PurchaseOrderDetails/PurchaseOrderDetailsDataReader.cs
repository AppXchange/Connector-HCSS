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

namespace Connector.Equipment360.v1.PurchaseOrderDetails;

public class PurchaseOrderDetailsDataReader : TypedAsyncDataReaderBase<PurchaseOrderDetailsDataObject>
{
    private readonly ILogger<PurchaseOrderDetailsDataReader> _logger;
    private int _currentPage = 0;

    public PurchaseOrderDetailsDataReader(
        ILogger<PurchaseOrderDetailsDataReader> logger)
    {
        _logger = logger;
    }

    public override async IAsyncEnumerable<PurchaseOrderDetailsDataObject> GetTypedDataAsync(DataObjectCacheWriteArguments ? dataObjectRunArguments, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = new ApiResponse<PaginatedResponse<PurchaseOrderDetailsDataObject>>();
            // If the PurchaseOrderDetailsDataObject does not have the same structure as the PurchaseOrderDetails response from the API, create a new class for it and replace PurchaseOrderDetailsDataObject with it.
            // Example:
            // var response = new ApiResponse<IEnumerable<PurchaseOrderDetailsResponse>>();

            // Make a call to your API/system to retrieve the objects/type for the connector's configuration.
            try
            {
                //response = await _apiClient.GetRecords<PurchaseOrderDetailsDataObject>(
                //    relativeUrl: "purchaseOrderDetails",
                //    page: _currentPage,
                //    cancellationToken: cancellationToken)
                //    .ConfigureAwait(false);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while making a read request to data object 'PurchaseOrderDetailsDataObject'");
                throw;
            }

            if (!response.IsSuccessful)
            {
                throw new Exception($"Failed to retrieve records for 'PurchaseOrderDetailsDataObject'. API StatusCode: {response.StatusCode}");
            }

            if (response.Data == null || !response.Data.Items.Any()) break;

            // Return the data objects to Cache.
            foreach (var item in response.Data.Items)
            {
                // If new class was created to match the API response, create a new PurchaseOrderDetailsDataObject object, map the properties and return a PurchaseOrderDetailsDataObject.

                // Example:
                //var resource = new PurchaseOrderDetailsDataObject
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