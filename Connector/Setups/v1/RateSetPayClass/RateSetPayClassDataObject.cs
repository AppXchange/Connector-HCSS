namespace Connector.Setups.v1.RateSetPayClass;

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
[Description("Represents a pay class rate set in HCSS")]
public class RateSetPayClassDataObject
{
    [JsonPropertyName("businessUnitCode")]
    [Description("Gets the business unit code")]
    [Required]
    public required string BusinessUnitCode { get; init; }

    [JsonPropertyName("payClassRates")]
    [Description("Gets the pay class rates")]
    public PayClassRate[]? PayClassRates { get; init; }

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
    [Required]
    public required Guid Id { get; init; }
}

public class PayClassRate
{
    [JsonPropertyName("payClassCode")]
    [Description("The pay class code")]
    [Required]
    public required string PayClassCode { get; init; }

    [JsonPropertyName("shift")]
    [Description("The shift number")]
    public int Shift { get; init; }

    [JsonPropertyName("baseRate")]
    [Description("The base rate")]
    public double BaseRate { get; init; }

    [JsonPropertyName("overtimeFactor")]
    [Description("The overtime factor")]
    public double OvertimeFactor { get; init; }

    [JsonPropertyName("doubleOvertimeFactor")]
    [Description("The double overtime factor")]
    public double DoubleOvertimeFactor { get; init; }

    [JsonPropertyName("fringeRateWithPremium")]
    [Description("The fringe rate with premium")]
    public double FringeRateWithPremium { get; init; }

    [JsonPropertyName("fringeRateWithoutPremium")]
    [Description("The fringe rate without premium")]
    public double FringeRateWithoutPremium { get; init; }

    [JsonPropertyName("taxPercent")]
    [Description("The tax percent")]
    public double TaxPercent { get; init; }

    [JsonPropertyName("id")]
    [Description("The Id of the rate")]
    public Guid? Id { get; init; }
}