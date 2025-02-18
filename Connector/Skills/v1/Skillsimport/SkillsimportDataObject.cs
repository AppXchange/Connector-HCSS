namespace Connector.Skills.v1.Skillsimport;

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
[Description("Represents a skill to import in HCSS")]
public class SkillsimportDataObject
{
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

    [JsonPropertyName("id")]
    [Description("The Id of the skill")]
    [Required]
    public required Guid Id { get; init; }
}

public class SkillAttachment
{
    [JsonPropertyName("attachmentUrl")]
    [Description("Url of the attachment")]
    [Required]
    public required string AttachmentUrl { get; init; }

    [JsonPropertyName("name")]
    [Description("Display name of the attachment")]
    [Required]
    public required string Name { get; init; }

    [JsonPropertyName("mimeType")]
    [Description("MimeType examples: application/pdf image/png image/jpeg")]
    [Required]
    public required string MimeType { get; init; }
}