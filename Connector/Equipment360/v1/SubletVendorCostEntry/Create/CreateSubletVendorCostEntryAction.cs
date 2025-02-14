namespace Connector.Equipment360.v1.SubletVendorCostEntry.Create;

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
[Description("Creates a new sublet vendor cost entry")]
public class CreateSubletVendorCostEntryAction : IStandardAction<CreateSubletVendorCostEntryActionInput, SubletVendorCostEntryDataObject>
{
    public CreateSubletVendorCostEntryActionInput ActionInput { get; set; } = new()
    {
        WorkOrderNumber = 0
    };
    public SubletVendorCostEntryDataObject ActionOutput { get; set; } = new()
    {
        Id = Guid.Empty,
        WorkOrderNumber = 0
    };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateSubletVendorCostEntryActionInput
{
    [JsonPropertyName("workOrderNumber")]
    [Description("The work order number")]
    [Required]
    public required int WorkOrderNumber { get; init; }

    [JsonPropertyName("entryDate")]
    [Description("The effective date of the sublet vendor cost entry")]
    public DateTime? EntryDate { get; init; }

    [JsonPropertyName("amount")]
    [Description("The value of the amount")]
    public double? Amount { get; init; }

    [JsonPropertyName("estimatedCost")]
    [Description("The value of the estimated cost")]
    public double? EstimatedCost { get; init; }

    [JsonPropertyName("referenceNumber")]
    [Description("The reference number")]
    public string? ReferenceNumber { get; init; }

    [JsonPropertyName("description")]
    [Description("The description of the cost entry")]
    public string? Description { get; init; }
}
