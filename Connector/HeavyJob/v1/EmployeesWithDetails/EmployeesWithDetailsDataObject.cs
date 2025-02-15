namespace Connector.HeavyJob.v1.EmployeesWithDetails;

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
[Description("Employee details including contact information")]
public class EmployeesWithDetailsDataObject
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

    [JsonPropertyName("lastName")]
    [Description("The last name of the employee")]
    public string? LastName { get; init; }

    [JsonPropertyName("email")]
    [Description("The email of the employee")]
    public string? Email { get; init; }

    [JsonPropertyName("cellPhone")]
    [Description("The cell phone number of the employee")]
    public string? CellPhone { get; init; }

    [JsonPropertyName("otherPhone")]
    [Description("The other phone number of the employee")]
    public string? OtherPhone { get; init; }

    [JsonPropertyName("physicalAddress")]
    [Description("The physical address of the employee")]
    public string? PhysicalAddress { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Whether the employee is deleted")]
    public bool IsDeleted { get; init; }
}

public class EmployeesWithDetailsResponse
{
    [JsonPropertyName("results")]
    [Required]
    public EmployeesWithDetailsDataObject[] Results { get; init; } = Array.Empty<EmployeesWithDetailsDataObject>();

    [JsonPropertyName("metadata")]
    [Required]
    public EmployeesWithDetailsMetadata Metadata { get; init; } = new();
}

public class EmployeesWithDetailsMetadata
{
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; init; }
}