namespace Connector.HeavyBidEstimate.v1.Biditem;

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
[Description("Represents a biditem in HeavyBid Estimate")]
public class BiditemDataObject
{
    [JsonPropertyName("id")]
    [Description("The biditem id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("estimateId")]
    [Description("The estimate id")]
    public Guid EstimateId { get; init; }

    [JsonPropertyName("estimateCode")]
    [Description("Estimate code")]
    public string? EstimateCode { get; init; }

    [JsonPropertyName("lastModified")]
    [Description("Last modified timestamp")]
    public DateTime LastModified { get; init; }

    [JsonPropertyName("biditemCode")]
    [Description("Biditem code")]
    public int BiditemCode { get; init; }

    [JsonPropertyName("description")]
    [Description("Description")]
    public string? Description { get; init; }

    [JsonPropertyName("type")]
    [Description("Type")]
    public string? Type { get; init; }

    [JsonPropertyName("quantity")]
    [Description("Quantity")]
    public decimal Quantity { get; init; }

    [JsonPropertyName("bidQuantity")]
    [Description("Bid quantity")]
    public decimal BidQuantity { get; init; }

    [JsonPropertyName("units")]
    [Description("Units")]
    public string? Units { get; init; }

    [JsonPropertyName("clientNumber")]
    [Description("Client number")]
    public int ClientNumber { get; init; }

    [JsonPropertyName("subtotalLevel")]
    [Description("Subtotal level")]
    public string? SubtotalLevel { get; init; }

    [JsonPropertyName("otherOptions")]
    [Description("Other options")]
    public string? OtherOptions { get; init; }

    [JsonPropertyName("wbsCode")]
    [Description("WBS code")]
    public string? WbsCode { get; init; }

    [JsonPropertyName("passThrough")]
    [Description("Pass through flag")]
    public string? PassThrough { get; init; }

    [JsonPropertyName("marineLand")]
    [Description("Marine/Land indicator")]
    public string? MarineLand { get; init; }

    [JsonPropertyName("parent")]
    [Description("Parent")]
    public string? Parent { get; init; }

    [JsonPropertyName("subDivided")]
    [Description("Subdivided flag")]
    public string? SubDivided { get; init; }

    [JsonPropertyName("alternateUnits")]
    [Description("Alternate units")]
    public string? AlternateUnits { get; init; }

    [JsonPropertyName("alternateDescription")]
    [Description("Alternate description")]
    public string? AlternateDescription { get; init; }

    [JsonPropertyName("lowBid")]
    [Description("Low bid amount")]
    public decimal LowBid { get; init; }

    [JsonPropertyName("averageBid")]
    [Description("Average bid amount")]
    public decimal AverageBid { get; init; }

    [JsonPropertyName("highBid")]
    [Description("High bid amount")]
    public decimal HighBid { get; init; }

    [JsonPropertyName("stateCode")]
    [Description("State code")]
    public string? StateCode { get; init; }

    [JsonPropertyName("unitCostHoldingAccount")]
    [Description("Unit cost holding account")]
    public string? UnitCostHoldingAccount { get; init; }

    [JsonPropertyName("taxPercent")]
    [Description("Tax percentage")]
    public decimal TaxPercent { get; init; }

    [JsonPropertyName("taxable")]
    [Description("Taxable flag")]
    public string? Taxable { get; init; }

    [JsonPropertyName("bidPrice")]
    [Description("Bid price")]
    public decimal BidPrice { get; init; }

    // Summary groups 1-6
    [JsonPropertyName("summaryGroup1")]
    [Description("Summary group 1")]
    public string? SummaryGroup1 { get; init; }

    [JsonPropertyName("summaryGroup2")]
    [Description("Summary group 2")]
    public string? SummaryGroup2 { get; init; }

    [JsonPropertyName("summaryGroup3")]
    [Description("Summary group 3")]
    public string? SummaryGroup3 { get; init; }

    [JsonPropertyName("summaryGroup4")]
    [Description("Summary group 4")]
    public string? SummaryGroup4 { get; init; }

    [JsonPropertyName("summaryGroup5")]
    [Description("Summary group 5")]
    public string? SummaryGroup5 { get; init; }

    [JsonPropertyName("summaryGroup6")]
    [Description("Summary group 6")]
    public string? SummaryGroup6 { get; init; }

    [JsonPropertyName("reviewFlag")]
    [Description("Review flag")]
    public string? ReviewFlag { get; init; }

    [JsonPropertyName("estInitials")]
    [Description("Estimator initials")]
    public string? EstInitials { get; init; }

    [JsonPropertyName("sortCode")]
    [Description("Sort code")]
    public int SortCode { get; init; }

    [JsonPropertyName("costNotes")]
    [Description("Cost notes")]
    public string? CostNotes { get; init; }

    [JsonPropertyName("bidNotes")]
    [Description("Bid notes")]
    public string? BidNotes { get; init; }

    [JsonPropertyName("factor")]
    [Description("Factor")]
    public decimal Factor { get; init; }

    // Scheduling fields
    [JsonPropertyName("schedulingStart1")]
    [Description("Scheduling start 1")]
    public int SchedulingStart1 { get; init; }

    [JsonPropertyName("schedulingDuration1")]
    [Description("Scheduling duration 1")]
    public int SchedulingDuration1 { get; init; }

    [JsonPropertyName("schedulingPercent1")]
    [Description("Scheduling percent 1")]
    public decimal SchedulingPercent1 { get; init; }

    [JsonPropertyName("schedulingStart2")]
    [Description("Scheduling start 2")]
    public int SchedulingStart2 { get; init; }

    [JsonPropertyName("schedulingDuration2")]
    [Description("Scheduling duration 2")]
    public int SchedulingDuration2 { get; init; }

    [JsonPropertyName("schedulingPercent2")]
    [Description("Scheduling percent 2")]
    public decimal SchedulingPercent2 { get; init; }

    [JsonPropertyName("schedulingStart3")]
    [Description("Scheduling start 3")]
    public int SchedulingStart3 { get; init; }

    [JsonPropertyName("schedulingDuration3")]
    [Description("Scheduling duration 3")]
    public int SchedulingDuration3 { get; init; }

    [JsonPropertyName("schedulingPercent3")]
    [Description("Scheduling percent 3")]
    public decimal SchedulingPercent3 { get; init; }

    [JsonPropertyName("schedulingStart4")]
    [Description("Scheduling start 4")]
    public int SchedulingStart4 { get; init; }

    [JsonPropertyName("schedulingDuration4")]
    [Description("Scheduling duration 4")]
    public int SchedulingDuration4 { get; init; }

    [JsonPropertyName("schedulingPercent4")]
    [Description("Scheduling percent 4")]
    public decimal SchedulingPercent4 { get; init; }

    [JsonPropertyName("biditemPercentValue")]
    [Description("Biditem percent value")]
    public decimal BiditemPercentValue { get; init; }

    [JsonPropertyName("pricingStatus")]
    [Description("Pricing status")]
    public string? PricingStatus { get; init; }

    // User activities 1-4
    [JsonPropertyName("userActivity1")]
    [Description("User activity 1")]
    public decimal UserActivity1 { get; init; }

    [JsonPropertyName("userActivity2")]
    [Description("User activity 2")]
    public decimal UserActivity2 { get; init; }

    [JsonPropertyName("userActivity3")]
    [Description("User activity 3")]
    public decimal UserActivity3 { get; init; }

    [JsonPropertyName("userActivity4")]
    [Description("User activity 4")]
    public decimal UserActivity4 { get; init; }

    // Cost fields
    [JsonPropertyName("labor")]
    [Description("Labor cost")]
    public decimal Labor { get; init; }

    [JsonPropertyName("burden")]
    [Description("Burden cost")]
    public decimal Burden { get; init; }

    [JsonPropertyName("permanentMaterial")]
    [Description("Permanent material cost")]
    public decimal PermanentMaterial { get; init; }

    [JsonPropertyName("constructionMaterial")]
    [Description("Construction material cost")]
    public decimal ConstructionMaterial { get; init; }

    [JsonPropertyName("subcontract")]
    [Description("Subcontract cost")]
    public decimal Subcontract { get; init; }

    [JsonPropertyName("equipmentOperatingExpense")]
    [Description("Equipment operating expense")]
    public decimal EquipmentOperatingExpense { get; init; }

    [JsonPropertyName("companyEquipment")]
    [Description("Company equipment cost")]
    public decimal CompanyEquipment { get; init; }

    [JsonPropertyName("rentedEquipment")]
    [Description("Rented equipment cost")]
    public decimal RentedEquipment { get; init; }

    // Misc costs 1-3
    [JsonPropertyName("misc1")]
    [Description("Miscellaneous cost 1")]
    public decimal Misc1 { get; init; }

    [JsonPropertyName("misc2")]
    [Description("Miscellaneous cost 2")]
    public decimal Misc2 { get; init; }

    [JsonPropertyName("misc3")]
    [Description("Miscellaneous cost 3")]
    public decimal Misc3 { get; init; }

    [JsonPropertyName("directTotal")]
    [Description("Direct total cost")]
    public decimal DirectTotal { get; init; }

    [JsonPropertyName("equipmentAccountDollars")]
    [Description("Equipment account dollars")]
    public decimal EquipmentAccountDollars { get; init; }

    [JsonPropertyName("indirectTotal")]
    [Description("Indirect total cost")]
    public decimal IndirectTotal { get; init; }

    [JsonPropertyName("addonBond")]
    [Description("Addon bond cost")]
    public decimal AddonBond { get; init; }

    [JsonPropertyName("totalCost")]
    [Description("Total cost")]
    public decimal TotalCost { get; init; }

    [JsonPropertyName("totalCostAdjToBidQuantity")]
    [Description("Total cost adjusted to bid quantity")]
    public decimal TotalCostAdjToBidQuantity { get; init; }

    [JsonPropertyName("markup")]
    [Description("Markup amount")]
    public decimal Markup { get; init; }

    [JsonPropertyName("totalTakeoff")]
    [Description("Total takeoff amount")]
    public decimal TotalTakeoff { get; init; }

    [JsonPropertyName("totalBalanced")]
    [Description("Total balanced amount")]
    public decimal TotalBalanced { get; init; }

    [JsonPropertyName("manhours")]
    [Description("Man hours")]
    public decimal Manhours { get; init; }

    [JsonPropertyName("escalationTotalCost")]
    [Description("Escalation total cost")]
    public decimal EscalationTotalCost { get; init; }

    [JsonPropertyName("fixedCost")]
    [Description("Fixed cost")]
    public decimal FixedCost { get; init; }

    [JsonPropertyName("freezeBid")]
    [Description("Freeze bid flag")]
    public string? FreezeBid { get; init; }

    [JsonPropertyName("sequenceItemNumber")]
    [Description("Sequence item number")]
    public int SequenceItemNumber { get; init; }

    [JsonPropertyName("holdingAccountActivityQuantity")]
    [Description("Holding account activity quantity")]
    public decimal HoldingAccountActivityQuantity { get; init; }

    [JsonPropertyName("accountingRevenueCode")]
    [Description("Accounting revenue code")]
    public int AccountingRevenueCode { get; init; }

    [JsonPropertyName("schedulingCPMCode")]
    [Description("Scheduling CPM code")]
    public string? SchedulingCPMCode { get; init; }

    [JsonPropertyName("schedulingCPMOverlap")]
    [Description("Scheduling CPM overlap")]
    public int SchedulingCPMOverlap { get; init; }

    [JsonPropertyName("schedulingCalc_Days")]
    [Description("Scheduling calculated days")]
    public int SchedulingCalcDays { get; init; }

    [JsonPropertyName("folder")]
    [Description("Folder")]
    public string? Folder { get; init; }

    [JsonPropertyName("singleAlternate")]
    [Description("Single alternate flag")]
    public string? SingleAlternate { get; init; }

    [JsonPropertyName("packageAlternate")]
    [Description("Package alternate")]
    public string? PackageAlternate { get; init; }

    [JsonPropertyName("userFlag1")]
    [Description("User flag 1")]
    public string? UserFlag1 { get; init; }

    [JsonPropertyName("userFlag2")]
    [Description("User flag 2")]
    public string? UserFlag2 { get; init; }

    [JsonPropertyName("childBidPrice")]
    [Description("Child bid price")]
    public decimal ChildBidPrice { get; init; }

    [JsonPropertyName("zeroPriceText")]
    [Description("Zero price text")]
    public string? ZeroPriceText { get; init; }

    [JsonPropertyName("unitCostItem")]
    [Description("Unit cost item")]
    public string? UnitCostItem { get; init; }
}