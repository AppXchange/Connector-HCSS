namespace Connector.Equipment360.v1.PurchaseOrder.Create;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class CreatePurchaseOrderResponse
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("businessUnitId")]
    public Guid? BusinessUnitId { get; init; }

    [JsonPropertyName("purchaseOrderNumber")]
    public required int PurchaseOrderNumber { get; init; }

    [JsonPropertyName("dateIssued")]
    public DateTime? DateIssued { get; init; }

    [JsonPropertyName("vendorId")]
    public Guid? VendorId { get; init; }

    [JsonPropertyName("referenceNumber")]
    public string? ReferenceNumber { get; init; }

    [JsonPropertyName("taxRatePercent")]
    public double? TaxRatePercent { get; init; }

    [JsonPropertyName("estimatedTotal")]
    public double? EstimatedTotal { get; init; }

    [JsonPropertyName("approvalStatus")]
    public string? ApprovalStatus { get; init; }

    [JsonPropertyName("notes")]
    public IEnumerable<ApiNoteRead>? Notes { get; init; }
}

public class ApiNoteRead
{
    [JsonPropertyName("note")]
    public string? Note { get; init; }
} 