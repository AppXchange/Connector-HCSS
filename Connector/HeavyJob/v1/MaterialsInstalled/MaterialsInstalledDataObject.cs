namespace Connector.HeavyJob.v1.MaterialsInstalled;

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
[Description("Represents an installed material in HeavyJob")]
public class MaterialsInstalledDataObject
{
    [JsonPropertyName("id")]
    [Description("The id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("jobMaterial")]
    [Description("A POCO that represents a slice of material state")]
    [Required]
    public required MaterialCompactRead JobMaterial { get; init; }

    [JsonPropertyName("job")]
    [Description("A POCO that represents a job's basic information")]
    [Required]
    public required JobCompactRead Job { get; init; }

    [JsonPropertyName("costCode")]
    [Description("A POCO that represents a cost code's basic information")]
    public CostCodeCompactRead? CostCode { get; init; }

    [JsonPropertyName("foreman")]
    [Description("A POCO that represents an employee's basic information")]
    public EmployeeCompactRead? Foreman { get; init; }

    [JsonPropertyName("date")]
    [Description("The material installed date")]
    [Required]
    public required DateTime Date { get; init; }

    [JsonPropertyName("jobMaterialId")]
    [Description("The job material guid")]
    public Guid? JobMaterialId { get; init; }

    [JsonPropertyName("consumedQuantity")]
    [Description("The consumed quantity. Includes the installed quantity and accounts for any waste / mistakes during installation")]
    [Required]
    public required double ConsumedQuantity { get; init; }

    [JsonPropertyName("consumedCost")]
    [Description("The consumed cost")]
    [Required]
    public required double ConsumedCost { get; init; }

    [JsonPropertyName("installedQuantity")]
    [Description("The install quantity")]
    [Required]
    public required double InstalledQuantity { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The unit of measure")]
    public string? UnitOfMeasure { get; init; }

    [JsonPropertyName("purchaseOrder")]
    [Description("A POCO that represents a purchase order")]
    public PurchaseOrderCompactRead? PurchaseOrder { get; init; }

    [JsonPropertyName("purchaseOrderItemId")]
    [Description("The purchase order item guid")]
    public Guid? PurchaseOrderItemId { get; init; }

    [JsonPropertyName("purchaseOrderId")]
    [Description("The purchase order guid")]
    public Guid? PurchaseOrderId { get; init; }

    [JsonPropertyName("vendor")]
    [Description("A POCO that represents a vendor")]
    public VendorCompactRead? Vendor { get; init; }

    [JsonPropertyName("referenceNumber")]
    [Description("The reference number")]
    public string? ReferenceNumber { get; init; }

    [JsonPropertyName("invoiceNumber")]
    [Description("The invoice number")]
    public string? InvoiceNumber { get; init; }

    [JsonPropertyName("isInvoiced")]
    [Description("The isInvoiced flag")]
    public bool IsInvoiced { get; init; }

    [JsonPropertyName("isTm")]
    [Description("Indicates whether the installed material is T & M")]
    public bool IsTm { get; init; }

    [JsonPropertyName("loads")]
    [Description("The loads")]
    public int Loads { get; init; }

    [JsonPropertyName("note")]
    [Description("The note")]
    public string? Note { get; init; }

    [JsonPropertyName("unitCost")]
    [Description("The unit cost")]
    public double UnitCost { get; init; }

    [JsonPropertyName("salesTax")]
    [Description("The sales tax")]
    public double SalesTax { get; init; }

    [JsonPropertyName("lastModifiedDateTime")]
    [Description("The RFC 3339 dateTime, in UTC, when this installed material was last modified")]
    [Required]
    public required DateTime LastModifiedDateTime { get; init; }

    [JsonPropertyName("lastModifiedPreciseDateTime")]
    [Description("The RFC 3339 dateTime (including fractional seconds), in UTC, when this installed material was last modified")]
    [Required]
    public required DateTime LastModifiedPreciseDateTime { get; init; }

    [JsonPropertyName("linkedReceivedMaterialIds")]
    [Description("List of Ids of linked received material transactions")]
    public Guid[]? LinkedReceivedMaterialIds { get; init; }
}

public class MaterialCompactRead
{
    [JsonPropertyName("id")]
    [Description("The material id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("type")]
    [Description("The material type")]
    [Required]
    public required string Type { get; init; }

    [JsonPropertyName("code")]
    [Description("Code")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("description")]
    [Description("Description")]
    [Required]
    public required string Description { get; init; }
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

public class CostCodeCompactRead
{
    [JsonPropertyName("costCodeId")]
    [Description("The cost code guid")]
    [Required]
    public required Guid CostCodeId { get; init; }

    [JsonPropertyName("costCodeCode")]
    [Description("The cost code's code")]
    [Required]
    public required string CostCodeCode { get; init; }

    [JsonPropertyName("costCodeDescription")]
    [Description("The cost code's description")]
    [Required]
    public required string CostCodeDescription { get; init; }
}

public class EmployeeCompactRead
{
    [JsonPropertyName("employeeId")]
    [Description("The employee guid")]
    [Required]
    public required Guid EmployeeId { get; init; }

    [JsonPropertyName("employeeCode")]
    [Description("The employee's code")]
    [Required]
    public required string EmployeeCode { get; init; }

    [JsonPropertyName("employeeFirstName")]
    [Description("The employee's first name")]
    [Required]
    public required string EmployeeFirstName { get; init; }

    [JsonPropertyName("employeeLastName")]
    [Description("The employee's last name")]
    [Required]
    public required string EmployeeLastName { get; init; }
}

public class PurchaseOrderCompactRead
{
    [JsonPropertyName("id")]
    [Description("The purchase order id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    [Description("The purchase order name")]
    public string? Name { get; init; }

    [JsonPropertyName("description")]
    [Description("The purchase order description")]
    public string? Description { get; init; }
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