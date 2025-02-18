namespace Connector.Setups.v1.RateSet;

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
[Description("Represents an employee rate set in HCSS")]
public class RateSetDataObject
{
    [JsonPropertyName("businessUnitCode")]
    [Description("Gets the business unit code")]
    [Required]
    public required string BusinessUnitCode { get; init; }

    [JsonPropertyName("employeeRates")]
    [Description("Gets the employee rates")]
    public EmployeeRate[]? EmployeeRates { get; init; }

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

public class EmployeeRate
{
    [JsonPropertyName("employeeCode")]
    [Description("The employee code for whom the minimum base rate should be applied")]
    [Required]
    public required string EmployeeCode { get; init; }

    [JsonPropertyName("minimumBaseRate")]
    [Description("Gets the minimum base rate for the employee, which is usually in dollars per hour")]
    public double? MinimumBaseRate { get; init; }

    [JsonPropertyName("id")]
    [Description("The Id of the rate")]
    public Guid? Id { get; init; }
}