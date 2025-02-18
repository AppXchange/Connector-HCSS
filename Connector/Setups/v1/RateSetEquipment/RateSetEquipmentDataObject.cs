namespace Connector.Setups.v1.RateSetEquipment;

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
[Description("Represents an equipment rate set in HCSS")]
public class RateSetEquipmentDataObject
{
    [JsonPropertyName("businessUnitCode")]
    [Description("Gets the business unit code")]
    [Required]
    public required string BusinessUnitCode { get; init; }

    [JsonPropertyName("equipmentRates")]
    [Description("The underlying EquipmentRates")]
    public EquipmentRate[]? EquipmentRates { get; init; }

    [JsonPropertyName("effectiveDate")]
    [Description("The DateTime from which these equipment rates become effective")]
    public DateTime? EffectiveDate { get; init; }

    [JsonPropertyName("rateSetGroupCode")]
    [Description("Gets the rate set group code, used to identify this particular rate set")]
    [Required]
    public required string RateSetGroupCode { get; init; }

    [JsonPropertyName("rateSetGroupDescription")]
    [Description("Gets the rate set group description")]
    public string? RateSetGroupDescription { get; init; }

    [JsonPropertyName("id")]
    [Description("The Id of the rate set")]
    public Guid? Id { get; init; }
}

public class EquipmentRate
{
    [JsonPropertyName("equipmentCode")]
    [Description("The equipment code for which the rates below should apply")]
    [Required]
    public required string EquipmentCode { get; init; }

    [JsonPropertyName("totalRate")]
    [Description("The total rate, usually specified in dollars per hour. This field is ignored if the OperatingRate or the OwnershipRate are set")]
    public double? TotalRate { get; init; }

    [JsonPropertyName("operatingRate")]
    [Description("The operating rate, usually specified in dollars per hour. (e.g., the cost of the equipment while it is operating)")]
    public double? OperatingRate { get; init; }

    [JsonPropertyName("ownershipRate")]
    [Description("The ownership rate, usually specified in dollars per hour. (e.g., the cost of the equipment rental, amortized over time. The ownership rate is applied even if the equipment is idle")]
    public double? OwnershipRate { get; init; }

    [JsonPropertyName("id")]
    [Description("The Id of the rate")]
    public Guid? Id { get; init; }
}