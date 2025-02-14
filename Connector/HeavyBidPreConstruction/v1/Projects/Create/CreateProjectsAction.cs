namespace Connector.HeavyBidPreConstruction.v1.Projects.Create;

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
[Description("Creates multiple projects in HeavyBid Pre-Construction")]
public class CreateProjectsAction : IStandardAction<CreateProjectsActionInput, CreateProjectsActionOutput>
{
    public CreateProjectsActionInput ActionInput { get; set; } = new() { Projects = new() };
    public CreateProjectsActionOutput ActionOutput { get; set; } = new() 
    { 
        Success = Array.Empty<ProjectsDataObject>(),
        Failed = Array.Empty<ProjectsDataObject>(),
        Invalid = Array.Empty<ProjectValidationResult>()
    };
    public StandardActionFailure ActionFailure { get; set; } = new();
    public bool CreateRtap => true;
}

public class CreateProjectsActionInput
{
    [JsonPropertyName("projects")]
    [Description("Array of projects to create")]
    [Required]
    public required List<ProjectCreate> Projects { get; init; }

    [JsonPropertyName("skipInvalidFields")]
    [Description("Whether to save projects without invalid fields")]
    public bool SkipInvalidFields { get; init; }
}

public class ProjectCreate
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

public class CreateProjectsActionOutput
{
    [JsonPropertyName("success")]
    [Description("Successfully created projects")]
    [Required]
    public required ProjectsDataObject[] Success { get; init; }

    [JsonPropertyName("failed")]
    [Description("Failed to create projects")]
    [Required]
    public required ProjectsDataObject[] Failed { get; init; }

    [JsonPropertyName("invalid")]
    [Description("Invalid project entries")]
    [Required]
    public required ProjectValidationResult[] Invalid { get; init; }
}

public class ProjectValidationResult
{
    [JsonPropertyName("entry")]
    public ProjectsDataObject? Entry { get; init; }

    [JsonPropertyName("errors")]
    public IEnumerable<ProjectFieldError>? Errors { get; init; }

    [JsonPropertyName("warnings")]
    public IEnumerable<ProjectFieldWarning>? Warnings { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }
}

public class ProjectFieldError
{
    [JsonPropertyName("fieldId")]
    public string? FieldId { get; init; }

    [JsonPropertyName("fieldName")]
    public string? FieldName { get; init; }

    [JsonPropertyName("message")]
    public string? Message { get; init; }

    [JsonPropertyName("invalidValue")]
    public object? InvalidValue { get; init; }
}

public class ProjectFieldWarning
{
    [JsonPropertyName("fieldId")]
    public string? FieldId { get; init; }

    [JsonPropertyName("message")]
    public string? Message { get; init; }

    [JsonPropertyName("warningValue")]
    public object? WarningValue { get; init; }
}
