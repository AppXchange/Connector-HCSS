namespace Connector.Users.v1.Users;

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
[Description("Represents users in HCSS")]
public class UsersDataObject
{
    [JsonPropertyName("id")]
    [Description("The Guid of the User according to HCSS Credentials")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("userName")]
    [Description("The unique UserName of the User, used to login to HCSS Apps")]
    public string? UserName { get; init; }

    [JsonPropertyName("firstName")]
    [Description("The first name of the User")]
    public string? FirstName { get; init; }

    [JsonPropertyName("lastName")]
    [Description("The last name of the User")]
    public string? LastName { get; init; }

    [JsonPropertyName("phoneNumber")]
    [Description("The phone number of the User")]
    public string? PhoneNumber { get; init; }

    [JsonPropertyName("email")]
    [Description("The email address of the User")]
    public string? Email { get; init; }

    [JsonPropertyName("contactMethod")]
    [Description("Contact method for notifying the user")]
    public string? ContactMethod { get; init; }

    [JsonPropertyName("userRole")]
    [Description("The Role Guid of the User")]
    [Required]
    public required Guid UserRole { get; init; }

    [JsonPropertyName("subscriptionGroup")]
    [Description("The Subscription Group Guid of the User")]
    public Guid? SubscriptionGroup { get; init; }

    [JsonPropertyName("note")]
    [Description("Optional notes of the User")]
    public string? Note { get; init; }

    [JsonPropertyName("homeBusinessUnit")]
    [Description("The default Business Unit that the User belongs to")]
    [Required]
    public required Guid HomeBusinessUnit { get; init; }

    [JsonPropertyName("employeeCode")]
    [Description("The Employee Code of the User")]
    public string? EmployeeCode { get; init; }

    [JsonPropertyName("allowPhoneNumberLogin")]
    [Description("Shows if the User is able to login to HCSS Apps using their phone number")]
    public bool? AllowPhoneNumberLogin { get; init; }

    [JsonPropertyName("excludeFromExternalAuthentication")]
    [Description("Excludes the User from signing in with external authentication")]
    public bool? ExcludeFromExternalAuthentication { get; init; }

    [JsonPropertyName("businessUnitAccess")]
    [Description("A model describing Business Unit Access")]
    [Required]
    public required BusinessUnitAccess BusinessUnitAccess { get; init; }

    [JsonPropertyName("jobAccess")]
    [Description("A model describing Job Access")]
    [Required]
    public required JobAccess JobAccess { get; init; }

    [JsonPropertyName("createdDate")]
    [Description("DateTime this user record was created")]
    public DateTime? CreatedDate { get; init; }

    [JsonPropertyName("modifiedDate")]
    [Description("DateTime this user record was updated")]
    public DateTime? ModifiedDate { get; init; }
}

public class BusinessUnitAccess
{
    [JsonPropertyName("type")]
    [Required]
    public required string Type { get; init; }

    [JsonPropertyName("values")]
    public Guid[]? Values { get; init; }
}

public class JobAccess
{
    [JsonPropertyName("type")]
    [Required]
    public required string Type { get; init; }

    [JsonPropertyName("values")]
    public Guid[]? Values { get; init; }
}