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

namespace Connector.HeavyBidEstimate.v1.Biditems;

public class BiditemsDataReader : TypedAsyncDataReaderBase<BiditemsDataObject>
{
    private readonly ILogger<BiditemsDataReader> _logger;
    private int _currentPage = 0;

    public BiditemsDataReader(
        ILogger<BiditemsDataReader> logger)
    {
        _logger = logger;
    }

    public override async IAsyncEnumerable<BiditemsDataObject> GetTypedDataAsync(DataObjectCacheWriteArguments ? dataObjectRunArguments, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = new ApiResponse<PaginatedResponse<BiditemsDataObject>>();
            // If the BiditemsDataObject does not have the same structure as the Biditems response from the API, create a new class for it and replace BiditemsDataObject with it.
            // Example:
            // var response = new ApiResponse<IEnumerable<BiditemsResponse>>();

            // Make a call to your API/system to retrieve the objects/type for the connector's configuration.
            try
            {
                //response = await _apiClient.GetRecords<BiditemsDataObject>(
                //    relativeUrl: "biditems",
                //    page: _currentPage,
                //    cancellationToken: cancellationToken)
                //    .ConfigureAwait(false);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while making a read request to data object 'BiditemsDataObject'");
                throw;
            }

            if (!response.IsSuccessful)
            {
                throw new Exception($"Failed to retrieve records for 'BiditemsDataObject'. API StatusCode: {response.StatusCode}");
            }

            if (response.Data == null || !response.Data.Items.Any()) break;

            // Return the data objects to Cache.
            foreach (var item in response.Data.Items)
            {
                // If new class was created to match the API response, create a new BiditemsDataObject object, map the properties and return a BiditemsDataObject.

                // Example:
                //var resource = new BiditemsDataObject
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