namespace Connector.HeavyBidEstimate.v1.ActivityCodeBook;

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
public class ActivityCodeBookDataObject
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

    [JsonPropertyName("marineLand")]
    [Description("Marine land indicator")]
    public string? MarineLand { get; init; }

    [JsonPropertyName("factorable")]
    [Description("Factorable indicator")]
    public string? Factorable { get; init; }

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
}