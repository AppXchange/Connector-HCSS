namespace Connector.Equipment360.v1.Employee.Update;

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
[Description("Updates an existing employee record")]
public class UpdateEmployeeAction : IStandardAction<UpdateEmployeeActionInput, EmployeeDataObject>
{
    public UpdateEmployeeActionInput ActionInput { get; set; } = new() { Id = Guid.Empty };
    public EmployeeDataObject ActionOutput { get; set; } = new() 
    { 
        Id = Guid.Empty,
        FirstName = string.Empty,
        LastName = string.Empty
    };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class UpdateEmployeeActionInput
{
    [JsonPropertyName("id")]
    [Description("The ID of the employee to update")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("code")]
    [Description("The employee's Code")]
    public string? Code { get; init; }

    [JsonPropertyName("firstName")]
    [Description("The employee's first name")]
    public string? FirstName { get; init; }

    [JsonPropertyName("lastName")]
    [Description("The employee's last name")]
    public string? LastName { get; init; }

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
