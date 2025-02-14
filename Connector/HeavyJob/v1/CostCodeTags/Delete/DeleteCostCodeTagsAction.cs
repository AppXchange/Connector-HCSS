namespace Connector.HeavyJob.v1.CostCodeTags.Delete;

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
[Description("Deletes cost code - tag relationships")]
public class DeleteCostCodeTagsAction : IStandardAction<DeleteCostCodeTagsActionInput, DeleteCostCodeTagsActionOutput>
{
    public DeleteCostCodeTagsActionInput ActionInput { get; set; } = new();
    public DeleteCostCodeTagsActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class DeleteCostCodeTagsActionInput
{
    [JsonPropertyName("jobId")]
    [Required]
    [Description("The job ID")]
    public Guid JobId { get; init; }

    [JsonPropertyName("costCodeId")]
    [Required]
    [Description("The cost code ID")]
    public Guid CostCodeId { get; init; }

    [JsonPropertyName("tagId")]
    [Required]
    [Description("The tag ID")]
    public Guid TagId { get; init; }
}

public class DeleteCostCodeTagsActionOutput
{
    // No output properties needed since API returns 204 No Content
}
