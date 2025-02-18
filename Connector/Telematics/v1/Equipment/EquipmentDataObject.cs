namespace Connector.Telematics.v1.Equipment;

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
[Description("Represents equipment in HCSS Telematics")]
public class EquipmentDataObject
{
    [JsonPropertyName("id")]
    [Description("The equipment's id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("code")]
    [Description("The equipment's code")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("description")]
    [Description("The equipment's description")]
    public string? Description { get; init; }

    [JsonPropertyName("fuelUom")]
    [Description("The unit of measure used by the equipment's fuel reading")]
    public string? FuelUom { get; init; }

    [JsonPropertyName("lastBearing")]
    [Description("The equipment's last bearing in degrees. 0 degrees is North")]
    public float? LastBearing { get; init; }

    [JsonPropertyName("lastLatitude")]
    [Description("The equipment's last latitude")]
    public double? LastLatitude { get; init; }

    [JsonPropertyName("lastLongitude")]
    [Description("The equipment's last longitude")]
    public double? LastLongitude { get; init; }

    [JsonPropertyName("lastLocationDateTime")]
    [Description("The datetime (in UTC) of the equipment's last location")]
    public DateTime? LastLocationDateTime { get; init; }

    [JsonPropertyName("lastHourMeterReadingInSeconds")]
    [Description("The equipment's last meter reading in seconds")]
    public double? LastHourMeterReadingInSeconds { get; init; }

    [JsonPropertyName("lastHourMeterReadingInHours")]
    [Description("The equipment's last meter reading in hours")]
    public double? LastHourMeterReadingInHours { get; init; }

    [JsonPropertyName("lastHourMeterReadingDateTime")]
    [Description("The datetime (in UTC) of the equipment's last hour meter reading")]
    public DateTime? LastHourMeterReadingDateTime { get; init; }

    [JsonPropertyName("lastHourMeterReadingSource")]
    [Description("The source of the equipment's last hour meter reading")]
    public string? LastHourMeterReadingSource { get; init; }

    [JsonPropertyName("hourMeterOffsetInSeconds")]
    [Description("The hour meter offset in seconds")]
    public double? HourMeterOffsetInSeconds { get; init; }

    [JsonPropertyName("lastEngineStatus")]
    [Description("The last engine status for the equipment")]
    public string? LastEngineStatus { get; init; }

    [JsonPropertyName("lastEngineStatusDateTime")]
    [Description("The datetime (in UTC) of the equipment's last engine status")]
    public DateTime? LastEngineStatusDateTime { get; init; }

    [JsonPropertyName("lastOdometerReadingInMeters")]
    [Description("The equipment's last meter reading in meters")]
    public double? LastOdometerReadingInMeters { get; init; }

    [JsonPropertyName("lastOdometerReadingInMiles")]
    [Description("The equipment's last meter reading in miles")]
    public double? LastOdometerReadingInMiles { get; init; }

    [JsonPropertyName("lastOdometerReadingDateTime")]
    [Description("The datetime (in UTC) of the equipment's last odometer reading")]
    public DateTime? LastOdometerReadingDateTime { get; init; }

    [JsonPropertyName("lastOdometerReadingSource")]
    [Description("The source of the equipment's last odometer reading")]
    public string? LastOdometerReadingSource { get; init; }

    [JsonPropertyName("lastSpeed")]
    [Description("The equipment's last speed in miles per hour")]
    public float? LastSpeed { get; init; }

    [JsonPropertyName("lastTotalFuelUsedInLiters")]
    [Description("The equipment's last total fuel used in liters")]
    public double? LastTotalFuelUsedInLiters { get; init; }

    [JsonPropertyName("lastTotalFuelUsedReport")]
    [Description("The datetime (in UTC) of the equipment's last total fuel used report")]
    public DateTime? LastTotalFuelUsedReport { get; init; }

    [JsonPropertyName("make")]
    [Description("The make of the equipment")]
    public string? Make { get; init; }

    [JsonPropertyName("model")]
    [Description("The model of the equipment")]
    public string? Model { get; init; }

    [JsonPropertyName("odometerOffset")]
    [Description("The odometer offset")]
    public double? OdometerOffset { get; init; }

    [JsonPropertyName("speedUom")]
    [Description("The unit of measure used by the equipment's speed reading")]
    public string? SpeedUom { get; init; }

    [JsonPropertyName("isRegistered")]
    [Description("Whether or not the equipment is registered")]
    public bool IsRegistered { get; init; }
}