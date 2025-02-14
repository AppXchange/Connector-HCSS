namespace Connector.Equipment360.v1.PartInventory.Create;

using Connector.Client.Equipment360;
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
[Description("Sets on hand quantity for part at part location")]
public class CreatePartInventoryAction : IStandardAction<CreatePartInventoryActionInput, Equipment360PaginatedResponse<PartInventoryDataObject>>
{
    public CreatePartInventoryActionInput ActionInput { get; set; } = new()
    {
        PartNum = string.Empty,
        PartLocationCode = string.Empty,
        OnHandQty = 0,
        UnitPrice = 0
    };
    public Equipment360PaginatedResponse<PartInventoryDataObject> ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreatePartInventoryActionInput
{
    [JsonPropertyName("partNum")]
    [Description("The part number")]
    [Required]
    public required string PartNum { get; init; }

    [JsonPropertyName("partLocationCode")]
    [Description("The part location code")]
    [Required]
    public required string PartLocationCode { get; init; }

    [JsonPropertyName("onHandQty")]
    [Description("The on hand quantity for the part at part location")]
    [Required]
    public required int OnHandQty { get; init; }

    [JsonPropertyName("unitPrice")]
    [Description("The unit price of the item")]
    [Required]
    public required double UnitPrice { get; init; }

    [JsonPropertyName("note")]
    [Description("The note for inventory adjustment")]
    public string? Note { get; init; }
}
