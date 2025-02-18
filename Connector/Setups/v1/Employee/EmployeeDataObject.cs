namespace Connector.Setups.v1.Employee;

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
[Description("Represents an employee in HCSS")]
public class EmployeeDataObject
{
    [JsonPropertyName("code")]
    [Description("Gets the employee code")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("businessUnitCode")]
    [Description("Gets the business unit")]
    [Required]
    public required string BusinessUnitCode { get; init; }

    [JsonPropertyName("id")]
    [Description("Gets the master data id for this entity")]
    public Guid? Id { get; init; }

    [JsonPropertyName("payClass")]
    [Description("Gets the pay class. The default HeavyJob pay class will be assigned if the value is null or empty while doing POST/PUT requests")]
    public string? PayClass { get; init; }

    [JsonPropertyName("phone")]
    [Description("The phone number of the employee")]
    public string? Phone { get; init; }

    [JsonPropertyName("accountingCode")]
    [Description("The accounting code")]
    public string? AccountingCode { get; init; }

    [JsonPropertyName("address")]
    [Description("The address of the employee")]
    public string? Address { get; init; }

    [JsonPropertyName("address2")]
    [Description("The address2 of the employee")]
    public string? Address2 { get; init; }

    [JsonPropertyName("city")]
    [Description("The city")]
    public string? City { get; init; }

    [JsonPropertyName("state")]
    [Description("The state")]
    [MaxLength(2)]
    public string? State { get; init; }

    [JsonPropertyName("zipCode")]
    [Description("The zip code")]
    public string? ZipCode { get; init; }

    [JsonPropertyName("isForeman")]
    [Description("Whether the employee is a foreman")]
    public bool? IsForeman { get; init; }

    [JsonPropertyName("isActive")]
    [Description("The active status of the employee")]
    public bool? IsActive { get; init; }

    [JsonPropertyName("isSalaried")]
    [Description("The salaried status of the employee")]
    public bool? IsSalaried { get; init; }

    [JsonPropertyName("department")]
    [Description("The \"Department\" accounting field")]
    public string? Department { get; init; }

    [JsonPropertyName("costType")]
    [Description("The \"CostType\" accounting field")]
    public string? CostType { get; init; }

    [JsonPropertyName("earnCode")]
    [Description("The \"EarnCode\" accounting field")]
    public string? EarnCode { get; init; }

    [JsonPropertyName("crew")]
    [Description("The \"Crew\" accounting field")]
    public string? Crew { get; init; }

    [JsonPropertyName("unionCode")]
    [Description("The \"UnionCode\" accounting field")]
    public string? UnionCode { get; init; }

    [JsonPropertyName("division")]
    [Description("The \"Division\" accounting field")]
    public string? Division { get; init; }

    [JsonPropertyName("salary")]
    [Description("The \"Salary\" accounting field")]
    public double? Salary { get; init; }

    [JsonPropertyName("generalLedgerAccount")]
    [Description("The \"GLAcct\" accounting field")]
    public string? GeneralLedgerAccount { get; init; }

    [JsonPropertyName("taxCode")]
    [Description("The \"TaxCode\" accounting field")]
    public string? TaxCode { get; init; }

    [JsonPropertyName("type")]
    [Description("The \"Type\" accounting field")]
    public string? Type { get; init; }

    [JsonPropertyName("isDiscontinued")]
    [Description("Whether the employee is discontinued")]
    public bool? IsDiscontinued { get; init; }

    [JsonPropertyName("supervisor")]
    [Description("The supervisor")]
    public string? Supervisor { get; init; }

    [JsonPropertyName("defaultEquipment")]
    [Description("The default equipment")]
    public string? DefaultEquipment { get; init; }

    [JsonPropertyName("company")]
    [Description("The company")]
    public string? Company { get; init; }

    [JsonPropertyName("mobilePhone")]
    [Description("The mobile phone of the employee")]
    public string? MobilePhone { get; init; }

    [JsonPropertyName("email")]
    [Description("The email address of the employee")]
    public string? Email { get; init; }

    [JsonPropertyName("lastName")]
    [Description("The last name")]
    public string? LastName { get; init; }

    [JsonPropertyName("firstName")]
    [Description("The first name")]
    public string? FirstName { get; init; }

    [JsonPropertyName("suffix")]
    [Description("The suffix")]
    public string? Suffix { get; init; }

    [JsonPropertyName("middleInitial")]
    [Description("The middle initial")]
    [MaxLength(1)]
    public string? MiddleInitial { get; init; }

    [JsonPropertyName("accountingTemplateName")]
    [Description("The accounting template name")]
    public string? AccountingTemplateName { get; init; }

    [JsonPropertyName("payRateLevel")]
    [Description("The \"Pay Rate Level\" accounting field")]
    public string? PayRateLevel { get; init; }

    [JsonPropertyName("payType")]
    [Description("The \"Pay Type\" accounting field")]
    public string? PayType { get; init; }

    [JsonPropertyName("trade")]
    [Description("The \"Trade\" accounting field")]
    public string? Trade { get; init; }

    [JsonPropertyName("viewExclusions")]
    [Description("Gets the view exclusions")]
    public string[]? ViewExclusions { get; init; }
}