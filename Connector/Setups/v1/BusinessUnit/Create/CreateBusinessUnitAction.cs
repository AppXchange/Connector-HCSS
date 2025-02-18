namespace Connector.Setups.v1.BusinessUnit.Create;

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
[Description("Creates a new business unit in HCSS")]
public class CreateBusinessUnitAction : IStandardAction<CreateBusinessUnitActionInput, CreateBusinessUnitActionOutput>
{
    public CreateBusinessUnitActionInput ActionInput { get; set; } = new() 
    { 
        Code = string.Empty 
    };
    public CreateBusinessUnitActionOutput ActionOutput { get; set; } = new()
    {
        Id = Guid.Empty,
        Code = string.Empty
    };
    public StandardActionFailure ActionFailure { get; set; } = new();
    public bool CreateRtap => true;
}

public class CreateBusinessUnitActionInput
{
    [JsonPropertyName("code")]
    [Description("A code, in all caps, that represents this business unit")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("description")]
    [Description("An optional description for this business unit")]
    public string? Description { get; init; }
}

public class CreateBusinessUnitActionOutput
{
    [JsonPropertyName("id")]
    [Description("The business unit id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("code")]
    [Description("A code, in all caps, that represents this business unit")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("description")]
    [Description("An optional description for this business unit")]
    public string? Description { get; init; }
}
