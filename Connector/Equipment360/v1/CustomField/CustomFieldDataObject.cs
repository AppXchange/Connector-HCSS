namespace Connector.Equipment360.v1.CustomField;

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
[Description("Represents a custom field record in the system")]
public class CustomFieldDataObject
{
    [JsonPropertyName("id")]
    [Description("The ID associated with the custom field record")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("customFieldType")]
    [Description("The type of custom field record (e.g. Equipment, Employee, Location, etc.)")]
    public string? CustomFieldType { get; init; }

    [JsonPropertyName("customFieldName")]
    [Description("The custom field category name associated with the custom field record")]
    public string? CustomFieldName { get; init; }

    [JsonPropertyName("customFieldCategoryId")]
    [Description("The unique integer associated with the custom field category")]
    public int CustomFieldCategoryId { get; init; }

    [JsonPropertyName("entityId")]
    [Description("The integer key associated with the target")]
    public int EntityId { get; init; }

    [JsonPropertyName("entityGuid")]
    [Description("The ID associated with the target")]
    public Guid? EntityGuid { get; init; }

    [JsonPropertyName("value")]
    [Description("The value assigned to the custom field record")]
    public string? Value { get; init; }
}