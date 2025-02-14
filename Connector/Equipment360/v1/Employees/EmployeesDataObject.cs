namespace Connector.Equipment360.v1.Employees;

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
[Description("Represents an employee in the system")]
public class EmployeesDataObject
{
    [JsonPropertyName("id")]
    [Description("The guid of the employee record")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("employeeId")]
    [Description("The integer ID (or \"Legacy Key\") of the employee record")]
    public int EmployeeId { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The employee's business unit ID")]
    public Guid BusinessUnitId { get; init; }

    [JsonPropertyName("code")]
    [Description("The employee's Code")]
    public string? Code { get; init; }

    [JsonPropertyName("firstName")]
    [Description("The employee's first name")]
    [Required]
    public required string FirstName { get; init; }

    [JsonPropertyName("lastName")]
    [Description("The employee's last name")]
    [Required]
    public required string LastName { get; init; }

    [JsonPropertyName("types")]
    [Description("An array of assigned employee type(s)")]
    public string[]? Types { get; init; }

    [JsonPropertyName("payclass")]
    [Description("The employee's payclass")]
    public string? Payclass { get; init; }

    [JsonPropertyName("address")]
    [Description("The employee's address information")]
    public ApiAddressCreate? Address { get; init; }

    [JsonPropertyName("hireDate")]
    [Description("The employeees hire date value is the server time")]
    public DateTime? HireDate { get; init; }

    [JsonPropertyName("mobilePhone")]
    [Description("The employee's mobile phone number")]
    public string? MobilePhone { get; init; }

    [JsonPropertyName("homePhone")]
    [Description("The employee's home phone number")]
    public string? HomePhone { get; init; }

    [JsonPropertyName("officePhone")]
    [Description("The employee's office phone number")]
    public string? OfficePhone { get; init; }

    [JsonPropertyName("homeEmail")]
    [Description("The employee's home email")]
    public string? HomeEmail { get; init; }

    [JsonPropertyName("officeEmail")]
    [Description("The employee's office email")]
    public string? OfficeEmail { get; init; }

    [JsonPropertyName("region")]
    [Description("The employee's region code")]
    public string? Region { get; init; }

    [JsonPropertyName("division")]
    [Description("The employee's division code")]
    public string? Division { get; init; }

    [JsonPropertyName("accountingCode")]
    [Description("The employee's accounting code")]
    public string? AccountingCode { get; init; }

    [JsonPropertyName("onLoanBusinessUnitId")]
    [Description("The ID associated with the business unit the employee is currently on-loan to")]
    public Guid? OnLoanBusinessUnitId { get; init; }
}

public class ApiAddressCreate
{
    [JsonPropertyName("line1")]
    public string? Line1 { get; init; }

    [JsonPropertyName("line2")]
    public string? Line2 { get; init; }

    [JsonPropertyName("city")]
    public string? City { get; init; }

    [JsonPropertyName("state")]
    public string? State { get; init; }

    [JsonPropertyName("zip")]
    public string? Zip { get; init; }
}