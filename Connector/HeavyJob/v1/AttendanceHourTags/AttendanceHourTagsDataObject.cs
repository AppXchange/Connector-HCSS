namespace Connector.HeavyJob.v1.AttendanceHourTags;

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
[Description("Represents an employee attendance hour tag in HeavyJob")]
public class AttendanceHourTagsDataObject
{
    [JsonPropertyName("id")]
    [Description("The attendance hour tag id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("code")]
    [Description("The code")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("description")]
    [Description("The description")]
    public string? Description { get; init; }

    [JsonPropertyName("regularTimeDescription")]
    [Description("The regular-time description")]
    public string? RegularTimeDescription { get; init; }

    [JsonPropertyName("overtimeDescription")]
    [Description("The overtime description")]
    public string? OvertimeDescription { get; init; }

    [JsonPropertyName("doubleOvertimeDescription")]
    [Description("The double overtime description")]
    public string? DoubleOvertimeDescription { get; init; }

    [JsonPropertyName("applyCost")]
    [Description("How to apply cost")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ApplyCostType ApplyCost { get; init; }

    [JsonPropertyName("affectsOvertimeCalculation")]
    [Description("Whether the non-work hour code will be used in the Timecard Tool's overtime calculation")]
    public bool AffectsOvertimeCalculation { get; init; }

    [JsonPropertyName("includeInHourTotal")]
    [Description("Whether hours with this tag should be included in the total time card hours calculation")]
    public bool IncludeInHourTotal { get; init; }
}

public enum ApplyCostType
{
    Undefined,
    NoCost,
    TotalCost,
    OwnershipCost,
    OperatingCost
}