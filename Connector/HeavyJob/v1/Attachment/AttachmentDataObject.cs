namespace Connector.HeavyJob.v1.Attachment;

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
[Description("Represents an attachment in HeavyJob")]
public class AttachmentDataObject
{
    [JsonPropertyName("id")]
    [Description("The unique identifier of the attachment")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("transactionDate")]
    [Description("The transaction date")]
    [Required]
    public required DateTime TransactionDate { get; init; }

    [JsonPropertyName("jobId")]
    [Description("The job id")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("foremanId")]
    [Description("The foreman id")]
    [Required]
    public required Guid ForemanId { get; init; }

    [JsonPropertyName("attachmentInfos")]
    [Description("The attachment infos")]
    public AttachmentInfo[]? AttachmentInfos { get; init; }
}

public class AttachmentInfo
{
    [JsonPropertyName("fileId")]
    [Description("The file id")]
    [Required]
    public required Guid FileId { get; init; }

    [JsonPropertyName("note")]
    [Description("The note associated with the attachment")]
    public string? Note { get; init; }
}