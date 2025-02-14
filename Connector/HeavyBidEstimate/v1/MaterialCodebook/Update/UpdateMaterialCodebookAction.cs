namespace Connector.HeavyBidEstimate.v1.MaterialCodebook.Update;

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
[Description("Updates a material codebook resource")]
public class UpdateMaterialCodebookAction : IStandardAction<UpdateMaterialCodebookActionInput, MaterialCodebookDataObject>
{
    public UpdateMaterialCodebookActionInput ActionInput { get; set; } = null!;
    public MaterialCodebookDataObject ActionOutput { get; set; } = null!;
    public StandardActionFailure ActionFailure { get; set; } = new();
    public bool CreateRtap => true;
}

public class UpdateMaterialCodebookActionInput
{
    [JsonPropertyName("id")]
    [Description("The material codebook resource id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("description")]
    [Description("The description")]
    public string? Description { get; init; }

    [JsonPropertyName("unitCost")]
    [Description("The unit cost")]
    public decimal? UnitCost { get; init; }

    [JsonPropertyName("unit")]
    [Description("The unit of measure")]
    public string? Unit { get; init; }

    [JsonPropertyName("nonTaxable")]
    [Description("Flag indicating if the resource is not taxable")]
    public string? NonTaxable { get; init; }

    [JsonPropertyName("accountingCode")]
    [Description("The accounting code")]
    public string? AccountingCode { get; init; }

    [JsonPropertyName("accountingDesc")]
    [Description("The accounting code description")]
    public string? AccountingDesc { get; init; }

    [JsonPropertyName("mhPerUnit")]
    [Description("The manhours needed per unit when using resource factoring production")]
    public decimal? MhPerUnit { get; init; }

    [JsonPropertyName("quoteFolder")]
    [Description("The default class/folder of the resource for the quote system")]
    public string? QuoteFolder { get; init; }

    [JsonPropertyName("resourceText1")]
    [Description("The resource text 1")]
    public string? ResourceText1 { get; init; }

    [JsonPropertyName("resourceText2")]
    [Description("The resource text 2")]
    public string? ResourceText2 { get; init; }

    [JsonPropertyName("scheduleCode")]
    [Description("The code used instead of the resource code when exporting to primavera")]
    public string? ScheduleCode { get; init; }

    [JsonPropertyName("excludeFromQuotes")]
    [Description("Flag to exclude the detail when populating quote folders")]
    public string? ExcludeFromQuotes { get; init; }
}
