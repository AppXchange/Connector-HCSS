namespace Connector.Setups.v1.Equipment;

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
[Description("Represents equipment in HCSS")]
public class EquipmentDataObject
{
    [JsonPropertyName("code")]
    [Description("The code")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("businessUnitCode")]
    [Description("The business unit code")]
    [Required]
    public required string BusinessUnitCode { get; init; }

    [JsonPropertyName("id")]
    [Description("The Id of the equipment")]
    public Guid? Id { get; init; }

    [JsonPropertyName("isActive")]
    [Description("The is Active flag")]
    public bool? IsActive { get; init; }

    [JsonPropertyName("defaultPayClass")]
    [Description("The default pay class code")]
    public string? DefaultPayClass { get; init; }

    [JsonPropertyName("description")]
    [Description("The description")]
    public string? Description { get; init; }

    [JsonPropertyName("gpsDeviceTag")]
    [Description("The GPS device tag")]
    public string? GpsDeviceTag { get; init; }

    [JsonPropertyName("group")]
    [Description("The group name")]
    public string? Group { get; init; }

    [JsonPropertyName("licensePlate")]
    [Description("The license plate")]
    public string? LicensePlate { get; init; }

    [JsonPropertyName("state")]
    [Description("The state")]
    public string? State { get; init; }

    [JsonPropertyName("serialNumber")]
    [Description("The serial number or VIN")]
    public string? SerialNumber { get; init; }

    [JsonPropertyName("isRental")]
    [Description("The is Rental flag")]
    public bool? IsRental { get; init; }

    [JsonPropertyName("make")]
    [Description("The make of the equipment")]
    public string? Make { get; init; }

    [JsonPropertyName("model")]
    [Description("The model of the equipment")]
    public string? Model { get; init; }

    [JsonPropertyName("year")]
    [Description("The year of the equipment")]
    public int? Year { get; init; }

    [JsonPropertyName("capacity")]
    [Description("The capacity of the equipment")]
    public double? Capacity { get; init; }

    [JsonPropertyName("accountingCode")]
    [Description("The accounting code")]
    public string? AccountingCode { get; init; }

    [JsonPropertyName("company")]
    [Description("The \"Company\" accounting field")]
    public string? Company { get; init; }

    [JsonPropertyName("miscAccount")]
    [Description("The \"MiscAccount\" accounting field")]
    public string? MiscAccount { get; init; }

    [JsonPropertyName("accountingType")]
    [Description("The \"AccountingType\" accounting field")]
    public string? AccountingType { get; init; }

    [JsonPropertyName("meterType")]
    [Description("The \"MeterType\" accounting field")]
    public string? MeterType { get; init; }

    [JsonPropertyName("usageCode")]
    [Description("The \"UsageCode\" accounting field")]
    public string? UsageCode { get; init; }

    [JsonPropertyName("costType")]
    [Description("The \"CostType\" accounting field")]
    public string? CostType { get; init; }

    [JsonPropertyName("division")]
    [Description("The \"Division\" accounting field")]
    public string? Division { get; init; }

    [JsonPropertyName("generalLedgerAccount")]
    [Description("The \"GLAcct\" accounting field")]
    public string? GeneralLedgerAccount { get; init; }

    [JsonPropertyName("accountingTemplateName")]
    [Description("The accounting template name")]
    public string? AccountingTemplateName { get; init; }
}