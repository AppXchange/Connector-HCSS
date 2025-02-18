namespace Connector.Setups.v1.PayClass;

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
[Description("Represents a pay class in HCSS")]
public class PayClassDataObject
{
    [JsonPropertyName("code")]
    [Description("Gets the pay class code")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("businessUnitCode")]
    [Description("Gets the business unit")]
    [Required]
    public required string BusinessUnitCode { get; init; }

    [JsonPropertyName("id")]
    [Description("The id of the pay class")]
    public Guid? Id { get; init; }

    [JsonPropertyName("description")]
    [Description("The description of the pay class")]
    public string? Description { get; init; }

    [JsonPropertyName("unionCode")]
    [Description("The \"UnionCode\" accounting field")]
    public string? UnionCode { get; init; }

    [JsonPropertyName("accountingCode")]
    [Description("The accounting code")]
    public string? AccountingCode { get; init; }

    [JsonPropertyName("category")]
    [Description("The \"Category\" accounting field")]
    public string? Category { get; init; }

    [JsonPropertyName("trade")]
    [Description("The \"Trade\" accounting field")]
    public string? Trade { get; init; }

    [JsonPropertyName("type")]
    [Description("The \"Type\" accounting field")]
    public string? Type { get; init; }

    [JsonPropertyName("unionClass")]
    [Description("The \"UnionClass\" accounting field")]
    public string? UnionClass { get; init; }

    [JsonPropertyName("unionLocal")]
    [Description("The \"UnionLocal\" accounting field")]
    public string? UnionLocal { get; init; }

    [JsonPropertyName("craft")]
    [Description("The \"Craft\" accounting field")]
    public string? Craft { get; init; }

    [JsonPropertyName("heavyBidCode")]
    [Description("The HeavyBid code")]
    public string? HeavyBidCode { get; init; }

    [JsonPropertyName("isActive")]
    [Description("is active flag")]
    public bool? IsActive { get; init; }

    [JsonPropertyName("accountingTemplateName")]
    [Description("The accounting template name")]
    public string? AccountingTemplateName { get; init; }
}