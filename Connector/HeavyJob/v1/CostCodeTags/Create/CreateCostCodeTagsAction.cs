namespace Connector.HeavyJob.v1.CostCodeTags.Create;

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
[Description("Returns cost codes with associated setup tags")]
public class CreateCostCodeTagsAction : IStandardAction<CreateCostCodeTagsActionInput, CreateCostCodeTagsActionOutput>
{
    public CreateCostCodeTagsActionInput ActionInput { get; set; } = new();
    public CreateCostCodeTagsActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateCostCodeTagsActionInput
{
    [JsonPropertyName("costCodeIds")]
    [Description("List of Cost Code Ids")]
    public Guid[]? CostCodeIds { get; init; }

    [JsonPropertyName("jobIds")]
    [Description("List of Job Ids")]
    public Guid[]? JobIds { get; init; }

    [JsonPropertyName("tagIds")]
    [Description("List of Tag Ids")]
    public Guid[]? TagIds { get; init; }

    [JsonPropertyName("modifiedSince")]
    [Description("The date since the last update")]
    public DateTime? ModifiedSince { get; init; }

    [JsonPropertyName("cursor")]
    [Description("Optional cursor for pagination")]
    public string? Cursor { get; init; }

    [JsonPropertyName("limit")]
    [Description("The maximum number of results that should be returned")]
    public int? Limit { get; init; }
}

public class CreateCostCodeTagsActionOutput
{
    [JsonPropertyName("results")]
    [Required]
    public CostCodeTagsDataObject[] Results { get; init; } = Array.Empty<CostCodeTagsDataObject>();

    [JsonPropertyName("metadata")]
    [Required]
    public CostCodeTagsMetadata Metadata { get; init; } = new();
}
