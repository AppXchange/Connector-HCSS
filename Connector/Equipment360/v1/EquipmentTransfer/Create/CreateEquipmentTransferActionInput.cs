namespace Connector.Equipment360.v1.EquipmentTransfer.Create;

using Json.Schema.Generation;
using System;
using System.Text.Json.Serialization;

public class CreateEquipmentTransferActionInput
{
    [JsonPropertyName("equipmentId")]
    [Description("The ID of the equipment being transferred")]
    [Required]
    public required Guid EquipmentId { get; init; }

    [JsonPropertyName("currentBusinessUnitId")]
    [Description("The business unit currently associated with the equipment being transferred")]
    [Required]
    public required Guid CurrentBusinessUnitId { get; init; }

    [JsonPropertyName("newBusinessUnitId")]
    [Description("The business unit that the equipment should be moved to")]
    [Required]
    public required Guid NewBusinessUnitId { get; init; }
} 