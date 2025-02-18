namespace Connector.Safety.v1.UserAccessGroups.Update;

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
[Description("Updates access group assignments for users")]
public class UpdateUserAccessGroupsAction : IStandardAction<UpdateUserAccessGroupsActionInput[], UpdateUserAccessGroupsActionOutput[]>
{
    public UpdateUserAccessGroupsActionInput[] ActionInput { get; set; } = Array.Empty<UpdateUserAccessGroupsActionInput>();
    public UpdateUserAccessGroupsActionOutput[] ActionOutput { get; set; } = Array.Empty<UpdateUserAccessGroupsActionOutput>();
    public StandardActionFailure ActionFailure { get; set; } = new();
    public bool CreateRtap => true;
}

public class UpdateUserAccessGroupsActionInput
{
    [JsonPropertyName("userId")]
    [Description("The user id that belongs to this access group")]
    [Required]
    public required Guid UserId { get; init; }

    [JsonPropertyName("accessGroupId")]
    [Description("The access group id")]
    [Required]
    public required Guid AccessGroupId { get; init; }
}

public class UpdateUserAccessGroupsActionOutput
{
    [JsonPropertyName("id")]
    [Description("The id of the user - access group relation")]
    public Guid Id { get; init; }

    [JsonPropertyName("userId")]
    [Description("The user id belongs to this access group")]
    public Guid UserId { get; init; }

    [JsonPropertyName("accessGroupId")]
    [Description("The access group id")]
    public Guid AccessGroupId { get; init; }

    [JsonPropertyName("success")]
    [Description("Whether or not the update was successful")]
    public bool Success { get; init; }

    [JsonPropertyName("message")]
    [Description("A message status of the update")]
    public string? Message { get; init; }
}
