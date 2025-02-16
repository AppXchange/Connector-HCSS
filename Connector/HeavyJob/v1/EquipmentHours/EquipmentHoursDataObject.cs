namespace Connector.HeavyJob.v1.EquipmentHours;

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
[PrimaryKey("equipment.equipmentId", "Equipment.EquipmentId")]
[Description("Equipment time card hours in HeavyJob")]
public class EquipmentHoursDataObject
{
    [JsonPropertyName("equipment")]
    [Description("Equipment information")]
    [Required]
    public EquipmentInfo Equipment { get; init; } = new();

    [JsonPropertyName("foreman")]
    [Description("Foreman information")]
    [Required]
    public EmployeeInfo Foreman { get; init; } = new();

    [JsonPropertyName("job")]
    [Description("Job information")]
    [Required]
    public JobInfo Job { get; init; } = new();

    [JsonPropertyName("date")]
    [Description("The date")]
    public DateTime Date { get; init; }

    [JsonPropertyName("notes")]
    [Description("The notes")]
    public string? Notes { get; init; }

    [JsonPropertyName("startTime")]
    [Description("The schedule's start time")]
    public string? StartTime { get; init; }

    [JsonPropertyName("endTime")]
    [Description("The schedule's end time")]
    public string? EndTime { get; init; }

    [JsonPropertyName("meterStart")]
    [Description("The meter start")]
    public double MeterStart { get; init; }

    [JsonPropertyName("meterStop")]
    [Description("The meter stop")]
    public double MeterStop { get; init; }

    [JsonPropertyName("engineOffDuration")]
    [Description("The amount of engine-off duration")]
    public string? EngineOffDuration { get; init; }

    [JsonPropertyName("timeCardShift")]
    [Description("The time card shift")]
    public int TimeCardShift { get; init; }

    [JsonPropertyName("timeCardRevision")]
    [Description("The time card revision")]
    public int TimeCardRevision { get; init; }

    [JsonPropertyName("hoursDetails")]
    [Description("The equipment hours detail")]
    public HoursDetail[]? HoursDetails { get; init; }

    [JsonPropertyName("gpsId")]
    [Description("The GPS ID")]
    public string? GpsId { get; init; }

    [JsonPropertyName("rowOrder")]
    [Description("The slot on the time card")]
    public int RowOrder { get; init; }

    [JsonPropertyName("linkedEmployee")]
    [Description("Linked employee information")]
    public LinkedEmployeeInfo? LinkedEmployee { get; init; }

    [JsonPropertyName("linkedEmployeeRowOrder")]
    [Description("The linked employee slot on the timecard")]
    public int? LinkedEmployeeRowOrder { get; init; }

    [JsonPropertyName("equipmentType")]
    [Description("Equipment type information")]
    public EquipmentTypeInfo? EquipmentType { get; init; }
}

public class EquipmentInfo
{
    [JsonPropertyName("equipmentId")]
    public Guid EquipmentId { get; init; }

    [JsonPropertyName("equipmentCode")]
    public string? EquipmentCode { get; init; }

    [JsonPropertyName("equipmentDescription")]
    public string? EquipmentDescription { get; init; }

    [JsonPropertyName("isRental")]
    public bool IsRental { get; init; }
}

public class EmployeeInfo
{
    [JsonPropertyName("employeeId")]
    public Guid EmployeeId { get; init; }

    [JsonPropertyName("employeeCode")]
    public string? EmployeeCode { get; init; }

    [JsonPropertyName("employeeFirstName")]
    public string? EmployeeFirstName { get; init; }

    [JsonPropertyName("employeeLastName")]
    public string? EmployeeLastName { get; init; }
}

public class JobInfo
{
    [JsonPropertyName("jobId")]
    public Guid JobId { get; init; }

    [JsonPropertyName("jobCode")]
    public string? JobCode { get; init; }

    [JsonPropertyName("jobDescription")]
    public string? JobDescription { get; init; }
}

public class HoursDetail
{
    [JsonPropertyName("costCode")]
    public CostCodeInfo CostCode { get; init; } = new();

    [JsonPropertyName("totalHours")]
    public double TotalHours { get; init; }

    [JsonPropertyName("ownershipHours")]
    public double OwnershipHours { get; init; }

    [JsonPropertyName("operatingHours")]
    public double OperatingHours { get; init; }

    [JsonPropertyName("hourTag")]
    public HourTagInfo? HourTag { get; init; }

    [JsonPropertyName("isInTimeCardHours")]
    public bool IsInTimeCardHours { get; init; }

    [JsonPropertyName("isCosted")]
    public bool IsCosted { get; init; }
}

public class CostCodeInfo
{
    [JsonPropertyName("costCodeId")]
    public Guid CostCodeId { get; init; }

    [JsonPropertyName("costCodeCode")]
    public string? CostCodeCode { get; init; }

    [JsonPropertyName("costCodeDescription")]
    public string? CostCodeDescription { get; init; }
}

public class HourTagInfo
{
    [JsonPropertyName("hourTagId")]
    public Guid HourTagId { get; init; }

    [JsonPropertyName("hourTagCode")]
    public string? HourTagCode { get; init; }

    [JsonPropertyName("hourTagDescription")]
    public string? HourTagDescription { get; init; }
}

public class LinkedEmployeeInfo
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("code")]
    public string? Code { get; init; }

    [JsonPropertyName("firstName")]
    public string? FirstName { get; init; }

    [JsonPropertyName("lastName")]
    public string? LastName { get; init; }
}

public class EquipmentTypeInfo
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("code")]
    public string? Code { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }
}

public class EquipmentHoursResponse
{
    [JsonPropertyName("results")]
    [Required]
    public EquipmentHoursDataObject[] Results { get; init; } = Array.Empty<EquipmentHoursDataObject>();

    [JsonPropertyName("metadata")]
    [Required]
    public EquipmentHoursMetadata Metadata { get; init; } = new();
}

public class EquipmentHoursMetadata
{
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; init; }
}