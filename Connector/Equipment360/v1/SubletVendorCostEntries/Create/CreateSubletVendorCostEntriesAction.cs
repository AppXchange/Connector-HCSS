namespace Connector.Equipment360.v1.SubletVendorCostEntries.Create;

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
[Description("Adds a detail to the sublet vendor cost entry")]
public class CreateSubletVendorCostEntriesAction : IStandardAction<CreateSubletVendorCostEntriesActionInput, SubletVendorCostEntriesDataObject>
{
    public CreateSubletVendorCostEntriesActionInput ActionInput { get; set; } = new()
    {
        SubletVendorCostEntryId = Guid.Empty,
        VendorId = Guid.Empty
    };
    public SubletVendorCostEntriesDataObject ActionOutput { get; set; } = new()
    {
        Id = Guid.Empty,
        VendorId = Guid.Empty
    };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateSubletVendorCostEntriesActionInput
{
    [JsonIgnore]
    [Description("Sublet Vendor Cost Entry Id for the detail being created")]
    [Required]
    public required Guid SubletVendorCostEntryId { get; init; }

    [JsonPropertyName("vendorId")]
    [Description("The vendor id for the cost entry")]
    [Required]
    public required Guid VendorId { get; init; }

    [JsonPropertyName("amount")]
    [Description("The value of the amount")]
    public double? Amount { get; init; }

    [JsonPropertyName("estimatedCost")]
    [Description("The value of the estimated cost")]
    public double? EstimatedCost { get; init; }

    [JsonPropertyName("description")]
    [Description("The description of the cost entry")]
    public string? Description { get; init; }
}
