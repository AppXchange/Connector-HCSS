namespace Connector.HeavyJob.v1.CostCodeProgress;

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
[PrimaryKey("costCodeId", nameof(CostCodeId))]
[Description("Represents cost code progress in HeavyJob")]
public class CostCodeProgressDataObject
{
    [JsonPropertyName("costCodeId")]
    [Description("The cost code ID")]
    [Required]
    public Guid CostCodeId { get; init; }

    [JsonPropertyName("date")]
    [Description("The date of the progress")]
    public DateTime Date { get; init; }

    [JsonPropertyName("quantity")]
    [Description("The quantity")]
    public double Quantity { get; init; }

    [JsonPropertyName("reworkQuantity")]
    [Description("The rework quantity")]
    public double ReworkQuantity { get; init; }

    [JsonPropertyName("laborHours")]
    [Description("The labor hours")]
    public double LaborHours { get; init; }

    [JsonPropertyName("toDateQuantity")]
    [Description("The to-date quantity")]
    public double ToDateQuantity { get; init; }

    [JsonPropertyName("toDateLaborHours")]
    [Description("The to-date labor hours")]
    public double ToDateLaborHours { get; init; }
}

public class CostCodeProgressResponse
{
    [JsonPropertyName("results")]
    [Required]
    public CostCodeProgressDataObject[] Results { get; init; } = Array.Empty<CostCodeProgressDataObject>();

    [JsonPropertyName("metadata")]
    [Required]
    public CostCodeProgressMetadata Metadata { get; init; } = new();
}

public class CostCodeProgressMetadata
{
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; init; }
}