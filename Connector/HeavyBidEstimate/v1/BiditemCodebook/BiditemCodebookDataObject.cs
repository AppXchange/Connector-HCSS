namespace Connector.HeavyBidEstimate.v1.BiditemCodebook;

using Json.Schema.Generation;
using System;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.CacheWriter;

[PrimaryKey("id", nameof(Id))]
[Description("Represents a biditem codebook entry in HeavyBid Estimate")]
public class BiditemCodebookDataObject
{
    [JsonPropertyName("id")]
    [Description("The biditem codebook id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("systemBackupId")]
    [Description("The system backup ID")]
    public Guid SystemBackupId { get; init; }

    [JsonPropertyName("state")]
    [Description("State code")]
    public string? State { get; init; }

    [JsonPropertyName("biditemCode")]
    [Description("Biditem code")]
    public string? BiditemCode { get; init; }

    [JsonPropertyName("description")]
    [Description("Description")]
    public string? Description { get; init; }

    [JsonPropertyName("units")]
    [Description("Units")]
    public string? Units { get; init; }

    [JsonPropertyName("categoryLevel")]
    [Description("Category level")]
    public string? CategoryLevel { get; init; }

    [JsonPropertyName("lowUnitPrice")]
    [Description("Low unit price")]
    public decimal LowUnitPrice { get; init; }

    [JsonPropertyName("averageUnitPrice")]
    [Description("Average unit price")]
    public decimal AverageUnitPrice { get; init; }

    [JsonPropertyName("highUnitPrice")]
    [Description("High unit price")]
    public decimal HighUnitPrice { get; init; }

    [JsonPropertyName("lock")]
    [Description("Lock flag")]
    public string? Lock { get; init; }

    [JsonPropertyName("libraryBiditem")]
    [Description("Library biditem")]
    public string? LibraryBiditem { get; init; }

    [JsonPropertyName("linkedResource")]
    [Description("Linked resource")]
    public string? LinkedResource { get; init; }

    [JsonPropertyName("summarySortCode1")]
    [Description("Summary sort code 1")]
    public string? SummarySortCode1 { get; init; }

    [JsonPropertyName("summarySortCode2")]
    [Description("Summary sort code 2")]
    public string? SummarySortCode2 { get; init; }

    [JsonPropertyName("summarySortCode3")]
    [Description("Summary sort code 3")]
    public string? SummarySortCode3 { get; init; }

    [JsonPropertyName("summarySortCode4")]
    [Description("Summary sort code 4")]
    public string? SummarySortCode4 { get; init; }

    [JsonPropertyName("summarySortCode5")]
    [Description("Summary sort code 5")]
    public string? SummarySortCode5 { get; init; }

    [JsonPropertyName("summarySortCode6")]
    [Description("Summary sort code 6")]
    public string? SummarySortCode6 { get; init; }

    [JsonPropertyName("linkedActivity1")]
    [Description("Linked activity 1")]
    public string? LinkedActivity1 { get; init; }

    [JsonPropertyName("linkedActivity2")]
    [Description("Linked activity 2")]
    public string? LinkedActivity2 { get; init; }

    [JsonPropertyName("linkedActivity3")]
    [Description("Linked activity 3")]
    public string? LinkedActivity3 { get; init; }

    [JsonPropertyName("linkedActivity4")]
    [Description("Linked activity 4")]
    public string? LinkedActivity4 { get; init; }

    [JsonPropertyName("linkedActivity5")]
    [Description("Linked activity 5")]
    public string? LinkedActivity5 { get; init; }

    [JsonPropertyName("equivalentBid")]
    [Description("Equivalent bid")]
    public string? EquivalentBid { get; init; }

    [JsonPropertyName("alternateDescription")]
    [Description("Alternate description")]
    public string? AlternateDescription { get; init; }

    [JsonPropertyName("passThrough")]
    [Description("Pass through flag")]
    public string? PassThrough { get; init; }

    [JsonPropertyName("lastUpdate")]
    [Description("Last update timestamp")]
    public DateTime LastUpdate { get; init; }

    [JsonPropertyName("rsMeansAssembly")]
    [Description("RS Means assembly")]
    public string? RsMeansAssembly { get; init; }

    [JsonPropertyName("taxable")]
    [Description("Taxable flag")]
    public string? Taxable { get; init; }

    [JsonPropertyName("salesTax")]
    [Description("Sales tax percentage")]
    public decimal SalesTax { get; init; }

    [JsonPropertyName("spreadSheetAssembly")]
    [Description("Spreadsheet assembly")]
    public string? SpreadSheetAssembly { get; init; }
}