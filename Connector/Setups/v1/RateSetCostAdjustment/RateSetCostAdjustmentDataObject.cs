namespace Connector.Setups.v1.RateSetCostAdjustment;

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
[Description("Represents a cost adjustment rate set in HCSS")]
public class RateSetCostAdjustmentDataObject
{
    [JsonPropertyName("businessUnitCode")]
    [Description("Gets the business unit code")]
    [Required]
    public required string BusinessUnitCode { get; init; }

    [JsonPropertyName("costAdjustmentRates")]
    [Description("Gets the cost adjustment rates")]
    public CostAdjustmentRate[]? CostAdjustmentRates { get; init; }

    [JsonPropertyName("effectiveDate")]
    [Description("Gets the effective date")]
    public DateTime? EffectiveDate { get; init; }

    [JsonPropertyName("rateSetGroupCode")]
    [Description("Gets the rate set group code, used to uniquely identify this rate set")]
    [Required]
    public required string RateSetGroupCode { get; init; }

    [JsonPropertyName("rateSetGroupDescription")]
    [Description("Gets the rate set group description")]
    public string? RateSetGroupDescription { get; init; }

    [JsonPropertyName("id")]
    [Description("The Id of the rate set")]
    public Guid? Id { get; init; }
}

public class CostAdjustmentRate
{
    [JsonPropertyName("costAdjustmentCode")]
    [Description("The cost adjustment code for which these rates should apply")]
    [Required]
    public required string CostAdjustmentCode { get; init; }

    [JsonPropertyName("rateType")]
    [Description("The rate type")]
    [Required]
    public required string RateType { get; init; }

    [JsonPropertyName("rate")]
    [Description("The rate, usually in dollars per hour")]
    [Required]
    public required double Rate { get; init; }

    [JsonPropertyName("taxPercent")]
    [Description("Gets the tax percent")]
    [Required]
    public required double TaxPercent { get; init; }

    [JsonPropertyName("id")]
    [Description("The Id of the rate")]
    public Guid? Id { get; init; }
}