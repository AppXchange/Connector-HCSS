namespace Connector.Equipment360.v1.PartCostEntries.Create;

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
[Description("Add a detail to the part cost entry")]
public class CreatePartCostEntriesAction : IStandardAction<CreatePartCostEntriesActionInput, PartCostEntriesDataObject>
{
    public CreatePartCostEntriesActionInput ActionInput { get; set; } = new()
    {
        PartCostEntryId = Guid.Empty,
        ItemCodeId = 0,
        Amount = 0,
        EstimatedCost = 0
    };
    public PartCostEntriesDataObject ActionOutput { get; set; } = new()
    {
        Id = Guid.Empty,
        ItemCodeId = 0,
        Amount = 0,
        EstimatedCost = 0
    };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreatePartCostEntriesActionInput
{
    [JsonIgnore]
    [Description("Part Cost Entry Id for the detail being created")]
    [Required]
    public required Guid PartCostEntryId { get; init; }

    [JsonPropertyName("vendorId")]
    [Description("The vendor id for the cost entry")]
    public Guid? VendorId { get; init; }

    [JsonPropertyName("vendorCode")]
    [Description("The vendor code for the cost entry")]
    public string? VendorCode { get; init; }

    [JsonPropertyName("partId")]
    [Description("The part id for the cost entry")]
    public Guid? PartId { get; init; }

    [JsonPropertyName("partNum")]
    [Description("The part num for the cost entry")]
    public string? PartNum { get; init; }

    [JsonPropertyName("itemCodeId")]
    [Description("The value of the item code id")]
    [Required]
    public required int ItemCodeId { get; init; }

    [JsonPropertyName("amount")]
    [Description("The value of the amount")]
    [Required]
    public required double Amount { get; init; }

    [JsonPropertyName("estimatedCost")]
    [Description("The value of the estimated cost")]
    [Required]
    public required double EstimatedCost { get; init; }

    [JsonPropertyName("description")]
    [Description("The description of the cost entry")]
    public string? Description { get; init; }
}
