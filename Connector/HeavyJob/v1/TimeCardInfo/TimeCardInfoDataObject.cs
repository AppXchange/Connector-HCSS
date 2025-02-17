namespace Connector.HeavyJob.v1.TimeCardInfo;

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
[Description("Represents a time card summary in HeavyJob")]
public class TimeCardInfoDataObject
{
    [JsonPropertyName("id")]
    [Description("The time card guid")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("foremanId")]
    [Description("The foreman guid")]
    [Required]
    public required Guid ForemanId { get; init; }

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

    [JsonPropertyName("lockedDateTime")]
    [Description("The date time when this time card was locked (submitted)")]
    public DateTime? LockedDateTime { get; init; }

    [JsonPropertyName("sentToPayrollDateTime")]
    [Description("The RFC 3339 dateTime, in UTC, when this time card sent to payroll")]
    public DateTime? SentToPayrollDateTime { get; init; }

    [JsonPropertyName("sentToPayrollRevision")]
    [Description("The revision of the time card sent to payroll")]
    public int? SentToPayrollRevision { get; init; }

    [JsonPropertyName("isApproved")]
    [Description("Whether the time card is approved")]
    [Required]
    public required bool IsApproved { get; init; }
}