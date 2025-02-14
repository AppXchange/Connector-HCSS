namespace Connector.Contacts.v1.ProductVendors;

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
[Description("Represents a vendor associated with a product type")]
public class ProductVendorsDataObject
{
    public class CompanyTypeDto
    {
        [JsonPropertyName("id")]
        [Description("The company type's unique identifier")]
        public string? Id { get; init; }

        [JsonPropertyName("name")]
        [Description("The company type's name")]
        public string? Name { get; init; }
    }

    [JsonPropertyName("id")]
    [Description("The vendor's unique identifier")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The vendor's business unit unique identifier")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("name")]
    [Description("The vendor's name")]
    public string? Name { get; init; }

    [JsonPropertyName("webAddress")]
    [Description("The vendor's website address")]
    public string? WebAddress { get; init; }

    [JsonPropertyName("code")]
    [Description("The vendor's unique code")]
    [Required]
    [MinLength(1)]
    public required string Code { get; init; }

    [JsonPropertyName("type")]
    [Description("A company type data transfer object")]
    public CompanyTypeDto? Type { get; init; }

    [JsonPropertyName("isBonded")]
    [Description("A flag indicating if this vendor is bonded")]
    public bool IsBonded { get; init; }

    [JsonPropertyName("bondRate")]
    [Description("The rate at which this vendor is bonded")]
    public double BondRate { get; init; }

    [JsonPropertyName("note")]
    [Description("Notes about this vendor")]
    public string? Note { get; init; }

    [JsonPropertyName("experienceModificationRating")]
    [Description("The vendor's experience modification rating, which is used for workers' compensation premium")]
    public double? ExperienceModificationRating { get; init; }

    [JsonPropertyName("isUnion")]
    [Description("A flag indicating if the vendor is in a union")]
    public bool IsUnion { get; init; }

    [JsonPropertyName("rating")]
    [Description("The rating this vendor has been given")]
    public int? Rating { get; init; }
}