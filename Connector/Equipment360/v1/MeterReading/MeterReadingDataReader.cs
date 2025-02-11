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

namespace Connector.Equipment360.v1.MeterReading;

public class MeterReadingDataReader : TypedAsyncDataReaderBase<MeterReadingDataObject>
{
    private readonly ILogger<MeterReadingDataReader> _logger;
    private int _currentPage = 0;

    public MeterReadingDataReader(
        ILogger<MeterReadingDataReader> logger)
    {
        _logger = logger;
    }

    public override async IAsyncEnumerable<MeterReadingDataObject> GetTypedDataAsync(DataObjectCacheWriteArguments ? dataObjectRunArguments, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = new ApiResponse<PaginatedResponse<MeterReadingDataObject>>();
            // If the MeterReadingDataObject does not have the same structure as the MeterReading response from the API, create a new class for it and replace MeterReadingDataObject with it.
            // Example:
            // var response = new ApiResponse<IEnumerable<MeterReadingResponse>>();

            // Make a call to your API/system to retrieve the objects/type for the connector's configuration.
            try
            {
                //response = await _apiClient.GetRecords<MeterReadingDataObject>(
                //    relativeUrl: "meterReadings",
                //    page: _currentPage,
                //    cancellationToken: cancellationToken)
                //    .ConfigureAwait(false);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while making a read request to data object 'MeterReadingDataObject'");
                throw;
            }

            if (!response.IsSuccessful)
            {
                throw new Exception($"Failed to retrieve records for 'MeterReadingDataObject'. API StatusCode: {response.StatusCode}");
            }

            if (response.Data == null || !response.Data.Items.Any()) break;

            // Return the data objects to Cache.
            foreach (var item in response.Data.Items)
            {
                // If new class was created to match the API response, create a new MeterReadingDataObject object, map the properties and return a MeterReadingDataObject.

                // Example:
                //var resource = new MeterReadingDataObject
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