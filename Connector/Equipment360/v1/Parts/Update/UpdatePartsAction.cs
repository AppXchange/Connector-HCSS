namespace Connector.Equipment360.v1.Parts.Update;

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
[Description("Update an existing part")]
public class UpdatePartsAction : IStandardAction<UpdatePartsActionInput, PartsDataObject>
{
    public UpdatePartsActionInput ActionInput { get; set; } = new()
    {
        Id = Guid.Empty,
        PartNumber = string.Empty,
        StockUnitOfMeasure = "EA",
        PurchaseUnitOfMeasure = "EA"
    };
    public PartsDataObject ActionOutput { get; set; } = new()
    {
        Id = Guid.Empty,
        PartNumber = string.Empty,
        StockUnitOfMeasure = "EA",
        PurchaseUnitOfMeasure = "EA"
    };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class UpdatePartsActionInput
{
    [JsonIgnore]
    [Description("The Id of the part to update")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("partNumber")]
    [Description("The Part's number")]
    public string? PartNumber { get; init; }

    [JsonPropertyName("oemPartNumber")]
    [Description("The original equipment manufacturer part number")]
    public string? OemPartNumber { get; init; }

    [JsonPropertyName("description")]
    [Description("The description of the Part")]
    public string? Description { get; init; }

    [JsonPropertyName("name")]
    [Description("The name of the part")]
    public string? Name { get; init; }

    [JsonPropertyName("barCode")]
    [Description("The part's bar code")]
    public string? BarCode { get; init; }

    [JsonPropertyName("category")]
    [Description("The part category")]
    public string? Category { get; init; }

    [JsonPropertyName("categoryId")]
    [Description("The id of the part category")]
    public Guid? CategoryId { get; init; }

    [JsonPropertyName("stockUnitOfMeasure")]
    [Description("The Unit of Measure for this part (e.g. \"EA\")")]
    public string? StockUnitOfMeasure { get; init; }

    [JsonPropertyName("stockUnitOfMeasureId")]
    [Description("The stock Unit of Measure's ID. (e.g. \"EA\")")]
    public Guid? StockUnitOfMeasureId { get; init; }

    [JsonPropertyName("purchaseUnitOfMeasure")]
    [Description("The Unit of Measure used by default for purchases of this part. (e.g. \"EA\")")]
    public string? PurchaseUnitOfMeasure { get; init; }

    [JsonPropertyName("purchaseUnitOfMeasureId")]
    [Description("The purchase Unit of Measure's ID. (e.g. \"EA\")")]
    public Guid? PurchaseUnitOfMeasureId { get; init; }

    [JsonPropertyName("preferredVendor")]
    [Description("The Preferred Vendor for this part")]
    public string? PreferredVendor { get; init; }

    [JsonPropertyName("preferredVendorId")]
    [Description("The id of the Preferred Vendor for this part")]
    public int? PreferredVendorId { get; init; }
}
