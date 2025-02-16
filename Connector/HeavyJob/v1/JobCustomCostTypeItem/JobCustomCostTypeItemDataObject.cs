namespace Connector.HeavyJob.v1.JobCustomCostTypeItem;

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
[Description("Job custom cost type item in HeavyJob")]
public class JobCustomCostTypeItemDataObject
{
    [JsonPropertyName("customCostTypeItemId")]
    [Description("The custom cost type item id")]
    [Required]
    public required Guid CustomCostTypeItemId { get; init; }

    [JsonPropertyName("description")]
    [Description("The description")]
    public string? Description { get; init; }

    [JsonPropertyName("salesTaxPercent")]
    [Description("The sales tax, expressed as a percent")]
    public double? SalesTaxPercent { get; init; }

    [JsonPropertyName("unitCost")]
    [Description("The cost per unit of measure, in dollars")]
    public double? UnitCost { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The unit of measure")]
    public string? UnitOfMeasure { get; init; }

    [JsonPropertyName("accountingCode")]
    [Description("The accounting code")]
    public string? AccountingCode { get; init; }

    [JsonPropertyName("id")]
    [Description("The job custom-cost-type item id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("code")]
    [Description("The code")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("heavyBidCode")]
    [Description("The HeavyBid code")]
    public string? HeavyBidCode { get; init; }

    [JsonPropertyName("jobId")]
    [Description("The job guid")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("businessUnitCostType")]
    [Description("The business unit cost type information")]
    [Required]
    public required BusinessUnitCostTypeInfo BusinessUnitCostType { get; init; }

    [JsonPropertyName("businessUnitCostTypeItem")]
    [Description("The business unit cost type item information")]
    [Required]
    public required BusinessUnitCostTypeItemInfo BusinessUnitCostTypeItem { get; init; }

    [JsonPropertyName("isDiscontinued")]
    [Description("Whether the item is discontinued")]
    [Required]
    public required bool IsDiscontinued { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Whether the item is deleted")]
    [Required]
    public required bool IsDeleted { get; init; }
}

public class BusinessUnitCostTypeInfo
{
    [JsonPropertyName("id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("code")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("description")]
    [Required]
    public required string Description { get; init; }

    [JsonPropertyName("isDeleted")]
    [Required]
    public required bool IsDeleted { get; init; }
}

public class BusinessUnitCostTypeItemInfo
{
    [JsonPropertyName("id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("type")]
    [Required]
    public required string Type { get; init; }

    [JsonPropertyName("code")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("description")]
    [Required]
    public required string Description { get; init; }

    [JsonPropertyName("isDeleted")]
    [Required]
    public required bool IsDeleted { get; init; }
}