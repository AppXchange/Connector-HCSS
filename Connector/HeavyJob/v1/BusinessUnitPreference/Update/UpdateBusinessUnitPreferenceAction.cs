namespace Connector.HeavyJob.v1.BusinessUnitPreference.Update;

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
[Description("Updates preferences for a business unit in HeavyJob")]
public class UpdateBusinessUnitPreferenceAction : IStandardAction<UpdateBusinessUnitPreferenceActionInput, UpdateBusinessUnitPreferenceActionOutput>
{
    public UpdateBusinessUnitPreferenceActionInput ActionInput { get; set; } = new()
    {
        BusinessUnitId = Guid.Empty
    };
    public UpdateBusinessUnitPreferenceActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class UpdateBusinessUnitPreferenceActionInput
{
    [JsonPropertyName("businessUnitId")]
    [Description("ID of the business unit that the preferences belong to")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("defaultLaborRateSetId")]
    [Description("ID of the default labor rate set to apply to a new job")]
    public Guid? DefaultLaborRateSetId { get; init; }

    [JsonPropertyName("defaultEquipmentRateSetId")]
    [Description("ID of the default equipment rate set to apply to a new job")]
    public Guid? DefaultEquipmentRateSetId { get; init; }

    [JsonPropertyName("startOfPayWeek")]
    [Description("The day of the week that the pay week starts")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DayOfWeek StartOfPayWeek { get; init; }
}

public class UpdateBusinessUnitPreferenceActionOutput : BusinessUnitPreferenceDataObject
{
}
