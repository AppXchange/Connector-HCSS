namespace Connector.HeavyJob.v1.JobSubcontracts;

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
[Description("Represents a list of job subcontract items in HeavyJob")]
public class JobSubcontractsDataObject
{
    [JsonPropertyName("id")]
    [Description("The job subcontract item id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("subcontractId")]
    [Description("The subcontract guid")]
    [Required]
    public required Guid SubcontractId { get; init; }

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

    [JsonPropertyName("description")]
    [Description("The description")]
    [Required]
    public required string Description { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Flags a deleted record")]
    public bool IsDeleted { get; init; }

    [JsonPropertyName("isDiscontinued")]
    [Description("Flags a discontinued record")]
    public bool IsDiscontinued { get; init; }
}