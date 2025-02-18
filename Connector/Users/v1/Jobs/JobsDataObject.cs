namespace Connector.Users.v1.Jobs;

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
[Description("Represents a job in HCSS")]
public class JobsDataObject
{
    [JsonPropertyName("id")]
    [Description("The Guid of the job in HeavyJob")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The Guid of the business unit that the job belongs to")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("code")]
    [Description("The Code of the job in HeavyJob")]
    public string? Code { get; init; }

    [JsonPropertyName("description")]
    [Description("The description of the job in HeavyJob")]
    public string? Description { get; init; }
}