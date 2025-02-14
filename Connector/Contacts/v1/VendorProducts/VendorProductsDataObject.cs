namespace Connector.Contacts.v1.VendorProducts;

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
[Description("Represents a product associated with a vendor")]
public class VendorProductsDataObject
{
    [JsonPropertyName("id")]
    [Description("The product's unique identifier")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("productTypeId")]
    [Description("The product type's unique identifier")]
    [Required]
    public required Guid ProductTypeId { get; init; }

    [JsonPropertyName("vendorId")]
    [Description("The vendor's unique identifier")]
    [Required]
    public required Guid VendorId { get; init; }
}