namespace Connector.Setups.v1.RateSetEquipment.Update;

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
[Description("Updates an existing equipment rate set in HCSS")]
public class UpdateRateSetEquipmentAction : IStandardAction<UpdateRateSetEquipmentActionInput, UpdateRateSetEquipmentActionOutput>
{
    public UpdateRateSetEquipmentActionInput ActionInput { get; set; } = new()
    {
        Id = Guid.Empty,
        BusinessUnitCode = string.Empty,
        RateSetGroupCode = string.Empty
    };
    public UpdateRateSetEquipmentActionOutput ActionOutput { get; set; } = new()
    {
        BusinessUnitCode = string.Empty,
        RateSetGroupCode = string.Empty
    };
    public StandardActionFailure ActionFailure { get; set; } = new();
    public bool CreateRtap => true;
}

public class UpdateRateSetEquipmentActionInput
{
    [JsonPropertyName("id")]
    [Description("The equipment rate set guid")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("businessUnitCode")]
    [Description("Gets the business unit code")]
    [Required]
    public required string BusinessUnitCode { get; init; }

    [JsonPropertyName("equipmentRates")]
    [Description("The underlying EquipmentRates")]
    public EquipmentRate[]? EquipmentRates { get; init; }

    [JsonPropertyName("effectiveDate")]
    [Description("The DateTime from which these equipment rates become effective")]
    public DateTime? EffectiveDate { get; init; }

    [JsonPropertyName("rateSetGroupCode")]
    [Description("Gets the rate set group code, used to identify this particular rate set")]
    [Required]
    public required string RateSetGroupCode { get; init; }

    [JsonPropertyName("rateSetGroupDescription")]
    [Description("Gets the rate set group description")]
    public string? RateSetGroupDescription { get; init; }
}

public class UpdateRateSetEquipmentActionOutput : RateSetEquipmentDataObject
{
}
