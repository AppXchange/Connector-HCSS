namespace Connector.HeavyBidEstimate.v1.ActivityCodebookResources;

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
[Description("Represents an activity codebook resource in HeavyBid Estimate")]
public class ActivityCodebookResourcesDataObject
{
    [JsonPropertyName("id")]
    [Description("The activity codebook resource id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("activityCodebookId")]
    [Description("The parent activity codebook ID")]
    public Guid ActivityCodebookId { get; init; }

    [JsonPropertyName("activityCodebookCode")]
    [Description("The activity codebook code")]
    public string? ActivityCodebookCode { get; init; }

    [JsonPropertyName("resourceCode")]
    [Description("Resource code")]
    public string? ResourceCode { get; init; }

    [JsonPropertyName("unitPrice")]
    [Description("Unit price")]
    public decimal UnitPrice { get; init; }

    [JsonPropertyName("units")]
    [Description("Units of measurement")]
    public string? Units { get; init; }

    [JsonPropertyName("quantityFactor")]
    [Description("Quantity factor")]
    public decimal QuantityFactor { get; init; }

    [JsonPropertyName("wasteFactor")]
    [Description("Waste factor")]
    public decimal WasteFactor { get; init; }

    [JsonPropertyName("mhPerUnit")]
    [Description("Man hours per unit")]
    public decimal MhPerUnit { get; init; }
}