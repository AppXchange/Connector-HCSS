namespace Connector.Equipment360.v1.Invoice;

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
[Description("Represents an invoice")]
public class InvoiceDataObject
{
    [JsonPropertyName("id")]
    [Description("The invoice id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("modifiedDateTime")]
    [Description("The invoice last modified date time")]
    public DateTime? ModifiedDateTime { get; init; }

    [JsonPropertyName("total")]
    [Description("The total amount of the invoice (in dollars)")]
    public double? Total { get; init; }

    [JsonPropertyName("invoiceNumber")]
    [Description("The invoice number to be used on the invoice")]
    public string? InvoiceNumber { get; init; }

    [JsonPropertyName("referenceNumber")]
    [Description("The reference number to be used on the invoice")]
    public string? ReferenceNumber { get; init; }

    [JsonPropertyName("receivalDate")]
    [Description("The date invoice was issued")]
    public DateTime? ReceivalDate { get; init; }

    [JsonPropertyName("vendorCode")]
    [Description("The vendor code for the invoice")]
    [Required]
    public required string VendorCode { get; init; }

    [JsonPropertyName("status")]
    [Description("The purchasing status for the invoice (Open/Closed)")]
    public string? Status { get; init; }

    [JsonPropertyName("details")]
    [Description("The notes for the purchase order")]
    public InvoiceDetailDataObject[]? Details { get; init; }
}

public class InvoiceDetailDataObject
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("partNum")]
    public string? PartNum { get; init; }

    [JsonPropertyName("vendorPartNumber")]
    public string? VendorPartNumber { get; init; }

    [JsonPropertyName("purchaseUnitOfMeasureId")]
    public Guid PurchaseUnitOfMeasureId { get; init; }

    [JsonPropertyName("partLocationId")]
    public Guid PartLocationId { get; init; }

    [JsonPropertyName("qtyOrdered")]
    public double QtyOrdered { get; init; }

    [JsonPropertyName("qtyReceived")]
    public double QtyReceived { get; init; }

    [JsonPropertyName("unitPrice")]
    public double UnitPrice { get; init; }

    [JsonPropertyName("isTaxable")]
    public bool IsTaxable { get; init; }

    [JsonPropertyName("taxRate")]
    public double TaxRate { get; init; }

    [JsonPropertyName("taxAmount")]
    public double TaxAmount { get; init; }

    [JsonPropertyName("totalCost")]
    public double TotalCost { get; init; }
}