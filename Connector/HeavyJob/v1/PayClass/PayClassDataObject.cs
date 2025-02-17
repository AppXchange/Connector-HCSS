namespace Connector.HeavyJob.v1.PayClass;

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
[Description("Represents a pay class in HeavyJob")]
public class PayClassDataObject
{
    [JsonPropertyName("id")]
    [Description("The pay class Id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("code")]
    [Description("The pay class code")]
    public string? Code { get; init; }

    [JsonPropertyName("description")]
    [Description("The pay class description")]
    public string? Description { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("The deleted status of the pay class")]
    public bool IsDeleted { get; init; }
}