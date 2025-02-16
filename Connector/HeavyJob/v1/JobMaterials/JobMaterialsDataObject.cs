namespace Connector.HeavyJob.v1.JobMaterials;

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
[Description("Represents a list of job materials in HeavyJob")]
public class JobMaterialsDataObject
{
    [JsonPropertyName("id")]
    [Description("The job material guid")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("materialId")]
    [Description("The material guid")]
    [Required]
    public required Guid MaterialId { get; init; }

    [JsonPropertyName("salesTaxPercent")]
    [Description("The sales tax, expressed as a percent (e.g., 8 means 8% sales tax)")]
    public double SalesTaxPercent { get; init; }

    [JsonPropertyName("tmRate")]
    [Description("The T&M rate, in dollars per unit of measure")]
    public double TmRate { get; init; }

    [JsonPropertyName("unitCost")]
    [Description("The cost per unit of measure, in dollars")]
    public double UnitCost { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The unit of measure")]
    public string? UnitOfMeasure { get; init; }

    [JsonPropertyName("accountingCode")]
    [Description("The accounting code")]
    public string? AccountingCode { get; init; }

    [JsonPropertyName("isDiscontinued")]
    [Description("The IsDiscontinued flag")]
    public bool IsDiscontinued { get; init; }

    [JsonPropertyName("code")]
    [Description("The code")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("isStockpiled")]
    [Description("Flag indicating whether the material is used immediately (e.g., installed), or added to the stockpile for later")]
    public bool IsStockpiled { get; init; }

    [JsonPropertyName("heavyBidCode")]
    [Description("The HeavyBid code")]
    public string? HeavyBidCode { get; init; }

    [JsonPropertyName("jobId")]
    [Description("The job guid")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("description")]
    [Description("The description")]
    [Required]
    public required string Description { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("The IsDeleted flag")]
    public bool IsDeleted { get; init; }
}