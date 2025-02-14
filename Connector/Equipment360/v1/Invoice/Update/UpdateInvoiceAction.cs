namespace Connector.Equipment360.v1.Invoice.Update;

using Json.Schema.Generation;
using System;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.Action;

/// <summary>
/// Action object that will represent an action in the Xchange system. This will contain an input object type,
/// an output object type, and a Action failure type (this will default to <see cref="StandardActionFailure"/>
/// but that can be overridden with your own preferred type). These objects will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// These types will be used for validation at runtime to make sure the objects being passed through the system 
/// are properly formed. The schema also helps provide integrators more information for what the values 
/// are intended to be.
/// </summary>
[Description("Update invoice status and add details to invoice")]
public class UpdateInvoiceAction : IStandardAction<UpdateInvoiceActionInput, InvoiceDataObject>
{
    public UpdateInvoiceActionInput ActionInput { get; set; } = new()
    {
        VendorCode = string.Empty
    };
    public InvoiceDataObject ActionOutput { get; set; } = new() 
    { 
        Id = Guid.Empty,
        VendorCode = string.Empty
    };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class UpdateInvoiceActionInput
{
    [JsonPropertyName("invoiceNumber")]
    [Description("The invoice number to be used on the invoice")]
    public string? InvoiceNumber { get; init; }

    [JsonPropertyName("referenceNumber")]
    [Description("The reference number to be used on the invoice")]
    public string? ReferenceNumber { get; init; }

    [JsonPropertyName("receivalDate")]
    [Description("The date invoice was issued. If not specified, the default value is the server time")]
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
    public UpdateInvoiceDetailInput[]? Details { get; init; }
}

public class UpdateInvoiceDetailInput
{
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
