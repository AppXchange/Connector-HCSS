namespace Connector.Skills.v1.EmployeeSkills;

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
[Description("Represents an employee skill in HCSS")]
public class EmployeeSkillsDataObject
{
    [JsonPropertyName("employeeCode")]
    [Description("A unique string identifier for this employee")]
    [Required]
    public required string EmployeeCode { get; init; }

    [JsonPropertyName("employeePayrollCode")]
    [Description("The payroll code for the employee from HeavyJob")]
    public string? EmployeePayrollCode { get; init; }

    [JsonPropertyName("skillName")]
    [Description("The display name for the skill")]
    public string? SkillName { get; init; }

    [JsonPropertyName("courseCode")]
    [Description("A unique string identifier for this skill's course code")]
    public string? CourseCode { get; init; }

    [JsonPropertyName("certificationDate")]
    [Description("A datetime of when the employee was certified in this skill")]
    public DateTime? CertificationDate { get; init; }

    [JsonPropertyName("expirationDate")]
    [Description("A datetime of when this skill expires for this employee")]
    public DateTime? ExpirationDate { get; init; }

    [JsonPropertyName("trainingTime")]
    [Description("TrainingTime is the amount of minutes it took the employee to complete the skill")]
    public int? TrainingTime { get; init; }

    [JsonPropertyName("note")]
    [Description("Note or description for this employee's skill")]
    public string? Note { get; init; }

    [JsonPropertyName("isDismissed")]
    [Description("If the employee skill has been archived/dismissed")]
    public bool IsDismissed { get; init; }

    [JsonPropertyName("lastModified")]
    [Description("When the employee skill was last modified")]
    public DateTime? LastModified { get; init; }

    [JsonPropertyName("createdDate")]
    [Description("When the employee skill was created")]
    public DateTime? CreatedDate { get; init; }

    [JsonPropertyName("attachments")]
    [Description("Attachments to the employees skill")]
    public SkillAttachment[]? Attachments { get; init; }

    [JsonPropertyName("id")]
    [Description("The Id of the skill")]
    [Required]
    public required Guid Id { get; init; }
}

public class SkillAttachment
{
    [JsonPropertyName("attachmentUrl")]
    [Description("Url of the attachment")]
    [Required]
    public required string AttachmentUrl { get; init; }

    [JsonPropertyName("name")]
    [Description("Display name of the attachment")]
    [Required]
    public required string Name { get; init; }
}