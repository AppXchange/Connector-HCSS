namespace Connector.HeavyJob.v1.MaterialPurchaseOrderDetails.Update;

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
[Description("Updates an existing material purchase order detail by its id")]
public class UpdateMaterialPurchaseOrderDetailsAction : IStandardAction<UpdateMaterialPurchaseOrderDetailsActionInput, UpdateMaterialPurchaseOrderDetailsActionOutput>
{
    public UpdateMaterialPurchaseOrderDetailsActionInput ActionInput { get; set; } = new() { Id = Guid.Empty };
    public UpdateMaterialPurchaseOrderDetailsActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class UpdateMaterialPurchaseOrderDetailsActionInput
{
    [JsonPropertyName("id")]
    [Description("The purchase order detail id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("isFullyReceived")]
    [Description("Whether the item is fully received. Default is false")]
    public bool? IsFullyReceived { get; init; }

    [JsonPropertyName("isFullyInstalled")]
    [Description("Whether the item is fully installed. Default is false")]
    public bool? IsFullyInstalled { get; init; }
}

public class UpdateMaterialPurchaseOrderDetailsActionOutput
{
    [JsonPropertyName("success")]
    [Description("Whether the update was successful")]
    public bool Success { get; init; }
}
