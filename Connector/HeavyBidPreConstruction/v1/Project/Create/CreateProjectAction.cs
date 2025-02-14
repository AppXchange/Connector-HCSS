namespace Connector.HeavyBidPreConstruction.v1.Project.Create;

using Json.Schema.Generation;
using System;
using System.Collections.Generic;
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
[Description("Creates a new project in HeavyBid Pre-Construction")]
public class CreateProjectAction : IStandardAction<CreateProjectActionInput, CreateProjectActionOutput>
{
    public CreateProjectActionInput ActionInput { get; set; } = new() { Fields = new() };
    public CreateProjectActionOutput ActionOutput { get; set; } = new() 
    { 
        Id = Guid.Empty,
        LastModified = DateTime.UtcNow,
        Deleted = false,
        Fields = new(),
        Archived = false
    };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateProjectActionInput
{
    [JsonPropertyName("id")]
    [Description("Optional - The unique Id of the project")]
    public Guid? Id { get; init; }

    [JsonPropertyName("fields")]
    [Description("Project fields from schema")]
    [Required]
    public required Dictionary<string, object> Fields { get; init; }

    [JsonPropertyName("fieldsMetadata")]
    [Description("Metadata for project fields")]
    public Dictionary<string, object>? FieldsMetadata { get; init; }

    [JsonPropertyName("locationId")]
    [Description("Optional - The Location Id (HeavyJob) linked to the project")]
    public Guid? LocationId { get; init; }
}

public class CreateProjectActionOutput
{
    [JsonPropertyName("id")]
    [Description("The unique identifier for the project")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("lastModifiedByUserId")]
    [Description("The last modified user Id of the project")]
    public string? LastModifiedByUserId { get; init; }

    [JsonPropertyName("lastModifiedByClientId")]
    [Description("The last modified client_id")]
    public string? LastModifiedByClientId { get; init; }

    [JsonPropertyName("lastModifiedBySystemUser")]
    [Description("Indicates if entity was last modified by system user")]
    public bool LastModifiedBySystemUser { get; init; }

    [JsonPropertyName("dateCreated")]
    [Description("The created date of the project")]
    public DateTime DateCreated { get; init; }

    [JsonPropertyName("lastModified")]
    [Description("The last modified date of the project")]
    [Required]
    public required DateTime LastModified { get; init; }

    [JsonPropertyName("deleted")]
    [Description("Whether the project is deleted")]
    [Required]
    public required bool Deleted { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The Business Unit Id the project belongs to")]
    public Guid? BusinessUnitId { get; init; }

    [JsonPropertyName("fields")]
    [Description("Project fields from schema")]
    [Required]
    public required Dictionary<string, object> Fields { get; init; }

    [JsonPropertyName("fieldsMetadata")]
    [Description("Metadata for project fields")]
    public Dictionary<string, object>? FieldsMetadata { get; init; }

    [JsonPropertyName("locationId")]
    [Description("The Location Id (HeavyJob) linked to the project")]
    public Guid? LocationId { get; init; }

    [JsonPropertyName("archived")]
    [Description("Whether the project is archived")]
    [Required]
    public required bool Archived { get; init; }

    [JsonPropertyName("warnings")]
    [Description("Project field warnings")]
    public IEnumerable<ProjectWarning>? Warnings { get; init; }
}

public class ProjectWarning
{
    [JsonPropertyName("fieldId")]
    public string? FieldId { get; init; }

    [JsonPropertyName("fieldName")]
    public string? FieldName { get; init; }

    [JsonPropertyName("message")]
    public string? Message { get; init; }

    [JsonPropertyName("warningValue")]
    public object? WarningValue { get; init; }
}
