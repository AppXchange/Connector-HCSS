namespace Connector.HeavyJob.v1.CustomCostTypeInstalled.Create;

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
[Description("Returns installed custom cost type items")]
public class CreateCustomCostTypeInstalledAction : IStandardAction<CreateCustomCostTypeInstalledActionInput, CreateCustomCostTypeInstalledActionOutput>
{
    public CreateCustomCostTypeInstalledActionInput ActionInput { get; set; } = new();
    public CreateCustomCostTypeInstalledActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateCustomCostTypeInstalledActionInput
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

    [JsonPropertyName("modifiedSince")]
    [Description("The modifiedSince datetime")]
    public DateTime? ModifiedSince { get; init; }

    [JsonPropertyName("onlyTM")]
    [Description("The onlyTM optional parameter to filter to T&M data")]
    public bool? OnlyTM { get; init; }
}

public class CreateCustomCostTypeInstalledActionOutput
{
    [JsonPropertyName("results")]
    [Required]
    public CustomCostTypeInstalledDataObject[] Results { get; init; } = Array.Empty<CustomCostTypeInstalledDataObject>();

    [JsonPropertyName("metadata")]
    [Required]
    public CustomCostTypeInstalledMetadata Metadata { get; init; } = new();
}
