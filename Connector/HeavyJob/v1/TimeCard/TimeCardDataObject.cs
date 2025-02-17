namespace Connector.HeavyJob.v1.TimeCard;

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
[Description("Represents a time card in HeavyJob")]
public class TimeCardDataObject
{
    [JsonPropertyName("id")]
    [Description("The time card guid")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("foremanId")]
    [Description("The foreman guid")]
    [Required]
    public required Guid ForemanId { get; init; }

    [JsonPropertyName("foremanCode")]
    [Description("The foreman's employee code")]
    [Required]
    public required string ForemanCode { get; init; }

    [JsonPropertyName("foremanDescription")]
    [Description("The foreman's full name")]
    [Required]
    public required string ForemanDescription { get; init; }

    [JsonPropertyName("jobId")]
    [Description("The job guid")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("jobCode")]
    [Description("The job code")]
    [Required]
    public required string JobCode { get; init; }

    [JsonPropertyName("jobDescription")]
    [Description("The job description")]
    public string? JobDescription { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit guid")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("businessUnitCode")]
    [Description("The business unit code")]
    [Required]
    public required string BusinessUnitCode { get; init; }

    [JsonPropertyName("businessUnitDescription")]
    [Description("The business unit description")]
    public string? BusinessUnitDescription { get; init; }

    [JsonPropertyName("date")]
    [Description("The time card date")]
    [Required]
    public required DateTime Date { get; init; }

    [JsonPropertyName("shift")]
    [Description("The shift of the time card")]
    public int Shift { get; init; }

    [JsonPropertyName("revision")]
    [Description("The current revision of the time card")]
    [Required]
    public required int Revision { get; init; }

    [JsonPropertyName("isApproved")]
    [Description("The flag whether the time card is approved")]
    [Required]
    public required bool IsApproved { get; init; }

    [JsonPropertyName("approvedById")]
    [Description("The user id of the approver")]
    public Guid? ApprovedById { get; init; }

    [JsonPropertyName("isReviewed")]
    [Description("The flag whether the time card is reviewed")]
    [Required]
    public required bool IsReviewed { get; init; }

    [JsonPropertyName("reviewedById")]
    [Description("The user id of the reviewer")]
    public Guid? ReviewedById { get; init; }

    [JsonPropertyName("isAccepted")]
    [Description("The flag whether the time card is accepted")]
    [Required]
    public required bool IsAccepted { get; init; }

    [JsonPropertyName("acceptedById")]
    [Description("The user id of the accepter")]
    public Guid? AcceptedById { get; init; }

    [JsonPropertyName("isRejected")]
    [Description("The flag whether the time card is rejected")]
    [Required]
    public required bool IsRejected { get; init; }

    [JsonPropertyName("rejectedById")]
    [Description("The user id of the rejecter")]
    public Guid? RejectedById { get; init; }

    [JsonPropertyName("sentToPayrollRevision")]
    [Description("The revision of the time card sent to payroll")]
    public int? SentToPayrollRevision { get; init; }

    [JsonPropertyName("sentToPayrollDateTime")]
    [Description("When the time card was sent to payroll")]
    public DateTime? SentToPayrollDateTime { get; init; }

    [JsonPropertyName("lastModifiedDateTime")]
    [Description("The RFC 3339 dateTime, in UTC, when this time card was last modified")]
    [Required]
    public required DateTime LastModifiedDateTime { get; init; }

    [JsonPropertyName("lockedDateTime")]
    [Description("The date time when this time card was locked (submitted)")]
    public DateTime? LockedDateTime { get; init; }

    [JsonPropertyName("costCodes")]
    [Description("The time card cost codes")]
    public TimeCardCostCode[]? CostCodes { get; init; }

    [JsonPropertyName("employees")]
    [Description("The time card employees")]
    public TimeCardEmployee[]? Employees { get; init; }

    [JsonPropertyName("equipment")]
    [Description("The time card equipment")]
    public TimeCardEquipment[]? Equipment { get; init; }
}

public class TimeCardCostCode
{
    [JsonPropertyName("timeCardCostCodeId")]
    [Description("The time card cost code guid")]
    [Required]
    public required Guid TimeCardCostCodeId { get; init; }

    [JsonPropertyName("costCodeId")]
    [Description("The cost code guid")]
    [Required]
    public required Guid CostCodeId { get; init; }

    [JsonPropertyName("costCodeCode")]
    [Description("The cost code code")]
    [Required]
    public required string CostCodeCode { get; init; }

    [JsonPropertyName("costCodeDescription")]
    [Description("The cost code description")]
    public string? CostCodeDescription { get; init; }

    [JsonPropertyName("isRework")]
    [Description("The flag indicating whether the cost code is a rework item")]
    [Required]
    public required bool IsRework { get; init; }

    [JsonPropertyName("isTm")]
    [Description("The flag indicating whether the cost code is a time-and-material item")]
    [Required]
    public required bool IsTm { get; init; }

    [JsonPropertyName("quantity")]
    [Description("The quantity")]
    [Required]
    public required double Quantity { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The unit of measure for the specified quantity")]
    [Required]
    public required string UnitOfMeasure { get; init; }

    [JsonPropertyName("column")]
    [Description("The column order")]
    public int Column { get; init; }

    [JsonPropertyName("publicNotes")]
    [Description("The cost code public inspector notes")]
    public string? PublicNotes { get; init; }

    [JsonPropertyName("privateNotes")]
    [Description("The cost code private company notes")]
    public string? PrivateNotes { get; init; }
}

public class TimeCardEmployee
{
    [JsonPropertyName("timeCardEmployeeId")]
    [Description("The time card employee guid")]
    [Required]
    public required Guid TimeCardEmployeeId { get; init; }

    [JsonPropertyName("employeeId")]
    [Description("The employee guid")]
    [Required]
    public required Guid EmployeeId { get; init; }

    [JsonPropertyName("employeeCode")]
    [Description("The employee's code")]
    [Required]
    public required string EmployeeCode { get; init; }

    [JsonPropertyName("employeeDescription")]
    [Description("The employee's full name")]
    [Required]
    public required string EmployeeDescription { get; init; }

    [JsonPropertyName("payClassId")]
    [Description("The pay class guid associated to the time card employee")]
    [Required]
    public required Guid PayClassId { get; init; }

    [JsonPropertyName("payClassCode")]
    [Description("The pay class code of the associated employee")]
    [Required]
    public required string PayClassCode { get; init; }

    [JsonPropertyName("payClassDescription")]
    [Description("The pay class description of the associated employee")]
    public string? PayClassDescription { get; init; }

    [JsonPropertyName("regularHours")]
    [Description("The time card employee regular hours")]
    public TimeCardEmployeeHourEntry[]? RegularHours { get; init; }

    [JsonPropertyName("overtimeHours")]
    [Description("The time card employee overtime hours")]
    public TimeCardEmployeeHourEntry[]? OvertimeHours { get; init; }

    [JsonPropertyName("doubleOvertimeHours")]
    [Description("The time card employee double overtime hours")]
    public TimeCardEmployeeHourEntry[]? DoubleOvertimeHours { get; init; }

    [JsonPropertyName("costAdjustments")]
    [Description("The time card employee cost adjustments")]
    public TimeCardEmployeeCostAdjustment[]? CostAdjustments { get; init; }

    [JsonPropertyName("order")]
    [Description("The employee row order")]
    public int Order { get; init; }
}

public class TimeCardEmployeeHourEntry
{
    [JsonPropertyName("timeCardCostCodeId")]
    [Description("The time card cost code guid")]
    [Required]
    public required Guid TimeCardCostCodeId { get; init; }

    [JsonPropertyName("tagId")]
    [Description("The tag guid")]
    public Guid? TagId { get; init; }

    [JsonPropertyName("tagCode")]
    [Description("The tag code")]
    public string? TagCode { get; init; }

    [JsonPropertyName("hours")]
    [Description("The hours")]
    public double Hours { get; init; }
}

public class TimeCardEmployeeCostAdjustment
{
    [JsonPropertyName("costAdjustmentId")]
    [Description("The cost adjustment's id")]
    [Required]
    public required Guid CostAdjustmentId { get; init; }

    [JsonPropertyName("costAdjustmentCode")]
    [Description("The cost adjustment's code")]
    [Required]
    public required string CostAdjustmentCode { get; init; }

    [JsonPropertyName("costAdjustmentDescription")]
    [Description("The cost adjustment's description")]
    public string? CostAdjustmentDescription { get; init; }

    [JsonPropertyName("costAdjustmentType")]
    [Description("The cost adjustment type")]
    public string? CostAdjustmentType { get; init; }

    [JsonPropertyName("quantity")]
    [Description("The quantity of the cost adjustment")]
    public double Quantity { get; init; }
}

public class TimeCardEquipment
{
    [JsonPropertyName("timeCardEquipmentId")]
    [Description("The time card equipment guid")]
    [Required]
    public required Guid TimeCardEquipmentId { get; init; }

    [JsonPropertyName("equipmentId")]
    [Description("The equipment guid")]
    [Required]
    public required Guid EquipmentId { get; init; }

    [JsonPropertyName("equipmentCode")]
    [Description("The equipment code")]
    [Required]
    public required string EquipmentCode { get; init; }

    [JsonPropertyName("equipmentDescription")]
    [Description("The equipment description")]
    public string? EquipmentDescription { get; init; }

    [JsonPropertyName("payClassId")]
    [Description("The pay class guid associated to the time card equipment, if any")]
    public Guid? PayClassId { get; init; }

    [JsonPropertyName("payClassCode")]
    [Description("The pay class code, if any")]
    public string? PayClassCode { get; init; }

    [JsonPropertyName("payClassDescription")]
    [Description("The pay class description, if any")]
    public string? PayClassDescription { get; init; }

    [JsonPropertyName("linkedTimeCardEmployeeId")]
    [Description("The time card employee guid the time card equipment is linked to")]
    public Guid? LinkedTimeCardEmployeeId { get; init; }

    [JsonPropertyName("totalHours")]
    [Description("The time card equipment total hours")]
    public TimeCardEquipmentHourEntry[]? TotalHours { get; init; }

    [JsonPropertyName("ownershipHours")]
    [Description("The time card equipment ownership hours")]
    public TimeCardEquipmentHourEntry[]? OwnershipHours { get; init; }

    [JsonPropertyName("operatingHours")]
    [Description("The time card equipment operating hours")]
    public TimeCardEquipmentHourEntry[]? OperatingHours { get; init; }

    [JsonPropertyName("order")]
    [Description("The equipment row order")]
    public int Order { get; init; }
}

public class TimeCardEquipmentHourEntry
{
    [JsonPropertyName("timeCardCostCodeId")]
    [Description("The time card cost code guid")]
    [Required]
    public required Guid TimeCardCostCodeId { get; init; }

    [JsonPropertyName("tagId")]
    [Description("The tag guid")]
    public Guid? TagId { get; init; }

    [JsonPropertyName("tagCode")]
    [Description("The tag code")]
    public string? TagCode { get; init; }

    [JsonPropertyName("hours")]
    [Description("The hours")]
    public double Hours { get; init; }
}