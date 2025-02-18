using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Text.Json;

namespace Connector.Skills.v1.Skills;

public class SkillsDataReader : TypedAsyncDataReaderBase<SkillsDataObject>
{
    private readonly ILogger<SkillsDataReader> _logger;
    private readonly ApiClient _apiClient;

    public SkillsDataReader(
        ILogger<SkillsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<SkillsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
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

        do
        {
            var response = await _apiClient.GetSkills(
                dateAfterUtc,
                limit,
                offset,
                cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve skills. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve skills. API StatusCode: {response.StatusCode}");
            }

            if (response.Data == null)
            {
                _logger.LogWarning("No skills found");
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