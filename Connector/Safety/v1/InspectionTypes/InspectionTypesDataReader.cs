using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.Safety.v1.InspectionTypes;

public class InspectionTypesDataReader : TypedAsyncDataReaderBase<InspectionTypesDataObject>
{
    private readonly ILogger<InspectionTypesDataReader> _logger;
    private readonly ApiClient _apiClient;
    private string? _nextCursor;

    public InspectionTypesDataReader(
        ILogger<InspectionTypesDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<InspectionTypesDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        do
        {
            var response = await _apiClient.GetInspectionTypes(
                limit: 1000,
                cursor: _nextCursor,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful || response.Data == null)
            {
                _logger.LogError("Failed to retrieve inspection types. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve inspection types. API StatusCode: {response.StatusCode}");
            }

            foreach (var inspectionType in response.Data.Results)
            {
                yield return inspectionType;
            }

            _nextCursor = response.Data.Metadata?.NextCursor;

        } while (!string.IsNullOrEmpty(_nextCursor));
    }
}