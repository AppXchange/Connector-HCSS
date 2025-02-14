namespace Connector.Contacts.v1.ContactProducts;

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
[PrimaryKey("vendorProductId", nameof(VendorProductId))]
[Description("Represents a product associated with a contact in the HCSS system")]
public class ContactProductsDataObject
{
    [JsonPropertyName("vendorProductId")]
    [Description("The product unique identifier")]
    [Required]
    public required Guid VendorProductId { get; init; }

    [JsonPropertyName("productTypeId")]
    [Description("The contact product's type")]
    [Required]
    public required Guid ProductTypeId { get; init; }

    [JsonPropertyName("productTypeCode")]
    [Description("The contact product type's code")]
    public string? ProductTypeCode { get; init; }

    [JsonPropertyName("code")]
    [Description("The contact product's code")]
    public string? Code { get; init; }

    [JsonPropertyName("regionCode")]
    [Description("The contact product's region code")]
    public string? RegionCode { get; init; }

    [JsonPropertyName("date")]
    [Description("The contact product's date")]
    public DateTime Date { get; init; }
}