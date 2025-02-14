namespace Connector.HeavyBidPreConstruction.v1.Reports.Create;

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
[Description("Generates a project details report in HeavyBid Pre-Construction")]
public class CreateReportsAction : IStandardAction<CreateReportsActionInput, CreateReportsActionOutput>
{
    public CreateReportsActionInput ActionInput { get; set; } = new() 
    { 
        BusinessUnitId = default,
        ProjectId = default
    };
    public CreateReportsActionOutput ActionOutput { get; set; } = new() 
    { 
        ReportContent = Array.Empty<byte>() 
    };
    public StandardActionFailure ActionFailure { get; set; } = new();
    public bool CreateRtap => true;
}

public class CreateReportsActionInput
{
    [JsonPropertyName("businessUnitId")]
    [Description("The business unit ID")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("projectId")]
    [Description("The project ID")]
    [Required]
    public required Guid ProjectId { get; init; }

    [JsonPropertyName("hiddenProjectFields")]
    [Description("Optional project fields to hide")]
    public List<string>? HiddenProjectFields { get; init; }

    [JsonPropertyName("hiddenEstimateColumns")]
    [Description("Optional estimate columns to hide")]
    public List<string>? HiddenEstimateColumns { get; init; }

    [JsonPropertyName("settings")]
    [Description("Optional report settings")]
    public ReportSettings? Settings { get; init; }
}

public class ReportSettings
{
    [JsonPropertyName("localizationSetting")]
    public int LocalizationSetting { get; init; }

    [JsonPropertyName("timeZoneId")]
    public string? TimeZoneId { get; init; }

    [JsonPropertyName("verticalMargins")]
    public int VerticalMargins { get; init; }

    [JsonPropertyName("horizontalMargins")]
    public int HorizontalMargins { get; init; }
}

public class CreateReportsActionOutput
{
    [JsonPropertyName("reportContent")]
    [Description("The binary content of the generated report")]
    [Required]
    public required byte[] ReportContent { get; init; }
}
