namespace Connector.HeavyJob.v1.AdvancedBudgetCustomCostTypeItem;

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
public class AdvancedBudgetCustomCostTypeItemDataObject
{
    [JsonPropertyName("id")]
    [Description("The unique identifier")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("costCodeId")]
    [Description("The cost code id")]
    [Required]
    public required Guid CostCodeId { get; init; }

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

    [JsonPropertyName("jobCustomCostTypeItemId")]
    public Guid JobCustomCostTypeItemId { get; init; }

    [JsonPropertyName("customCostTypeItemDescription")]
    public string? CustomCostTypeItemDescription { get; init; }

    [JsonPropertyName("purchaseOrderId")]
    public Guid? PurchaseOrderId { get; init; }

    [JsonPropertyName("costCode")]
    public string? CostCode { get; init; }

    [JsonPropertyName("costCodeDescription")]
    public string? CostCodeDescription { get; init; }

    [JsonPropertyName("salesTaxPercent")]
    public double SalesTaxPercent { get; init; }

    [JsonPropertyName("unitCost")]
    public double UnitCost { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    public string? UnitOfMeasure { get; init; }

    [JsonPropertyName("vendorId")]
    public Guid? VendorId { get; init; }

    [JsonPropertyName("isDeleted")]
    public bool IsDeleted { get; init; }

    [JsonPropertyName("mCostTypeItemBusinessUnitId")]
    public Guid MCostTypeItemBusinessUnitId { get; init; }
}

public enum CustomCostTypeStatus
{
    Active,
    Completed,
    Discontinued
}