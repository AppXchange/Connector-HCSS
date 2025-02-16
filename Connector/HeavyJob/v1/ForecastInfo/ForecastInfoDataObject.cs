namespace Connector.HeavyJob.v1.ForecastInfo;

using Json.Schema.Generation;
using System;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.CacheWriter;

/// <summary>
/// Data object that will represent an object in the Xchange system. This will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// These types will be used for validation at runtime to make sure the objects being passed through the system 
/// are properly formed. The schema also helps provide integrators more information for what the values 
/// are intended to be.
/// </summary>
[PrimaryKey("id", nameof(Id))]
//[AlternateKey("alt-key-id", nameof(CompanyId), nameof(EquipmentNumber))]
[Description("Forecast summary information in HeavyJob")]
public class ForecastInfoDataObject
{
    [JsonPropertyName("id")]
    [Description("The forecast guid")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("jobId")]
    [Description("The job guid")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("forecastDate")]
    [Description("The forecast date")]
    [Required]
    public required DateTime ForecastDate { get; init; }

    [JsonPropertyName("finalizedDateTime")]
    [Description("The forecast finalized date")]
    public DateTime? FinalizedDateTime { get; init; }
}

public class ForecastInfoResponse
{
    [JsonPropertyName("results")]
    [Required]
    public required ForecastInfoDataObject[] Results { get; init; }

    [JsonPropertyName("metadata")]
    [Required]
    public required ForecastInfoMetadata Metadata { get; init; }
}

public class ForecastInfoMetadata
{
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; init; }
}