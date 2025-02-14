namespace Connector.HeavyJob.v1.BusinessUnitPreference;

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
[PrimaryKey("businessUnitId", nameof(BusinessUnitId))]
[Description("Represents business unit preferences in HeavyJob")]
public class BusinessUnitPreferenceDataObject
{
    [JsonIgnore]
    public Guid BusinessUnitId { get; init; }

    [JsonPropertyName("defaultLaborRateSetId")]
    [Description("ID of the default labor rate set to apply to a new job")]
    public Guid? DefaultLaborRateSetId { get; init; }

    [JsonPropertyName("defaultPayClassId")]
    [Description("ID of the default pay class to apply to a new employee")]
    public Guid? DefaultPayClassId { get; init; }

    [JsonPropertyName("defaultEquipmentRateSetId")]
    [Description("ID of the default equipment rate set to apply to a new job")]
    public Guid? DefaultEquipmentRateSetId { get; init; }

    [JsonPropertyName("startOfPayWeek")]
    [Description("The day of the week that the pay week starts")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DayOfWeek StartOfPayWeek { get; init; }

    [JsonPropertyName("truckingCostTypeId")]
    [Description("The custom cost type id that the trucking cost maps to")]
    public Guid? TruckingCostTypeId { get; init; }
}

public enum DayOfWeek
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday
}