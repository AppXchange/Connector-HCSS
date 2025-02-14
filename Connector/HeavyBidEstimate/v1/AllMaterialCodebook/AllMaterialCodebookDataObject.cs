namespace Connector.HeavyBidEstimate.v1.AllMaterialCodebook;

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
[Description("Represents a material codebook resource in HeavyBid Estimate")]
public class AllMaterialCodebookDataObject
{
    [JsonPropertyName("id")]
    [Description("The material codebook resource id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("systemBackupId")]
    [Description("The system backup ID")]
    public Guid SystemBackupId { get; init; }

    [JsonPropertyName("resourceCode")]
    [Description("Resource code")]
    public string? ResourceCode { get; init; }

    [JsonPropertyName("description")]
    [Description("Description")]
    public string? Description { get; init; }

    [JsonPropertyName("unitCost")]
    [Description("Unit cost")]
    public decimal UnitCost { get; init; }

    [JsonPropertyName("unit")]
    [Description("Unit of measure")]
    public string? Unit { get; init; }

    [JsonPropertyName("categoryLevel")]
    [Description("Category level")]
    public string? CategoryLevel { get; init; }

    [JsonPropertyName("nonTaxable")]
    [Description("Non-taxable flag")]
    public string? NonTaxable { get; init; }

    [JsonPropertyName("accountingCode")]
    [Description("Accounting code")]
    public string? AccountingCode { get; init; }

    [JsonPropertyName("accountingDesc")]
    [Description("Accounting description")]
    public string? AccountingDesc { get; init; }

    [JsonPropertyName("mhPerUnit")]
    [Description("Man hours per unit")]
    public decimal MhPerUnit { get; init; }

    [JsonPropertyName("lastUpdate")]
    [Description("Last update timestamp")]
    public DateTime LastUpdate { get; init; }

    [JsonPropertyName("lastUpdateUser")]
    [Description("Last update user ID")]
    public int LastUpdateUser { get; init; }

    [JsonPropertyName("quoteFolder")]
    [Description("Quote folder")]
    public string? QuoteFolder { get; init; }

    [JsonPropertyName("resourceText1")]
    [Description("Resource text 1")]
    public string? ResourceText1 { get; init; }

    [JsonPropertyName("resourceText2")]
    [Description("Resource text 2")]
    public string? ResourceText2 { get; init; }

    [JsonPropertyName("scheduleCode")]
    [Description("Schedule code")]
    public string? ScheduleCode { get; init; }

    [JsonPropertyName("excludeFromQuotes")]
    [Description("Exclude from quotes flag")]
    public string? ExcludeFromQuotes { get; init; }
}