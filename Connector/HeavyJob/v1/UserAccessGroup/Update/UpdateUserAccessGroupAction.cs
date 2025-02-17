namespace Connector.HeavyJob.v1.UserAccessGroup.Update;

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
[Description("Updates access groups for users in HeavyJob")]
public class UpdateUserAccessGroupAction : IStandardAction<UpdateUserAccessGroupActionInput[], UpdateUserAccessGroupActionOutput[]>
{
    public UpdateUserAccessGroupActionInput[] ActionInput { get; set; } = Array.Empty<UpdateUserAccessGroupActionInput>();
    public UpdateUserAccessGroupActionOutput[] ActionOutput { get; set; } = Array.Empty<UpdateUserAccessGroupActionOutput>();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class UpdateUserAccessGroupActionInput
{
    [JsonPropertyName("userId")]
    [Description("The user id")]
    [Required]
    public required Guid UserId { get; init; }

    [JsonPropertyName("accessGroupId")]
    [Description("The access group id")]
    [Required]
    public required Guid AccessGroupId { get; init; }
}

public class UpdateUserAccessGroupActionOutput
{
    [JsonPropertyName("id")]
    [Description("The id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("userId")]
    [Description("The userId")]
    [Required]
    public required Guid UserId { get; init; }

    [JsonPropertyName("accessGroupId")]
    [Description("The accessGroupId")]
    [Required]
    public required Guid AccessGroupId { get; init; }

    [JsonPropertyName("success")]
    [Description("The success flag")]
    [Required]
    public required bool Success { get; init; }

    [JsonPropertyName("message")]
    [Description("The message")]
    [Required]
    public required string Message { get; init; }
}
