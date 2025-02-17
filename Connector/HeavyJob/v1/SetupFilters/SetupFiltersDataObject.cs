namespace Connector.HeavyJob.v1.SetupFilters;

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
[Description("Represents a cost code setup filter group in HeavyJob")]
public class SetupFiltersDataObject
{
    [JsonPropertyName("id")]
    [Description("The id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    [Description("The name of the group")]
    [Required]
    public required string Name { get; init; }

    [JsonPropertyName("lastModified")]
    [Description("The timestamp")]
    [Required]
    public required DateTime LastModified { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("The isDeleted flag")]
    [Required]
    public required bool IsDeleted { get; init; }

    [JsonPropertyName("tags")]
    [Description("The tags in this group")]
    [Required]
    public required CostCodeFilterRead[] Tags { get; init; }
}

public class CostCodeFilterRead
{
    [JsonPropertyName("id")]
    [Description("The id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("code")]
    [Description("The code")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("description")]
    [Description("The description")]
    [Required]
    public required string Description { get; init; }

    [JsonPropertyName("lastModified")]
    [Description("The timestamp")]
    [Required]
    public required DateTime LastModified { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("The isDeleted flag")]
    [Required]
    public required bool IsDeleted { get; init; }
}