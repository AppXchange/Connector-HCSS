namespace Connector.HeavyJob.v1.MaterialsReceived;

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
[Description("Represents a received material in HeavyJob")]
public class MaterialsReceivedDataObject
{
    [JsonPropertyName("id")]
    [Description("The id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("jobMaterial")]
    [Description("A POCO that represents a slice of material state")]
    [Required]
    public required MaterialCompactRead JobMaterial { get; init; }

    [JsonPropertyName("foreman")]
    [Description("A POCO that represents an employee's basic information")]
    public EmployeeCompactRead? Foreman { get; init; }

    [JsonPropertyName("job")]
    [Description("A POCO that represents a job's basic information")]
    [Required]
    public required JobCompactRead Job { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit guid")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("date")]
    [Description("The material received date")]
    [Required]
    public required DateTime Date { get; init; }

    [JsonPropertyName("referenceNumber")]
    [Description("The reference number")]
    public string? ReferenceNumber { get; init; }

    [JsonPropertyName("invoiceNumber")]
    [Description("The invoice number")]
    public string? InvoiceNumber { get; init; }

    [JsonPropertyName("isInvoiced")]
    [Description("The isInvoiced flag")]
    public bool IsInvoiced { get; init; }

    [JsonPropertyName("quantity")]
    [Description("The received quantity")]
    [Required]
    public required double Quantity { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The unit of measure")]
    public string? UnitOfMeasure { get; init; }

    [JsonPropertyName("purchaseOrder")]
    [Description("A POCO that represents a purchase order")]
    public PurchaseOrderCompactRead? PurchaseOrder { get; init; }

    [JsonPropertyName("purchaseOrderDetailId")]
    [Description("The purchase order detail guid")]
    public Guid? PurchaseOrderDetailId { get; init; }

    [JsonPropertyName("vendor")]
    [Description("A POCO that represents a vendor")]
    public VendorCompactRead? Vendor { get; init; }

    [JsonPropertyName("costCodeTransactionTags")]
    [Description("The cost code transaction tags")]
    public TransactionTag[]? CostCodeTransactionTags { get; init; }

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

    [JsonPropertyName("linkedInstalledMaterialIds")]
    [Description("List of Ids of linked installed material transactions")]
    public Guid[]? LinkedInstalledMaterialIds { get; init; }
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

public class TransactionTag
{
    [JsonPropertyName("id")]
    [Description("Tag id")]
    public Guid Id { get; init; }

    [JsonPropertyName("code")]
    [Description("Tag code")]
    public string? Code { get; init; }

    [JsonPropertyName("description")]
    [Description("Tag description")]
    public string? Description { get; init; }

    [JsonPropertyName("note")]
    [Description("Tag note")]
    public string? Note { get; init; }

    [JsonPropertyName("groupId")]
    [Description("Tag group id")]
    public Guid? GroupId { get; init; }

    [JsonPropertyName("groupCode")]
    [Description("Tag group code")]
    public string? GroupCode { get; init; }
}