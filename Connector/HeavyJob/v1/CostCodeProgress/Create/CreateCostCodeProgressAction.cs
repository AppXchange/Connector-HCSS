namespace Connector.HeavyJob.v1.CostCodeProgress.Create;

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
[Description("Returns a list of quantities for a given date range, job Id and other optional parameters")]
public class CreateCostCodeProgressAction : IStandardAction<CreateCostCodeProgressActionInput, CreateCostCodeProgressActionOutput>
{
    public CreateCostCodeProgressActionInput ActionInput { get; set; } = new();
    public CreateCostCodeProgressActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateCostCodeProgressActionInput
{
    [JsonPropertyName("jobId")]
    [Required]
    [Description("Job Id. Required for all queries")]
    public Guid JobId { get; init; }

    [JsonPropertyName("startDate")]
    [Description("Start Date")]
    public DateTime? StartDate { get; init; }

    [JsonPropertyName("endDate")]
    [Description("End Date")]
    public DateTime? EndDate { get; init; }

    [JsonPropertyName("costCodeIds")]
    [Description("List of cost code Ids")]
    public Guid[]? CostCodeIds { get; init; }

    [JsonPropertyName("costCodeTagIds")]
    [Description("List of cost code Tag Ids")]
    public Guid[]? CostCodeTagIds { get; init; }

    [JsonPropertyName("costCodeTransactionTagIds")]
    [Description("List of cost code Transaction Tag Ids")]
    public Guid[]? CostCodeTransactionTagIds { get; init; }

    [JsonPropertyName("cursor")]
    [Description("Optional cursor for pagination")]
    public string? Cursor { get; init; }

    [JsonPropertyName("limit")]
    [Description("The maximum number of items to return")]
    public int? Limit { get; init; }
}

public class CreateCostCodeProgressActionOutput
{
    [JsonPropertyName("results")]
    [Required]
    public CostCodeProgressDataObject[] Results { get; init; } = Array.Empty<CostCodeProgressDataObject>();

    [JsonPropertyName("metadata")]
    [Required]
    public CostCodeProgressMetadata Metadata { get; init; } = new();
}
