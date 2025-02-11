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

namespace Connector.HeavyJob.v1.Attachment;

public class AttachmentDataReader : TypedAsyncDataReaderBase<AttachmentDataObject>
{
    private readonly ILogger<AttachmentDataReader> _logger;
    private int _currentPage = 0;

    public AttachmentDataReader(
        ILogger<AttachmentDataReader> logger)
    {
        _logger = logger;
    }

    public override async IAsyncEnumerable<AttachmentDataObject> GetTypedDataAsync(DataObjectCacheWriteArguments ? dataObjectRunArguments, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var response = new ApiResponse<PaginatedResponse<AttachmentDataObject>>();
            // If the AttachmentDataObject does not have the same structure as the Attachment response from the API, create a new class for it and replace AttachmentDataObject with it.
            // Example:
            // var response = new ApiResponse<IEnumerable<AttachmentResponse>>();

            // Make a call to your API/system to retrieve the objects/type for the connector's configuration.
            try
            {
                //response = await _apiClient.GetRecords<AttachmentDataObject>(
                //    relativeUrl: "attachments",
                //    page: _currentPage,
                //    cancellationToken: cancellationToken)
                //    .ConfigureAwait(false);
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception, "Exception while making a read request to data object 'AttachmentDataObject'");
                throw;
            }

            if (!response.IsSuccessful)
            {
                throw new Exception($"Failed to retrieve records for 'AttachmentDataObject'. API StatusCode: {response.StatusCode}");
            }

            if (response.Data == null || !response.Data.Items.Any()) break;

            // Return the data objects to Cache.
            foreach (var item in response.Data.Items)
            {
                // If new class was created to match the API response, create a new AttachmentDataObject object, map the properties and return a AttachmentDataObject.

                // Example:
                //var resource = new AttachmentDataObject
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