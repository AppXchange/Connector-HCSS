namespace Connector.HeavyBidPreConstruction.v1.Schema;

using Json.Schema.Generation;
using System;
using System.Collections.Generic;
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
[Description("Schema definition for HeavyBid Pre-Construction")]
public class SchemaDataObject
{
    [JsonPropertyName("id")]
    [Description("The unique Id of the schema")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("schemaName")]
    [Description("The name of the type of schema (e.g. 'projects')")]
    [Required]
    public required string SchemaName { get; init; }

    [JsonPropertyName("lastModified")]
    [Description("The last modified date of the Schema")]
    [Required]
    public required DateTime LastModified { get; init; }

    [JsonPropertyName("dateCreated")]
    [Description("The created date of the schema")]
    public DateTime DateCreated { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit Id that this schema belongs to")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("fields")]
    [Description("An object containing the fields contained in the schema")]
    [Required]
    public required Dictionary<string, object> Fields { get; init; }

    [JsonPropertyName("sections")]
    [Description("An object containing the sections contained in the schema")]
    [Required]
    public required Dictionary<string, object> Sections { get; init; }

    [JsonPropertyName("orderedSections")]
    [Description("An array of section Ids that specifies the order in which sections appear in the UI")]
    [Required]
    public required string[] OrderedSections { get; init; }

    [JsonPropertyName("dataSyncPreference")]
    [Description("The data sync preference for this schema")]
    public string? DataSyncPreference { get; init; }
}