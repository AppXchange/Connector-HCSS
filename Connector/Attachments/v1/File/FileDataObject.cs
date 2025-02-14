namespace Connector.Attachments.v1.File;

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
[Description("Represents a file in the HCSS system with its metadata and access URIs")]
public class FileDataObject
{
    [JsonPropertyName("id")]
    [Description("The unique identifier of the file")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    [Description("The name of the file")]
    public string? Name { get; init; }

    [JsonPropertyName("fileUri")]
    [Description("A temporary link to the file that expires after 1 hour")]
    public string? FileUri { get; init; }

    [JsonPropertyName("thumbnailUri")]
    [Description("A temporary link to the thumbnail image (if the file is an image) that expires after 1 hour")]
    public string? ThumbnailUri { get; init; }

    [JsonPropertyName("previewUri")]
    [Description("A temporary link to the preview image (if the file is an image) that expires after 1 hour")]
    public string? PreviewUri { get; init; }

    [JsonPropertyName("jobId")]
    [Description("The unique identifier of the job associated with the file")]
    public Guid? JobId { get; init; }
}