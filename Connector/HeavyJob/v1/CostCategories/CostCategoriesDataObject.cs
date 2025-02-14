namespace Connector.HeavyJob.v1.CostCategories;

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
[Description("Represents a cost category in HeavyJob")]
public class CostCategoriesDataObject
{
    [JsonPropertyName("id")]
    [Description("The unique identifier of the cost category")]
    [Required]
    public Guid Id { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit ID this cost category belongs to")]
    [Required]
    public Guid BusinessUnitId { get; init; }

    [JsonPropertyName("costTypeId")]
    [Description("The cost type ID")]
    [Required]
    public Guid CostTypeId { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Indicates if the cost category has been deleted")]
    public bool IsDeleted { get; init; }

    [JsonPropertyName("code")]
    [Description("The cost category code")]
    [Required]
    public string Code { get; init; } = string.Empty;

    [JsonPropertyName("description")]
    [Description("The description of the cost category")]
    [Required]
    public string Description { get; init; } = string.Empty;
}