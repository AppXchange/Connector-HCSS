namespace Connector.HeavyBidEstimate.v1.BusinessUnits;

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
[Description("Represents a business unit in HeavyBid Estimate")]
public class BusinessUnitsDataObject
{
    [JsonPropertyName("id")]
    [Description("The business unit id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("division")]
    [Description("The division name")]
    public string? Division { get; init; }

    [JsonPropertyName("businessUnitCode")]
    [Description("The business unit code")]
    public string? BusinessUnitCode { get; init; }

    [JsonPropertyName("partitionId")] 
    [Description("The partition ID")]
    public Guid PartitionId { get; init; }

    [JsonPropertyName("systemInfoId")]
    [Description("The system info ID")]
    public Guid SystemInfoId { get; init; }
}