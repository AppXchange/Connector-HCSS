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
using Connector.Connections;

namespace Connector.HeavyBidPreConstruction.v1.Project;

public class ProjectDataReader : TypedAsyncDataReaderBase<ProjectDataObject>
{
    private readonly ILogger<ProjectDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;
    private string? _nextPageToken;

    public ProjectDataReader(
        ILogger<ProjectDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<ProjectDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (_connectionConfig.BusinessUnitId == default)
        {
            throw new InvalidOperationException("BusinessUnitId must be configured in the connection settings");
        }

        do
        {
            var response = await _apiClient.GetProjects(_connectionConfig.BusinessUnitId, _nextPageToken, cancellationToken);

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