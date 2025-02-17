namespace Connector.HeavyJob.v1.VendorContractDetails.Update;

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
[Description("Updates a vendor contract detail in HeavyJob")]
public class UpdateVendorContractDetailsAction : IStandardAction<UpdateVendorContractDetailsActionInput, UpdateVendorContractDetailsActionOutput>
{
    public UpdateVendorContractDetailsActionInput ActionInput { get; set; } = new()
    {
        Id = Guid.Empty,
        IsComplete = false
    };

    public UpdateVendorContractDetailsActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();
    public bool CreateRtap => true;
}

public class UpdateVendorContractDetailsActionInput
{
    [JsonPropertyName("id")]
    [Description("The vendor contract detail id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("isComplete")]
    [Description("Whether the work item is complete")]
    [Required]
    public required bool IsComplete { get; init; }
}

public class UpdateVendorContractDetailsActionOutput
{
    // No content returned for 204 response
}
