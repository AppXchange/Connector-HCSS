namespace Connector.Safety.v1.AccessGroups;

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
[Description("Represents an access group in Safety")]
public class AccessGroupsDataObject
{
    [JsonPropertyName("id")]
    [Description("The role id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    [Description("The role name")]
    [Required]
    public required string Name { get; init; }

    [JsonPropertyName("description")]
    [Description("The role description")]
    public string? Description { get; init; }

    [JsonPropertyName("lastChangedById")]
    [Description("The guid of the user who last modified the role")]
    [Required]
    public required Guid LastChangedById { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Is the role deleted")]
    public bool IsDeleted { get; init; }
}