namespace Connector.HeavyJob.v1.Attachment.Create;

using Json.Schema.Generation;
using System;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.Action;

/// <summary>
/// Action object that will represent an action in the Xchange system. This will contain an input object type,
/// an output object type, and a Action failure type (this will default to <see cref="StandardActionFailure"/>
/// but that can be overridden with your own preferred type). These objects will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// These types will be used for validation at runtime to make sure the objects being passed through the system 
/// are properly formed. The schema also helps provide integrators more information for what the values 
/// are intended to be.
/// </summary>
[Description("Creates a new attachment")]
public class CreateAttachmentAction : IStandardAction<CreateAttachmentActionInput, CreateAttachmentActionOutput>
{
    public CreateAttachmentActionInput ActionInput { get; set; } = new() 
    { 
        JobId = Guid.Empty,
        ForemanId = Guid.Empty,
        TransactionDate = DateTime.UtcNow
    };
    public CreateAttachmentActionOutput ActionOutput { get; set; } = new() 
    { 
        Id = Guid.Empty,
        JobId = Guid.Empty,
        ForemanId = Guid.Empty,
        TransactionDate = DateTime.UtcNow
    };
    public StandardActionFailure ActionFailure { get; set; } = new();
    public bool CreateRtap => true;
}

public class CreateAttachmentActionInput
{
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

public class CreateAttachmentActionOutput : AttachmentDataObject
{
}
