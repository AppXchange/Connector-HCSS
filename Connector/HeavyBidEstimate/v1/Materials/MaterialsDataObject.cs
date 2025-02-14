namespace Connector.HeavyBidEstimate.v1.Materials;

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
[PrimaryKey("resourceId", nameof(ResourceId))]
[Description("Represents materials for an estimate in HeavyBid")]
public class MaterialsDataObject
{
    [JsonPropertyName("resourceId")]
    [Description("The resource ID")]
    [Required]
    public required Guid ResourceId { get; init; }

    [JsonPropertyName("resourceCode")]
    [Description("The resource code")]
    public string? ResourceCode { get; init; }

    [JsonPropertyName("description")]
    [Description("The description")]
    public string? Description { get; init; }

    [JsonPropertyName("currency")]
    [Description("The currency")]
    public string? Currency { get; init; }

    [JsonPropertyName("units")]
    [Description("The units")]
    public string? Units { get; init; }

    [JsonPropertyName("unitCost")]
    [Description("The unit cost")]
    public decimal UnitCost { get; init; }

    [JsonPropertyName("total")]
    [Description("The total cost")]
    public decimal Total { get; init; }

    [JsonPropertyName("biditems")]
    [Description("The associated bid items")]
    public BidItemDetail[]? BidItems { get; init; }
}

public class BidItemDetail
{
    [JsonPropertyName("biditemId")]
    public Guid BidItemId { get; init; }

    [JsonPropertyName("biditemCode")]
    public int BidItemCode { get; init; }

    [JsonPropertyName("activityId")]
    public Guid ActivityId { get; init; }

    [JsonPropertyName("activityCode")]
    public int ActivityCode { get; init; }

    [JsonPropertyName("quantity")]
    public decimal Quantity { get; init; }

    [JsonPropertyName("units")]
    public string? Units { get; init; }

    [JsonPropertyName("unitCost")]
    public decimal UnitCost { get; init; }

    [JsonPropertyName("percent")]
    public decimal Percent { get; init; }

    [JsonPropertyName("total")]
    public decimal Total { get; init; }

    [JsonPropertyName("escalationPercent")]
    public decimal EscalationPercent { get; init; }
}