namespace Connector.HeavyJob.v1.MaterialsInstalledQuantities;

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
[Description("Represents an installed material quantity in HeavyJob")]
public class MaterialsInstalledQuantitiesDataObject
{
    [JsonPropertyName("id")]
    [Description("The id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("costCodeId")]
    [Description("The cost code guid")]
    public Guid? CostCodeId { get; init; }

    [JsonPropertyName("jobMaterialId")]
    [Description("The job material guid")]
    public Guid? JobMaterialId { get; init; }

    [JsonPropertyName("foremanId")]
    [Description("The foreman's employee guid")]
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
    [Description("The material installed date")]
    [Required]
    public required DateTime Date { get; init; }

    [JsonPropertyName("consumedQuantity")]
    [Description("The consumed quantity. Includes the installed quantity and accounts for any waste / mistakes during installation")]
    [Required]
    public required double ConsumedQuantity { get; init; }

    [JsonPropertyName("installedQuantity")]
    [Description("The install quantity")]
    [Required]
    public required double InstalledQuantity { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The unit of measure")]
    public string? UnitOfMeasure { get; init; }

    [JsonPropertyName("purchaseOrderDetailId")]
    [Description("The purchase order detail guid")]
    public Guid? PurchaseOrderDetailId { get; init; }

    [JsonPropertyName("purchaseOrderId")]
    [Description("The purchase order guid")]
    public Guid? PurchaseOrderId { get; init; }

    [JsonPropertyName("vendorId")]
    [Description("The vendor guid")]
    public Guid? VendorId { get; init; }

    [JsonPropertyName("referenceNumber")]
    [Description("The reference number")]
    public string? ReferenceNumber { get; init; }

    [JsonPropertyName("invoiceNumber")]
    [Description("The invoice number")]
    public string? InvoiceNumber { get; init; }

    [JsonPropertyName("isInvoiced")]
    [Description("The isInvoiced flag")]
    public bool IsInvoiced { get; init; }

    [JsonPropertyName("lastModifiedDateTime")]
    [Description("The RFC 3339 dateTime, in UTC, when this installed material was last modified")]
    [Required]
    public required DateTime LastModifiedDateTime { get; init; }

    [JsonPropertyName("lastModifiedPreciseDateTime")]
    [Description("The RFC 3339 dateTime (including fractional seconds), in UTC, when this installed material was last modified")]
    [Required]
    public required DateTime LastModifiedPreciseDateTime { get; init; }
}