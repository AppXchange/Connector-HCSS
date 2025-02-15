namespace Connector.HeavyJob.v1.Diaries;

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
public class DiariesDataObject
{
    [JsonPropertyName("id")]
    [Description("The diary ID")]
    [Required]
    public Guid Id { get; init; }

    [JsonPropertyName("job")]
    [Description("The job details")]
    public JobInfo Job { get; init; } = new();

    [JsonPropertyName("foreman")]
    [Description("The foreman details")]
    public ForemanInfo Foreman { get; init; } = new();

    [JsonPropertyName("workingConditionNote")]
    [Description("The working condition note")]
    public string? WorkingConditionNote { get; init; }

    [JsonPropertyName("note")]
    [Description("The diary note")]
    public string? Note { get; init; }

    [JsonPropertyName("tags")]
    [Description("The diary tags")]
    public DiaryTag[] Tags { get; init; } = Array.Empty<DiaryTag>();

    [JsonPropertyName("date")]
    [Description("The diary date")]
    public DateTime Date { get; init; }

    [JsonPropertyName("revision")]
    [Description("The revision number")]
    public int Revision { get; init; }

    [JsonPropertyName("lastChangedDateTime")]
    [Description("When the diary was last changed")]
    public DateTime LastChangedDateTime { get; init; }

    [JsonPropertyName("lastChangedBy")]
    [Description("Who last changed the diary")]
    public UserInfo LastChangedBy { get; init; } = new();
}

public class JobInfo
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("code")]
    public string Code { get; init; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; init; } = string.Empty;
}

public class ForemanInfo
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("code")]
    public string Code { get; init; } = string.Empty;

    [JsonPropertyName("firstName")]
    public string FirstName { get; init; } = string.Empty;

    [JsonPropertyName("lastName")]
    public string LastName { get; init; } = string.Empty;
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

public class UserInfo
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("firstName")]
    public string FirstName { get; init; } = string.Empty;

    [JsonPropertyName("lastName")]
    public string LastName { get; init; } = string.Empty;

    [JsonPropertyName("email")]
    public string Email { get; init; } = string.Empty;
}

public class DiariesResponse
{
    [JsonPropertyName("results")]
    [Required]
    public DiariesDataObject[] Results { get; init; } = Array.Empty<DiariesDataObject>();

    [JsonPropertyName("metadata")]
    [Required]
    public DiariesMetadata Metadata { get; init; } = new();
}

public class DiariesMetadata
{
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; init; }
}