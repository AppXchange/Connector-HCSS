namespace Connector.Safety.v1.Meetings;

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
[Description("Represents a meeting in Safety")]
public class MeetingsDataObject
{
    [JsonPropertyName("id")]
    [Description("Unique identifier for this meeting")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("meetingDate")]
    [Description("The date this meeting was held")]
    [Required]
    public required DateTime MeetingDate { get; init; }

    [JsonPropertyName("jobId")]
    [Description("Job ID for this meeting")]
    public Guid? JobId { get; init; }

    [JsonPropertyName("jobCode")]
    [Description("Job code for this meeting")]
    public string? JobCode { get; init; }

    [JsonPropertyName("recorderId")]
    [Description("Recorder's employee ID")]
    public Guid? RecorderId { get; init; }

    [JsonPropertyName("recorderCode")]
    [Description("Recorder's employee code")]
    public string? RecorderCode { get; init; }

    [JsonPropertyName("durationMinutes")]
    [Description("Meeting duration, in minutes")]
    public int? DurationMinutes { get; init; }

    [JsonPropertyName("type")]
    [Description("Meeting type")]
    public string? Type { get; init; }

    [JsonPropertyName("notes")]
    [Description("Additional notes")]
    public string? Notes { get; init; }

    [JsonPropertyName("topics")]
    [Description("List of meeting topics")]
    public Topic[]? Topics { get; init; }

    [JsonPropertyName("attachments")]
    [Description("List of meeting attachments")]
    public string[]? Attachments { get; init; }

    [JsonPropertyName("employees")]
    [Description("List of employees attending this meeting")]
    public Employee[]? Employees { get; init; }

    [JsonPropertyName("visitors")]
    [Description("List of non-employee visitors attending this meeting")]
    public Visitor[]? Visitors { get; init; }
}

public class Topic
{
    [JsonPropertyName("topicName")]
    [Description("Topic name")]
    public string? TopicName { get; init; }

    [JsonPropertyName("subtopics")]
    [Description("List of subtopics")]
    public string[]? Subtopics { get; init; }
}

public class Employee
{
    [JsonPropertyName("firstName")]
    [Description("Employee's first name")]
    public string? FirstName { get; init; }

    [JsonPropertyName("lastName")]
    [Description("Employee's last name")]
    public string? LastName { get; init; }

    [JsonPropertyName("employeeCode")]
    [Description("Employee code")]
    public string? EmployeeCode { get; init; }

    [JsonPropertyName("onSite")]
    [Description("Was this attendee on-site?")]
    public bool OnSite { get; init; }

    [JsonPropertyName("attended")]
    [Description("Did this person attend?")]
    public bool Attended { get; init; }
}

public class Visitor
{
    [JsonPropertyName("name")]
    [Description("Name of visitor")]
    public string? Name { get; init; }

    [JsonPropertyName("note")]
    [Description("Additional notes regarding this visitor")]
    public string? Note { get; init; }

    [JsonPropertyName("onSite")]
    [Description("Was this attendee on-site?")]
    public bool OnSite { get; init; }

    [JsonPropertyName("attended")]
    [Description("Did this person attend?")]
    public bool Attended { get; init; }
}