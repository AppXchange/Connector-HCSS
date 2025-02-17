namespace Connector.HeavyJob.v1.Vendors;

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
[Description("Represents a vendor in HeavyJob")]
public class VendorsDataObject
{
    [JsonPropertyName("id")]
    [Description("The vendor id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    [Description("The name of the vendor")]
    [Required]
    public required string Name { get; init; }

    [JsonPropertyName("description")]
    [Description("The description of the vendor")]
    public string? Description { get; init; }

    [JsonPropertyName("address1")]
    [Description("The street address (e.g., 123 Main St)")]
    public string? Address1 { get; init; }

    [JsonPropertyName("address2")]
    [Description("The secondary address info (suite, apartment, PO box numbers etc.)")]
    public string? Address2 { get; init; }

    [JsonPropertyName("city")]
    [Description("The city")]
    public string? City { get; init; }

    [JsonPropertyName("state")]
    [Description("The state abbreviation")]
    public string? State { get; init; }

    [JsonPropertyName("zip")]
    [Description("The zip code")]
    public string? Zip { get; init; }

    [JsonPropertyName("country")]
    [Description("The country")]
    public string? Country { get; init; }

    [JsonPropertyName("phoneNumber")]
    [Description("The phone number. Can include numbers, symbols and whitespace")]
    public string? PhoneNumber { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("A flag indicating whether or not the vendor has been deleted from the system")]
    [Required]
    public required bool IsDeleted { get; init; }
}