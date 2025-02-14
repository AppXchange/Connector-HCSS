namespace Connector.HeavyJob.v1.AdvancedBudgetSubcontract;

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
[Description("Represents a subcontract advanced budget in HeavyJob")]
public class AdvancedBudgetSubcontractDataObject
{
    [JsonPropertyName("id")]
    [Description("The subcontract advanced budget id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("costCodeId")]
    [Description("The cost code id")]
    [Required]
    public required Guid CostCodeId { get; init; }

    [JsonPropertyName("jobSubcontractId")]
    [Description("The job subcontract id")]
    [Required]
    public required Guid JobSubcontractId { get; init; }

    [JsonPropertyName("vendorContractDetailId")]
    [Description("The vendor contract detail id")]
    [Required]
    public required Guid VendorContractDetailId { get; init; }

    [JsonPropertyName("status")]
    [Description("The status of the work item")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public WorkItemStatus Status { get; init; }

    [JsonPropertyName("quantity")]
    [Description("The quantity of the subcontract")]
    public double Quantity { get; init; }

    [JsonPropertyName("subcontractDescription")]
    [Description("The subcontract description")]
    public string? SubcontractDescription { get; init; }

    [JsonPropertyName("vendorContractId")]
    [Description("The vendor contract id")]
    public Guid? VendorContractId { get; init; }

    [JsonPropertyName("costCode")]
    [Description("The cost code")]
    public string? CostCode { get; init; }

    [JsonPropertyName("costCodeDescription")]
    [Description("The cost code description")]
    public string? CostCodeDescription { get; init; }

    [JsonPropertyName("salesTaxPercent")]
    [Description("The sales tax, expressed as a percent")]
    public double SalesTaxPercent { get; init; }

    [JsonPropertyName("unitCost")]
    [Description("The cost per unit of measure, in dollars")]
    public double UnitCost { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The unit of measure")]
    public string? UnitOfMeasure { get; init; }

    [JsonPropertyName("vendorId")]
    [Description("The vendor id")]
    public Guid? VendorId { get; init; }

    [JsonPropertyName("mWorkItemBusinessUnitId")]
    [Description("MWorkItemBusinessUnitId")]
    public Guid MWorkItemBusinessUnitId { get; init; }
}

public enum WorkItemStatus
{
    Active,
    Completed,
    Discontinued
}