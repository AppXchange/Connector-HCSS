namespace Connector.HeavyJob.v1.TimeCardApproval;

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
[Description("Represents a time card approval in HeavyJob")]
public class TimeCardApprovalDataObject
{
    [JsonPropertyName("id")]
    [Description("The time card guid")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("foreman")]
    [Description("A POCO that represents an employee's basic information")]
    public EmployeeCompactRead? Foreman { get; init; }

    [JsonPropertyName("jobId")]
    [Description("The job guid")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit guid")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("date")]
    [Description("The time card date")]
    [Required]
    public required DateTime Date { get; init; }

    [JsonPropertyName("revision")]
    [Description("The current revision of the time card")]
    [Required]
    public required int Revision { get; init; }

    [JsonPropertyName("shift")]
    [Description("The time card shift")]
    [Required]
    public required int Shift { get; init; }

    [JsonPropertyName("lastModifiedDateTime")]
    [Description("The RFC 3339 dateTime, in UTC, when this time card was last modified")]
    [Required]
    public required DateTime LastModifiedDateTime { get; init; }

    [JsonPropertyName("lastModifiedPreciseDateTime")]
    [Description("The RFC 3339 dateTime (including fractional seconds), in UTC, when this time card was last modified")]
    [Required]
    public required DateTime LastModifiedPreciseDateTime { get; init; }

    [JsonPropertyName("sentToPayrollDateTime")]
    [Description("In UTC, when this time card sent to payroll")]
    public DateTime? SentToPayrollDateTime { get; init; }

    [JsonPropertyName("sentToPayrollRevision")]
    [Description("The revision of the time card sent to payroll")]
    public int? SentToPayrollRevision { get; init; }

    [JsonPropertyName("lockedDateTime")]
    [Description("In UTC, when this time card was locked")]
    [Required]
    public required DateTime LockedDateTime { get; init; }

    [JsonPropertyName("isApproved")]
    [Description("Whether the time card is approved")]
    [Required]
    public required bool IsApproved { get; init; }

    [JsonPropertyName("lastChangedById")]
    [Description("Guid of user who last changed the time card")]
    [Required]
    public required Guid LastChangedById { get; init; }

    [JsonPropertyName("lastChangedByName")]
    [Description("Name of user who last changed the time card")]
    public string? LastChangedByName { get; init; }

    [JsonPropertyName("lastPreparedById")]
    [Description("Guid of user who last prepared the time card")]
    [Required]
    public required Guid LastPreparedById { get; init; }

    [JsonPropertyName("lastPreparedByName")]
    [Description("Name of user who last prepared the time card")]
    public string? LastPreparedByName { get; init; }

    [JsonPropertyName("isReviewed")]
    [Description("Whether the time card is reviewed")]
    [Required]
    public required bool IsReviewed { get; init; }

    [JsonPropertyName("isAccepted")]
    [Description("Whether the time card is accepted")]
    [Required]
    public required bool IsAccepted { get; init; }

    [JsonPropertyName("isRejected")]
    [Description("Whether the time card is rejected")]
    [Required]
    public required bool IsRejected { get; init; }

    [JsonPropertyName("isSentToPayroll")]
    [Description("Whether the time card is sent to payroll")]
    [Required]
    public required bool IsSentToPayroll { get; init; }

    [JsonPropertyName("approvedDateTime")]
    [Description("In UTC, when this time card was approved")]
    [Required]
    public required DateTime ApprovedDateTime { get; init; }

    [JsonPropertyName("approvedBy")]
    [Description("A POCO that represents an employee's basic information")]
    public EmployeeCompactRead? ApprovedBy { get; init; }

    [JsonPropertyName("reviewedDateTime")]
    [Description("In UTC, when this time card was reviewed")]
    [Required]
    public required DateTime ReviewedDateTime { get; init; }

    [JsonPropertyName("reviewedBy")]
    [Description("A POCO that represents an employee's basic information")]
    public EmployeeCompactRead? ReviewedBy { get; init; }

    [JsonPropertyName("acceptedDateTime")]
    [Description("In UTC, when this time card was accepted")]
    [Required]
    public required DateTime AcceptedDateTime { get; init; }

    [JsonPropertyName("acceptedBy")]
    [Description("A POCO that represents an employee's basic information")]
    public EmployeeCompactRead? AcceptedBy { get; init; }

    [JsonPropertyName("rejectedDateTime")]
    [Description("In UTC, when this time card was rejected")]
    [Required]
    public required DateTime RejectedDateTime { get; init; }

    [JsonPropertyName("rejectedBy")]
    [Description("A POCO that represents an employee's basic information")]
    public EmployeeCompactRead? RejectedBy { get; init; }
}

public class EmployeeCompactRead
{
    [JsonPropertyName("employeeId")]
    [Description("The employee guid")]
    [Required]
    public required Guid EmployeeId { get; init; }

    [JsonPropertyName("employeeCode")]
    [Description("The employee's code")]
    [Required]
    public required string EmployeeCode { get; init; }

    [JsonPropertyName("employeeFirstName")]
    [Description("The employee's first name")]
    [Required]
    public required string EmployeeFirstName { get; init; }

    [JsonPropertyName("employeeLastName")]
    [Description("The employee's last name")]
    [Required]
    public required string EmployeeLastName { get; init; }
}