namespace Connector.Skills.v1.Skill.Update;

using Json.Schema.Generation;
using System;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.Action;

[Description("Updates an existing skill in HCSS")]
public class UpdateSkillAction : IStandardAction<UpdateSkillActionInput, UpdateSkillActionOutput>
{
    public UpdateSkillActionInput ActionInput { get; set; } = new()
    {
        CourseCodeOrName = string.Empty,
        Description = string.Empty,
        SkillType = string.Empty,
        HasExpiration = false
    };
    public UpdateSkillActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();
    public bool CreateRtap => true;
}

public class UpdateSkillActionInput
{
    [JsonPropertyName("courseCodeOrName")]
    [Description("The course code or skill name")]
    [Required]
    public required string CourseCodeOrName { get; init; }

    [JsonPropertyName("name")]
    [Description("Display name of the skill")]
    public string? Name { get; init; }

    [JsonPropertyName("description")]
    [Description("Description of the skill")]
    [Required]
    public required string Description { get; init; }

    [JsonPropertyName("hasExpiration")]
    [Description("Boolean whether or not the skill expires")]
    [Required]
    public required bool HasExpiration { get; init; }

    [JsonPropertyName("expirationAlertThreshold")]
    [Description("Threshold of days to the set Expiration when a skill changes to expiring")]
    public int? ExpirationAlertThreshold { get; init; }

    [JsonPropertyName("expiresAfter")]
    [Description("Quantity of time units the skill expires after")]
    public int? ExpiresAfter { get; init; }

    [JsonPropertyName("expiresAfterUnits")]
    [Description("Enum for time units Days = 1, Months = 2, Years = 3")]
    public string? ExpiresAfterUnits { get; init; }

    [JsonPropertyName("trainingTime")]
    [Description("The amount of time in minutes the skill takes to complete")]
    public int? TrainingTime { get; init; }

    [JsonPropertyName("enableTrainingMeetings")]
    [Description("If training meetings for this skill are enabled")]
    public bool EnableTrainingMeetings { get; init; }

    [JsonPropertyName("skillType")]
    [Description("A type to group skills by")]
    [Required]
    public required string SkillType { get; init; }

    [JsonPropertyName("courseCode")]
    [Description("A unique string identifier for the course related to the skill")]
    public string? CourseCode { get; init; }

    [JsonPropertyName("isPrivate")]
    [Description("Boolean to determine if skill is public or private")]
    public bool IsPrivate { get; init; }

    [JsonPropertyName("lastModified")]
    [Description("When the skill was last modified")]
    public DateTime? LastModified { get; init; }

    [JsonPropertyName("createdDate")]
    [Description("When the skill was created")]
    public DateTime? CreatedDate { get; init; }

    [JsonPropertyName("attachments")]
    [Description("Attachments to the skill")]
    public SkillAttachment[]? Attachments { get; init; }
}

public class UpdateSkillActionOutput
{
    // Empty response per API spec
}
