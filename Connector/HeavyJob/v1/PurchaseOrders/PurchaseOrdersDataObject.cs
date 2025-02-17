namespace Connector.HeavyJob.v1.PurchaseOrders;

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
[Description("Represents a purchase order in HeavyJob")]
public class PurchaseOrdersDataObject
{
    [JsonPropertyName("id")]
    [Description("The purchase order id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("jobId")]
    [Description("The job id")]
    [Required] 
    public required Guid JobId { get; init; }

    [JsonPropertyName("job")]
    [Description("Basic information about the associated job")]
    [Required]
    public required JobCompactRead Job { get; init; }

    [JsonPropertyName("purchaseOrder")]
    [Description("The purchase order number")]
    public string? PurchaseOrder { get; init; }

    [JsonPropertyName("description")]
    [Description("The purchase order description")]
    public string? Description { get; init; }

    [JsonPropertyName("orderStatus")]
    [Description("The status of the purchase order")]
    [Required]
    public required string OrderStatus { get; init; }

    [JsonPropertyName("dateIssued")]
    [Description("The date purchase order was issued")]
    public DateTime? DateIssued { get; init; }

    [JsonPropertyName("vendorId")]
    [Description("The vendor id")]
    public Guid? VendorId { get; init; }

    [JsonPropertyName("vendor")]
    [Description("Basic information about the associated vendor")]
    public VendorCompactRead? Vendor { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Whether the purchase order is deleted")]
    [Required]
    public required bool IsDeleted { get; init; }
}

public class JobCompactRead
{
    [JsonPropertyName("jobId")]
    [Description("The job guid")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("jobCode")]
    [Description("The job's code")]
    [Required]
    public required string JobCode { get; init; }

    [JsonPropertyName("jobDescription")] 
    [Description("The job's description")]
    [Required]
    public required string JobDescription { get; init; }
}

public class VendorCompactRead
{
    [JsonPropertyName("id")]
    [Description("Vendor ID")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    [Description("The name of the vendor")]
    [Required]
    public required string Name { get; init; }

    [JsonPropertyName("description")]
    [Description("The description of the vendor")]
    public string? Description { get; init; }
}