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

namespace Connector.HeavyJob.v1.MaterialsInstalled;

public class MaterialsInstalledDataReader : TypedAsyncDataReaderBase<MaterialsInstalledDataObject>
{
    private readonly ILogger<MaterialsInstalledDataReader> _logger;
    private int _currentPage = 0;

    public MaterialsInstalledDataReader(
        ILogger<MaterialsInstalledDataReader> logger)
    {
        _logger = logger;
    }

    public override async IAsyncEnumerable<MaterialsInstalledDataObject> GetTypedDataAsync(DataObjectCacheWriteArguments ? dataObjectRunArguments, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = new ApiResponse<PaginatedResponse<MaterialsInstalledDataObject>>();
            // If the MaterialsInstalledDataObject does not have the same structure as the MaterialsInstalled response from the API, create a new class for it and replace MaterialsInstalledDataObject with it.
            // Example:
            // var response = new ApiResponse<IEnumerable<MaterialsInstalledResponse>>();

            // Make a call to your API/system to retrieve the objects/type for the connector's configuration.
            try
            {
                //response = await _apiClient.GetRecords<MaterialsInstalledDataObject>(
                //    relativeUrl: "materialsInstalleds",
                //    page: _currentPage,
                //    cancellationToken: cancellationToken)
                //    .ConfigureAwait(false);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while making a read request to data object 'MaterialsInstalledDataObject'");
                throw;
            }

            if (!response.IsSuccessful)
            {
                throw new Exception($"Failed to retrieve records for 'MaterialsInstalledDataObject'. API StatusCode: {response.StatusCode}");
            }

            if (response.Data == null || !response.Data.Items.Any()) break;

            // Return the data objects to Cache.
            foreach (var item in response.Data.Items)
            {
                // If new class was created to match the API response, create a new MaterialsInstalledDataObject object, map the properties and return a MaterialsInstalledDataObject.

                // Example:
                //var resource = new MaterialsInstalledDataObject
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