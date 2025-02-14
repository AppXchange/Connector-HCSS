namespace Connector.Equipment360.v1.AllEquipment;

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
[Description("Represents equipment in the system")]
public class AllEquipmentDataObject
{
    [JsonPropertyName("id")]
    [Description("The equipment's unique identifier")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("equipmentId")]
    [Description("The equipment's numeric identifier")]
    public int EquipmentId { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The equipment's business unit guid")]
    public Guid BusinessUnitId { get; init; }

    [JsonPropertyName("code")]
    [Description("The equipment's code")]
    public string Code { get; init; } = string.Empty;

    [JsonPropertyName("equipmentType")]
    [Description("The equipment's type name")]
    public string? EquipmentType { get; init; }

    [JsonPropertyName("description")]
    [Description("A description of the equipment")]
    public string? Description { get; init; }

    [JsonPropertyName("accountingCode")]
    [Description("Equipment Accounting Code")]
    public string? AccountingCode { get; init; }

    [JsonPropertyName("make")]
    [Description("The equipment's make")]
    public string? Make { get; init; }

    [JsonPropertyName("model")]
    [Description("The equipment's model")]
    public string? Model { get; init; }

    [JsonPropertyName("year")]
    [Description("The equipment's year")]
    public int? Year { get; init; }

    [JsonPropertyName("vin")]
    [Description("The equipment's VIN")]
    public string? Vin { get; init; }

    [JsonPropertyName("serialNo")]
    [Description("The equipment's serial number")]
    public string? SerialNo { get; init; }

    [JsonPropertyName("hourMeter")]
    [Description("The most recent hour reading")]
    public int HourMeter { get; init; }

    [JsonPropertyName("hourMeterDate")]
    [Description("The most recent hour reading date")]
    public DateTime? HourMeterDate { get; init; }

    [JsonPropertyName("odometer")]
    [Description("The most recent odometer reading")]
    public int Odometer { get; init; }

    [JsonPropertyName("status")]
    [Description("Equipment status")]
    public string? Status { get; init; }

    [JsonPropertyName("enabled")]
    [Description("Enabled? (Y/N)")]
    public string? Enabled { get; init; }

    [JsonPropertyName("purchaseDate")]
    [Description("Purchase Date")]
    public DateTime PurchaseDate { get; init; }

    [JsonPropertyName("purchasePrice")]
    [Description("Purchase Value")]
    public double PurchasePrice { get; init; }

    [JsonPropertyName("jobCode")]
    [Description("Job code associated with the equipment")]
    public string? JobCode { get; init; }
}