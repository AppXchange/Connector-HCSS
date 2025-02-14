namespace Connector.Equipment360.v1.PartInventory;

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
[PrimaryKey("partID", nameof(PartId))]
//[AlternateKey("alt-key-id", nameof(CompanyId), nameof(EquipmentNumber))]
[Description("Represents a part inventory")]
public class PartInventoryDataObject
{
    [JsonPropertyName("partID")]
    [Description("The part ID")]
    [Required]
    public required Guid PartId { get; init; }

    [JsonPropertyName("partNum")]
    [Description("The part number")]
    public string? PartNum { get; init; }

    [JsonPropertyName("oemPartNum")]
    [Description("The OEM part number")]
    public string? OemPartNum { get; init; }

    [JsonPropertyName("partLocationID")]
    [Description("The part location ID")]
    public Guid PartLocationId { get; init; }

    [JsonPropertyName("partLocationCode")]
    [Description("The part location code")]
    public string? PartLocationCode { get; init; }

    [JsonPropertyName("onHandQty")]
    [Description("The on hand quantity")]
    public int OnHandQty { get; init; }

    [JsonPropertyName("onOrderQty")]
    [Description("The on order quantity")]
    public int OnOrderQty { get; init; }

    [JsonPropertyName("neededQuantity")]
    [Description("The needed quantity")]
    public int NeededQuantity { get; init; }

    [JsonPropertyName("bin")]
    [Description("The bin location")]
    public string? Bin { get; init; }

    [JsonPropertyName("lot")]
    [Description("The lot number")]
    public string? Lot { get; init; }
}