namespace Connector.HeavyJob.v1.Equipment;

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
[PrimaryKey("equipmentId", nameof(EquipmentId))]
[Description("Equipment in HeavyJob")]
public class EquipmentDataObject
{
    [JsonPropertyName("equipmentId")]
    [Description("The equipment Id")]
    [Required]
    public Guid EquipmentId { get; init; }

    [JsonPropertyName("legacyId")]
    [Description("The legacy system Id. Primarily for internal HJ usage")]
    public Guid LegacyId { get; init; }

    [JsonPropertyName("equipmentCode")]
    [Description("The equipment code")]
    public string? EquipmentCode { get; init; }

    [JsonPropertyName("equipmentDescription")]
    [Description("The equipment description")]
    public string? EquipmentDescription { get; init; }

    [JsonPropertyName("gpsDeviceTag")]
    [Description("The GPS device tag")]
    public string? GpsDeviceTag { get; init; }

    [JsonPropertyName("isRental")]
    [Description("The is Rental flag")]
    public bool IsRental { get; init; }

    [JsonPropertyName("make")]
    [Description("The make of the equipment")]
    public string? Make { get; init; }

    [JsonPropertyName("model")]
    [Description("The model of the equipment")]
    public string? Model { get; init; }

    [JsonPropertyName("licensePlate")]
    [Description("The license plate")]
    public string? LicensePlate { get; init; }

    [JsonPropertyName("serialNumber")]
    [Description("The serial number or VIN")]
    public string? SerialNumber { get; init; }

    [JsonPropertyName("state")]
    [Description("The state")]
    public string? State { get; init; }

    [JsonPropertyName("vendorId")]
    [Description("The vendor Id")]
    public Guid? VendorId { get; init; }

    [JsonPropertyName("year")]
    [Description("The year of the equipment")]
    public int Year { get; init; }

    [JsonPropertyName("isActive")]
    [Description("The is Active flag")]
    public bool? IsActive { get; init; }

    [JsonPropertyName("operatorPayClassId")]
    [Description("The Operator's pay class Id")]
    public Guid? OperatorPayClassId { get; init; }

    [JsonPropertyName("operatorPayClassCode")]
    [Description("The Operator's pay class code")]
    public string? OperatorPayClassCode { get; init; }

    [JsonPropertyName("operatorPayClassDescription")]
    [Description("The Operator's pay class description")]
    public string? OperatorPayClassDescription { get; init; }

    [JsonPropertyName("equipmentTypeId")]
    [Description("The equipment type Id")]
    public Guid? EquipmentTypeId { get; init; }

    [JsonPropertyName("equipmentTypeCode")]
    [Description("The equipment type code")]
    public string? EquipmentTypeCode { get; init; }

    [JsonPropertyName("equipmentTypeDescription")]
    [Description("The equipment type description")]
    public string? EquipmentTypeDescription { get; init; }

    [JsonPropertyName("fuelTypeId")]
    [Description("The Fuel Type ID")]
    public Guid? FuelTypeId { get; init; }

    [JsonPropertyName("fuelTypeCode")]
    [Description("The Fuel Type code")]
    public string? FuelTypeCode { get; init; }

    [JsonPropertyName("fuelTypeDescription")]
    [Description("The Fuel Type Description")]
    public string? FuelTypeDescription { get; init; }

    [JsonPropertyName("fuelCapacity")]
    [Description("The Fuel Capacity")]
    public double FuelCapacity { get; init; }

    [JsonPropertyName("isFueler")]
    [Description("The IsFueler")]
    public bool IsFueler { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Whether the equipment is deleted")]
    public bool IsDeleted { get; init; }

    [JsonPropertyName("accountingCode")]
    [Description("Accounting values object")]
    public AccountingValue AccountingCode { get; init; } = new();

    [JsonPropertyName("accountingType")]
    [Description("Accounting values object")]
    public AccountingValue AccountingType { get; init; } = new();

    [JsonPropertyName("company")]
    [Description("Accounting values object")]
    public AccountingValue Company { get; init; } = new();

    [JsonPropertyName("costType")]
    [Description("Accounting values object")]
    public AccountingValue CostType { get; init; } = new();

    [JsonPropertyName("division")]
    [Description("Accounting values object")]
    public AccountingValue Division { get; init; } = new();

    [JsonPropertyName("generalLedgerAccount")]
    [Description("Accounting values object")]
    public AccountingValue GeneralLedgerAccount { get; init; } = new();

    [JsonPropertyName("meterType")]
    [Description("Accounting values object")]
    public AccountingValue MeterType { get; init; } = new();

    [JsonPropertyName("miscAccount")]
    [Description("Accounting values object")]
    public AccountingValue MiscAccount { get; init; } = new();

    [JsonPropertyName("usageCode")]
    [Description("Accounting values object")]
    public AccountingValue UsageCode { get; init; } = new();
}

public class AccountingValue
{
    [JsonPropertyName("value")]
    [Description("The value")]
    public string? Value { get; init; }

    [JsonPropertyName("description")]
    [Description("The custom description of the accounting value")]
    public string? Description { get; init; }

    [JsonPropertyName("code")]
    [Description("The code")]
    public string? Code { get; init; }

    [JsonPropertyName("accountingValueId")]
    [Description("The Id for the accounting value")]
    public Guid AccountingValueId { get; init; }

    [JsonPropertyName("parentId")]
    [Description("The Id of the parent entity")]
    public Guid? ParentId { get; init; }

    [JsonPropertyName("dataType")]
    [Description("The data type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DataType DataType { get; init; }
}

public enum DataType
{
    Unknown,
    String,
    Decimal,
    DateTime,
    Boolean,
    Integer
}