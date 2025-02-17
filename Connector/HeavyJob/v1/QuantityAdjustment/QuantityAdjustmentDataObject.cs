namespace Connector.HeavyJob.v1.QuantityAdjustment;

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
[Description("Represents a quantity adjustment in HeavyJob")]
public class QuantityAdjustmentDataObject
{
    [JsonPropertyName("id")]
    [Description("The quantity adjustment id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("jobId")]
    [Description("The job id")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("transactionDate")]
    [Description("Date on which the adjustments were made")]
    [Required]
    public required DateTime TransactionDate { get; init; }
}