namespace Connector.Equipment360.v1.UnitOfMeasure;

using Json.Schema.Generation;
using System;
using System.Collections.Generic;
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
[Description("Represents a unit of measure in Equipment360")]
public class UnitOfMeasureDataObject
{
    [JsonPropertyName("id")]
    [Description("The Unit of Measure id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("code")]
    [Description("The Unit of Measure's Code (i.e. \"EA\")")]
    public string? Code { get; init; }

    [JsonPropertyName("description")]
    [Description("The description of the Unit of Measure (i.e. \"Each\")")]
    public string? Description { get; init; }

    [JsonPropertyName("isPartDefault")]
    [Description("Indicates whether this UoM should be applied by default")]
    public bool IsPartDefault { get; init; }

    [JsonPropertyName("isFluidDefault")]
    [Description("Indicates whether this UoM should be applied by default for fluids")]
    public bool IsFluidDefault { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Indicates whether the record is soft deleted")]
    public bool IsDeleted { get; init; }

    [JsonPropertyName("purchaseUnitsOfMeasure")]
    [Description("List of associated purchase units of measure")]
    public IEnumerable<ApiPurchaseUnitOfMeasureRead>? PurchaseUnitsOfMeasure { get; init; }
}

public class ApiPurchaseUnitOfMeasureRead
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("code")]
    public string? Code { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("stockQuantity")]
    public double? StockQuantity { get; init; }

    [JsonPropertyName("isPartDefault")]
    public bool IsPartDefault { get; init; }

    [JsonPropertyName("isFluidDefault")]
    public bool IsFluidDefault { get; init; }

    [JsonPropertyName("isDeleted")]
    public bool IsDeleted { get; init; }
}