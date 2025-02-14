namespace Connector.HeavyBidEstimate.v1.Estimates;

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
[Description("Represents an estimate in HeavyBid")]
public class EstimatesDataObject
{
    [JsonPropertyName("id")]
    [Description("The estimate id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("partitionId")]
    [Description("The partition ID")]
    public Guid PartitionId { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit ID")]
    public Guid BusinessUnitId { get; init; }

    [JsonPropertyName("businessUnitCode")]
    [Description("The business unit code")]
    public string? BusinessUnitCode { get; init; }

    [JsonPropertyName("heavyBidDivision")]
    [Description("The HeavyBid division")]
    public string? HeavyBidDivision { get; init; }

    [JsonPropertyName("code")]
    [Description("The estimate code")]
    public string? Code { get; init; }

    [JsonPropertyName("name")]
    [Description("The estimate name")]
    public string? Name { get; init; }

    [JsonPropertyName("processedStatus")]
    [Description("The processed status")]
    public int ProcessedStatus { get; init; }

    [JsonPropertyName("description")]
    [Description("The estimate description")]
    public string? Description { get; init; }

    [JsonPropertyName("estimateVersion")]
    [Description("The estimate version")]
    public int EstimateVersion { get; init; }

    [JsonPropertyName("lastModified")]
    [Description("Last modified timestamp")]
    public DateTime LastModified { get; init; }

    [JsonPropertyName("lastProcessed")]
    [Description("Last processed timestamp")]
    public DateTime LastProcessed { get; init; }

    [JsonPropertyName("isExcludedEstimate")]
    [Description("Whether the estimate is excluded")]
    public bool IsExcludedEstimate { get; init; }

    [JsonPropertyName("isActiveEstimate")]
    [Description("Whether the estimate is active")]
    public bool IsActiveEstimate { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Whether the estimate is deleted")]
    public bool IsDeleted { get; init; }

    [JsonPropertyName("deletedTimestamp")]
    [Description("Deletion timestamp")]
    [Nullable(true)]
    public DateTime? DeletedTimestamp { get; init; }
}