namespace Connector.HeavyJob.v1.PayItems;

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
[Description("Represents a pay item in HeavyJob")]
public class PayItemsDataObject
{
    [JsonPropertyName("id")]
    [Description("The id of this pay item")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("jobId")]
    [Description("The job that this pay item is associated with")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("payItem")]
    [Description("A unique code that describes this pay item")]
    [Required]
    public required string PayItem { get; init; }

    [JsonPropertyName("description")]
    [Description("A description for this pay item")]
    public string? Description { get; init; }

    [JsonPropertyName("status")]
    [Description("The pay item status")]
    [Required]
    public required string Status { get; init; }

    [JsonPropertyName("ownerCode")]
    [Description("The associated pay item code in the owner's system")]
    public string? OwnerCode { get; init; }

    [JsonPropertyName("contractQuantity")]
    [Description("The agreed-to quantity between the owner and the company")]
    [Required]
    public required double ContractQuantity { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The unit of measure used to bill the owner for this pay item")]
    public string? UnitOfMeasure { get; init; }

    [JsonPropertyName("unitPrice")]
    [Description("The unit price used to bill the owner for this pay item")]
    [Required]
    public required double UnitPrice { get; init; }

    [JsonPropertyName("stopOverruns")]
    [Description("Whether to cap the billable quantity at the ContractQuantity")]
    [Required]
    public required bool StopOverruns { get; init; }

    [JsonPropertyName("notes")]
    [Description("Notes associated with this pay item")]
    public string? Notes { get; init; }

    [JsonPropertyName("linkedCostCodes")]
    [Description("Cost Codes linked to the Pay Item")]
    public CostCodeCompactWithPayItemRead[]? LinkedCostCodes { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Whether the Pay Item is soft deleted")]
    public bool IsDeleted { get; init; }

    [JsonPropertyName("deletedDate")]
    [Description("When the Pay Item was soft deleted")]
    public DateTime? DeletedDate { get; init; }
}

public class CostCodeCompactWithPayItemRead
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

    [JsonPropertyName("payItemId")]
    [Description("The pay item id this cost code is associated with")]
    public Guid? PayItemId { get; init; }

    [JsonPropertyName("payItemFactor")]
    [Description("Any costs contributed by this cost code are multiplied by this factor before being applied to its parent pay item")]
    public double? PayItemFactor { get; init; }

    [JsonPropertyName("isPayItemDriver")]
    [Description("Whether this cost code contributes to the cost of its parent pay item")]
    public bool IsPayItemDriver { get; init; }
}