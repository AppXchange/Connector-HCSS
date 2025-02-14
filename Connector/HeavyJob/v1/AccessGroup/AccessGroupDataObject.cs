namespace Connector.HeavyJob.v1.AccessGroup;

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
[Description("Represents an access group/role in HeavyJob")]
public class AccessGroupDataObject
{
    [JsonPropertyName("id")]
    [Description("The unique identifier of the access group")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    [Description("The name of the access group")]
    [Required]
    [MinLength(1)]
    public required string Name { get; init; }

    [JsonPropertyName("description")]
    [Description("The description of the access group")]
    public string? Description { get; init; }

    [JsonPropertyName("lastChangedById")]
    [Description("The ID of the user who last modified the access group")]
    public Guid? LastChangedById { get; init; }

    [JsonPropertyName("subscriptionType")]
    [Description("The subscription type of the access group")]
    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public SubscriptionType SubscriptionType { get; init; }

    [JsonPropertyName("applicationType")]
    [Description("The application type of the access group")]
    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ApplicationType ApplicationType { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Indicates if the access group is deleted")]
    public bool IsDeleted { get; init; }
}

public enum SubscriptionType
{
    Hybrid,
    HybridFree,
    WebOnly,
    EmployeeApp
}

public enum ApplicationType
{
    Unknown,
    HeavyJob,
    EmployeeApp
}