namespace Connector.HeavyJob.v1.JobEquipment.Update;

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
[Description("Creates and updates job-equipment relationships")]
public class UpdateJobEquipmentAction : IStandardAction<UpdateJobEquipmentActionInput, UpdateJobEquipmentActionOutput>
{
    public UpdateJobEquipmentActionInput ActionInput { get; set; } = new() { 
        BusinessUnitId = Guid.Empty,
        Relations = Array.Empty<JobEquipmentRelation>()
        };
    public UpdateJobEquipmentActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class JobEquipmentRelation
{
    [JsonPropertyName("jobId")]
    [Description("The job id")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("equipmentId")]
    [Description("The equipment id")]
    [Required]
    public required Guid EquipmentId { get; init; }

    [JsonPropertyName("operatorPayClassId")]
    [Description("The equipment operator pay class id")]
    public Guid? OperatorPayClassId { get; init; }
}

public class UpdateJobEquipmentActionInput
{
    [JsonPropertyName("businessUnitId")]
    [Description("The business unit ID")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("relations")]
    [Description("The list of job-equipment relations to be created or updated")]
    [Required]
    [MinLength(1)]
    [MaxLength(100)]
    public required JobEquipmentRelation[] Relations { get; init; } = Array.Empty<JobEquipmentRelation>();
}

public class UpdateJobEquipmentActionOutput
{
    [JsonPropertyName("success")]
    [Description("Whether the update was successful")]
    public bool Success { get; init; }
}
