namespace Connector.HeavyJob.v1.AdvancedBudgetCustomCostTypes;

using Connector.HeavyJob.v1.AdvancedBudgetCustomCostTypeItem;
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
[Description("Represents a custom cost type item advanced budget in HeavyJob")]
public class AdvancedBudgetCustomCostTypesDataObject
{
    [JsonPropertyName("id")]
    [Description("The custom-cost-type item advanced budget id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("costCodeId")]
    [Description("The cost code id")]
    [Required]
    public required Guid CostCodeId { get; init; }

    [JsonPropertyName("jobCustomCostTypeItemId")]
    [Description("The job-level custom-cost-type item id")]
    [Required]
    public required Guid JobCustomCostTypeItemId { get; init; }

    [JsonPropertyName("purchaseOrderDetailId")]
    [Description("The purchase order detail id")]
    public Guid? PurchaseOrderDetailId { get; init; }

    [JsonPropertyName("status")]
    [Description("The status of the custom cost type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CustomCostTypeStatus Status { get; init; }

    [JsonPropertyName("quantity")]
    [Description("The quantity of the custom-cost-type item")]
    public double Quantity { get; init; }

    [JsonPropertyName("customCostTypeItemDescription")]
    [Description("The custom-cost-type item description")]
    public string? CustomCostTypeItemDescription { get; init; }

    [JsonPropertyName("purchaseOrderId")]
    [Description("The purchase order id")]
    public Guid? PurchaseOrderId { get; init; }

    [JsonPropertyName("costCode")]
    [Description("The cost code")]
    public string? CostCode { get; init; }

    [JsonPropertyName("costCodeDescription")]
    [Description("The cost code description")]
    public string? CostCodeDescription { get; init; }

    [JsonPropertyName("salesTaxPercent")]
    [Description("The sales tax, expressed as a percent")]
    public double SalesTaxPercent { get; init; }

    [JsonPropertyName("unitCost")]
    [Description("The cost per unit of measure, in dollars")]
    public double UnitCost { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The unit of measure")]
    public string? UnitOfMeasure { get; init; }

    [JsonPropertyName("vendorId")]
    [Description("The vendor id")]
    public Guid? VendorId { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Soft Deleted Flag")]
    public bool IsDeleted { get; init; }

    [JsonPropertyName("mCostTypeItemBusinessUnitId")]
    [Description("MCostTypeBusinessUnitId")]
    public Guid MCostTypeItemBusinessUnitId { get; init; }
}