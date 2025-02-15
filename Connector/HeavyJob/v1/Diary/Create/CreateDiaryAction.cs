namespace Connector.HeavyJob.v1.Diary.Create;

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
[Description("Creates or updates a diary record")]
public class CreateDiaryAction : IStandardAction<CreateDiaryActionInput, CreateDiaryActionOutput>
{
    public CreateDiaryActionInput ActionInput { get; set; } = new();
    public CreateDiaryActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateDiaryActionInput
{
    [JsonPropertyName("jobId")]
    [Description("The job id")]
    [Required]
    public Guid JobId { get; init; }

    [JsonPropertyName("foremanId")]
    [Description("The foreman id")]
    [Required]
    public Guid ForemanId { get; init; }

    [JsonPropertyName("date")]
    [Description("The diary date")]
    [Required]
    public DateTime Date { get; init; }

    [JsonPropertyName("lockedById")]
    [Description("The ID of who locked the diary")]
    public Guid? LockedById { get; init; }

    [JsonPropertyName("lockedDateTime")]
    [Description("The date diary was submitted/sent")]
    public DateTime? LockedDateTime { get; init; }

    [JsonPropertyName("revision")]
    [Description("Revision number")]
    [Required]
    public int Revision { get; init; }

    [JsonPropertyName("tags")]
    [Description("Diary tags")]
    public DiaryTag[]? Tags { get; init; }

    [JsonPropertyName("note")]
    [Description("The diary note")]
    [MaxLength(7502)]
    public string? Note { get; init; }

    [JsonPropertyName("workingConditions")]
    [Description("The diary working conditions")]
    [MaxLength(200)]
    public string? WorkingConditions { get; init; }
}

public class CreateDiaryActionOutput
{
    [JsonPropertyName("id")]
    [Description("The diary id")]
    [Required]
    public Guid Id { get; init; }
}
