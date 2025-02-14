namespace Connector.Equipment360.v1.Vendors;

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
[Description("Represents a vendor in Equipment360")]
public class VendorsDataObject
{
    [JsonPropertyName("id")]
    [Description("The vendor id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("vendorType")]
    [Description("The type/s of the vendor (e.g. Fuel, Parts)")]
    public string? VendorType { get; init; }

    [JsonPropertyName("name")]
    [Description("The vendor name")]
    [Required]
    public required string Name { get; init; }

    [JsonPropertyName("vendorNum")]
    [Description("The vendor number")]
    [Required]
    public required string VendorNum { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Whether the vendor is marked as deleted")]
    public bool IsDeleted { get; init; }

    [JsonPropertyName("taxRate")]
    [Description("The vendor tax rate")]
    public double? TaxRate { get; init; }

    [JsonPropertyName("isFuel")]
    [Description("The vendor is fuel")]
    public bool? IsFuel { get; init; }

    [JsonPropertyName("isParts")]
    [Description("The vendor is parts")]
    public bool? IsParts { get; init; }

    [JsonPropertyName("isSublet")]
    [Description("The vendor is sublet")]
    public bool? IsSublet { get; init; }

    [JsonPropertyName("isRental")]
    [Description("The vendor is rental")]
    public bool? IsRental { get; init; }
}