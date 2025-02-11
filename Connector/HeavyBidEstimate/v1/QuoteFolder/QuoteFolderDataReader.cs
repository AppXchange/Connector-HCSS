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

namespace Connector.HeavyBidEstimate.v1.QuoteFolder;

public class QuoteFolderDataReader : TypedAsyncDataReaderBase<QuoteFolderDataObject>
{
    private readonly ILogger<QuoteFolderDataReader> _logger;
    private int _currentPage = 0;

    public QuoteFolderDataReader(
        ILogger<QuoteFolderDataReader> logger)
    {
        _logger = logger;
    }

    public override async IAsyncEnumerable<QuoteFolderDataObject> GetTypedDataAsync(DataObjectCacheWriteArguments ? dataObjectRunArguments, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = new ApiResponse<PaginatedResponse<QuoteFolderDataObject>>();
            // If the QuoteFolderDataObject does not have the same structure as the QuoteFolder response from the API, create a new class for it and replace QuoteFolderDataObject with it.
            // Example:
            // var response = new ApiResponse<IEnumerable<QuoteFolderResponse>>();

            // Make a call to your API/system to retrieve the objects/type for the connector's configuration.
            try
            {
                //response = await _apiClient.GetRecords<QuoteFolderDataObject>(
                //    relativeUrl: "quoteFolders",
                //    page: _currentPage,
                //    cancellationToken: cancellationToken)
                //    .ConfigureAwait(false);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while making a read request to data object 'QuoteFolderDataObject'");
                throw;
            }

            if (!response.IsSuccessful)
            {
                throw new Exception($"Failed to retrieve records for 'QuoteFolderDataObject'. API StatusCode: {response.StatusCode}");
            }

            if (response.Data == null || !response.Data.Items.Any()) break;

            // Return the data objects to Cache.
            foreach (var item in response.Data.Items)
            {
                // If new class was created to match the API response, create a new QuoteFolderDataObject object, map the properties and return a QuoteFolderDataObject.

                // Example:
                //var resource = new QuoteFolderDataObject
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