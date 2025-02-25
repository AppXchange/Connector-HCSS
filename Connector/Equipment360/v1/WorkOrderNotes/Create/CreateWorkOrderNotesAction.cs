namespace Connector.Equipment360.v1.WorkOrderNotes.Create;

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
[Description("Creates a new work order note in Equipment360")]
public class CreateWorkOrderNotesAction : IStandardAction<CreateWorkOrderNotesActionInput, WorkOrderNotesDataObject>
{
    public CreateWorkOrderNotesActionInput ActionInput { get; set; } = new() { WorkOrderId = Guid.Empty };
    public WorkOrderNotesDataObject ActionOutput { get; set; } = new()
    {
        Id = Guid.Empty,
        CreatedDate = DateTime.UtcNow,
        Note = null
    };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateWorkOrderNotesActionInput
{
    [JsonIgnore]
    [Description("The work order id")]
    [Required]
    public required Guid WorkOrderId { get; init; }

    [JsonPropertyName("note")]
    [Description("The note")]
    public string? Note { get; init; }
}
