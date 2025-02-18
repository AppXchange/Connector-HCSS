namespace Connector.Setups.v1.RateSetPayClass.Create;

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
[Description("Creates a new pay class rate set in HCSS")]
public class CreateRateSetPayClassAction : IStandardAction<CreateRateSetPayClassActionInput, CreateRateSetPayClassActionOutput>
{
    public CreateRateSetPayClassActionInput ActionInput { get; set; } = new()
    {
        BusinessUnitCode = string.Empty,
        RateSetGroupCode = string.Empty
    };
    public CreateRateSetPayClassActionOutput ActionOutput { get; set; } = new()
    {
        Id = Guid.Empty,
        BusinessUnitCode = string.Empty,
        RateSetGroupCode = string.Empty
    };
    public StandardActionFailure ActionFailure { get; set; } = new();
    public bool CreateRtap => true;
}

public class CreateRateSetPayClassActionInput
{
    [JsonPropertyName("businessUnitCode")]
    [Description("Gets the business unit code")]
    [Required]
    public required string BusinessUnitCode { get; init; }

    [JsonPropertyName("payClassRates")]
    [Description("Gets the pay class rates")]
    public PayClassRate[]? PayClassRates { get; init; }

    [JsonPropertyName("effectiveDate")]
    [Description("Gets the effective date")]
    public DateTime? EffectiveDate { get; init; }

    [JsonPropertyName("rateSetGroupCode")]
    [Description("Gets the rate set group code, used to uniquely identify this rate set")]
    [Required]
    public required string RateSetGroupCode { get; init; }

    [JsonPropertyName("rateSetGroupDescription")]
    [Description("Gets the rate set group description")]
    public string? RateSetGroupDescription { get; init; }

    [JsonPropertyName("id")]
    [Description("The Id of the rate set")]
    public Guid? Id { get; init; }
}

public class CreateRateSetPayClassActionOutput : RateSetPayClassDataObject
{
}
