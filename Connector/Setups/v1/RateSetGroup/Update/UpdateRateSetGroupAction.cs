namespace Connector.Setups.v1.RateSetGroup.Update;

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
[Description("Updates an existing rate set group in HCSS")]
public class UpdateRateSetGroupAction : IStandardAction<UpdateRateSetGroupActionInput, UpdateRateSetGroupActionOutput>
{
    public UpdateRateSetGroupActionInput ActionInput { get; set; } = new()
    {
        Id = Guid.Empty,
        BusinessUnitCode = string.Empty,
        Code = string.Empty,
        Type = string.Empty
    };
    public UpdateRateSetGroupActionOutput ActionOutput { get; set; } = new() { Id = Guid.Empty };
    public StandardActionFailure ActionFailure { get; set; } = new();
    public bool CreateRtap => true;
}

public class UpdateRateSetGroupActionInput
{
    [JsonPropertyName("id")]
    [Description("The rate set group id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("code")]
    [Description("The code of the rate set group")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("description")]
    [Description("The description")]
    public string? Description { get; init; }

    [JsonPropertyName("type")]
    [Description("The rate set group type")]
    [Required]
    public required string Type { get; init; }

    [JsonPropertyName("businessUnitCode")]
    [Description("The business unit code")]
    [Required]
    public required string BusinessUnitCode { get; init; }
}

public class UpdateRateSetGroupActionOutput
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }
}
