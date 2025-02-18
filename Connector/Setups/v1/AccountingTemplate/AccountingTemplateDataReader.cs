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

namespace Connector.Setups.v1.AccountingTemplate;

public class AccountingTemplateDataReader : TypedAsyncDataReaderBase<AccountingTemplateDataObject>
{
    private readonly ILogger<AccountingTemplateDataReader> _logger;
    private readonly ApiClient _apiClient;

    public AccountingTemplateDataReader(
        ILogger<AccountingTemplateDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<AccountingTemplateDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var businessUnitCode = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("businessUnitCode", out var businessUnitElement)
            ? businessUnitElement.GetString()
            : null;

        if (string.IsNullOrEmpty(businessUnitCode))
        {
            _logger.LogError("BusinessUnitCode is required but was not provided");
            throw new ArgumentException("BusinessUnitCode is required");
        }

        var response = await _apiClient.GetAccountingTemplates(businessUnitCode, cancellationToken);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Failed to retrieve accounting templates. Status code: {StatusCode}", response.StatusCode);
            throw new Exception($"Failed to retrieve accounting templates. API StatusCode: {response.StatusCode}");
        }

        if (response.Data == null)
        {
            _logger.LogWarning("No accounting templates found");
            yield break;
        }

        foreach (var template in response.Data)
        {
            yield return template;
        }
    }
}