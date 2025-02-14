namespace Connector.HeavyBidEstimate.v1.QuoteFolder;

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
[Description("Represents a quote folder in HeavyBid")]
public class QuoteFolderDataObject
{
    [JsonPropertyName("id")]
    [Description("The quote folder ID")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("quoteMasterId")]
    [Description("The quote master ID")]
    public string? QuoteMasterId { get; init; }

    [JsonPropertyName("folder")]
    [Description("The folder name")]
    public string? Folder { get; init; }

    [JsonPropertyName("description")]
    [Description("The description")]
    public string? Description { get; init; }

    [JsonPropertyName("type")]
    [Description("The type")]
    public string? Type { get; init; }

    [JsonPropertyName("breakout")]
    [Description("The breakout")]
    public string? Breakout { get; init; }

    [JsonPropertyName("selectedVendor")]
    [Description("The selected vendor")]
    public string? SelectedVendor { get; init; }

    [JsonPropertyName("totalAdditiveFactored")]
    [Description("The total additive factored amount")]
    public decimal TotalAdditiveFactored { get; init; }

    [JsonPropertyName("totalAdditiveNonFactored")]
    [Description("The total additive non-factored amount")]
    public decimal TotalAdditiveNonFactored { get; init; }

    [JsonPropertyName("totalNonAdditiveFactored")]
    [Description("The total non-additive factored amount")]
    public decimal TotalNonAdditiveFactored { get; init; }

    [JsonPropertyName("totalNonAdditiveNonFactored")]
    [Description("The total non-additive non-factored amount")]
    public decimal TotalNonAdditiveNonFactored { get; init; }

    [JsonPropertyName("estimatorInitials")]
    [Description("The estimator initials")]
    public string? EstimatorInitials { get; init; }

    [JsonPropertyName("notes")]
    [Description("The notes")]
    public string? Notes { get; init; }

    [JsonPropertyName("updatedSelectedVendorTotal")]
    [Description("The updated selected vendor total")]
    public decimal UpdatedSelectedVendorTotal { get; init; }

    [JsonPropertyName("quoteItems")]
    [Description("The quote items")]
    public QuoteItem[]? QuoteItems { get; init; }
}

public class QuoteItem
{
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("quoteFolderId")]
    public string? QuoteFolderId { get; init; }

    [JsonPropertyName("biditem")]
    public string? BidItem { get; init; }

    [JsonPropertyName("activity")]
    public string? Activity { get; init; }

    [JsonPropertyName("resource")]
    public string? Resource { get; init; }

    [JsonPropertyName("unit")]
    public string? Unit { get; init; }

    [JsonPropertyName("quantityAdditiveFactored")]
    public decimal QuantityAdditiveFactored { get; init; }

    [JsonPropertyName("quantityAdditiveNonFactored")]
    public decimal QuantityAdditiveNonFactored { get; init; }

    [JsonPropertyName("quantityNonAdditiveFactored")]
    public decimal QuantityNonAdditiveFactored { get; init; }

    [JsonPropertyName("quantityNonAdditiveNonFactored")]
    public decimal QuantityNonAdditiveNonFactored { get; init; }

    [JsonPropertyName("currency")]
    public string? Currency { get; init; }

    [JsonPropertyName("selfAmount")]
    public decimal SelfAmount { get; init; }

    [JsonPropertyName("selectedVendor")]
    public string? SelectedVendor { get; init; }

    [JsonPropertyName("alternateDescription")]
    public string? AlternateDescription { get; init; }

    [JsonPropertyName("addendumNumber")]
    public string? AddendumNumber { get; init; }

    [JsonPropertyName("alternateQuantity")]
    public decimal AlternateQuantity { get; init; }

    [JsonPropertyName("unitCostInEstimate")]
    public decimal UnitCostInEstimate { get; init; }

    [JsonPropertyName("clientNo")]
    public string? ClientNo { get; init; }
}