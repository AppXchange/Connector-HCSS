namespace Connector.HeavyJob.v1.EmployeesAdvanced;

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
[Description("Advanced employee details in HeavyJob")]
public class EmployeesAdvancedDataObject
{
    [JsonPropertyName("id")]
    [Description("The id of the employee")]
    [Required]
    public Guid Id { get; init; }

    [JsonPropertyName("code")]
    [Description("The code of the employee")]
    public string? Code { get; init; }

    [JsonPropertyName("firstName")]
    [Description("The first name of the employee")]
    public string? FirstName { get; init; }

    [JsonPropertyName("middleInitial")]
    [Description("The middle initial of the employee")]
    public string? MiddleInitial { get; init; }

    [JsonPropertyName("lastName")]
    [Description("The last name of the employee")]
    public string? LastName { get; init; }

    [JsonPropertyName("suffix")]
    [Description("The suffix of the employee")]
    public string? Suffix { get; init; }

    [JsonPropertyName("nickName")]
    [Description("The nick name of the employee")]
    public string? NickName { get; init; }

    [JsonPropertyName("email")]
    [Description("The email of the employee")]
    public string? Email { get; init; }

    [JsonPropertyName("isSalaried")]
    [Description("The salaried status of the employee")]
    public bool IsSalaried { get; init; }

    [JsonPropertyName("isActive")]
    [Description("The active status of the employee")]
    public bool IsActive { get; init; }

    [JsonPropertyName("isForeman")]
    [Description("Whether the employee is an active foreman")]
    public bool IsForeman { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Whether the employee is deleted")]
    public bool IsDeleted { get; init; }

    [JsonPropertyName("isHistoricalForeman")]
    [Description("Whether the employee is or ever has been a foreman")]
    public bool IsHistoricalForeman { get; init; }
}

public class EmployeesAdvancedResponse
{
    [JsonPropertyName("results")]
    [Required]
    public EmployeesAdvancedDataObject[] Results { get; init; } = Array.Empty<EmployeesAdvancedDataObject>();

    [JsonPropertyName("metadata")]
    [Required]
    public EmployeesAdvancedMetadata Metadata { get; init; } = new();
}

public class EmployeesAdvancedMetadata
{
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; init; }
}