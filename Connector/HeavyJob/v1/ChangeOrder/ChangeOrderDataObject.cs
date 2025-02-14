namespace Connector.HeavyJob.v1.ChangeOrder;

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
[Description("Represents a change order in HeavyJob")]
public class ChangeOrderDataObject
{
    [JsonPropertyName("id")]
    [Description("The change order ID")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("changeOrderNumber")]
    [Description("The change order number")]
    [Required]
    public required int ChangeOrderNumber { get; init; }

    [JsonPropertyName("subject")]
    [Description("The subject")]
    [Required]
    public required string Subject { get; init; }

    [JsonPropertyName("description")]
    [Description("The change order description")]
    public string? Description { get; init; }

    [JsonPropertyName("ownerNumber")]
    [Description("The owner Number")]
    public string? OwnerNumber { get; init; }

    [JsonPropertyName("subSupplierNumber")]
    [Description("The sub/supplier number")]
    public string? SubSupplierNumber { get; init; }

    [JsonPropertyName("showInMobile")]
    [Description("Is the change order shown on mobile devices?")]
    public bool ShowInMobile { get; init; }

    [JsonPropertyName("statusId")]
    [Description("The StatusId")]
    public Guid? StatusId { get; init; }

    [JsonPropertyName("roughOrderOfMagnitude")]
    [Description("The estimated ROM of how impactful this change will be")]
    public double? RoughOrderOfMagnitude { get; init; }

    [JsonPropertyName("costImpactEvaluation")]
    [Description("The cost impact evaluation")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ChangeOrderImpactEvaluation CostImpactEvaluation { get; init; }

    [JsonPropertyName("costImpactDescription")]
    [Description("The description of this change's impact on cost")]
    public string? CostImpactDescription { get; init; }

    [JsonPropertyName("scheduleImpactEvaluation")]
    [Description("The schedule impact evaluation")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ChangeOrderImpactEvaluation ScheduleImpactEvaluation { get; init; }

    [JsonPropertyName("scheduleImpactDescription")]
    [Description("The description of this change's impact on schedule")]
    public string? ScheduleImpactDescription { get; init; }

    [JsonPropertyName("actualCost")]
    [Description("The change order actual cost")]
    public double? ActualCost { get; init; }

    [JsonPropertyName("productionQuantityChange")]
    [Description("The change order Production Quantity Change")]
    public double? ProductionQuantityChange { get; init; }

    [JsonPropertyName("otherDrawings")]
    [Description("Other Drawings associated with the change order")]
    public string[]? OtherDrawings { get; init; }

    [JsonPropertyName("lastUpdatedDate")]
    [Description("The datetime when this change order was last modified")]
    public DateTime LastUpdatedDate { get; init; }

    [JsonPropertyName("createdOnDate")]
    [Description("The datetime when this change order was created")]
    public DateTime CreatedOnDate { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("If the change order is deleted")]
    public bool IsDeleted { get; init; }

    [JsonPropertyName("auditEventType")]
    [Description("Enumerations for temporal table audit event types")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public AuditEventType AuditEventType { get; init; }

    [JsonPropertyName("createdByUser")]
    [Description("The user who created this change order")]
    public ApiUserSlimRead? CreatedByUser { get; init; }

    [JsonPropertyName("managedByUser")]
    [Description("The user who manages this change order")]
    public ApiUserSlimRead? ManagedByUser { get; init; }

    [JsonPropertyName("lastUpdatedByUser")]
    [Description("The user who last updated this change order")]
    public ApiUserSlimRead? LastUpdatedByUser { get; init; }

    [JsonPropertyName("status")]
    [Description("The status of the change order")]
    public ApiChangeOrderStatusCompactRead? Status { get; init; }

    [JsonPropertyName("linkedCostCodes")]
    [Description("The cost codes linked to the PCO")]
    public ApiCostCodeCompactReadV2[]? LinkedCostCodes { get; init; }

    [JsonPropertyName("job")]
    [Description("The job this change order belongs to")]
    public ApiJobCompactReadV2? Job { get; init; }
}

public enum ChangeOrderImpactEvaluation
{
    No,
    Yes,
    Potential
}

public enum AuditEventType
{
    Created,
    Edited,
    Deleted,
    Restored
}

public class ApiUserSlimRead
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("firstName")]
    public string? FirstName { get; init; }

    [JsonPropertyName("lastName")]
    public string? LastName { get; init; }

    [JsonPropertyName("email")]
    public string? Email { get; init; }
}

public class ApiChangeOrderStatusCompactRead
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("value")]
    public string? Value { get; init; }
}

public class ApiCostCodeCompactReadV2
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("code")]
    public string? Code { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }
}

public class ApiJobCompactReadV2
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("code")]
    public string? Code { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }
}