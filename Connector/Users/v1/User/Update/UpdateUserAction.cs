namespace Connector.Users.v1.User.Update;

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
[Description("Updates a user in HCSS")]
public class UpdateUserAction : IStandardAction<UpdateUserActionInput, UpdateUserActionOutput>
{
    public UpdateUserActionInput ActionInput { get; set; } = new()
    {
        Id = Guid.Empty,
        BusinessUnitAccess = new() { Type = string.Empty },
        JobAccess = new() { Type = string.Empty }
    };
    public UpdateUserActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();
    public bool CreateRtap => true;
}

public class UpdateUserActionInput
{
    [JsonPropertyName("id")]
    [Description("The ID of the user to update")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("userName")]
    [Description("The unique username of the User, used to login to HCSS Apps")]
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
    [Description("Assigns a Role to the User")]
    public Guid? UserRole { get; init; }

    [JsonPropertyName("subscriptionGroup")]
    [Description("Assigns a Subscription Group to the User")]
    public Guid? SubscriptionGroup { get; init; }

    [JsonPropertyName("note")]
    [Description("Used to add optional notes for the User")]
    public string? Note { get; init; }

    [JsonPropertyName("homeBusinessUnit")]
    [Description("The default Business Unit that the User belongs to")]
    public Guid? HomeBusinessUnit { get; init; }

    [JsonPropertyName("employeeCode")]
    [Description("Assigns an Employee to the User")]
    public string? EmployeeCode { get; init; }

    [JsonPropertyName("allowPhoneNumberLogin")]
    [Description("Enables the User to login to HCSS Apps using their phone number")]
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

public class UpdateUserActionOutput
{
    // Empty response per API spec - 204 status code
}
