namespace Connector.Equipment360.v1.EquipmentTransfer;

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
[Description("Represents an equipment transfer record between business units")]
public class EquipmentTransferDataObject
{
    [JsonPropertyName("id")]
    [Description("The unique identifier of the transfer")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("equipmentId")]
    [Description("The ID of the equipment being transferred")]
    public int EquipmentId { get; init; }

    [JsonPropertyName("equipmentName")]
    [Description("The name/code of the equipment")]
    public string? EquipmentName { get; init; }

    [JsonPropertyName("oldBusinessUnit")]
    [Description("The business unit the equipment was transferred from")]
    public string? OldBusinessUnit { get; init; }

    [JsonPropertyName("newBusinessUnit")]
    [Description("The business unit the equipment was transferred to")]
    public string? NewBusinessUnit { get; init; }

    [JsonPropertyName("transferDateTime")]
    [Description("The date and time when the transfer occurred")]
    public DateTime TransferDateTime { get; init; }
}