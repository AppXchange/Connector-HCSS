namespace Connector.HeavyBidEstimate.v1.MaterialCodebook;

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
[Description("Represents a material codebook resource in HeavyBid")]
public class MaterialCodebookDataObject
{
    [JsonPropertyName("id")]
    [Description("The material codebook resource id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("systemBackupId")]
    [Description("The system backup ID")]
    public Guid SystemBackupId { get; init; }

    [JsonPropertyName("resourceCode")]
    [Description("The resource code")]
    public string? ResourceCode { get; init; }

    [JsonPropertyName("description")]
    [Description("The description")]
    public string? Description { get; init; }

    [JsonPropertyName("unitCost")]
    [Description("The unit cost")]
    public decimal UnitCost { get; init; }

    [JsonPropertyName("unit")]
    [Description("The unit of measure")]
    public string? Unit { get; init; }

    [JsonPropertyName("categoryLevel")]
    [Description("The category level")]
    public string? CategoryLevel { get; init; }

    [JsonPropertyName("nonTaxable")]
    [Description("Flag indicating if the resource is not taxable")]
    public string? NonTaxable { get; init; }

    [JsonPropertyName("accountingCode")]
    [Description("The accounting code")]
    public string? AccountingCode { get; init; }

    [JsonPropertyName("accountingDesc")]
    [Description("The accounting code description")]
    public string? AccountingDesc { get; init; }

    [JsonPropertyName("mhPerUnit")]
    [Description("The manhours needed per unit when using resource factoring production")]
    public decimal MhPerUnit { get; init; }

    [JsonPropertyName("lastUpdate")]
    [Description("The last update timestamp")]
    public DateTime LastUpdate { get; init; }

    [JsonPropertyName("lastUpdateUser")]
    [Description("The last update user ID")]
    public int LastUpdateUser { get; init; }

    [JsonPropertyName("quoteFolder")]
    [Description("The default class/folder of the resource for the quote system")]
    public string? QuoteFolder { get; init; }

    [JsonPropertyName("resourceText1")]
    [Description("The resource text 1")]
    public string? ResourceText1 { get; init; }

    [JsonPropertyName("resourceText2")]
    [Description("The resource text 2")]
    public string? ResourceText2 { get; init; }

    [JsonPropertyName("scheduleCode")]
    [Description("The code used instead of the resource code when exporting to primavera")]
    public string? ScheduleCode { get; init; }

    [JsonPropertyName("excludeFromQuotes")]
    [Description("Flag to exclude the detail when populating quote folders")]
    public string? ExcludeFromQuotes { get; init; }
}