namespace Connector.Equipment360.v1.Parts;

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
[Description("Represents a part")]
public class PartsDataObject
{
    [JsonPropertyName("id")]
    [Description("The Part id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Indicates if the part has been disabled")]
    public bool IsDeleted { get; init; }

    [JsonPropertyName("partNumber")]
    [Description("The Part's number")]
    [Required]
    public required string PartNumber { get; init; }

    [JsonPropertyName("oemPartNumber")]
    [Description("The original equipment manufacturer part number")]
    public string? OemPartNumber { get; init; }

    [JsonPropertyName("description")]
    [Description("The description of the Part")]
    public string? Description { get; init; }

    [JsonPropertyName("name")]
    [Description("The name of the part")]
    public string? Name { get; init; }

    [JsonPropertyName("barCode")]
    [Description("The part's bar code")]
    public string? BarCode { get; init; }

    [JsonPropertyName("category")]
    [Description("The part category")]
    public string? Category { get; init; }

    [JsonPropertyName("categoryId")]
    [Description("The id of the part category")]
    public Guid? CategoryId { get; init; }

    [JsonPropertyName("stockUnitOfMeasure")]
    [Description("The Unit of Measure for this part (e.g. \"EA\")")]
    [Required]
    public required string StockUnitOfMeasure { get; init; }

    [JsonPropertyName("stockUnitOfMeasureId")]
    [Description("The stock Unit of Measure's ID. (e.g. \"EA\")")]
    public Guid? StockUnitOfMeasureId { get; init; }

    [JsonPropertyName("purchaseUnitOfMeasure")]
    [Description("The Unit of Measure used by default for purchases of this part. (e.g. \"EA\")")]
    [Required]
    public required string PurchaseUnitOfMeasure { get; init; }

    [JsonPropertyName("purchaseUnitOfMeasureId")]
    [Description("The purchase Unit of Measure's ID. (e.g. \"EA\")")]
    public Guid? PurchaseUnitOfMeasureId { get; init; }

    [JsonPropertyName("preferredVendor")]
    [Description("The Preferred Vendor for this part")]
    public string? PreferredVendor { get; init; }

    [JsonPropertyName("preferredVendorId")]
    [Description("The id of the Preferred Vendor for this part")]
    public int? PreferredVendorId { get; init; }
}