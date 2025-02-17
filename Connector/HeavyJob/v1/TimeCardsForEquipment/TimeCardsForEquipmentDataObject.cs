namespace Connector.HeavyJob.v1.TimeCardsForEquipment;

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
[PrimaryKey("timeCardId", nameof(TimeCardId))]
[Description("Represents time card data for equipment usage in HeavyJob")]
public class TimeCardsForEquipmentDataObject
{
    [JsonPropertyName("date")]
    [Description("The time card date")]
    public DateTime? Date { get; init; }

    [JsonPropertyName("timeCardId")]
    [Description("The time card id")]
    [Required]
    public required Guid TimeCardId { get; init; }

    [JsonPropertyName("jobId")]
    [Description("The job id")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("jobCode")]
    [Description("The job code")]
    public string? JobCode { get; init; }

    [JsonPropertyName("jobDescription")]
    [Description("The job description")]
    public string? JobDescription { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit id")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("businessUnitCode")]
    [Description("The business unit code")]
    public string? BusinessUnitCode { get; init; }

    [JsonPropertyName("foreman")]
    [Description("A POCO that represents an employee's basic information")]
    [Required]
    public required EmployeeCompactRead Foreman { get; init; }

    [JsonPropertyName("operators")]
    [Description("The operator that was linked to the equipment for the time card")]
    public EmployeeCompactRead[]? Operators { get; init; }
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