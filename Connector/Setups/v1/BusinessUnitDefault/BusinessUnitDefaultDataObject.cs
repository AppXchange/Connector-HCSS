namespace Connector.Setups.v1.BusinessUnitDefault;

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
[Description("Represents the default business unit in HCSS")]
public class BusinessUnitDefaultDataObject
{
    [JsonPropertyName("id")]
    [Description("The business unit id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("code")]
    [Description("A code, in all caps, that represents this business unit")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("description")]
    [Description("An optional description for this business unit")]
    public string? Description { get; init; }
}