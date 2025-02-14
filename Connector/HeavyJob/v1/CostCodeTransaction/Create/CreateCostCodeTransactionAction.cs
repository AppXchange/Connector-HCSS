namespace Connector.HeavyJob.v1.CostCodeTransaction.Create;

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
[Description("Returns a paginated list of cost code time card transactions")]
public class CreateCostCodeTransactionAction : IStandardAction<CreateCostCodeTransactionActionInput, CreateCostCodeTransactionActionOutput>
{
    public CreateCostCodeTransactionActionInput ActionInput { get; set; } = new();
    public CreateCostCodeTransactionActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateCostCodeTransactionActionInput
{
    [JsonPropertyName("businessUnitId")]
    [Description("The business unit id")]
    public Guid? BusinessUnitId { get; init; }

    [JsonPropertyName("jobIds")]
    [Description("List of Job Ids. Used with JobTagIds to limit jobs")]
    public Guid[]? JobIds { get; init; }

    [JsonPropertyName("jobTagIds")]
    [Description("List of Job Tag Ids. Used with JobIds to limit jobs")]
    public Guid[]? JobTagIds { get; init; }

    [JsonPropertyName("foremanIds")]
    [Description("List of Foreman Ids. Used to limit transactions")]
    public Guid[]? ForemanIds { get; init; }

    [JsonPropertyName("startDate")]
    [Description("Beginning local date of date range")]
    public DateTime? StartDate { get; init; }

    [JsonPropertyName("endDate")]
    [Description("End local date of date range")]
    public DateTime? EndDate { get; init; }

    [JsonPropertyName("cursor")]
    [Description("Optional cursor for pagination")]
    public string? Cursor { get; init; }

    [JsonPropertyName("limit")]
    [Description("The maximum number of results that should be returned")]
    public int? Limit { get; init; }

    [JsonPropertyName("costCodeIds")]
    [Description("List of Cost Code Ids")]
    public Guid[]? CostCodeIds { get; init; }

    [JsonPropertyName("includeCostsAndHours")]
    [Description("Whether to include costs and hours")]
    public bool IncludeCostsAndHours { get; init; }
}

public class CreateCostCodeTransactionActionOutput
{
    [JsonPropertyName("results")]
    [Required]
    public CostCodeTransactionDataObject[] Results { get; init; } = Array.Empty<CostCodeTransactionDataObject>();

    [JsonPropertyName("metadata")]
    [Required]
    public CostCodeTransactionMetadata Metadata { get; init; } = new();
}
