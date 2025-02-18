using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Text.Json;

namespace Connector.Skills.v1.EmployeeSkillsBySkill;

public class EmployeeSkillsBySkillDataReader : TypedAsyncDataReaderBase<EmployeeSkillsBySkillDataObject>
{
    private readonly ILogger<EmployeeSkillsBySkillDataReader> _logger;
    private readonly ApiClient _apiClient;

    public EmployeeSkillsBySkillDataReader(
        ILogger<EmployeeSkillsBySkillDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<EmployeeSkillsBySkillDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var courseCodeOrName = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("courseCodeOrName", out var courseElement)
            ? courseElement.GetString()
            : null;

        var dateAfterUtc = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("dateAfterUtc", out var dateElement)
            ? (DateTime?)dateElement.GetDateTime()
            : null;

        var limit = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("limit", out var limitElement)
            ? limitElement.GetInt32()
            : 1000;

        var offset = 0;
        bool hasMorePages;

        if (string.IsNullOrEmpty(courseCodeOrName))
        {
            _logger.LogError("CourseCodeOrName is required but was not provided");
            throw new ArgumentException("CourseCodeOrName is required");
        }

        do
        {
            var response = await _apiClient.GetEmployeeSkillsBySkill(
                courseCodeOrName,
                dateAfterUtc,
                limit,
                offset,
                usePayrollCode: false,
                cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve employee skills. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve employee skills. API StatusCode: {response.StatusCode}");
            }

            if (response.Data == null)
            {
                _logger.LogWarning("No employee skills found");
                yield break;
            }

            foreach (var item in response.Data)
            {
                yield return item;
            }

            hasMorePages = response.IsSuccessful && response.StatusCode == 200;
            offset += limit;

        } while (hasMorePages);
    }
}