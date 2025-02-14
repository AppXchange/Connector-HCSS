namespace Connector.Equipment360.v1.PurchaseOrderDetails;

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
[Description("Represents a purchase order detail")]
public class PurchaseOrderDetailsDataObject
{
    [JsonPropertyName("id")]
    [Description("The purchase order detail id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("purchaseOrderId")]
    [Description("Purchase Order Id")]
    [Required]
    public required Guid PurchaseOrderId { get; init; }

    [JsonPropertyName("orderQuantityReceived")]
    [Description("Order quantity received")]
    public int? OrderQuantityReceived { get; init; }

    [JsonPropertyName("taxAmount")]
    [Description("The tax amount")]
    public double? TaxAmount { get; init; }

    [JsonPropertyName("totalCost")]
    [Description("Total cost for this line item")]
    [Required]
    public required double TotalCost { get; init; }

    [JsonPropertyName("type")]
    [Description("Purchase order detail type")]
    [Required]
    public required string Type { get; init; }

    [JsonPropertyName("approvalStatus")]
    [Description("Purchase order approval status")]
    public string? ApprovalStatus { get; init; }

    [JsonPropertyName("partId")]
    [Description("The part id (not required if there's a charge item)")]
    public Guid? PartId { get; init; }

    [JsonPropertyName("vendorPartNumber")]
    [Description("Vendor part number")]
    public string? VendorPartNumber { get; init; }

    [JsonPropertyName("purchaseUnitOfMeasureId")]
    [Description("The purchase unit of measure id (not required if there's a charge item)")]
    public Guid? PurchaseUnitOfMeasureId { get; init; }

    [JsonPropertyName("partLocationId")]
    [Description("The inventory location id (to pre-populate inventory location on the invoice)")]
    public Guid? PartLocationId { get; init; }

    [JsonPropertyName("quantity")]
    [Description("The quantity of the item")]
    [Required]
    public required int Quantity { get; init; }

    [JsonPropertyName("unitPrice")]
    [Description("The unit price of the item")]
    [Required]
    public required double UnitPrice { get; init; }

    [JsonPropertyName("isTaxable")]
    [Description("Whether the item is taxable")]
    public bool? IsTaxable { get; init; }

    [JsonPropertyName("chargeItem")]
    [Description("A miscellaneous charge item (there will be no partId when this is on the detail)")]
    public string? ChargeItem { get; init; }
}