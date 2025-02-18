namespace Connector.Safety.v1.Users;

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
[Description("Represents a user in Safety")]
public class UsersDataObject
{
    [JsonPropertyName("id")]
    [Description("User ID")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("userName")]
    [Description("User Name")]
    public string? UserName { get; init; }

    [JsonPropertyName("firstName")]
    [Description("User First Name")]
    public string? FirstName { get; init; }

    [JsonPropertyName("lastName")]
    [Description("User Last Name")]
    public string? LastName { get; init; }

    [JsonPropertyName("email")]
    [Description("User Email")]
    public string? Email { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("User IsDeleted")]
    public bool IsDeleted { get; init; }

    [JsonPropertyName("deletedBy")]
    [Description("User Deleted By")]
    public Guid? DeletedBy { get; init; }

    [JsonPropertyName("deletedDate")]
    [Description("User Deleted Date")]
    public DateTime? DeletedDate { get; init; }

    [JsonPropertyName("allowSync")]
    [Description("User Allow Sync")]
    public bool AllowSync { get; init; }

    [JsonPropertyName("syncTimestamp")]
    [Description("User SyncTimestamp")]
    public DateTime? SyncTimestamp { get; init; }

    [JsonPropertyName("employee")]
    [Description("DTO for Customer API Employee data")]
    public UserEmployee? Employee { get; init; }
}

public class UserEmployee
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("code")]
    public string? Code { get; init; }

    [JsonPropertyName("firstName")]
    public string? FirstName { get; init; }

    [JsonPropertyName("lastName")]
    public string? LastName { get; init; }
}