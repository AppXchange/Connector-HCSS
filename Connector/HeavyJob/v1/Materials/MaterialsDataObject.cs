namespace Connector.HeavyJob.v1.Materials;

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
[Description("Represents a material in HeavyJob")]
public class MaterialsDataObject
{
    [JsonPropertyName("id")]
    [Description("The material id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit id")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("code")]
    [Description("The code")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("description")]
    [Description("The description")]
    public string? Description { get; init; }

    [JsonPropertyName("isStockpiled")]
    [Description("Flag indicating whether the material is used immediately (e.g., installed), or added to the stockpile for later")]
    [Required]
    public required bool IsStockpiled { get; init; }

    [JsonPropertyName("heavyBidCode")]
    [Description("The HeavyBid code")]
    public string? HeavyBidCode { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Flags a deleted record")]
    public bool IsDeleted { get; init; }
}