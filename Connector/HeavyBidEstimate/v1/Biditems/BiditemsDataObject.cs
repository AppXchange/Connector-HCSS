namespace Connector.HeavyBidEstimate.v1.Biditems;

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
[Description("Represents a collection of biditems in HeavyBid Estimate")]
public class BiditemsDataObject
{
    [JsonPropertyName("id")]
    [Description("The biditem id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("estimateId")]
    [Description("The estimate ID")]
    public Guid EstimateId { get; init; }

    [JsonPropertyName("estimateCode")]
    [Description("The estimate code")]
    public string? EstimateCode { get; init; }

    [JsonPropertyName("lastModified")]
    [Description("Last modified timestamp")]
    public DateTime LastModified { get; init; }

    [JsonPropertyName("biditemCode")]
    [Description("The bid item code")]
    public int BiditemCode { get; init; }

    [JsonPropertyName("description")]
    [Description("Bid item description")]
    public string? Description { get; init; }

    [JsonPropertyName("type")]
    [Description("Type of bid item")]
    public string? Type { get; init; }

    [JsonPropertyName("quantity")]
    [Description("Quantity")]
    public decimal Quantity { get; init; }

    [JsonPropertyName("bidQuantity")]
    [Description("Bid quantity")]
    public decimal BidQuantity { get; init; }

    [JsonPropertyName("units")]
    [Description("Units of measurement")]
    public string? Units { get; init; }

    [JsonPropertyName("bidPrice")]
    [Description("Bid price")]
    public decimal BidPrice { get; init; }
}