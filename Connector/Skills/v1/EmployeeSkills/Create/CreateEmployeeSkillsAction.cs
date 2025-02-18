namespace Connector.Skills.v1.EmployeeSkills.Create;

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
[Description("Creates or updates a skill for an existing employee in HCSS")]
public class CreateEmployeeSkillsAction : IStandardAction<CreateEmployeeSkillsActionInput, CreateEmployeeSkillsActionOutput>
{
    public CreateEmployeeSkillsActionInput ActionInput { get; set; } = new()
    {
        EmployeeCode = string.Empty,
        SkillName = string.Empty
    };
    public CreateEmployeeSkillsActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();
    public bool CreateRtap => true;
}

public class CreateEmployeeSkillsActionInput
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

    [JsonPropertyName("usePayrollCode")]
    [Description("Whether to use payroll code instead of employee code")]
    public bool UsePayrollCode { get; init; }
}

public class CreateEmployeeSkillsActionOutput
{
    [JsonPropertyName("id")]
    [Description("The Id of the created skill")]
    public string Id { get; init; } = string.Empty;
}
