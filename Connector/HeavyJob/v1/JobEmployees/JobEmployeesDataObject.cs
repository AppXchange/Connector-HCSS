namespace Connector.HeavyJob.v1.JobEmployees;

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
[Description("Represents a job-employee relationship in HeavyJob")]
public class JobEmployeesDataObject
{
    [JsonPropertyName("id")]
    [Description("The job-employee relationship id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit id")]
    [Required] 
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("businessUnitCode")]
    [Description("The business unit code")]
    [Required]
    public required string BusinessUnitCode { get; init; }

    [JsonPropertyName("jobId")]
    [Description("The job id")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("jobCode")]
    [Description("The job code")]
    [Required]
    public required string JobCode { get; init; }

    [JsonPropertyName("employeeId")]
    [Description("The employee id")]
    [Required]
    public required Guid EmployeeId { get; init; }

    [JsonPropertyName("employeeCode")]
    [Description("The employee code")]
    [Required]
    public required string EmployeeCode { get; init; }

    [JsonPropertyName("employeeFirstName")]
    [Description("The employee first name")]
    [Required]
    public required string EmployeeFirstName { get; init; }

    [JsonPropertyName("employeeLastName")]
    [Description("The employee last name")]
    [Required]
    public required string EmployeeLastName { get; init; }

    [JsonPropertyName("defaultPayClassId")]
    [Description("The pay class id for the employee on the job")]
    public Guid? DefaultPayClassId { get; init; }

    [JsonPropertyName("defaultPayClassCode")]
    [Description("The pay class code for the employee on the job")]
    public string? DefaultPayClassCode { get; init; }

    [JsonPropertyName("defaultPayClassDescription")]
    [Description("The pay class description for the employee on the job")]
    public string? DefaultPayClassDescription { get; init; }

    [JsonPropertyName("assignedEquipmentId")]
    [Description("The assigned equipment id")]
    public Guid? AssignedEquipmentId { get; init; }

    [JsonPropertyName("assignedEquipmentCode")]
    [Description("The assigned equipment code")]
    public string? AssignedEquipmentCode { get; init; }

    [JsonPropertyName("assignedEquipmentDescription")]
    [Description("The assigned equipment description")]
    public string? AssignedEquipmentDescription { get; init; }

    [JsonPropertyName("isActive")]
    [Description("The isActive status")]
    public bool? IsActive { get; init; }

    [JsonPropertyName("costAdjustmentStatus")]
    [Description("The cost adjustment status")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CostAdjustmentStatus CostAdjustmentStatus { get; init; }
}

public enum CostAdjustmentStatus
{
    UseDefault,
    None,
    Override
}