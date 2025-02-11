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

namespace Connector.Equipment360.v1.UnitOfMeasure;

public class UnitOfMeasureDataReader : TypedAsyncDataReaderBase<UnitOfMeasureDataObject>
{
    private readonly ILogger<UnitOfMeasureDataReader> _logger;
    private int _currentPage = 0;

    public UnitOfMeasureDataReader(
        ILogger<UnitOfMeasureDataReader> logger)
    {
        _logger = logger;
    }

    public override async IAsyncEnumerable<UnitOfMeasureDataObject> GetTypedDataAsync(DataObjectCacheWriteArguments ? dataObjectRunArguments, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = new ApiResponse<PaginatedResponse<UnitOfMeasureDataObject>>();
            // If the UnitOfMeasureDataObject does not have the same structure as the UnitOfMeasure response from the API, create a new class for it and replace UnitOfMeasureDataObject with it.
            // Example:
            // var response = new ApiResponse<IEnumerable<UnitOfMeasureResponse>>();

            // Make a call to your API/system to retrieve the objects/type for the connector's configuration.
            try
            {
                //response = await _apiClient.GetRecords<UnitOfMeasureDataObject>(
                //    relativeUrl: "unitOfMeasures",
                //    page: _currentPage,
                //    cancellationToken: cancellationToken)
                //    .ConfigureAwait(false);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while making a read request to data object 'UnitOfMeasureDataObject'");
                throw;
            }

            if (!response.IsSuccessful)
            {
                throw new Exception($"Failed to retrieve records for 'UnitOfMeasureDataObject'. API StatusCode: {response.StatusCode}");
            }

            if (response.Data == null || !response.Data.Items.Any()) break;

            // Return the data objects to Cache.
            foreach (var item in response.Data.Items)
            {
                // If new class was created to match the API response, create a new UnitOfMeasureDataObject object, map the properties and return a UnitOfMeasureDataObject.

                // Example:
                //var resource = new UnitOfMeasureDataObject
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