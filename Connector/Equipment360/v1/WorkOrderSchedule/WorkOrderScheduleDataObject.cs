namespace Connector.Equipment360.v1.WorkOrderSchedule;

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
[Description("Represents a work order schedule in Equipment360")]
public class WorkOrderScheduleDataObject
{
    [JsonPropertyName("id")]
    [Description("The work order schedule id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("workOrderNumber")]
    [Description("The work order number")]
    public int WorkOrderNumber { get; init; }

    [JsonPropertyName("workOrder_ID")]
    [Description("The associated work order ID")]
    public Guid WorkOrderId { get; init; }

    [JsonPropertyName("scheduledDate")]
    [Description("The scheduled date for the work order")]
    public DateTime ScheduledDate { get; init; }

    [JsonPropertyName("workComplete")]
    [Description("Whether the work is complete")]
    public bool WorkComplete { get; init; }

    [JsonPropertyName("mechanic_ID")]
    [Description("The ID of the assigned mechanic")]
    public Guid? MechanicId { get; init; }

    [JsonPropertyName("mechanic_FirstName")]
    [Description("The first name of the assigned mechanic")]
    public string? MechanicFirstName { get; init; }

    [JsonPropertyName("mechanic_LastName")]
    [Description("The last name of the assigned mechanic")]
    public string? MechanicLastName { get; init; }

    [JsonPropertyName("vendor_ID")]
    [Description("The ID of the assigned vendor")]
    public Guid? VendorId { get; init; }

    [JsonPropertyName("vendor_Name")]
    [Description("The name of the assigned vendor")]
    public string? VendorName { get; init; }
}