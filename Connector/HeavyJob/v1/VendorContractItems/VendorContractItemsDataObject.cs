namespace Connector.HeavyJob.v1.VendorContractItems;

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
[Description("Represents a vendor contract item in HeavyJob")]
public class VendorContractItemsDataObject
{
    [JsonPropertyName("id")]
    [Description("The vendor contract id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("vendorContractId")]
    [Description("The vendor contract id")]
    [Required]
    public required Guid VendorContractId { get; init; }

    [JsonPropertyName("jobSubcontractItemId")]
    [Description("The job subcontract item id")]
    [Required]
    public required Guid JobSubcontractItemId { get; init; }

    [JsonPropertyName("subcontractItem")]
    [Description("A POCO that represents a slice of subcontract item state returned by the API")]
    [Required]
    public required SubcontractItemCompactRead SubcontractItem { get; init; }

    [JsonPropertyName("sequence")]
    [Description("The sequence number of the vendor contract line item")]
    [Required]
    public required double Sequence { get; init; }

    [JsonPropertyName("isCompleted")]
    [Description("Whether the work item is complete")]
    public bool IsCompleted { get; init; }

    [JsonPropertyName("note")]
    [Description("The note")]
    public string? Note { get; init; }

    [JsonPropertyName("description")]
    [Description("An description for this vendor contract line item")]
    public string? Description { get; init; }

    [JsonPropertyName("quantity")]
    [Description("The item quantity")]
    [Required]
    public required double Quantity { get; init; }

    [JsonPropertyName("unitCost")]
    [Description("The item unit cost")]
    [Required]
    public required double UnitCost { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The item unit of measure")]
    [Required]
    public required string UnitOfMeasure { get; init; }

    [JsonPropertyName("salesTaxPercent")]
    [Description("The item sales tax represented in percent")]
    public double? SalesTaxPercent { get; init; }

    [JsonPropertyName("isCancelled")]
    [Description("Whether the vendor contract line item is canceled")]
    public bool IsCancelled { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Is the vendor contract item deleted in the vendor contract")]
    public bool IsDeleted { get; init; }

    [JsonPropertyName("vendorItemNumber")]
    [Description("The vendor item number")]
    public string? VendorItemNumber { get; init; }
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