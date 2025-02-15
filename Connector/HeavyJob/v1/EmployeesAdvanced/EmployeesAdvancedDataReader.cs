using Connector.Client;
using Connector.Connections;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.HeavyJob.v1.EmployeesAdvanced;

public class EmployeesAdvancedDataReader : TypedAsyncDataReaderBase<EmployeesAdvancedDataObject>
{
    private readonly ILogger<EmployeesAdvancedDataReader> _logger;
    private readonly ApiClient _apiClient;
    private readonly ConnectionConfig _connectionConfig;

    public EmployeesAdvancedDataReader(
        ILogger<EmployeesAdvancedDataReader> logger,
        ApiClient apiClient,
        ConnectionConfig connectionConfig)
    {
        _logger = logger;
        _apiClient = apiClient;
        _connectionConfig = connectionConfig;
    }

    public override async IAsyncEnumerable<EmployeesAdvancedDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        string? cursor = null;

        while (true)
        {
            var response = await _apiClient.GetEmployeesAdvanced(
                _connectionConfig.BusinessUnitId,
                null, // employeeCodes
                null, // employeeIds
                null, // accountingTemplateName
                null, // isActive
                null, // isForeman
                null, // includeHistoricalForeman
                null, // isDeleted
                cursor,
                1000, // limit
                cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve employees. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve employees. API StatusCode: {response.StatusCode}");
            }

            if (response.Data?.Results == null)
            {
                _logger.LogWarning("No employees found");
                yield break;
            }

            foreach (var employee in response.Data.Results)
            {
                yield return employee;
            }

            if (string.IsNullOrEmpty(response.Data.Metadata.NextCursor))
            {
                break;
            }

            cursor = response.Data.Metadata.NextCursor;
        }
    }
}