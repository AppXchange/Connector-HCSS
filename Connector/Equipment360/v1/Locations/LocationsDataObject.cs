namespace Connector.Equipment360.v1.Locations;

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
[Description("Represents a location")]
public class LocationsDataObject
{
    [JsonPropertyName("id")]
    [Description("The location id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit ID")]
    public Guid BusinessUnitId { get; init; }

    [JsonPropertyName("code")]
    [Description("The code")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("description")]
    [Description("An optional description")]
    public string? Description { get; init; }

    [JsonPropertyName("enabled")]
    [Description("Enabled? (Y/N)")]
    public string? Enabled { get; init; }

    [JsonPropertyName("address")]
    [Description("A representation of an Address object returned by the API")]
    public AddressObject? Address { get; init; }
}

public class AddressObject
{
    [JsonPropertyName("line1")]
    public string? Line1 { get; init; }

    [JsonPropertyName("line2")]
    public string? Line2 { get; init; }

    [JsonPropertyName("city")]
    public string? City { get; init; }

    [JsonPropertyName("state")]
    public string? State { get; init; }

    [JsonPropertyName("zip")]
    public string? Zip { get; init; }
}