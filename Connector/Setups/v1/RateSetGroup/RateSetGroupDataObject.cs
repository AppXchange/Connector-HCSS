namespace Connector.Setups.v1.RateSetGroup;

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
[Description("Represents a rate set group in HCSS")]
public class RateSetGroupDataObject
{
    [JsonPropertyName("id")]
    [Description("The Id of the rate set")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("code")]
    [Description("The code of the rate set")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("description")]
    [Description("The description")]
    public string? Description { get; init; }

    [JsonPropertyName("effectiveDate")]
    [Description("The effective date of the rate set group")]
    [Required]
    public required DateTime EffectiveDate { get; init; }

    [JsonPropertyName("type")]
    [Description("The rate set group type")]
    [Required]
    public required string Type { get; init; }
}