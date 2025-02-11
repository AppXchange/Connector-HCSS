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

namespace Connector.HeavyJob.v1.VendorContractItems;

public class VendorContractItemsDataReader : TypedAsyncDataReaderBase<VendorContractItemsDataObject>
{
    private readonly ILogger<VendorContractItemsDataReader> _logger;
    private int _currentPage = 0;

    public VendorContractItemsDataReader(
        ILogger<VendorContractItemsDataReader> logger)
    {
        _logger = logger;
    }

    public override async IAsyncEnumerable<VendorContractItemsDataObject> GetTypedDataAsync(DataObjectCacheWriteArguments ? dataObjectRunArguments, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = new ApiResponse<PaginatedResponse<VendorContractItemsDataObject>>();
            // If the VendorContractItemsDataObject does not have the same structure as the VendorContractItems response from the API, create a new class for it and replace VendorContractItemsDataObject with it.
            // Example:
            // var response = new ApiResponse<IEnumerable<VendorContractItemsResponse>>();

            // Make a call to your API/system to retrieve the objects/type for the connector's configuration.
            try
            {
                //response = await _apiClient.GetRecords<VendorContractItemsDataObject>(
                //    relativeUrl: "vendorContractItems",
                //    page: _currentPage,
                //    cancellationToken: cancellationToken)
                //    .ConfigureAwait(false);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while making a read request to data object 'VendorContractItemsDataObject'");
                throw;
            }

            if (!response.IsSuccessful)
            {
                throw new Exception($"Failed to retrieve records for 'VendorContractItemsDataObject'. API StatusCode: {response.StatusCode}");
            }

            if (response.Data == null || !response.Data.Items.Any()) break;

            // Return the data objects to Cache.
            foreach (var item in response.Data.Items)
            {
                // If new class was created to match the API response, create a new VendorContractItemsDataObject object, map the properties and return a VendorContractItemsDataObject.

                // Example:
                //var resource = new VendorContractItemsDataObject
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