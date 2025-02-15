namespace Connector.HeavyJob.v1.CustomCostTypeItems;

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
[Description("Represents a custom cost type item in HeavyJob")]
public class CustomCostTypeItemsDataObject
{
    [JsonPropertyName("id")]
    [Description("The custom cost type item id")]
    [Required]
    public Guid Id { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit id")]
    [Required]
    public Guid BusinessUnitId { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Flags a deleted record")]
    public bool IsDeleted { get; init; }

    [JsonPropertyName("costCategoryId")]
    [Description("The cost category (custom cost type) id")]
    [Required]
    public Guid CostCategoryId { get; init; }

    [JsonPropertyName("code")]
    [Description("The code")]
    [Required]
    public string Code { get; init; } = string.Empty;

    [JsonPropertyName("description")]
    [Description("The description")]
    public string? Description { get; init; }

    [JsonPropertyName("heavyBidCode")]
    [Description("The HeavyBid code")]
    public string? HeavyBidCode { get; init; }
}