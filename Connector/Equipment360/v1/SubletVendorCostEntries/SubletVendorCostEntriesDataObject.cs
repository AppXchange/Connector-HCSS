namespace Connector.Equipment360.v1.SubletVendorCostEntries;

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
[Description("Represents a sublet vendor cost entry detail")]
public class SubletVendorCostEntriesDataObject
{
    [JsonPropertyName("id")]
    [Description("The sublet vendor cost entry detail id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("vendorId")]
    [Description("The vendor id for the cost entry")]
    [Required]
    public required Guid VendorId { get; init; }

    [JsonPropertyName("amount")]
    [Description("The value of the amount")]
    public double? Amount { get; init; }

    [JsonPropertyName("estimatedCost")]
    [Description("The value of the estimated cost")]
    public double? EstimatedCost { get; init; }

    [JsonPropertyName("description")]
    [Description("The description of the cost entry")]
    public string? Description { get; init; }
}