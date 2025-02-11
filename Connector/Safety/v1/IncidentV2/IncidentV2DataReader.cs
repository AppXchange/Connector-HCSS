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

namespace Connector.Safety.v1.IncidentV2;

public class IncidentV2DataReader : TypedAsyncDataReaderBase<IncidentV2DataObject>
{
    private readonly ILogger<IncidentV2DataReader> _logger;
    private int _currentPage = 0;

    public IncidentV2DataReader(
        ILogger<IncidentV2DataReader> logger)
    {
        _logger = logger;
    }

    public override async IAsyncEnumerable<IncidentV2DataObject> GetTypedDataAsync(DataObjectCacheWriteArguments ? dataObjectRunArguments, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = new ApiResponse<PaginatedResponse<IncidentV2DataObject>>();
            // If the IncidentV2DataObject does not have the same structure as the IncidentV2 response from the API, create a new class for it and replace IncidentV2DataObject with it.
            // Example:
            // var response = new ApiResponse<IEnumerable<IncidentV2Response>>();

            // Make a call to your API/system to retrieve the objects/type for the connector's configuration.
            try
            {
                //response = await _apiClient.GetRecords<IncidentV2DataObject>(
                //    relativeUrl: "incidentV2s",
                //    page: _currentPage,
                //    cancellationToken: cancellationToken)
                //    .ConfigureAwait(false);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while making a read request to data object 'IncidentV2DataObject'");
                throw;
            }

            if (!response.IsSuccessful)
            {
                throw new Exception($"Failed to retrieve records for 'IncidentV2DataObject'. API StatusCode: {response.StatusCode}");
            }

            if (response.Data == null || !response.Data.Items.Any()) break;

            // Return the data objects to Cache.
            foreach (var item in response.Data.Items)
            {
                // If new class was created to match the API response, create a new IncidentV2DataObject object, map the properties and return a IncidentV2DataObject.

                // Example:
                //var resource = new IncidentV2DataObject
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