namespace Connector.HeavyJob.v1.TimeCard.Update;

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
[Description("Updates an existing time card's sent-to-payroll information")]
public class UpdateTimeCardAction : IStandardAction<UpdateTimeCardActionInput, UpdateTimeCardActionOutput>
{
    public UpdateTimeCardActionInput ActionInput { get; set; } = new() 
    { 
        Id = Guid.Empty,
        SentToPayrollRevision = 0,
        SentToPayrollDateTime = DateTime.UtcNow
    };
    public UpdateTimeCardActionOutput ActionOutput { get; set; } = new() 
    { 
        Success = false 
    };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class UpdateTimeCardActionInput
{
    [JsonPropertyName("id")]
    [Description("The id of the time card to be updated")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("sentToPayrollRevision")]
    [Description("The revision of the time card sent to payroll")]
    [Required]
    public required int SentToPayrollRevision { get; init; }

    [JsonPropertyName("sentToPayrollDateTime")]
    [Description("When the time card was sent to payroll")]
    [Required]
    public required DateTime SentToPayrollDateTime { get; init; }
}

public class UpdateTimeCardActionOutput
{
    [JsonPropertyName("success")]
    [Description("Whether the update was successful")]
    [Required]
    public required bool Success { get; init; }
}
