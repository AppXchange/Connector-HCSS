namespace Connector.HeavyJob.v1.User;

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
[Description("Represents a user in HeavyJob")]
public class UserDataObject
{
    [JsonPropertyName("id")]
    [Description("The user id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("firstName")]
    [Description("The first name")]
    [Required]
    public required string FirstName { get; init; }

    [JsonPropertyName("lastName")]
    [Description("The last name")]
    public string? LastName { get; init; }

    [JsonPropertyName("email")]
    [Description("The email")]
    public string? Email { get; init; }

    [JsonPropertyName("employee")]
    [Description("A POCO that represents an employee's basic information")]
    public EmployeeCompactRead? Employee { get; init; }
}

public class EmployeeCompactRead
{
    [JsonPropertyName("id")]
    [Description("The employee guid")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("code")]
    [Description("The employee's code")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("firstName")]
    [Description("The employee's first name")]
    [Required]
    public required string FirstName { get; init; }

    [JsonPropertyName("lastName")]
    [Description("The employee's last name")]
    [Required]
    public required string LastName { get; init; }
}