namespace Connector.Safety.v1.IncidentFormTypes;

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
[PrimaryKey("formLinkId", nameof(FormLinkId))]
[Description("Represents an incident form type in Safety")]
public class IncidentFormTypesDataObject
{
    [JsonPropertyName("formLinkId")]
    [Description("The form link id")]
    [Required]
    public required Guid FormLinkId { get; init; }

    [JsonPropertyName("name")]
    [Description("The form type name")]
    [Required]
    public required string Name { get; init; }

    [JsonPropertyName("businessUnitID")]
    [Description("The businessUnitId that form type is related to")]
    [Required]
    public required Guid BusinessUnitId { get; init; }
}