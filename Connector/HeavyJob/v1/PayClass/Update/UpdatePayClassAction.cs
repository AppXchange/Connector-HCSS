namespace Connector.HeavyJob.v1.PayClass.Update;

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
[Description("Updates a pay class in a business unit")]
public class UpdatePayClassAction : IStandardAction<UpdatePayClassActionInput, UpdatePayClassActionOutput>
{
    public UpdatePayClassActionInput ActionInput { get; set; } = new() { 
        BusinessUnitId = Guid.Empty,
        Id = Guid.Empty
    };
    public UpdatePayClassActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class UpdatePayClassActionInput
{
    [JsonPropertyName("id")]
    [Description("The Id of the pay class to be updated")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit Id")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("code")]
    [Description("The pay class code")]
    public string? Code { get; init; }

    [JsonPropertyName("hbEstimateCode")]
    [Description("The pay class HeavyBid code")]
    public string? HbEstimateCode { get; init; }

    [JsonPropertyName("description")]
    [Description("The pay class description")]
    public string? Description { get; init; }

    [JsonPropertyName("isActive")]
    [Description("The active status")]
    public bool? IsActive { get; init; }
}

public class UpdatePayClassActionOutput
{
    [JsonPropertyName("success")]
    [Description("Whether the update was successful")]
    public bool Success { get; init; }
}
