namespace Connector.Equipment360.v1.MeterReading;

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
[PrimaryKey("hourMeterId", nameof(HourMeterId))]
[Description("Represents a meter reading for equipment")]
public class MeterReadingDataObject
{
    [JsonPropertyName("businessUnitId")]
    [Description("The business unit id")]
    public Guid? BusinessUnitId { get; init; }

    [JsonPropertyName("equipmentCode")]
    [Description("The unique equipment code")]
    [Required]
    public required string EquipmentCode { get; init; }

    [JsonPropertyName("hourMeterId")]
    [Description("The hour meter reading id")]
    [Required]
    public required Guid HourMeterId { get; init; }

    [JsonPropertyName("hourMeterValue")]
    [Description("The value of the hour meter")]
    public int? HourMeterValue { get; init; }

    [JsonPropertyName("hourMeterDate")]
    [Description("The effective date of the hour meter reading")]
    public DateTime? HourMeterDate { get; init; }

    [JsonPropertyName("hourMeterEnteredBy")]
    [Description("The name of the person or entity who recorded the hour meter reading")]
    public string? HourMeterEnteredBy { get; init; }

    [JsonPropertyName("odometerId")]
    [Description("The odometer reading id")]
    [Required]
    public required Guid OdometerId { get; init; }

    [JsonPropertyName("odometerValue")]
    [Description("The value of the odometer")]
    [Required]
    public required int OdometerValue { get; init; }

    [JsonPropertyName("odometerDate")]
    [Description("The effective date of the odometer reading")]
    public DateTime? OdometerDate { get; init; }

    [JsonPropertyName("odometerEnteredBy")]
    [Description("The name of the person or entity who recorded the odometer reading")]
    public string? OdometerEnteredBy { get; init; }
}