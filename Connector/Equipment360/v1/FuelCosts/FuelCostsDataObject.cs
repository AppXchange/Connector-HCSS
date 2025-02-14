namespace Connector.Equipment360.v1.FuelCosts;

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
[PrimaryKey("jobId", nameof(JobId))]
[Description("Represents fuel costs for jobs")]
public class FuelCostsDataObject
{
    [JsonPropertyName("jobId")]
    [Description("The job id. Returns as empty guid for costs where a job isn't specified")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("jobCode")]
    [Description("The job code")]
    public string? JobCode { get; init; }

    [JsonPropertyName("totalFuelCost")]
    [Description("Total fuel cost, including both Dispenses and Direct Fluid Purchases")]
    public double TotalFuelCost { get; init; }
}