namespace Connector.HeavyBidPreConstruction.v1.Projects.Delete;

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
[Description("Deletes multiple projects in HeavyBid Pre-Construction")]
public class DeleteProjectsAction : IStandardAction<DeleteProjectsActionInput, DeleteProjectsActionOutput>
{
    public DeleteProjectsActionInput ActionInput { get; set; } = new() { ProjectIds = new() };
    public DeleteProjectsActionOutput ActionOutput { get; set; } = new() 
    { 
        Success = Array.Empty<string>(),
        Failed = Array.Empty<string>()
    };
    public StandardActionFailure ActionFailure { get; set; } = new();
    public bool CreateRtap => true;
}

public class DeleteProjectsActionInput
{
    [JsonPropertyName("projectIds")]
    [Description("Array of project IDs to delete")]
    [Required]
    public required List<string> ProjectIds { get; init; }
}

public class DeleteProjectsActionOutput
{
    [JsonPropertyName("success")]
    [Description("Successfully deleted project IDs")]
    [Required]
    public required string[] Success { get; init; }

    [JsonPropertyName("failed")]
    [Description("Failed to delete project IDs")]
    [Required]
    public required string[] Failed { get; init; }
}
