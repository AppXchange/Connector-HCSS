namespace Connector.Equipment360.v1.WorkOrderPurchase;

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
[Description("Represents a work order purchase in Equipment360")]
public class WorkOrderPurchaseDataObject
{
    [JsonPropertyName("id")]
    [Description("The unique identifier")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("workOrderNumber")]
    [Description("The work order number")]
    public int WorkOrderNumber { get; init; }

    [JsonPropertyName("vendorCode")]
    [Description("The vendor code")]
    public string? VendorCode { get; init; }

    [JsonPropertyName("referenceNumber")]
    [Description("The reference number (e.g. Invoice #)")]
    public string? ReferenceNumber { get; init; }

    [JsonPropertyName("partNumber")]
    [Description("The part number")]
    public string? PartNumber { get; init; }

    [JsonPropertyName("partDescription")]
    [Description("The part description")]
    public string? PartDescription { get; init; }

    [JsonPropertyName("vendorPartNumber")]
    [Description("The vendor's part number")]
    public string? VendorPartNumber { get; init; }

    [JsonPropertyName("itemCode")]
    [Description("The item code")]
    public string? ItemCode { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The unit of measure")]
    public string? UnitOfMeasure { get; init; }

    [JsonPropertyName("qtyOrdered")]
    [Description("The quantity ordered")]
    public double QtyOrdered { get; init; }

    [JsonPropertyName("qtyUsed")]
    [Description("The quantity used")]
    public double QtyUsed { get; init; }

    [JsonPropertyName("purchaseDate")]
    [Description("The purchase date")]
    public DateTime PurchaseDate { get; init; }

    [JsonPropertyName("equipmentCode")]
    [Description("The equipment code")]
    public string? EquipmentCode { get; init; }

    [JsonPropertyName("modifiedTimestamp")]
    [Description("The last modified timestamp")]
    public DateTime ModifiedTimestamp { get; init; }

    [JsonPropertyName("isReconciled")]
    [Description("Whether the purchase has been reconciled")]
    public bool IsReconciled { get; init; }

    [JsonPropertyName("inventoryLocation")]
    [Description("The inventory location")]
    public string? InventoryLocation { get; init; }
}