namespace Connector.HeavyJob.v1.Subcontracts.Update;

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
[Description("Updates an existing subcontract item")]
public class UpdateSubcontractsAction : IStandardAction<UpdateSubcontractsActionInput, UpdateSubcontractsActionOutput>
{
    public UpdateSubcontractsActionInput ActionInput { get; set; } = new() 
    { 
        Id = Guid.Empty,
        Code = string.Empty
    };
    public UpdateSubcontractsActionOutput ActionOutput { get; set; } = new() 
    { 
        Success = false 
    };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class UpdateSubcontractsActionInput
{
    [JsonPropertyName("id")]
    [Description("The subcontract item id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("code")]
    [Description("The code")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("description")]
    [Description("The description")]
    public string? Description { get; init; }

    [JsonPropertyName("heavyBidCode")]
    [Description("The HeavyBid code")]
    public string? HeavyBidCode { get; init; }
}

public class UpdateSubcontractsActionOutput
{
    [JsonPropertyName("success")]
    [Description("Whether the update was successful")]
    [Required]
    public required bool Success { get; init; }
}
