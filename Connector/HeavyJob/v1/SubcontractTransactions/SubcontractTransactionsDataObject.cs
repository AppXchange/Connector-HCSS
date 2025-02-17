namespace Connector.HeavyJob.v1.SubcontractTransactions;

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
[Description("Represents a subcontract transaction in HeavyJob")]
public class SubcontractTransactionsDataObject
{
    [JsonPropertyName("id")]
    [Description("The id")]
    [Required]
    public required Guid Id { get; init; }

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
    [Description("The subcontract work date")]
    [Required]
    public required DateTime Date { get; init; }

    [JsonPropertyName("jobSubcontractItem")]
    [Description("A POCO that represents a slice of subcontract item state")]
    public SubcontractItemCompactRead? JobSubcontractItem { get; init; }

    [JsonPropertyName("jobSubcontractId")]
    [Description("The job subcontract guid")]
    public Guid? JobSubcontractId { get; init; }

    [JsonPropertyName("quantity")]
    [Description("The quantity of subcontract work")]
    [Required]
    public required double Quantity { get; init; }

    [JsonPropertyName("cost")]
    [Description("The cost of subcontract work")]
    public double? Cost { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The unit of measure")]
    public string? UnitOfMeasure { get; init; }

    [JsonPropertyName("vendorContractItemId")]
    [Description("The vendor contract item guid")]
    public Guid? VendorContractItemId { get; init; }

    [JsonPropertyName("vendorContractId")]
    [Description("The vendor contract guid")]
    public Guid? VendorContractId { get; init; }

    [JsonPropertyName("vendorContract")]
    [Description("A shorter version of the Vendor Contract")]
    public VendorContractCompactRead? VendorContract { get; init; }

    [JsonPropertyName("vendor")]
    [Description("A POCO that represents a slice of vendor state")]
    public VendorCompactRead? Vendor { get; init; }

    [JsonPropertyName("costCodeTransactionTags")]
    [Description("The cost code transaction tags")]
    public TransactionTag[]? CostCodeTransactionTags { get; init; }

    [JsonPropertyName("referenceNumber")]
    [Description("The reference number")]
    public string? ReferenceNumber { get; init; }

    [JsonPropertyName("invoiceNumber")]
    [Description("The invoice number")]
    public string? InvoiceNumber { get; init; }

    [JsonPropertyName("isInvoiced")]
    [Description("The flag isInvoiced")]
    public bool IsInvoiced { get; init; }

    [JsonPropertyName("isTm")]
    [Description("Indicates whether the subcontract work is T & M")]
    public bool IsTm { get; init; }

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
    [Description("The RFC 3339 dateTime, in UTC, when this subcontract work was last modified")]
    [Required]
    public required DateTime LastModifiedDateTime { get; init; }

    [JsonPropertyName("lastModifiedPreciseDateTime")]
    [Description("The RFC 3339 dateTime (including fractional seconds), in UTC, when this subcontract work was last modified")]
    [Required]
    public required DateTime LastModifiedPreciseDateTime { get; init; }
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

public class SubcontractItemCompactRead
{
    [JsonPropertyName("id")]
    [Description("The subcontract item id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("code")]
    [Description("The code")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("description")]
    [Description("The description")]
    [Required]
    public required string Description { get; init; }
}

public class VendorContractCompactRead
{
    [JsonPropertyName("id")]
    [Description("The vendor contract id")]
    public Guid Id { get; init; }

    [JsonPropertyName("vendorContract")]
    [Description("The vendor contract number")]
    public string? VendorContract { get; init; }

    [JsonPropertyName("description")]
    [Description("The vendor contract description")]
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