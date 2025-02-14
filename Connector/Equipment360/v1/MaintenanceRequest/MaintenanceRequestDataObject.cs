namespace Connector.Equipment360.v1.MaintenanceRequest;

using Json.Schema.Generation;
using System;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.CacheWriter;

/// <summary>
/// Data object that will represent an object in the Xchange system. This will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// These types will be used for validation at runtime to make sure the objects being passed through the system 
/// are properly formed. The schema also helps provide integrators more information for what the values 
/// are intended to be.
/// </summary>
[PrimaryKey("id", nameof(Id))]
//[AlternateKey("alt-key-id", nameof(CompanyId), nameof(EquipmentNumber))]
[Description("Represents a maintenance request")]
public class MaintenanceRequestDataObject
{
    [JsonPropertyName("id")]
    [Description("The maintenance request id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("requestedDate")]
    [Description("The date the request was made")]
    public DateTime RequestedDate { get; init; }

    [JsonPropertyName("priorityCode")]
    [Description("The priority level code")]
    public string? PriorityCode { get; init; }

    [JsonPropertyName("status")]
    [Description("The current status")]
    public string? Status { get; init; }

    [JsonPropertyName("statusDate")]
    [Description("The date of the last status change")]
    public DateTime StatusDate { get; init; }

    [JsonPropertyName("workOrderId")]
    [Description("The associated work order ID")]
    public int? WorkOrderId { get; init; }

    [JsonPropertyName("workOrderStatusCode")]
    [Description("The status code of the work order")]
    public string? WorkOrderStatusCode { get; init; }

    [JsonPropertyName("workOrderStatusChangedBy")]
    [Description("Who last changed the work order status")]
    public string? WorkOrderStatusChangedBy { get; init; }

    [JsonPropertyName("workOrderStatusDate")]
    [Description("When the work order status was last changed")]
    public DateTime? WorkOrderStatusDate { get; init; }

    [JsonPropertyName("pointOfContact")]
    [Description("Contact information")]
    public string? PointOfContact { get; init; }

    [JsonPropertyName("dismissedDescription")]
    [Description("Description if dismissed")]
    public string? DismissedDescription { get; init; }

    [JsonPropertyName("description")]
    [Description("The maintenance request description")]
    public string? Description { get; init; }

    [JsonPropertyName("equipmentCode")]
    [Description("The equipment code")]
    public string? EquipmentCode { get; init; }

    [JsonPropertyName("equipmentId")]
    [Description("The equipment ID")]
    public Guid? EquipmentId { get; init; }

    [JsonPropertyName("jobId")]
    [Description("The job ID")]
    public Guid? JobId { get; init; }

    [JsonPropertyName("jobCode")]
    [Description("The job code")]
    public string? JobCode { get; init; }

    [JsonPropertyName("priorityId")]
    [Description("The priority ID")]
    public Guid? PriorityId { get; init; }

    [JsonPropertyName("source")]
    [Description("Source of the request")]
    public string? Source { get; init; }

    [JsonPropertyName("requestedBy")]
    [Description("Who made the request")]
    public string? RequestedBy { get; init; }
}