namespace Connector.HeavyJob.v1.ChangeOrder.Delete;

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
[Description("Deletes a change order in HeavyJob")]
public class DeleteChangeOrderAction : IStandardAction<DeleteChangeOrderActionInput, DeleteChangeOrderActionOutput>
{
    public DeleteChangeOrderActionInput ActionInput { get; set; } = new()
    {
        Id = Guid.Empty
    };
    public DeleteChangeOrderActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class DeleteChangeOrderActionInput
{
    [JsonPropertyName("id")]
    [Description("The change order ID to delete")]
    [Required]
    public required Guid Id { get; init; }
}

public class DeleteChangeOrderActionOutput
{
    [JsonPropertyName("id")]
    [Description("The ID of the deleted change order")]
    public Guid Id { get; init; }
}
