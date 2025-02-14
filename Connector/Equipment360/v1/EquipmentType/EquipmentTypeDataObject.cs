namespace Connector.Equipment360.v1.EquipmentType;

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
[PrimaryKey("equipmentTypeID", nameof(EquipmentTypeId))]
[Description("Represents an equipment type configuration")]
public class EquipmentTypeDataObject
{
    [JsonPropertyName("equipmentTypeID")]
    [Description("The equipment type integer ID")]
    [Required]
    public required int EquipmentTypeId { get; init; }

    [JsonPropertyName("name")]
    [Description("The equipment type name")]
    public string? Name { get; init; }

    [JsonPropertyName("description")]
    [Description("The equipment type description")]
    public string? Description { get; init; }

    [JsonPropertyName("longDescription")]
    [Description("The equipment type long description")]
    public string? LongDescription { get; init; }

    [JsonPropertyName("budget")]
    [Description("The equipment type budget")]
    public double Budget { get; init; }

    [JsonPropertyName("utilizedHoursPerYear")]
    [Description("The equipment type utilized hours per year")]
    public int UtilizedHoursPerYear { get; init; }

    [JsonPropertyName("utilizedMilesPerYear")]
    [Description("The equipment type utilized miles per year")]
    public int UtilizedMilesPerYear { get; init; }

    [JsonPropertyName("replacementCycleYears")]
    [Description("The equipment type replacement cycle years")]
    public double ReplacementCycleYears { get; init; }

    [JsonPropertyName("sweetSpotK")]
    [Description("The equipment type sweet spot K")]
    public double SweetSpotK { get; init; }

    [JsonPropertyName("sweetSpotEx")]
    [Description("The equipment type sweet spot ex")]
    public double SweetSpotEx { get; init; }

    [JsonPropertyName("billingRate")]
    [Description("The equipment type billing rate")]
    public double BillingRate { get; init; }

    [JsonPropertyName("avgOperatingCostPerHour")]
    [Description("The equipment type average operating cost per hour")]
    public double AvgOperatingCostPerHour { get; init; }

    [JsonPropertyName("avgOperatingCostPerOdometer")]
    [Description("The equipment type average operating cost per odometer")]
    public double AvgOperatingCostPerOdometer { get; init; }
}