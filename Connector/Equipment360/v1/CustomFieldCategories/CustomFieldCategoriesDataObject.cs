namespace Connector.Equipment360.v1.CustomFieldCategories;

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
[PrimaryKey("categoryId", nameof(CategoryId))]
[Description("Represents a custom field category in the system")]
public class CustomFieldCategoriesDataObject
{
    [JsonPropertyName("categoryId")]
    [Description("The unique identifier for the custom field category")]
    [Required]
    public required int CategoryId { get; init; }

    [JsonPropertyName("fieldName")]
    [Description("The name of the custom field")]
    public string? FieldName { get; init; }

    [JsonPropertyName("entityName")]
    [Description("The type of entity this field belongs to")]
    public string? EntityName { get; init; }

    [JsonPropertyName("dataType")]
    [Description("The data type of the custom field")]
    public string? DataType { get; init; }
}