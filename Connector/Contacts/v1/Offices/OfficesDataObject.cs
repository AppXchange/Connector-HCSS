namespace Connector.Contacts.v1.Offices;

using Connector.Contacts.v1.Office;
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
[Description("Represents an office location associated with a vendor")]
public class OfficesDataObject
{
    [JsonPropertyName("vendorId")]
    [Description("The vendor's unique id")]
    [Required]
    public required Guid VendorId { get; init; }

    [JsonPropertyName("id")]
    [Description("The vendor location's unique id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("address")]
    [Description("The office address")]
    public AddressDto? Address { get; init; }

    [JsonPropertyName("phoneNumber")]
    [Description("The vendor location's phonenumber")]
    public string? PhoneNumber { get; init; }

    [JsonPropertyName("faxNumber")]
    [Description("The vendor location's faxnumber")]
    public string? FaxNumber { get; init; }

    [JsonPropertyName("webAddress")]
    [Description("The vendor location's website address")]
    public string? WebAddress { get; init; }

    [JsonPropertyName("region")]
    [Description("A Region data transfer object")]
    public RegionDto? Region { get; init; }

    [JsonPropertyName("nickname")]
    [Description("The nickname for a vendor location")]
    public string? Nickname { get; init; }

    [JsonPropertyName("isQualified")]
    [Description("A flag if a vendor location is qualified")]
    public bool IsQualified { get; init; }

    [JsonPropertyName("isBlacklisted")]
    [Description("A flag if a vendor location is blacklisted")]
    public bool IsBlacklisted { get; init; }

    [JsonPropertyName("communicationMethod")]
    [Description("The preferred communication method")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CommunicationMethod CommunicationMethod { get; init; }

    [JsonPropertyName("isPrimary")]
    [Description("A flag if a vendor location is primary")]
    public bool IsPrimary { get; init; }

    [JsonPropertyName("isAlternate")]
    [Description("A flag if a vendor location is alternate")]
    public bool IsAlternate { get; init; }
}