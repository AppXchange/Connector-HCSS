namespace Connector.HeavyJob.v1.UserAccessGroup;

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
[PrimaryKey("userId", nameof(UserId))]
[Description("Represents a user's access group in HeavyJob")]
public class UserAccessGroupDataObject
{
    [JsonPropertyName("userId")]
    [Description("The user id")]
    [Required]
    public required Guid UserId { get; init; }

    [JsonPropertyName("accessGroupId")]
    [Description("The access group id")]
    [Required]
    public required Guid AccessGroupId { get; init; }
}