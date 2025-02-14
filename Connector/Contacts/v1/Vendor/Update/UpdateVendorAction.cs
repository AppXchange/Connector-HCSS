namespace Connector.Contacts.v1.Vendor.Update;

using Json.Schema.Generation;
using System;
using System.ComponentModel.DataAnnotations;
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
[Description("Updates an existing vendor")]
public class UpdateVendorAction : IStandardAction<UpdateVendorActionInput, UpdateVendorActionOutput>
{
    public UpdateVendorActionInput ActionInput { get; set; } = new() { Id = Guid.Empty, Code = string.Empty };
    public UpdateVendorActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class UpdateVendorActionInput
{
    [JsonPropertyName("id")]
    [Description("The vendor's unique identifier")]
    [System.ComponentModel.DataAnnotations.Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("code")]
    [Description("The vendor's unique code")]
    [System.ComponentModel.DataAnnotations.Required]
    [System.ComponentModel.DataAnnotations.MinLength(1)]
    public required string Code { get; init; }

    [JsonPropertyName("name")]
    [Description("The vendor's name")]
    public string? Name { get; init; }

    [JsonPropertyName("typeId")]
    [Description("The vendor type unique identifier")]
    public Guid? TypeId { get; init; }

    [JsonPropertyName("regionId")]
    [Description("The unique identifier of the region the vendor operates in")]
    public Guid? RegionId { get; init; }

    [JsonPropertyName("communicationMethod")]
    [Description("The vendor's preferred communication method")]
    public string? CommunicationMethod { get; init; }

    [JsonPropertyName("webAddress")]
    [Description("The vendor's website address")]
    public string? WebAddress { get; init; }

    [JsonPropertyName("isBonded")]
    [Description("A flag indicating if this vendor is bonded")]
    public bool IsBonded { get; init; }

    [JsonPropertyName("bondRate")]
    [Description("The rate at which this vendor is bonded")]
    public double BondRate { get; init; }

    [JsonPropertyName("note")]
    [Description("Notes about this vendor")]
    public string? Note { get; init; }

    [JsonPropertyName("isUnion")]
    [Description("A flag indicating if the vendor is in a union")]
    public bool IsUnion { get; init; }

    [JsonPropertyName("experienceModificationRating")]
    [Description("The vendor's experience modification rating")]
    [Range(0, 2)]
    public double? ExperienceModificationRating { get; init; }

    [JsonPropertyName("rating")]
    [Description("The rating this vendor has been given")]
    [Range(0, 5)]
    public int? Rating { get; init; }

    [JsonPropertyName("accountingCode")]
    [Description("The vendor's accounting code")]
    public string? AccountingCode { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit's guid")]
    public Guid? BusinessUnitId { get; init; }
}

public class UpdateVendorActionOutput
{
    [JsonPropertyName("id")]
    [Description("The updated vendor's unique identifier")]
    public Guid Id { get; init; }
}
