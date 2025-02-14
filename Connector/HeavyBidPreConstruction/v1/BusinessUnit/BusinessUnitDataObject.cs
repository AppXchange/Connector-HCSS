namespace Connector.HeavyBidPreConstruction.v1.BusinessUnit;

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
[Description("A business unit in HeavyBid Pre-Construction")]
public class BusinessUnitDataObject
{
    [JsonPropertyName("id")]
    [Description("The unique identifier for the business unit")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("code")]
    [Description("The business unit code")]
    public string? Code { get; init; }

    [JsonPropertyName("description")]
    [Description("Description of the business unit")]
    public string? Description { get; init; }

    [JsonPropertyName("dateCreated")]
    [Description("The date and time when the business unit was created")]
    public DateTime DateCreated { get; init; }
}