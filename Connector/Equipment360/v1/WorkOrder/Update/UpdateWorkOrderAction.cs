namespace Connector.Equipment360.v1.WorkOrder.Update;

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
[Description("Updates an existing work order in Equipment360")]
public class UpdateWorkOrderAction : IStandardAction<UpdateWorkOrderActionInput, WorkOrderDataObject>
{
    public UpdateWorkOrderActionInput ActionInput { get; set; } = new()
    {
        Id = Guid.Empty
    };
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

public class UpdateWorkOrderActionInput
{
    [JsonIgnore]
    [Description("The Id of the work order to update")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("equipmentId")]
    [Description("Equipment Id (can only be used for equipment type work orders)")]
    public Guid? EquipmentId { get; init; }

    [JsonPropertyName("equipmentJobId")]
    [Description("Equipment Job Id (can only be used for equipment type work orders)")]
    public Guid? EquipmentJobId { get; init; }

    [JsonPropertyName("jobId")]
    [Description("Job Id (can only be used for job type work orders)")]
    public Guid? JobId { get; init; }

    [JsonPropertyName("shopId")]
    [Description("Shop Id (can only be used for shop type work orders)")]
    public Guid? ShopId { get; init; }

    [JsonPropertyName("description")]
    [Description("The work order description")]
    public string? Description { get; init; }

    [JsonPropertyName("statusId")]
    [Description("Work order Status Id")]
    public Guid? StatusId { get; init; }

    [JsonPropertyName("priorityId")]
    [Description("Work order Priority Id")]
    public Guid? PriorityId { get; init; }
}
