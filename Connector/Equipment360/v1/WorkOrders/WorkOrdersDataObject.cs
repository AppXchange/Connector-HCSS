namespace Connector.Equipment360.v1.WorkOrders;

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
public class WorkOrdersDataObject
{
    [JsonPropertyName("id")]
    [Description("The work order id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit ID associated with the work order")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("workOrderNumber")]
    [Description("The work order number")]
    public int WorkOrderNumber { get; init; }

    [JsonPropertyName("equipmentJobId")]
    [Description("The equipment job ID if applicable")]
    public Guid? EquipmentJobId { get; init; }

    [JsonPropertyName("tags")]
    [Description("List of tags associated with the work order")]
    public IEnumerable<string>? Tags { get; init; }

    [JsonPropertyName("notes")]
    [Description("List of notes associated with the work order")]
    public IEnumerable<WorkOrderNoteRead>? Notes { get; init; }

    [JsonPropertyName("statusDate")]
    [Description("The date of the current status")]
    public DateTime StatusDate { get; init; }

    [JsonPropertyName("isPreventiveMaintenance")]
    [Description("Whether this is a preventive maintenance work order")]
    public bool IsPreventiveMaintenance { get; init; }

    [JsonPropertyName("equipmentId")]
    [Description("The equipment ID if applicable")]
    public Guid? EquipmentId { get; init; }

    [JsonPropertyName("jobId")]
    [Description("The job ID if applicable")]
    public Guid? JobId { get; init; }

    [JsonPropertyName("description")]
    [Description("The work order description")]
    public string? Description { get; init; }

    [JsonPropertyName("status")]
    [Description("The current status")]
    public string? Status { get; init; }

    [JsonPropertyName("priority")]
    [Description("The priority level")]
    public string? Priority { get; init; }
}

public class WorkOrderNoteRead
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