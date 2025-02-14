using Connector.Client;
using Connector.Connections;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyBidPreConstruction.v1.Projects;

public class ProjectsDataReader : TypedAsyncDataReaderBase<ProjectsDataObject>
{
    private readonly ILogger<ProjectsDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;
    private string? _nextPageToken;
    private readonly int _top = 100;

    public ProjectsDataReader(
        ILogger<ProjectsDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<ProjectsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (_connectionConfig.BusinessUnitId == default)
        {
            throw new InvalidOperationException("BusinessUnitId must be configured in the connection settings");
        }

        do
        {
            var response = await _apiClient.GetProjectsList(
                _connectionConfig.BusinessUnitId,
                _nextPageToken,
                _top,
                includeDynamicFields: true,
                includeArchived: false,
                cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve projects. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve projects. API StatusCode: {response.StatusCode}");
            }

            if (response.Data?.Results == null)
            {
                _logger.LogWarning("No projects found");
                yield break;
            }

            foreach (var project in response.Data.Results)
            {
                yield return project;
            }

            _nextPageToken = response.Data.NextPageToken;

        } while (!string.IsNullOrEmpty(_nextPageToken));
    }
}