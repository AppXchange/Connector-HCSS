using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;
using System.Linq;

namespace Connector.Equipment360.v1.Employee;

public class EmployeeDataReader : TypedAsyncDataReaderBase<EmployeeDataObject>
{
    private readonly ILogger<EmployeeDataReader> _logger;
    private readonly ApiClient _apiClient;

    public EmployeeDataReader(
        ILogger<EmployeeDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<EmployeeDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        ApiResponse<IEnumerable<EmployeeDataObject>> response;
        try
        {
            response = await _apiClient.GetEmployees(cancellationToken: cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve employees. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve employees. API StatusCode: {response.StatusCode}");
            }
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving employees");
            throw;
        }

        if (response.Data == null)
            yield break;

        foreach (var employee in response.Data)
        {
            yield return employee;
        }
    }
}