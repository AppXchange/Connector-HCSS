namespace Connector.Setups.v1.CostCode;

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
[Description("Represents a cost code in HCSS")]
public class CostCodeDataObject
{
    [JsonPropertyName("code")]
    [Description("Gets the cost code code")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("businessUnitCode")]
    [Description("Gets the business unit")]
    [Required]
    public required string BusinessUnitCode { get; init; }

    [JsonPropertyName("jobCode")]
    [Description("Gets job code")]
    [Required]
    public required string JobCode { get; init; }

    [JsonPropertyName("id")]
    [Description("The Id of the cost code")]
    public Guid? Id { get; init; }

    [JsonPropertyName("quantity")]
    [Description("The quantity")]
    public double? Quantity { get; init; }

    [JsonPropertyName("description")]
    [Description("The cost code description")]
    public string? Description { get; init; }

    [JsonPropertyName("unitOfMeasurement")]
    [Description("The unit of measure")]
    public string? UnitOfMeasurement { get; init; }

    [JsonPropertyName("laborHours")]
    [Description("The labor hours")]
    public double? LaborHours { get; init; }

    [JsonPropertyName("equipmentHours")]
    [Description("The equipment hours")]
    public double? EquipmentHours { get; init; }

    [JsonPropertyName("laborDollars")]
    [Description("The labor cost")]
    public double? LaborDollars { get; init; }

    [JsonPropertyName("equipmentDollars")]
    [Description("The equipment cost")]
    public double? EquipmentDollars { get; init; }

    [JsonPropertyName("materialDollars")]
    [Description("The material cost")]
    public double? MaterialDollars { get; init; }

    [JsonPropertyName("subcontractDollars")]
    [Description("The subcontract cost")]
    public double? SubcontractDollars { get; init; }

    [JsonPropertyName("supplyDollars")]
    [Description("The supply cost")]
    public double? SupplyDollars { get; init; }

    [JsonPropertyName("tags")]
    [Description("The cost code tags")]
    public DisTag[]? Tags { get; init; }

    [JsonPropertyName("status")]
    [Description("The cost code status. Items Enum: \"A\" for Active, \"C\" for Completed, \"I\" for Inactive")]
    public string? Status { get; init; }

    [JsonPropertyName("accountingCode")]
    [Description("The accounting code")]
    public string? AccountingCode { get; init; }

    [JsonPropertyName("category")]
    [Description("\"Category\" accounting field")]
    public string? Category { get; init; }

    [JsonPropertyName("criticalPathMethod")]
    [Description("\"CPM Code\" accounting field")]
    public string? CriticalPathMethod { get; init; }

    [JsonPropertyName("generalLedgerAccount")]
    [Description("\"GL Acct\" accounting field")]
    public string? GeneralLedgerAccount { get; init; }

    [JsonPropertyName("subJob")]
    [Description("\"Sub-Job\" accounting field")]
    public string? SubJob { get; init; }

    [JsonPropertyName("workBreakdownStructureCode")]
    [Description("\"WBS Code\" accounting field")]
    public string? WorkBreakdownStructureCode { get; init; }

    [JsonPropertyName("note")]
    [Description("The cost code note")]
    public string? Note { get; init; }

    [JsonPropertyName("estimateResources")]
    [Description("The estimate resources")]
    public string? EstimateResources { get; init; }

    [JsonPropertyName("historyCode")]
    [Description("The historical activity code")]
    public string? HistoryCode { get; init; }

    [JsonPropertyName("historicalBidItem")]
    [Description("The historical bid item")]
    public string? HistoricalBidItem { get; init; }

    [JsonPropertyName("heavyBidEstimateCode")]
    [Description("The HeavyBid estimate code")]
    public string? HeavyBidEstimateCode { get; init; }

    [JsonPropertyName("isTM")]
    [Description("The flag indicating whether the cost code is a time-and-material item")]
    public bool? IsTM { get; init; }

    [JsonPropertyName("workType")]
    [Description("The work type")]
    public string? WorkType { get; init; }

    [JsonPropertyName("payItemNumber")]
    [Description("The pay item number")]
    public string? PayItemNumber { get; init; }

    [JsonPropertyName("payItemFactor")]
    [Description("Any costs contributed by this cost code are multiplied by this factor before being applied to its parent pay item")]
    public double? PayItemFactor { get; init; }

    [JsonPropertyName("isPayItemDriver")]
    [Description("Whether this cost code contributes to the cost of its parent pay item")]
    public bool? IsPayItemDriver { get; init; }

    [JsonPropertyName("accountingTemplateName")]
    [Description("The accounting template name")]
    public string? AccountingTemplateName { get; init; }

    [JsonPropertyName("isCapExpected")]
    [Description("The flag indicating whether to set the cost code to cap expected")]
    public bool? IsCapExpected { get; init; }

    [JsonPropertyName("isHiddenFromMobile")]
    [Description("The flag indicating whether cost code is hidden from mobile")]
    public bool? IsHiddenFromMobile { get; init; }
}

public class DisTag
{
    [JsonPropertyName("group")]
    public string Group { get; init; } = string.Empty;

    [JsonPropertyName("tag")]
    public string Tag { get; init; } = string.Empty;

    [JsonPropertyName("tagDescription")]
    public string TagDescription { get; init; } = string.Empty;

    [JsonPropertyName("id")]
    public Guid Id { get; init; }
}