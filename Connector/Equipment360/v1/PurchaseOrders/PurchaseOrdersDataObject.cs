namespace Connector.Equipment360.v1.PurchaseOrders;

using Json.Schema.Generation;
using System;
using System.Collections.Generic;
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
[Description("Represents a purchase order")]
public class PurchaseOrdersDataObject
{
    [JsonPropertyName("id")]
    [Description("The purchase order id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit ID associated with the purchase order")]
    public Guid? BusinessUnitId { get; init; }

    [JsonPropertyName("purchaseOrderNumber")]
    [Description("The purchase order's integer id, generated upon creation")]
    [Required]
    public required int PurchaseOrderNumber { get; init; }

    [JsonPropertyName("dateIssued")]
    [Description("The date when the purchase order was created")]
    public DateTime? DateIssued { get; init; }

    [JsonPropertyName("vendorId")]
    [Description("The vendor id for the purchase order")]
    public Guid? VendorId { get; init; }

    [JsonPropertyName("referenceNumber")]
    [Description("The reference number used on the invoice")]
    public string? ReferenceNumber { get; init; }

    [JsonPropertyName("taxRatePercent")]
    [Description("The tax rate, expressed as a percent (e.g., 8 means 8% tax)")]
    public double? TaxRatePercent { get; init; }

    [JsonPropertyName("estimatedTotal")]
    [Description("The estimated total amount of the purchase order (in dollars)")]
    public double? EstimatedTotal { get; init; }

    [JsonPropertyName("approvalStatus")]
    [Description("The approval status")]
    public string? ApprovalStatus { get; init; }

    [JsonPropertyName("notes")]
    [Description("The notes for the purchase order")]
    public IEnumerable<ApiNoteRead>? Notes { get; init; }
}

public class ApiNoteRead
{
    [JsonPropertyName("note")]
    public string? Note { get; init; }
}