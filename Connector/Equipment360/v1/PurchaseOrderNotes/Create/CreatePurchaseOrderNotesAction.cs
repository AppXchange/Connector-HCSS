namespace Connector.Equipment360.v1.PurchaseOrderNotes.Create;

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
[Description("Creates a new purchase order note")]
public class CreatePurchaseOrderNotesAction : IStandardAction<CreatePurchaseOrderNotesActionInput, PurchaseOrderNotesDataObject>
{
    public CreatePurchaseOrderNotesActionInput ActionInput { get; set; } = new()
    {
        PurchaseOrderId = Guid.Empty
    };
    public PurchaseOrderNotesDataObject ActionOutput { get; set; } = new()
    {
        Id = Guid.Empty,
        CreatedDate = DateTime.UtcNow
    };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreatePurchaseOrderNotesActionInput
{
    [JsonIgnore]
    [Description("The purchase order id")]
    [Required]
    public required Guid PurchaseOrderId { get; init; }

    [JsonPropertyName("note")]
    [Description("The note")]
    public string? Note { get; init; }
}
