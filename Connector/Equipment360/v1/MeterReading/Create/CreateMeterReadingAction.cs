namespace Connector.Equipment360.v1.MeterReading.Create;

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
[Description("Submit a meter reading for specified equipment")]
public class CreateMeterReadingAction : IStandardAction<CreateMeterReadingActionInput, CreateMeterReadingActionOutput>
{
    public CreateMeterReadingActionInput ActionInput { get; set; } = new()
    {
        EquipmentCode = string.Empty,
        ReadingDate = DateTime.UtcNow,
        MeterType = "hourMeter",
        MeterValue = 0
    };
    public CreateMeterReadingActionOutput ActionOutput { get; set; } = new()
    {
        Id = Guid.Empty,
        EquipmentCode = string.Empty,
        ReadingDate = DateTime.UtcNow,
        MeterType = "hourMeter",
        MeterValue = 0
    };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateMeterReadingActionInput
{
    [JsonPropertyName("enteredBy")]
    [Description("The name of the person or entity who recorded the reading")]
    public string? EnteredBy { get; init; }

    [JsonPropertyName("equipmentCode")]
    [Description("The unique equipment code")]
    [Required]
    public required string EquipmentCode { get; init; }

    [JsonPropertyName("readingDate")]
    [Description("The effective date of the meter reading")]
    [Required]
    public required DateTime ReadingDate { get; init; }

    [JsonPropertyName("meterType")]
    [Description("Specifies which type of meter reading is being uses")]
    [Required]
    public required string MeterType { get; init; }

    [JsonPropertyName("meterValue")]
    [Description("The value of the meter")]
    [Required]
    public required int MeterValue { get; init; }

    [JsonPropertyName("bypassValidation")]
    [Description("If true, will bypass certain validation rules such as odometer threshold and hour meter time-elapsed validation")]
    public bool BypassValidation { get; init; }
}

public class CreateMeterReadingActionOutput
{
    [JsonPropertyName("id")]
    [Description("The meter reading id")]
    public Guid Id { get; init; }

    [JsonPropertyName("enteredBy")]
    [Description("The name of the person or entity who recorded the reading")]
    public string? EnteredBy { get; init; }

    [JsonPropertyName("equipmentCode")]
    [Description("The unique equipment code")]
    [Required]
    public required string EquipmentCode { get; init; }

    [JsonPropertyName("readingDate")]
    [Description("The effective date of the meter reading")]
    [Required]
    public required DateTime ReadingDate { get; init; }

    [JsonPropertyName("meterType")]
    [Description("Specifies which type of meter reading is being uses")]
    [Required]
    public required string MeterType { get; init; }

    [JsonPropertyName("meterValue")]
    [Description("The value of the meter")]
    [Required]
    public required int MeterValue { get; init; }

    [JsonPropertyName("bypassValidation")]
    [Description("If true, will bypass certain validation rules such as odometer threshold and hour meter time-elapsed validation")]
    public bool BypassValidation { get; init; }
}
