namespace Connector.Equipment360.v1.CustomFieldList;

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
[PrimaryKey("customFieldCategoryId", nameof(CustomFieldCategoryId))]
[Description("Represents a custom field list type category and its options")]
public class CustomFieldListDataObject
{
    [JsonPropertyName("customFieldType")]
    [Description("The type of custom field record (e.g. Equipment, Employee, Location, etc.)")]
    public string? CustomFieldType { get; init; }

    [JsonPropertyName("customFieldName")]
    [Description("The custom field category name associated with the custom field record")]
    public string? CustomFieldName { get; init; }

    [JsonPropertyName("customFieldCategoryId")]
    [Description("The unique integer associated with the custom field category")]
    [Required]
    public required int CustomFieldCategoryId { get; init; }

    [JsonPropertyName("listOptions")]
    [Description("Available options for custom field record of type List")]
    public string[]? ListOptions { get; init; }
}