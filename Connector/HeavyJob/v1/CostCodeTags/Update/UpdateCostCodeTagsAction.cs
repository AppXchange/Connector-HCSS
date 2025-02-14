namespace Connector.HeavyJob.v1.CostCodeTags.Update;

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
[Description("Upserts cost code setup tags")]
public class UpdateCostCodeTagsAction : IStandardAction<UpdateCostCodeTagsActionInput, UpdateCostCodeTagsActionOutput>
{
    public UpdateCostCodeTagsActionInput ActionInput { get; set; } = new();
    public UpdateCostCodeTagsActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CostCodeTagUpdate
{
    [JsonPropertyName("costCodeId")]
    [Required]
    [Description("The cost code id")]
    public Guid CostCodeId { get; init; }

    [JsonPropertyName("tagId")]
    [Required]
    [Description("The tag id")]
    public Guid TagId { get; init; }
}

public class UpdateCostCodeTagsActionInput
{
    [Required]
    [Description("The list of cost codes and associated setup tag to be created or updated")]
    public CostCodeTagUpdate[] Updates { get; init; } = Array.Empty<CostCodeTagUpdate>();
}

public class UpdateCostCodeTagsActionOutput
{
    // No output properties needed since API returns 204 No Content
}
