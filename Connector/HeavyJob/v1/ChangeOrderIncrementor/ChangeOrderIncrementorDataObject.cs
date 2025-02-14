namespace Connector.HeavyJob.v1.ChangeOrderIncrementor;

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
[Description("Change order incrementor data for a job")]
public class ChangeOrderIncrementorDataObject
{
    [JsonPropertyName("jobId")]
    [Description("The job id of the change order")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("changeOrderNumbers")]
    [Description("The list of PCO numbers")]
    public int[]? ChangeOrderNumbers { get; init; }
}