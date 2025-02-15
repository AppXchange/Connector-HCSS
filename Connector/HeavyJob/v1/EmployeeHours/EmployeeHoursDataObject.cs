namespace Connector.HeavyJob.v1.EmployeeHours;

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
[Description("Employee time card hours and cost adjustments")]
public class EmployeeHoursDataObject
{
    [JsonPropertyName("id")]
    [Description("The unique identifier")]
    [Required]
    public Guid Id { get; init; }

    [JsonPropertyName("employee")]
    [Description("The employee details")]
    [Required]
    public EmployeeInfo Employee { get; init; } = new();

    [JsonPropertyName("foreman")]
    [Description("The foreman details")]
    [Required]
    public EmployeeInfo Foreman { get; init; } = new();

    [JsonPropertyName("job")]
    [Description("The job details")]
    [Required]
    public JobInfo Job { get; init; } = new();

    [JsonPropertyName("payClass")]
    [Description("The pay class details")]
    [Required]
    public PayClassInfo PayClass { get; init; } = new();

    [JsonPropertyName("date")]
    [Description("The time card date")]
    [Required]
    public DateTime Date { get; init; }

    [JsonPropertyName("notes")]
    [Description("Time card notes")]
    public string? Notes { get; init; }

    [JsonPropertyName("startTime")]
    [Description("Start time (HH:mm)")]
    public string StartTime { get; init; } = string.Empty;

    [JsonPropertyName("endTime")]
    [Description("End time (HH:mm)")]
    public string EndTime { get; init; } = string.Empty;

    [JsonPropertyName("timeCardShift")]
    [Description("Time card shift number")]
    public int TimeCardShift { get; init; }

    [JsonPropertyName("timeCardRevision")]
    [Description("Time card revision number")]
    public int TimeCardRevision { get; init; }

    [JsonPropertyName("hoursDetails")]
    [Description("Hours details")]
    public HoursDetail[] HoursDetails { get; init; } = Array.Empty<HoursDetail>();

    [JsonPropertyName("rowOrder")]
    [Description("Row order")]
    public int RowOrder { get; init; }
}

public class EmployeeInfo
{
    [JsonPropertyName("employeeId")]
    public Guid EmployeeId { get; init; }

    [JsonPropertyName("employeeCode")]
    public string EmployeeCode { get; init; } = string.Empty;

    [JsonPropertyName("employeeFirstName")]
    public string EmployeeFirstName { get; init; } = string.Empty;

    [JsonPropertyName("employeeLastName")]
    public string EmployeeLastName { get; init; } = string.Empty;
}

public class JobInfo
{
    [JsonPropertyName("jobId")]
    public Guid JobId { get; init; }

    [JsonPropertyName("jobCode")]
    public string JobCode { get; init; } = string.Empty;

    [JsonPropertyName("jobDescription")]
    public string JobDescription { get; init; } = string.Empty;
}

public class PayClassInfo
{
    [JsonPropertyName("payClassId")]
    public Guid PayClassId { get; init; }

    [JsonPropertyName("payClassCode")]
    public string PayClassCode { get; init; } = string.Empty;

    [JsonPropertyName("payClassDescription")]
    public string PayClassDescription { get; init; } = string.Empty;
}

public class HoursDetail
{
    [JsonPropertyName("costCode")]
    public CostCodeInfo CostCode { get; init; } = new();

    [JsonPropertyName("regularHours")]
    public decimal RegularHours { get; init; }

    [JsonPropertyName("overtimeHours")]
    public decimal OvertimeHours { get; init; }

    [JsonPropertyName("otherHours")]
    public decimal OtherHours { get; init; }

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
    public string CostCodeCode { get; init; } = string.Empty;

    [JsonPropertyName("costCodeDescription")]
    public string CostCodeDescription { get; init; } = string.Empty;
}

public class HourTagInfo
{
    [JsonPropertyName("hourTagId")]
    public Guid HourTagId { get; init; }

    [JsonPropertyName("hourTagCode")]
    public string HourTagCode { get; init; } = string.Empty;

    [JsonPropertyName("hourTagDescription")]
    public string HourTagDescription { get; init; } = string.Empty;
}

public class EmployeeHoursResponse
{
    [JsonPropertyName("results")]
    [Required]
    public EmployeeHoursDataObject[] Results { get; init; } = Array.Empty<EmployeeHoursDataObject>();

    [JsonPropertyName("metadata")]
    [Required]
    public EmployeeHoursMetadata Metadata { get; init; } = new();
}

public class EmployeeHoursMetadata
{
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; init; }
}