namespace Connector.HeavyBidEstimate.v1.Resource;

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
[Description("Represents a resource in HeavyBid")]
public class ResourceDataObject
{
    [JsonPropertyName("id")]
    [Description("The resource ID")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("estimateId")]
    [Description("The estimate ID")]
    public Guid EstimateId { get; init; }

    [JsonPropertyName("estimateCode")]
    [Description("The estimate code")]
    public string? EstimateCode { get; init; }

    [JsonPropertyName("biditemId")]
    [Description("The bid item ID")]
    public Guid BidItemId { get; init; }

    [JsonPropertyName("activityId")]
    [Description("The activity ID")]
    public Guid ActivityId { get; init; }

    [JsonPropertyName("lastModified")]
    [Description("The last modified timestamp")]
    public DateTime LastModified { get; init; }

    [JsonPropertyName("resourceCode")]
    [Description("The resource code")]
    public string? ResourceCode { get; init; }

    [JsonPropertyName("activityCode")]
    [Description("The activity code")]
    public int ActivityCode { get; init; }

    [JsonPropertyName("biditemCode")]
    [Description("The bid item code")]
    public int BidItemCode { get; init; }

    [JsonPropertyName("description")]
    [Description("The description")]
    public string? Description { get; init; }

    [JsonPropertyName("typeCost")]
    [Description("The type cost")]
    public string? TypeCost { get; init; }

    [JsonPropertyName("typeOfEquipmentRent")]
    [Description("The type of equipment rent")]
    public string? TypeOfEquipmentRent { get; init; }

    [JsonPropertyName("subType")]
    [Description("The sub type")]
    public string? SubType { get; init; }

    [JsonPropertyName("quantity")]
    [Description("The quantity")]
    public decimal Quantity { get; init; }

    [JsonPropertyName("units")]
    [Description("The units")]
    public string? Units { get; init; }

    [JsonPropertyName("percent")]
    [Description("The percent")]
    public decimal Percent { get; init; }

    [JsonPropertyName("unitPrice")]
    [Description("The unit price")]
    public decimal UnitPrice { get; init; }

    [JsonPropertyName("currency")]
    [Description("The currency")]
    public string? Currency { get; init; }

    [JsonPropertyName("subTypeCost")]
    [Description("The sub type cost")]
    public decimal SubTypeCost { get; init; }

    [JsonPropertyName("total")]
    [Description("The total")]
    public decimal Total { get; init; }

    [JsonPropertyName("factorable")]
    [Description("The factorable flag")]
    public string? Factorable { get; init; }

    [JsonPropertyName("factor")]
    [Description("The factor")]
    public decimal Factor { get; init; }

    [JsonPropertyName("supplementalDescription")]
    [Description("The supplemental description")]
    public string? SupplementalDescription { get; init; }

    [JsonPropertyName("skipCost")]
    [Description("The skip cost flag")]
    public string? SkipCost { get; init; }

    [JsonPropertyName("pieces")]
    [Description("The pieces")]
    public decimal Pieces { get; init; }

    [JsonPropertyName("operatingPercent")]
    [Description("The operating percent")]
    public decimal OperatingPercent { get; init; }

    [JsonPropertyName("rentPercent")]
    [Description("The rent percent")]
    public decimal RentPercent { get; init; }

    [JsonPropertyName("productionCode")]
    [Description("The production code")]
    public string? ProductionCode { get; init; }

    [JsonPropertyName("production")]
    [Description("The production")]
    public decimal Production { get; init; }

    [JsonPropertyName("crewCode")]
    [Description("The crew code")]
    public string? CrewCode { get; init; }

    [JsonPropertyName("equipmentOperatorCode")]
    [Description("The equipment operator code")]
    public string? EquipmentOperatorCode { get; init; }

    [JsonPropertyName("escalationPercent")]
    [Description("The escalation percent")]
    public decimal EscalationPercent { get; init; }

    [JsonPropertyName("plugIndicator")]
    [Description("The plug indicator")]
    public string? PlugIndicator { get; init; }

    [JsonPropertyName("calendar")]
    [Description("The calendar")]
    public string? Calendar { get; init; }

    [JsonPropertyName("startDay")]
    [Description("The start day")]
    public string? StartDay { get; init; }

    [JsonPropertyName("specialSchedule")]
    [Description("The special schedule")]
    public string? SpecialSchedule { get; init; }

    [JsonPropertyName("manHourAdjustmentPerShift")]
    [Description("The man hour adjustment per shift")]
    public decimal ManHourAdjustmentPerShift { get; init; }

    [JsonPropertyName("selectedVendor")]
    [Description("The selected vendor")]
    public string? SelectedVendor { get; init; }

    [JsonPropertyName("manHourUnit")]
    [Description("The man hour unit")]
    public decimal ManHourUnit { get; init; }

    [JsonPropertyName("escalationOverride")]
    [Description("The escalation override")]
    public string? EscalationOverride { get; init; }

    [JsonPropertyName("class")]
    [Description("The class")]
    public string? Class { get; init; }

    [JsonPropertyName("alternateQuantity")]
    [Description("The alternate quantity")]
    public decimal AlternateQuantity { get; init; }

    [JsonPropertyName("alternateUnits")]
    [Description("The alternate units")]
    public string? AlternateUnits { get; init; }

    [JsonPropertyName("resourceText1")]
    [Description("The resource text 1")]
    public string? ResourceText1 { get; init; }

    [JsonPropertyName("resourceText2")]
    [Description("The resource text 2")]
    public string? ResourceText2 { get; init; }

    [JsonPropertyName("accountingJCCode")]
    [Description("The accounting JC code")]
    public string? AccountingJCCode { get; init; }

    [JsonPropertyName("dispatcherType")]
    [Description("The dispatcher type")]
    public string? DispatcherType { get; init; }

    [JsonPropertyName("dispatcherSubType")]
    [Description("The dispatcher sub type")]
    public string? DispatcherSubType { get; init; }
}