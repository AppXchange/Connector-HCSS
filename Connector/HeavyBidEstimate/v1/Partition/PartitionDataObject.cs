namespace Connector.HeavyBidEstimate.v1.Partition;

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
[Description("Represents a database partition in HeavyBid")]
public class PartitionDataObject
{
    [JsonPropertyName("id")]
    [Description("The partition ID")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("systemId")]
    [Description("The system ID")]
    public Guid SystemId { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit ID")]
    public Guid BusinessUnitId { get; init; }

    [JsonPropertyName("businessUnitCode")]
    [Description("The business unit code")]
    public string? BusinessUnitCode { get; init; }

    [JsonPropertyName("divisionId")]
    [Description("The division ID")]
    public Guid DivisionId { get; init; }

    [JsonPropertyName("divisionCode")]
    [Description("The division code")]
    public string? DivisionCode { get; init; }
}