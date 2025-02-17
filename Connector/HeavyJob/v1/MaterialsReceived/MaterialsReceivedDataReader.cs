using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Connector.HeavyJob.v1.MaterialsReceived;

public class MaterialsReceivedDataReader : TypedAsyncDataReaderBase<MaterialsReceivedDataObject>
{
    private readonly ILogger<MaterialsReceivedDataReader> _logger;
    private readonly ApiClient _apiClient;

    public MaterialsReceivedDataReader(
        ILogger<MaterialsReceivedDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<MaterialsReceivedDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var request = new MaterialsReceivedRequest();
        string? cursor = null;

        do
        {
            var response = await _apiClient.GetMaterialsReceived(
                request with { Cursor = cursor },
                cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve materials received. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve materials received. API StatusCode: {response.StatusCode}");
            }

            if (response.Data?.Results == null)
            {
                _logger.LogWarning("No materials received found");
                yield break;
            }

            foreach (var material in response.Data.Results)
            {
                yield return material;
            }

            cursor = response.Data.Metadata?.NextCursor;
        }
        while (!string.IsNullOrEmpty(cursor));
    }
}

public record MaterialsReceivedRequest
{
    [JsonPropertyName("jobIds")]
    public Guid[]? JobIds { get; init; }

    [JsonPropertyName("jobTagIds")]
    public Guid[]? JobTagIds { get; init; }

    [JsonPropertyName("foremanIds")]
    public Guid[]? ForemanIds { get; init; }

    [JsonPropertyName("startDate")]
    public DateTime? StartDate { get; init; }

    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }

    [JsonPropertyName("cursor")]
    public string? Cursor { get; init; }

    [JsonPropertyName("limit")]
    public int? Limit { get; init; }

    [JsonPropertyName("modifiedSince")]
    public DateTime? ModifiedSince { get; init; }

    [JsonPropertyName("businessUnitId")]
    public Guid? BusinessUnitId { get; init; }
}

public record MaterialsReceivedResponse
{
    [JsonPropertyName("results")]
    [Required]
    public required MaterialsReceivedDataObject[] Results { get; init; }

    [JsonPropertyName("metadata")]
    [Required]
    public required MaterialsReceivedResponseMetadata Metadata { get; init; }
}

public record MaterialsReceivedResponseMetadata
{
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; init; }
}