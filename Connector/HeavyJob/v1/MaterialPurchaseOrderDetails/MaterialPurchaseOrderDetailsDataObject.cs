namespace Connector.HeavyJob.v1.MaterialPurchaseOrderDetails;

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
[Description("Represents a material purchase order detail in HeavyJob")]
public class MaterialPurchaseOrderDetailsDataObject
{
    [JsonPropertyName("id")]
    [Description("The purchase order detail id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("purchaseOrderId")]
    [Description("The purchase order id")]
    [Required]
    public required Guid PurchaseOrderId { get; init; }

    [JsonPropertyName("sequence")]
    [Description("The sequence number of the purchase order detail. Used to sort the purchase order details")]
    [Required]
    public required double Sequence { get; init; }

    [JsonPropertyName("isFullyReceived")]
    [Description("Whether the item is fully received. Default is false")]
    public bool IsFullyReceived { get; init; }

    [JsonPropertyName("isFullyInstalled")]
    [Description("Whether the item is fully installed. Default is false")]
    public bool IsFullyInstalled { get; init; }

    [JsonPropertyName("note")]
    [Description("The note")]
    public string? Note { get; init; }

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
    public double SalesTaxPercent { get; init; }

    [JsonPropertyName("isCancelled")]
    [Description("Whether the purchase order detail is canceled")]
    public bool IsCancelled { get; init; }

    [JsonPropertyName("alternateDescription")]
    [Description("An alternate description for this purchase order")]
    public string? AlternateDescription { get; init; }

    [JsonPropertyName("vendorItemNumber")]
    [Description("The vendor item number")]
    public string? VendorItemNumber { get; init; }

    [JsonPropertyName("jobMaterialId")]
    [Description("The job material Id")]
    [Required]
    public required Guid JobMaterialId { get; init; }
}