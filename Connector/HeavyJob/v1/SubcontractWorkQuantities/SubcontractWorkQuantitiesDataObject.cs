namespace Connector.HeavyJob.v1.SubcontractWorkQuantities;

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
[Description("Represents a subcontract work performed quantity in HeavyJob")]
public class SubcontractWorkQuantitiesDataObject
{
    [JsonPropertyName("id")]
    [Description("The id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("costCodeId")]
    [Description("The cost code guid")]
    public Guid? CostCodeId { get; init; }

    [JsonPropertyName("jobSubcontractId")]
    [Description("The job subcontract guid")]
    public Guid? JobSubcontractId { get; init; }

    [JsonPropertyName("foremanId")]
    [Description("The foreman guid")]
    [Required]
    public required Guid ForemanId { get; init; }

    [JsonPropertyName("jobId")]
    [Description("The job guid")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit guid")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("date")]
    [Description("The subcontract work date")]
    [Required]
    public required DateTime Date { get; init; }

    [JsonPropertyName("quantity")]
    [Description("The installed quantity")]
    [Required]
    public required double Quantity { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The unit of measure")]
    public string? UnitOfMeasure { get; init; }

    [JsonPropertyName("referenceNumber")]
    [Description("The reference number")]
    public string? ReferenceNumber { get; init; }

    [JsonPropertyName("invoiceNumber")]
    [Description("The invoice number")]
    public string? InvoiceNumber { get; init; }

    [JsonPropertyName("isInvoiced")]
    [Description("The invoiced flag")]
    public bool IsInvoiced { get; init; }

    [JsonPropertyName("vendorContractDetailId")]
    [Description("The vendor contract detail guid")]
    public Guid? VendorContractDetailId { get; init; }

    [JsonPropertyName("vendorContractId")]
    [Description("The vendor contract guid")]
    public Guid? VendorContractId { get; init; }

    [JsonPropertyName("vendorId")]
    [Description("The vendor guid")]
    public Guid? VendorId { get; init; }

    [JsonPropertyName("lastModifiedDateTime")]
    [Description("The RFC 3339 dateTime, in UTC, when this subcontract work was last modified")]
    [Required]
    public required DateTime LastModifiedDateTime { get; init; }

    [JsonPropertyName("lastModifiedPreciseDateTime")]
    [Description("The RFC 3339 dateTime (including fractional seconds), in UTC, when this subcontract work was last modified")]
    [Required]
    public required DateTime LastModifiedPreciseDateTime { get; init; }
}