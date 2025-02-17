namespace Connector.HeavyJob.v1.PurchaseOrderItems;

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
[Description("Represents a purchase order line item in HeavyJob")]
public class PurchaseOrderItemsDataObject
{
    [JsonPropertyName("id")]
    [Description("The purchase order line item id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("purchaseOrderId")]
    [Description("The purchase order id")]
    [Required]
    public required Guid PurchaseOrderId { get; init; }

    [JsonPropertyName("jobMaterialId")]
    [Description("The job-level material or custom cost type item id")]
    [Required]
    public required Guid JobMaterialId { get; init; }

    [JsonPropertyName("material")]
    [Description("A POCO used as a base class for Materials and Custom Cost Type Items")]
    public MaterialCustomCostCompactRead? Material { get; init; }

    [JsonPropertyName("note")]
    [Description("The note")]
    public string? Note { get; init; }

    [JsonPropertyName("description")]
    [Description("A description for this purchase order line item")]
    public string? Description { get; init; }

    [JsonPropertyName("sequence")]
    [Description("The sequence number of the purchase order line item")]
    [Required]
    public required double Sequence { get; init; }

    [JsonPropertyName("quantity")]
    [Description("The item quantity")]
    [Required]
    public required double Quantity { get; init; }

    [JsonPropertyName("unitCost")]
    [Description("The item unit cost")]
    [Required]
    public required double UnitCost { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The item unit of measure")]
    [Required]
    public required string UnitOfMeasure { get; init; }

    [JsonPropertyName("salesTaxPercent")]
    [Description("The item sales tax represented in percent")]
    public double? SalesTaxPercent { get; init; }

    [JsonPropertyName("isFullyInstalled")]
    [Description("Whether the purchase order line item is fully installed")]
    public bool? IsFullyInstalled { get; init; }

    [JsonPropertyName("isFullyReceived")]
    [Description("Whether the purchase order line item is fully received")]
    public bool? IsFullyReceived { get; init; }

    [JsonPropertyName("isCanceled")]
    [Description("Whether the purchase order line item is canceled")]
    public bool IsCanceled { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Whether the purchase order line item is deleted")]
    public bool IsDeleted { get; init; }
}

public class MaterialCustomCostCompactRead
{
    [JsonPropertyName("id")]
    [Description("The material id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("type")]
    [Description("The material type")]
    [Required]
    public required string Type { get; init; }

    [JsonPropertyName("code")]
    [Description("Code")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("description")]
    [Description("Description")]
    [Required]
    public required string Description { get; init; }
}