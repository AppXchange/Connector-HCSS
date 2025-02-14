namespace Connector.Equipment360.v1.WorkOrder;

using Json.Schema.Generation;
using System;
using System.Collections.Generic;
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
[Description("Represents a work order in Equipment360")]
public class WorkOrderDataObject
{
    [JsonPropertyName("id")]
    [Description("The guid of the work order")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The Id of the business unit to which the work order belongs")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("workOrderNumber")]
    [Description("The integer id of the work order")]
    [Required]
    public required int WorkOrderNumber { get; init; }

    [JsonPropertyName("equipmentJobId")]
    [Description("If the work order is an equipment work order, this is the Id of the associated Job")]
    public Guid? EquipmentJobId { get; init; }

    [JsonPropertyName("tags")]
    [Description("A list of tags that have been applied to the work order")]
    public IEnumerable<string>? Tags { get; init; }

    [JsonPropertyName("notes")]
    [Description("The notes for the work order")]
    public IEnumerable<ApiNoteRead>? Notes { get; init; }

    [JsonPropertyName("statusDate")]
    [Description("The date of the most recent status change")]
    [Required]
    public required DateTime StatusDate { get; init; }

    [JsonPropertyName("isPreventiveMaintenance")]
    [Description("Indicates whether a work order contains one or more Preventive Maintenance setup")]
    [Required]
    public required bool IsPreventiveMaintenance { get; init; }

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
}

public class ApiNoteRead
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("createdBy")]
    public string? CreatedBy { get; init; }

    [JsonPropertyName("createdDate")]
    public DateTime? CreatedDate { get; init; }

    [JsonPropertyName("modifiedBy")]
    public string? ModifiedBy { get; init; }

    [JsonPropertyName("modifiedDate")]
    public DateTime? ModifiedDate { get; init; }

    [JsonPropertyName("note")]
    public string? Note { get; init; }
}