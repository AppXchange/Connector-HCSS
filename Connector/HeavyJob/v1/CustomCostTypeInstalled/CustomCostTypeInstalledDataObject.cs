namespace Connector.HeavyJob.v1.CustomCostTypeInstalled;

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
[Description("Represents an installed custom cost type item in HeavyJob")]
public class CustomCostTypeInstalledDataObject
{
    [JsonPropertyName("id")]
    [Description("The installed custom cost type item ID")]
    [Required]
    public Guid Id { get; init; }

    [JsonPropertyName("job")]
    [Description("The job details")]
    public JobInfo Job { get; init; } = new();

    [JsonPropertyName("costCode")]
    [Description("The cost code details")]
    public CostCodeInfo CostCode { get; init; } = new();

    [JsonPropertyName("foreman")]
    [Description("The foreman details")]
    public ForemanInfo Foreman { get; init; } = new();

    [JsonPropertyName("date")]
    [Description("The transaction date")]
    public DateTime Date { get; init; }

    [JsonPropertyName("jobCustomCostTypeItemId")]
    [Description("The job custom cost type item ID")]
    public Guid JobCustomCostTypeItemId { get; init; }

    [JsonPropertyName("jobCustomCostTypeItem")]
    [Description("The job custom cost type item details")]
    public JobCustomCostTypeItem JobCustomCostTypeItem { get; init; } = new();

    [JsonPropertyName("consumedQuantity")]
    [Description("The consumed quantity")]
    public double ConsumedQuantity { get; init; }

    [JsonPropertyName("installedQuantity")]
    [Description("The installed quantity")]
    public double InstalledQuantity { get; init; }

    [JsonPropertyName("consumedCost")]
    [Description("The consumed cost")]
    public double ConsumedCost { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The unit of measure")]
    public string UnitOfMeasure { get; init; } = string.Empty;

    [JsonPropertyName("purchaseOrder")]
    [Description("The purchase order details")]
    public PurchaseOrderInfo PurchaseOrder { get; init; } = new();

    [JsonPropertyName("purchaseOrderItemId")]
    [Description("The purchase order item ID")]
    public Guid? PurchaseOrderItemId { get; init; }

    [JsonPropertyName("purchaseOrderId")]
    [Description("The purchase order ID")]
    public Guid? PurchaseOrderId { get; init; }

    [JsonPropertyName("referenceNumber")]
    [Description("The reference number")]
    public string ReferenceNumber { get; init; } = string.Empty;

    [JsonPropertyName("invoiceNumber")]
    [Description("The invoice number")]
    public string InvoiceNumber { get; init; } = string.Empty;

    [JsonPropertyName("isInvoiced")]
    [Description("Whether this is invoiced")]
    public bool IsInvoiced { get; init; }

    [JsonPropertyName("isTm")]
    [Description("Whether this is T&M")]
    public bool IsTm { get; init; }

    [JsonPropertyName("vendor")]
    [Description("The vendor details")]
    public VendorInfo Vendor { get; init; } = new();

    [JsonPropertyName("costCodeTransactionTags")]
    [Description("The transaction tags")]
    public TransactionTag[] CostCodeTransactionTags { get; init; } = Array.Empty<TransactionTag>();

    [JsonPropertyName("lastModifiedDateTime")]
    [Description("When this was last modified")]
    public DateTime LastModifiedDateTime { get; init; }

    [JsonPropertyName("lastModifiedPreciseDateTime")]
    [Description("When this was last modified (precise)")]
    public DateTime LastModifiedPreciseDateTime { get; init; }

    [JsonPropertyName("loads")]
    [Description("The number of loads")]
    public int Loads { get; init; }

    [JsonPropertyName("note")]
    [Description("The note")]
    public string Note { get; init; } = string.Empty;

    [JsonPropertyName("unitCost")]
    [Description("The unit cost")]
    public double UnitCost { get; init; }

    [JsonPropertyName("salesTax")]
    [Description("The sales tax")]
    public double SalesTax { get; init; }

    [JsonPropertyName("linkedReceivedCostTypeItemIds")]
    [Description("The linked received cost type item IDs")]
    public Guid[] LinkedReceivedCostTypeItemIds { get; init; } = Array.Empty<Guid>();
}

public class JobInfo
{
    [JsonPropertyName("jobId")]
    public Guid JobId { get; init; }

    [JsonPropertyName("jobCode")]
    public string JobCode { get; init; } = string.Empty;

    [JsonPropertyName("jobDescription")]
    public string JobDescription { get; init; } = string.Empty;
}

public class CostCodeInfo
{
    [JsonPropertyName("costCodeId")]
    public Guid CostCodeId { get; init; }

    [JsonPropertyName("costCodeCode")]
    public string CostCodeCode { get; init; } = string.Empty;

    [JsonPropertyName("costCodeDescription")]
    public string CostCodeDescription { get; init; } = string.Empty;
}

public class ForemanInfo
{
    [JsonPropertyName("employeeId")]
    public Guid EmployeeId { get; init; }

    [JsonPropertyName("employeeCode")]
    public string EmployeeCode { get; init; } = string.Empty;

    [JsonPropertyName("employeeFirstName")]
    public string EmployeeFirstName { get; init; } = string.Empty;

    [JsonPropertyName("employeeLastName")]
    public string EmployeeLastName { get; init; } = string.Empty;
}

public class JobCustomCostTypeItem
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("legacyTypeCode")]
    public string LegacyTypeCode { get; init; } = string.Empty;

    [JsonPropertyName("code")]
    public string Code { get; init; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; init; } = string.Empty;

    [JsonPropertyName("typeDescription")]
    public string TypeDescription { get; init; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; init; } = string.Empty;
}

public class PurchaseOrderInfo
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; init; } = string.Empty;
}

public class VendorInfo
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; init; } = string.Empty;
}

public class TransactionTag
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("code")]
    public string Code { get; init; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; init; } = string.Empty;

    [JsonPropertyName("note")]
    public string Note { get; init; } = string.Empty;

    [JsonPropertyName("groupId")]
    public Guid GroupId { get; init; }

    [JsonPropertyName("groupCode")]
    public string GroupCode { get; init; } = string.Empty;
}

public class CustomCostTypeInstalledResponse
{
    [JsonPropertyName("results")]
    [Required]
    public CustomCostTypeInstalledDataObject[] Results { get; init; } = Array.Empty<CustomCostTypeInstalledDataObject>();

    [JsonPropertyName("metadata")]
    [Required]
    public CustomCostTypeInstalledMetadata Metadata { get; init; } = new();
}

public class CustomCostTypeInstalledMetadata
{
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; init; }
}