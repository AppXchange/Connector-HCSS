namespace Connector.HeavyJob.v1.Equipment.Create;

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
[Description("Get equipment with advanced filtering options")]
public class CreateEquipmentAction : IStandardAction<CreateEquipmentActionInput, CreateEquipmentActionOutput>
{
    public CreateEquipmentActionInput ActionInput { get; set; } = new();
    public CreateEquipmentActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateEquipmentActionInput
{
    [JsonPropertyName("businessUnitId")]
    [Description("The business unit id")]
    [Required]
    public Guid BusinessUnitId { get; init; }

    [JsonPropertyName("equipmentCodes")]
    [Description("List of equipment codes")]
    public string[]? EquipmentCodes { get; init; }

    [JsonPropertyName("equipmentIds")]
    [Description("List of equipment ids")]
    public Guid[]? EquipmentIds { get; init; }

    [JsonPropertyName("jobIds")]
    [Description("List of job ids")]
    public Guid[]? JobIds { get; init; }

    [JsonPropertyName("jobTagIds")]
    [Description("List of job tag ids")]
    public Guid[]? JobTagIds { get; init; }

    [JsonPropertyName("accountingTemplateName")]
    [Description("The accounting template name")]
    public string? AccountingTemplateName { get; init; }

    [JsonPropertyName("isActive")]
    [Description("The active flag")]
    public bool? IsActive { get; init; }

    [JsonPropertyName("isActiveInAnyActiveJobs")]
    [Description("The flag to filter equipment to the active status in any of the active jobs")]
    public bool? IsActiveInAnyActiveJobs { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("The soft-deleted flag")]
    public bool? IsDeleted { get; init; }

    [JsonPropertyName("cursor")]
    [Description("When there are additional results, the metadata nextCursor field should be passed to retrieve the next page of results")]
    public string? Cursor { get; init; }

    [JsonPropertyName("limit")]
    [Description("The maximum number of results that should be returned")]
    public int? Limit { get; init; }
}

public class CreateEquipmentActionOutput
{
    [JsonPropertyName("results")]
    [Required]
    public EquipmentDataObject[] Results { get; init; } = Array.Empty<EquipmentDataObject>();

    [JsonPropertyName("metadata")]
    [Required]
    public EquipmentMetadata Metadata { get; init; } = new();
}

public class EquipmentMetadata
{
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; init; }
}
