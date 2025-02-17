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

namespace Connector.HeavyJob.v1.MaterialsInstalledQuantities;

public class MaterialsInstalledQuantitiesDataReader : TypedAsyncDataReaderBase<MaterialsInstalledQuantitiesDataObject>
{
    private readonly ILogger<MaterialsInstalledQuantitiesDataReader> _logger;
    private readonly ApiClient _apiClient;

    public MaterialsInstalledQuantitiesDataReader(
        ILogger<MaterialsInstalledQuantitiesDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<MaterialsInstalledQuantitiesDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var request = new MaterialsInstalledQuantitiesRequest();
        string? cursor = null;

        do
        {
            var response = await _apiClient.GetMaterialsInstalledQuantities(
                request with { Cursor = cursor },
                cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve materials installed quantities. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve materials installed quantities. API StatusCode: {response.StatusCode}");
            }

            if (response.Data?.Results == null)
            {
                _logger.LogWarning("No materials installed quantities found");
                yield break;
            }

            foreach (var quantity in response.Data.Results)
            {
                yield return quantity;
            }

            cursor = response.Data.Metadata?.NextCursor;
        }
        while (!string.IsNullOrEmpty(cursor));
    }
}

public record MaterialsInstalledQuantitiesRequest
{
    [JsonPropertyName("jobId")]
    public Guid? JobId { get; init; }

    [JsonPropertyName("foremanId")]
    public Guid? ForemanId { get; init; }

    [JsonPropertyName("startDate")]
    public DateTime? StartDate { get; init; }

    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }

    [JsonPropertyName("modifiedSince")]
    public DateTime? ModifiedSince { get; init; }

    [JsonPropertyName("limit")]
    public int? Limit { get; init; }

    [JsonPropertyName("cursor")]
    public string? Cursor { get; init; }
}

public record MaterialsInstalledQuantitiesResponse
{
    [JsonPropertyName("results")]
    [Required]
    public required MaterialsInstalledQuantitiesDataObject[] Results { get; init; }

    [JsonPropertyName("metadata")]
    [Required]
    public required MaterialsInstalledQuantitiesResponseMetadata Metadata { get; init; }
}

public record MaterialsInstalledQuantitiesResponseMetadata
{
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; init; }
}