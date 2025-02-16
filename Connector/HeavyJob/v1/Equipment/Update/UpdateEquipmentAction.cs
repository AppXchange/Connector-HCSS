namespace Connector.HeavyJob.v1.Equipment.Update;

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
[Description("Updates an existing equipment")]
public class UpdateEquipmentAction : IStandardAction<UpdateEquipmentActionInput, UpdateEquipmentActionOutput>
{
    public UpdateEquipmentActionInput ActionInput { get; set; } = new();
    public UpdateEquipmentActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class UpdateEquipmentActionInput
{
    [JsonPropertyName("businessUnitId")]
    [Description("The business unit Id")]
    [Required]
    public Guid BusinessUnitId { get; init; }

    [JsonPropertyName("equipmentId")]
    [Description("The equipment Id")]
    [Required]
    public Guid EquipmentId { get; init; }

    [JsonPropertyName("equipmentCode")]
    [Description("The equipment code")]
    [Required]
    [MinLength(1), MaxLength(100)]
    public string EquipmentCode { get; init; } = string.Empty;

    [JsonPropertyName("equipmentDescription")]
    [Description("The equipment description")]
    [Required]
    [MaxLength(200)]
    public string EquipmentDescription { get; init; } = string.Empty;

    [JsonPropertyName("gpsDeviceTag")]
    [Description("The GPS device tag")]
    [Required]
    [MaxLength(50)]
    public string GpsDeviceTag { get; init; } = string.Empty;

    [JsonPropertyName("isRental")]
    [Description("The is Rental flag")]
    public bool IsRental { get; init; }

    [JsonPropertyName("make")]
    [Description("The make of the equipment")]
    [Required]
    [MaxLength(50)]
    public string Make { get; init; } = string.Empty;

    [JsonPropertyName("model")]
    [Description("The model of the equipment")]
    [Required]
    [MaxLength(50)]
    public string Model { get; init; } = string.Empty;

    [JsonPropertyName("licensePlate")]
    [Description("The license plate")]
    [Required]
    [MaxLength(20)]
    public string LicensePlate { get; init; } = string.Empty;

    [JsonPropertyName("serialNumber")]
    [Description("The serial number or VIN")]
    [Required]
    [MaxLength(50)]
    public string SerialNumber { get; init; } = string.Empty;

    [JsonPropertyName("state")]
    [Description("The state")]
    [Required]
    [MaxLength(20)]
    public string State { get; init; } = string.Empty;

    [JsonPropertyName("vendorId")]
    [Description("The vendor Id")]
    public Guid? VendorId { get; init; }

    [JsonPropertyName("year")]
    [Description("The year of the equipment")]
    public int Year { get; init; }

    [JsonPropertyName("isActive")]
    [Description("The is Active flag")]
    [Required]
    public bool IsActive { get; init; }

    [JsonPropertyName("operatorPayClassId")]
    [Description("The Operator's pay class Id")]
    public Guid? OperatorPayClassId { get; init; }

    [JsonPropertyName("equipmentTypeId")]
    [Description("The equipment type Id")]
    public Guid? EquipmentTypeId { get; init; }

    [JsonPropertyName("fuelTypeId")]
    [Description("The Fuel Type ID")]
    public Guid? FuelTypeId { get; init; }

    [JsonPropertyName("fuelCapacity")]
    [Description("The Fuel Capacity")]
    public double FuelCapacity { get; init; }

    [JsonPropertyName("isFueler")]
    [Description("The IsFueler")]
    public bool IsFueler { get; init; }

    [JsonPropertyName("accountingCode")]
    [Description("The accounting code")]
    [MaxLength(100)]
    public string? AccountingCode { get; init; }

    [JsonPropertyName("accountingType")]
    [Description("The accounting type")]
    [MaxLength(100)]
    public string? AccountingType { get; init; }

    [JsonPropertyName("company")]
    [Description("The accounting company")]
    [MaxLength(100)]
    public string? Company { get; init; }

    [JsonPropertyName("costType")]
    [Description("The accounting cost type")]
    [MaxLength(100)]
    public string? CostType { get; init; }

    [JsonPropertyName("division")]
    [Description("The accounting division")]
    [MaxLength(100)]
    public string? Division { get; init; }

    [JsonPropertyName("generalLedgerAccount")]
    [Description("The accounting general ledger account")]
    [MaxLength(100)]
    public string? GeneralLedgerAccount { get; init; }

    [JsonPropertyName("meterType")]
    [Description("The accounting meter type")]
    [MaxLength(100)]
    public string? MeterType { get; init; }

    [JsonPropertyName("miscAccount")]
    [Description("The accounting miscaccount")]
    [MaxLength(100)]
    public string? MiscAccount { get; init; }

    [JsonPropertyName("usageCode")]
    [Description("The accounting usage code")]
    [MaxLength(100)]
    public string? UsageCode { get; init; }

    [JsonPropertyName("accountingTemplateName")]
    [Description("The accounting template name")]
    public string? AccountingTemplateName { get; init; }
}

public class UpdateEquipmentActionOutput
{
    [JsonPropertyName("success")]
    [Description("Whether the update was successful")]
    public bool Success { get; init; }
}
