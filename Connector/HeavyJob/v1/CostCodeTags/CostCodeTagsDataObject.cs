namespace Connector.HeavyJob.v1.CostCodeTags;

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
[Description("Represents a cost code tag relationship in HeavyJob")]
public class CostCodeTagsDataObject
{
    [JsonPropertyName("id")]
    [Description("The cost code tag ID")]
    [Required]
    public Guid Id { get; init; }

    [JsonPropertyName("jobId")]
    [Description("The job ID")]
    public Guid JobId { get; init; }

    [JsonPropertyName("costCodeId")]
    [Description("The cost code ID")]
    public Guid CostCodeId { get; init; }

    [JsonPropertyName("tagId")]
    [Description("The tag ID")]
    public Guid TagId { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Whether the tag relationship is deleted")]
    public bool IsDeleted { get; init; }

    [JsonPropertyName("lastModified")]
    [Description("When the tag relationship was last modified")]
    public DateTime LastModified { get; init; }
}

public class CostCodeTagsResponse
{
    [JsonPropertyName("results")]
    [Required]
    public CostCodeTagsDataObject[] Results { get; init; } = Array.Empty<CostCodeTagsDataObject>();

    [JsonPropertyName("metadata")]
    [Required]
    public CostCodeTagsMetadata Metadata { get; init; } = new();
}

public class CostCodeTagsMetadata
{
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; init; }
}