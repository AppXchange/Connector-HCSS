namespace Connector.HeavyBidEstimate.v1.EstimateAttachments;

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
[Description("Represents an attachment in a HeavyBid estimate")]
public class EstimateAttachmentsDataObject
{
    [JsonPropertyName("id")]
    [Description("The attachment id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit ID")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("estimateId")]
    [Description("The estimate ID")]
    [Required]
    public required Guid EstimateId { get; init; }

    [JsonPropertyName("fileName")]
    [Description("The file name")]
    public string? FileName { get; init; }
}