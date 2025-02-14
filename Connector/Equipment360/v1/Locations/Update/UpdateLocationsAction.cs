namespace Connector.Equipment360.v1.Locations.Update;

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
[Description("Update an existing location")]
public class UpdateLocationsAction : IStandardAction<UpdateLocationsActionInput, LocationsDataObject>
{
    public UpdateLocationsActionInput ActionInput { get; set; } = new()
    {
        Id = Guid.Empty,
        Code = string.Empty
    };
    public LocationsDataObject ActionOutput { get; set; } = new() 
    { 
        Id = Guid.Empty,
        BusinessUnitId = Guid.Empty,
        Code = string.Empty
    };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class UpdateLocationsActionInput
{
    [JsonPropertyName("id")]
    [Description("The location guid")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("code")]
    [Description("The code")]
    public string? Code { get; init; }

    [JsonPropertyName("description")]
    [Description("An optional description")]
    public string? Description { get; init; }

    [JsonPropertyName("enabled")]
    [Description("Enabled? (Y/N)")]
    public string? Enabled { get; init; }

    [JsonPropertyName("address")]
    [Description("A representation of an Address object returned by the API")]
    public AddressObject? Address { get; init; }
}
