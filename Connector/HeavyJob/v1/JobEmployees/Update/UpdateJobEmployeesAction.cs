namespace Connector.HeavyJob.v1.JobEmployees.Update;

using Json.Schema.Generation;
using System;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.Action;

/// <summary>
/// Action object that will represent an action in the Xchange system. This will contain an input object type,
/// an output object type, and a Action failure type (this will default to <see cref="StandardActionFailure"/>
/// but that can be overridden with your own preferred type). These objects will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// These types will be used for validation at runtime to make sure the objects being passed through the system 
/// are properly formed. The schema also helps provide integrators more information for what the values 
/// are intended to be.
/// </summary>
[Description("Creates and updates job-employee relationships")]
public class UpdateJobEmployeesAction : IStandardAction<UpdateJobEmployeesActionInput, UpdateJobEmployeesActionOutput>
{
    public UpdateJobEmployeesActionInput ActionInput { get; set; } = new() 
    { 
        BusinessUnitId = Guid.Empty,
        Relations = Array.Empty<JobEmployeeRelation>()
    };
    public UpdateJobEmployeesActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class JobEmployeeRelation
{
    [JsonPropertyName("jobId")]
    [Description("The job id")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("employeeId")]
    [Description("The employee id")]
    [Required]
    public required Guid EmployeeId { get; init; }

    [JsonPropertyName("defaultPayClassId")]
    [Description("The pay class id for the employee on the job")]
    public Guid? DefaultPayClassId { get; init; }

    [JsonPropertyName("assignedEquipmentId")]
    [Description("The assigned equipment id")]
    public Guid? AssignedEquipmentId { get; init; }
}

public class UpdateJobEmployeesActionInput
{
    [JsonPropertyName("businessUnitId")]
    [Description("The business unit ID")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("relations")]
    [Description("The list of job-employee relations to be created or updated")]
    [Required]
    [MinLength(1)]
    [MaxLength(100)]
    public required JobEmployeeRelation[] Relations { get; init; }
}

public class UpdateJobEmployeesActionOutput
{
    [JsonPropertyName("success")]
    [Description("Whether the update was successful")]
    public bool Success { get; init; }
}
