namespace Connector.Equipment360.v1.MaintenanceRequest.Create;

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
[Description("Creates a new maintenance request")]
public class CreateMaintenanceRequestAction : IStandardAction<CreateMaintenanceRequestActionInput, MaintenanceRequestDataObject>
{
    public CreateMaintenanceRequestActionInput ActionInput { get; set; } = new()
    {
        Description = string.Empty,
        Source = string.Empty
    };
    public MaintenanceRequestDataObject ActionOutput { get; set; } = new() 
    { 
        Id = Guid.Empty,
        Description = string.Empty,
        Source = string.Empty
    };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateMaintenanceRequestActionInput
{
    [JsonPropertyName("description")]
    [Description("Description of the Maintenance Request")]
    [Required]
    public required string Description { get; init; }

    [JsonPropertyName("equipmentCode")]
    [Description("The unique equipment code (required if there is no equipment id)")]
    public string? EquipmentCode { get; init; }

    [JsonPropertyName("equipmentId")]
    [Description("The equipment id (required if there is no equipment code)")]
    public Guid? EquipmentId { get; init; }

    [JsonPropertyName("jobId")]
    [Description("(optional) Job Id")]
    public Guid? JobId { get; init; }

    [JsonPropertyName("jobCode")]
    [Description("(optional) Job Code(will use job code only if job id is not provided)")]
    public string? JobCode { get; init; }

    [JsonPropertyName("priorityId")]
    [Description("(optional) Priority Id")]
    public Guid? PriorityId { get; init; }

    [JsonPropertyName("pointOfContactName")]
    [Description("(optional) Point of contact name")]
    public string? PointOfContactName { get; init; }

    [JsonPropertyName("pointOfContactPhoneNumber")]
    [Description("(optional) Point of contact phone number")]
    public string? PointOfContactPhoneNumber { get; init; }

    [JsonPropertyName("source")]
    [Description("Client app submitting the maintenance request")]
    [Required]
    public required string Source { get; init; }

    [JsonPropertyName("requestedBy")]
    [Description("Person that made the request")]
    public string? RequestedBy { get; init; }

    [JsonPropertyName("attachments")]
    [Description("Photo attachments (maximum of 3 files, 10MB each)")]
    public AttachmentCreate[]? Attachments { get; init; }
}

public class AttachmentCreate
{
    [JsonPropertyName("imageAsBase64")]
    public string? ImageAsBase64 { get; init; }

    [JsonPropertyName("imageFileName")]
    public string? ImageFileName { get; init; }
}
