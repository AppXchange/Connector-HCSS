namespace Connector.Equipment360.v1.PartLocations;

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
[Description("Represents a part location")]
public class PartLocationsDataObject
{
    [JsonPropertyName("id")]
    [Description("The part location id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The part location's Business Unit id")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("code")]
    [Description("The location code")]
    public string? Code { get; init; }

    [JsonPropertyName("description")]
    [Description("The location description")]
    public string? Description { get; init; }

    [JsonPropertyName("isDefault")]
    [Description("Indicates whether this location is the default location for received parts")]
    public bool IsDefault { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Indicates whether this location has been soft deleted")]
    public bool IsDeleted { get; init; }
}