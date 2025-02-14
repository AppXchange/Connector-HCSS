namespace Connector.Equipment360.v1.Equipment;

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
[Description("Represents an equipment record in the system")]
public class EquipmentDataObject
{
    [JsonPropertyName("id")]
    [Description("The guid of the equipment record")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("equipmentId")]
    [Description("The integer id of the equipment record")]
    public int EquipmentId { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The equipment's business unit guid")]
    public Guid BusinessUnitId { get; init; }

    [JsonPropertyName("code")]
    [Description("The equipment's code")]
    public string? Code { get; init; }

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
    [Description("If initialized, the most recent hour reading")]
    public int HourMeter { get; init; }

    [JsonPropertyName("hourMeterDate")]
    [Description("If initialized, the most recent hour reading date")]
    public DateTime? HourMeterDate { get; init; }

    [JsonPropertyName("odometer")]
    [Description("If initialized, the most recent odometer reading")]
    public int Odometer { get; init; }

    [JsonPropertyName("odometerDate")]
    [Description("If initialized, the most recent odometer reading date")]
    public DateTime? OdometerDate { get; init; }

    [JsonPropertyName("imageUrl")]
    [Description("The full URL of the equipment's image at Equipment360's document storage endpoint")]
    public string? ImageUrl { get; init; }

    [JsonPropertyName("region")]
    [Description("The equipment's current region")]
    public string? Region { get; init; }

    [JsonPropertyName("division")]
    [Description("The equipment's current division")]
    public string? Division { get; init; }

    [JsonPropertyName("weight")]
    [Description("The equipment's unloaded weight")]
    public double Weight { get; init; }

    [JsonPropertyName("length")]
    [Description("The equipment's length")]
    public double Length { get; init; }

    [JsonPropertyName("width")]
    [Description("The equipment's width")]
    public double Width { get; init; }

    [JsonPropertyName("height")]
    [Description("The equipment's height")]
    public double Height { get; init; }

    [JsonPropertyName("numberAxles")]
    [Description("Number of axles on the equipment")]
    public int NumberAxles { get; init; }

    [JsonPropertyName("tireSize")]
    [Description("Tire Size Front / Rear")]
    public string? TireSize { get; init; }

    [JsonPropertyName("status")]
    [Description("Status")]
    public string? Status { get; init; }

    [JsonPropertyName("enabled")]
    [Description("Enabled? (Y/N)")]
    public string? Enabled { get; init; }

    [JsonPropertyName("rentalFlag")]
    [Description("Rental/Owned")]
    public bool RentalFlag { get; init; }

    [JsonPropertyName("ratedPowerHP")]
    [Description("Rated Power (HP)")]
    public int RatedPowerHP { get; init; }

    [JsonPropertyName("ratedPowerKW")]
    [Description("Rated Power (KW)")]
    public int RatedPowerKW { get; init; }

    [JsonPropertyName("defaultFuel")]
    [Description("Default Fuel")]
    public string? DefaultFuel { get; init; }

    [JsonPropertyName("purchaseDate")]
    [Description("Purchase Date")]
    public DateTime PurchaseDate { get; init; }

    [JsonPropertyName("purchasePrice")]
    [Description("Purchase Value")]
    public double PurchasePrice { get; init; }

    [JsonPropertyName("jobCode")]
    [Description("Job code associated with the equipment")]
    public string? JobCode { get; init; }

    [JsonPropertyName("locationName")]
    [Description("Location associated with the equipment")]
    public string? LocationName { get; init; }

    [JsonPropertyName("onLoanBusinessUnitID")]
    [Description("The ID associated with the Business Unit that the equipment is currently on-loan to")]
    public Guid OnLoanBusinessUnitId { get; init; }
}