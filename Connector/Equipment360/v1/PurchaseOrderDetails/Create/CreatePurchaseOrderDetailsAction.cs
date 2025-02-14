namespace Connector.Equipment360.v1.PurchaseOrderDetails.Create;

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
[Description("Adds a detail to the purchase order")]
public class CreatePurchaseOrderDetailsAction : IStandardAction<CreatePurchaseOrderDetailsActionInput, PurchaseOrderDetailsDataObject>
{
    public CreatePurchaseOrderDetailsActionInput ActionInput { get; set; } = new()
    {
        PurchaseOrderId = Guid.Empty,
        Quantity = 0,
        UnitPrice = 0
    };
    public PurchaseOrderDetailsDataObject ActionOutput { get; set; } = new()
    {
        Id = Guid.Empty,
        PurchaseOrderId = Guid.Empty,
        TotalCost = 0,
        Type = "details",
        Quantity = 0,
        UnitPrice = 0
    };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreatePurchaseOrderDetailsActionInput
{
    [JsonIgnore]
    [Description("Purchase Order Id for the detail being created")]
    [Required]
    public required Guid PurchaseOrderId { get; init; }

    [JsonPropertyName("partId")]
    [Description("The part id (not required if there's a charge item)")]
    public Guid? PartId { get; init; }

    [JsonPropertyName("vendorPartNumber")]
    [Description("Vendor part number")]
    public string? VendorPartNumber { get; init; }

    [JsonPropertyName("purchaseUnitOfMeasureId")]
    [Description("The purchase unit of measure id (not required if there's a charge item)")]
    public Guid? PurchaseUnitOfMeasureId { get; init; }

    [JsonPropertyName("partLocationId")]
    [Description("The inventory location id (to pre-populate inventory location on the invoice)")]
    public Guid? PartLocationId { get; init; }

    [JsonPropertyName("quantity")]
    [Description("The quantity of the item")]
    [Required]
    public required int Quantity { get; init; }

    [JsonPropertyName("unitPrice")]
    [Description("The unit price of the item")]
    [Required]
    public required double UnitPrice { get; init; }

    [JsonPropertyName("isTaxable")]
    [Description("Whether the item is taxable")]
    public bool? IsTaxable { get; init; }

    [JsonPropertyName("chargeItem")]
    [Description("A miscellaneous charge item (there will be no partId when this is on the detail)")]
    public string? ChargeItem { get; init; }
}
