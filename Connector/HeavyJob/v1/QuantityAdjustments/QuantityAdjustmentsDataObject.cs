namespace Connector.HeavyJob.v1.QuantityAdjustments;

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
[PrimaryKey("costCodeId", nameof(CostCodeId))]
[Description("Represents quantity adjustment changes in HeavyJob")]
public class QuantityAdjustmentsDataObject
{
    [JsonPropertyName("costCodeId")]
    [Description("The cost code guid")]
    [Required]
    public required Guid CostCodeId { get; init; }

    [JsonPropertyName("costCode")]
    [Description("The cost code code")]
    public string? CostCode { get; init; }

    [JsonPropertyName("foremanId")]
    [Description("The foreman's employee guid")]
    public Guid? ForemanId { get; init; }

    [JsonPropertyName("foremanCode")]
    [Description("The foreman's employee code")]
    public string? ForemanCode { get; init; }

    [JsonPropertyName("jobId")]
    [Description("The job guid")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("jobCode")]
    [Description("The job code")]
    [Required]
    public required string JobCode { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit guid")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("businessUnitCode")]
    [Description("The business unit code")]
    [Required]
    public required string BusinessUnitCode { get; init; }

    [JsonPropertyName("isForemanEntity")]
    [Description("Indicates whether the quantity adjustment was made without a specific foreman")]
    [Required]
    public required bool IsForemanEntity { get; init; }

    [JsonPropertyName("date")]
    [Description("The quantity adjustment date")]
    [Required]
    public required DateTime Date { get; init; }

    [JsonPropertyName("quantity")]
    [Description("The changed quantity")]
    [Required]
    public required double Quantity { get; init; }

    [JsonPropertyName("revision")]
    [Description("The revision of the change")]
    [Required]
    public required int Revision { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The unit of measure")]
    public string? UnitOfMeasure { get; init; }

    [JsonPropertyName("note")]
    [Description("The note")]
    public string? Note { get; init; }

    [JsonPropertyName("lastModifiedPreciseDateTime")]
    [Description("The RFC 3339 dateTime (including fractional seconds), in UTC, when this was last modified")]
    [Required]
    public required DateTime LastModifiedPreciseDateTime { get; init; }
}