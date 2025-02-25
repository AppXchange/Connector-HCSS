namespace Connector.HeavyJob.v1.Employees;

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
[Description("Employee in HeavyJob")]
public class EmployeesDataObject
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

    [JsonPropertyName("assignedEquipmentId")]
    [Description("The id of the default equipment assigned to the employee")]
    public Guid? AssignedEquipmentId { get; init; }

    [JsonPropertyName("assignedEquipmentCode")]
    [Description("The code of the default equipment assigned to the employee")]
    public string? AssignedEquipmentCode { get; init; }

    [JsonPropertyName("assignedEquipmentDescription")]
    [Description("The description of the default equipment assigned to the employee")]
    public string? AssignedEquipmentDescription { get; init; }

    [JsonPropertyName("defaultPayClassId")]
    [Description("The id of the default payclass assigned to the employee")]
    public Guid? DefaultPayClassId { get; init; }

    [JsonPropertyName("defaultPayClassCode")]
    [Description("The code of the default payclass assigned to the employee")]
    public string? DefaultPayClassCode { get; init; }

    [JsonPropertyName("defaultPayClassDescription")]
    [Description("The description of the default payclass assigned to the employee")]
    public string? DefaultPayClassDescription { get; init; }

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