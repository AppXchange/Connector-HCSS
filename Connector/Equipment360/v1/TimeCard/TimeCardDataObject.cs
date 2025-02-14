namespace Connector.Equipment360.v1.TimeCard;

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
[Description("Represents a time card in Equipment360")]
public class TimeCardDataObject
{
    [JsonPropertyName("id")]
    [Description("The time card id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("status")]
    [Description("The status of the time card")]
    public string? Status { get; init; }

    [JsonPropertyName("timeCardDate")]
    [Description("The date of the time card")]
    public DateTime? TimeCardDate { get; init; }

    [JsonPropertyName("workOrderNumber")]
    [Description("The work order number")]
    public int? WorkOrderNumber { get; init; }

    [JsonPropertyName("workType")]
    [Description("The type of work")]
    public string? WorkType { get; init; }

    [JsonPropertyName("equipmentId")]
    [Description("The equipment id")]
    public Guid? EquipmentId { get; init; }

    [JsonPropertyName("equipmentAccountingCode")]
    [Description("The equipment accounting code")]
    public string? EquipmentAccountingCode { get; init; }

    [JsonPropertyName("workOrderJobId")]
    [Description("The work order job id")]
    public Guid? WorkOrderJobId { get; init; }

    [JsonPropertyName("jobAltCode")]
    [Description("The job alternate code")]
    public string? JobAltCode { get; init; }

    [JsonPropertyName("mechanicCode")]
    [Description("The mechanic code")]
    public string? MechanicCode { get; init; }

    [JsonPropertyName("mechanicAccountingCode")]
    [Description("The mechanic accounting code")]
    public string? MechanicAccountingCode { get; init; }

    [JsonPropertyName("payclass")]
    [Description("The pay class")]
    public string? Payclass { get; init; }

    [JsonPropertyName("payclassAccountingCode")]
    [Description("The pay class accounting code")]
    public string? PayclassAccountingCode { get; init; }

    [JsonPropertyName("workCode")]
    [Description("The work code")]
    public string? WorkCode { get; init; }

    [JsonPropertyName("workCodeCostCode")]
    [Description("The work code cost code")]
    public string? WorkCodeCostCode { get; init; }

    [JsonPropertyName("itemCode")]
    [Description("The item code")]
    public string? ItemCode { get; init; }

    [JsonPropertyName("itemCodeCostCode")]
    [Description("The item code cost code")]
    public string? ItemCodeCostCode { get; init; }

    [JsonPropertyName("billingType")]
    [Description("The billing type")]
    public string? BillingType { get; init; }

    [JsonPropertyName("billingId")]
    [Description("The billing id")]
    public string? BillingId { get; init; }

    [JsonPropertyName("serviceEquipmentCode")]
    [Description("The service equipment code")]
    public string? ServiceEquipmentCode { get; init; }

    [JsonPropertyName("serviceEquipmentAccountingCode")]
    [Description("The service equipment accounting code")]
    public string? ServiceEquipmentAccountingCode { get; init; }

    [JsonPropertyName("overrideCostCode")]
    [Description("The override cost code")]
    public string? OverrideCostCode { get; init; }

    [JsonPropertyName("damage")]
    [Description("Whether the time card is for damage")]
    public bool? Damage { get; init; }

    [JsonPropertyName("onSite")]
    [Description("Whether the work was performed on site")]
    public bool? OnSite { get; init; }

    [JsonPropertyName("hours")]
    [Description("The number of regular hours")]
    public double? Hours { get; init; }

    [JsonPropertyName("overtime")]
    [Description("The number of overtime hours")]
    public double? Overtime { get; init; }

    [JsonPropertyName("doubleTime")]
    [Description("The number of double time hours")]
    public double? DoubleTime { get; init; }

    [JsonPropertyName("approvalLevel1")]
    [Description("The first level approval")]
    public string? ApprovalLevel1 { get; init; }

    [JsonPropertyName("approvalLevel2")]
    [Description("The second level approval")]
    public string? ApprovalLevel2 { get; init; }

    [JsonPropertyName("approvalLevel3")]
    [Description("The third level approval")]
    public string? ApprovalLevel3 { get; init; }

    [JsonPropertyName("shiftDetails")]
    [Description("Additional shift details if available")]
    public ShiftDetails? ShiftDetails { get; init; }
}

public class ShiftDetails
{
    [JsonPropertyName("shiftName")]
    public string? ShiftName { get; init; }

    [JsonPropertyName("shiftStartTime")]
    public string? ShiftStartTime { get; init; }

    [JsonPropertyName("shiftEndTime")]
    public string? ShiftEndTime { get; init; }

    [JsonPropertyName("break1")]
    public string? Break1 { get; init; }

    [JsonPropertyName("break2")]
    public string? Break2 { get; init; }

    [JsonPropertyName("break3")]
    public string? Break3 { get; init; }

    [JsonPropertyName("meal1Start")]
    public string? Meal1Start { get; init; }

    [JsonPropertyName("meal1End")]
    public string? Meal1End { get; init; }

    [JsonPropertyName("meal2Start")]
    public string? Meal2Start { get; init; }

    [JsonPropertyName("meal2End")]
    public string? Meal2End { get; init; }
}