namespace Connector.HeavyJob.v1.Diary;

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
[Description("Represents a diary entry in HeavyJob")]
public class DiaryDataObject
{
    [JsonPropertyName("id")]
    [Description("The diary id")]
    [Required]
    public Guid Id { get; init; }

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

public class DiaryTag
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("code")]
    public string Code { get; init; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; init; } = string.Empty;

    [JsonPropertyName("note")]
    public string Note { get; init; } = string.Empty;

    [JsonPropertyName("groupId")]
    public Guid GroupId { get; init; }

    [JsonPropertyName("groupCode")]
    public string GroupCode { get; init; } = string.Empty;
}