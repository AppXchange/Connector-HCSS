namespace Connector.HeavyBidEstimate.v1.AllBiditemCodebook;

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
[Description("Represents a biditem codebook entry in HeavyBid Estimate")]
public class AllBiditemCodebookDataObject
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
    [Description("Biditem description")]
    public string? Description { get; init; }

    [JsonPropertyName("units")]
    [Description("Units of measurement")]
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
    [Description("Lock indicator")]
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
    [Description("Pass through indicator")]
    public string? PassThrough { get; init; }

    [JsonPropertyName("lastUpdate")]
    [Description("Last update timestamp")]
    public DateTime LastUpdate { get; init; }

    [JsonPropertyName("rsMeansAssembly")]
    [Description("RS Means assembly")]
    public string? RsMeansAssembly { get; init; }

    [JsonPropertyName("taxable")]
    [Description("Taxable indicator")]
    public string? Taxable { get; init; }

    [JsonPropertyName("salesTax")]
    [Description("Sales tax percentage")]
    public decimal SalesTax { get; init; }

    [JsonPropertyName("spreadSheetAssembly")]
    [Description("Spreadsheet assembly path")]
    public string? SpreadSheetAssembly { get; init; }
}