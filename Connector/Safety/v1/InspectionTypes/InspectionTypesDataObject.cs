namespace Connector.Safety.v1.InspectionTypes;

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
[Description("Represents an inspection type in Safety")]
public class InspectionTypesDataObject
{
    [JsonPropertyName("id")]
    [Description("The inspection type id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    [Description("The inspection type name")]
    [Required]
    public required string Name { get; init; }

    [JsonPropertyName("isActive")]
    [Description("If the inspection type is active")]
    public bool IsActive { get; init; }

    [JsonPropertyName("businessUnitID")]
    [Description("The businessUnitId that inspection type is related to")]
    public Guid? BusinessUnitID { get; init; }

    [JsonPropertyName("isEquipmentType")]
    [Description("If the inspection type is an equipment type")]
    public bool IsEquipmentType { get; init; }

    [JsonPropertyName("createdByID")]
    [Description("The id of who created the inspection type")]
    public Guid? CreatedByID { get; init; }

    [JsonPropertyName("modifiedByID")] 
    [Description("Last id to modified the inspection type")]
    public Guid? ModifiedByID { get; init; }

    [JsonPropertyName("createdDate")]
    [Description("The date that the inspection type was created")]
    public DateTime CreatedDate { get; init; }
}