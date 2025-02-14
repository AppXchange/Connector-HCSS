namespace Connector.HeavyBidEstimate.v1.ActivityCodeBooks;

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
[Description("Represents an activity codebook entry in HeavyBid Estimate")]
public class ActivityCodeBooksDataObject
{
    [JsonPropertyName("id")]
    [Description("The activity codebook id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("systemBackupId")]
    [Description("The system backup ID")]
    public Guid SystemBackupId { get; init; }

    [JsonPropertyName("activityCode")]
    [Description("The activity code")]
    public string? ActivityCode { get; init; }

    [JsonPropertyName("description")]
    [Description("Activity description")]
    public string? Description { get; init; }

    [JsonPropertyName("categoryLevel")]
    [Description("Category level")]
    public string? CategoryLevel { get; init; }

    [JsonPropertyName("units")]
    [Description("Units of measurement")]
    public string? Units { get; init; }

    [JsonPropertyName("lastUpdate")]
    [Description("Last update timestamp")]
    public DateTime LastUpdate { get; init; }

    [JsonPropertyName("lastUpdateUser")]
    [Description("Last update user ID")]
    public int LastUpdateUser { get; init; }

    [JsonPropertyName("alternateDescription")]
    [Description("Alternate description")]
    public string? AlternateDescription { get; init; }

    [JsonPropertyName("alternateCode")]
    [Description("Alternate code")]
    public string? AlternateCode { get; init; }

    [JsonPropertyName("marineLand")]
    [Description("Marine land indicator")]
    public string? MarineLand { get; init; }

    [JsonPropertyName("factorable")]
    [Description("Factorable indicator")]
    public string? Factorable { get; init; }

    [JsonPropertyName("summaryCode")]
    [Description("Summary code")]
    public string? SummaryCode { get; init; }

    [JsonPropertyName("useBiditemDescription")]
    [Description("Use biditem description flag")]
    public string? UseBiditemDescription { get; init; }

    [JsonPropertyName("use1ForLs")]
    [Description("Use 1 for LS flag")]
    public string? Use1ForLs { get; init; }

    [JsonPropertyName("notes")]
    [Description("Notes")]
    public string? Notes { get; init; }

    [JsonPropertyName("spreadsheetCalcPath")]
    [Description("Spreadsheet calculation path")]
    public string? SpreadsheetCalcPath { get; init; }

    [JsonPropertyName("crew")]
    [Description("Crew code")]
    public string? Crew { get; init; }

    [JsonPropertyName("calendar")]
    [Description("Calendar code")]
    public string? Calendar { get; init; }

    [JsonPropertyName("defaultProdType")]
    [Description("Default production type")]
    public string? DefaultProdType { get; init; }

    [JsonPropertyName("defaultProdRate")]
    [Description("Default production rate")]
    public decimal DefaultProdRate { get; init; }

    [JsonPropertyName("workersCompCode")]
    [Description("Workers compensation code")]
    public string? WorkersCompCode { get; init; }

    [JsonPropertyName("bidConversionFactor")]
    [Description("Bid conversion factor")]
    public decimal BidConversionFactor { get; init; }

    [JsonPropertyName("pullResources")]
    [Description("Pull resources flag")]
    public string? PullResources { get; init; }

    [JsonPropertyName("allowInEstimate")]
    [Description("Allow in estimate flag")]
    public string? AllowInEstimate { get; init; }

    [JsonPropertyName("hjCode")]
    [Description("HJ code")]
    public string? HjCode { get; init; }

    [JsonPropertyName("heavyJobDescription")]
    [Description("HeavyJob description")]
    public string? HeavyJobDescription { get; init; }

    [JsonPropertyName("userFlag1")]
    [Description("User flag 1")]
    public string? UserFlag1 { get; init; }

    [JsonPropertyName("userFlag2")]
    [Description("User flag 2")]
    public string? UserFlag2 { get; init; }

    [JsonPropertyName("reportGroup1")]
    [Description("Report group 1")]
    public string? ReportGroup1 { get; init; }

    [JsonPropertyName("reportGroup2")]
    [Description("Report group 2")]
    public string? ReportGroup2 { get; init; }

    [JsonPropertyName("reportGroup3")]
    [Description("Report group 3")]
    public string? ReportGroup3 { get; init; }

    [JsonPropertyName("reportGroup4")]
    [Description("Report group 4")]
    public string? ReportGroup4 { get; init; }

    [JsonPropertyName("reportGroup5")]
    [Description("Report group 5")]
    public string? ReportGroup5 { get; init; }

    [JsonPropertyName("reportGroup6")]
    [Description("Report group 6")]
    public string? ReportGroup6 { get; init; }
}