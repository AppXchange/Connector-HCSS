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

namespace Connector.Skills.v1.Skill;

public class SkillDataReader : TypedAsyncDataReaderBase<SkillDataObject>
{
    private readonly ILogger<SkillDataReader> _logger;
    private readonly ApiClient _apiClient;

    public SkillDataReader(
        ILogger<SkillDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<SkillDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var courseCodeOrName = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("courseCodeOrName", out var courseElement)
            ? courseElement.GetString()
            : null;

        if (string.IsNullOrEmpty(courseCodeOrName))
        {
            _logger.LogError("CourseCodeOrName is required but was not provided");
            throw new ArgumentException("CourseCodeOrName is required");
        }

        var response = await _apiClient.GetSkill(courseCodeOrName, cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve skill. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve skill. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No skill found");
            yield break;
        }

        yield return response.Data;
    }
}