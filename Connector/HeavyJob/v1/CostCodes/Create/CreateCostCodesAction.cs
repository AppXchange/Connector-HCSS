namespace Connector.HeavyJob.v1.CostCodes.Create;

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
[Description("Returns a list of cost codes for the specified business unit, jobs, cost codes, or accounting template")]
public class CreateCostCodesAction : IStandardAction<CreateCostCodesActionInput, CreateCostCodesActionOutput>
{
    public CreateCostCodesActionInput ActionInput { get; set; } = new();
    public CreateCostCodesActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateCostCodesActionInput
{
    [JsonPropertyName("businessUnitId")]
    [Description("Business Unit Id")]
    public Guid? BusinessUnitId { get; init; }

    [JsonPropertyName("jobIds")]
    [Description("Job Ids")]
    public Guid[]? JobIds { get; init; }

    [JsonPropertyName("costCodeIds")]
    [Description("List of cost code Ids")]
    public Guid[]? CostCodeIds { get; init; }

    [JsonPropertyName("cursor")]
    [Description("Optional cursor for pagination")]
    public string? Cursor { get; init; }

    [JsonPropertyName("accountingTemplateName")]
    [Description("Optional accounting template name")]
    public string? AccountingTemplateName { get; init; }

    [JsonPropertyName("limit")]
    [Description("The maximum number of results that should be returned")]
    public int? Limit { get; init; }
}

public class CreateCostCodesActionOutput
{
    [JsonPropertyName("results")]
    [Required]
    public CostCodesDataObject[] Results { get; init; } = Array.Empty<CostCodesDataObject>();

    [JsonPropertyName("metadata")]
    [Required]
    public CostCodesMetadata Metadata { get; init; } = new();
}
