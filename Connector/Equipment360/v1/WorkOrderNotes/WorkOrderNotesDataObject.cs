namespace Connector.Equipment360.v1.WorkOrderNotes;

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
[Description("Represents a work order note in Equipment360")]
public class WorkOrderNotesDataObject
{
    [JsonPropertyName("id")]
    [Description("The note id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("createdBy")]
    [Description("The user who created the note")]
    public string? CreatedBy { get; init; }

    [JsonPropertyName("createdDate")]
    [Description("The date on which the note was created")]
    public DateTime CreatedDate { get; init; }

    [JsonPropertyName("modifiedBy")]
    [Description("The last user who modified the note")]
    public string? ModifiedBy { get; init; }

    [JsonPropertyName("modifiedDate")]
    [Description("The most recent date on which the note was modified")]
    public DateTime? ModifiedDate { get; init; }

    [JsonPropertyName("note")]
    [Description("The note")]
    public string? Note { get; init; }
}