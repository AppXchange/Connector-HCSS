namespace Connector.Equipment360.v1.WorkOrder.Create;

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
[Description("Creates a new work order in Equipment360")]
public class CreateWorkOrderAction : IStandardAction<CreateWorkOrderActionInput, WorkOrderDataObject>
{
    public CreateWorkOrderActionInput ActionInput { get; set; } = new();
    public WorkOrderDataObject ActionOutput { get; set; } = new()
    {
        Id = Guid.Empty,
        BusinessUnitId = Guid.Empty,
        WorkOrderNumber = 0,
        StatusDate = DateTime.UtcNow,
        IsPreventiveMaintenance = false
    };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateWorkOrderActionInput
{
    [JsonPropertyName("jobId")]
    [Description("The Id of the job (if any) to which the work order applies")]
    public Guid? JobId { get; init; }

    [JsonPropertyName("equipmentId")]
    [Description("The Id of the equipment (if any) to which the work order applies")]
    public Guid? EquipmentId { get; init; }

    [JsonPropertyName("shopId")]
    [Description("The Id of the shop (if any) to which the work order applies")]
    public Guid? ShopId { get; init; }

    [JsonPropertyName("description")]
    [Description("The work order's problem description")]
    public string? Description { get; init; }

    [JsonPropertyName("status")]
    [Description("The current status of the work order")]
    public string? Status { get; init; }

    [JsonPropertyName("priority")]
    [Description("The current priority of the work order")]
    public string? Priority { get; init; }

    [JsonPropertyName("dueDate")]
    [Description("The date, if specified, on which the work order is due")]
    public DateTime? DueDate { get; init; }

    [JsonIgnore]
    [Description("Optional business unit ID. If not specified, will create in authenticated user's business unit")]
    public Guid? BusinessUnitId { get; init; }
}
