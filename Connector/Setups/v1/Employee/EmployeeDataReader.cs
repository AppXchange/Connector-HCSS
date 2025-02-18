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
using System.Text.Json;

namespace Connector.Setups.v1.Employee;

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
        var businessUnitCode = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("businessUnitCode", out var businessUnitElement)
            ? businessUnitElement.GetString()
            : null;

        var accountingTemplateName = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("accountingTemplateName", out var templateElement)
            ? templateElement.GetString()
            : null;

        var includeDeleted = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("includeDeleted", out var deletedElement)
            ? deletedElement.GetBoolean()
            : false;

        if (string.IsNullOrEmpty(businessUnitCode))
        {
            _logger.LogError("BusinessUnitCode is required but was not provided");
            throw new ArgumentException("BusinessUnitCode is required");
        }

        var response = await _apiClient.GetSetupsEmployees(businessUnitCode, accountingTemplateName, includeDeleted, cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve employees. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve employees. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No employees found");
            yield break;
        }

        foreach (var employee in response.Data)
        {
            yield return employee;
        }
    }
}