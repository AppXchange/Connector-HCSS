namespace Connector.HeavyJob.v1.MaterialPurchaseOrderDetails.Create;

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
[Description("Creates a material purchase order detail")]
public class CreateMaterialPurchaseOrderDetailsAction : IStandardAction<CreateMaterialPurchaseOrderDetailsActionInput, CreateMaterialPurchaseOrderDetailsActionOutput>
{
    public CreateMaterialPurchaseOrderDetailsActionInput ActionInput { get; set; } = new() { 
        PurchaseOrderId = Guid.Empty,
        JobMaterialId = Guid.Empty,
        Sequence = 0,
        Quantity = 0,
        UnitCost = 0,
        UnitOfMeasure = string.Empty
    };
    public CreateMaterialPurchaseOrderDetailsActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateMaterialPurchaseOrderDetailsActionInput
{
    [JsonPropertyName("purchaseOrderId")]
    [Description("The purchase order id")]
    [Required]
    public required Guid PurchaseOrderId { get; init; }

    [JsonPropertyName("jobMaterialId")]
    [Description("The job material Id")]
    [Required]
    public required Guid JobMaterialId { get; init; }

    [JsonPropertyName("sequence")]
    [Description("The sequence number of the purchase order detail. Used to sort the purchase order details")]
    [Required]
    public required double Sequence { get; init; }

    [JsonPropertyName("quantity")]
    [Description("The item quantity")]
    [Required]
    public required double Quantity { get; init; }

    [JsonPropertyName("unitCost")]
    [Description("The item unit cost")]
    [Required]
    public required double UnitCost { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The item unit of measure")]
    [Required]
    public required string UnitOfMeasure { get; init; }

    [JsonPropertyName("isFullyReceived")]
    [Description("Whether the item is fully received. Default is false")]
    public bool? IsFullyReceived { get; init; }

    [JsonPropertyName("isFullyInstalled")]
    [Description("Whether the item is fully installed. Default is false")]
    public bool? IsFullyInstalled { get; init; }

    [JsonPropertyName("note")]
    [Description("The note")]
    public string? Note { get; init; }

    [JsonPropertyName("salesTaxPercent")]
    [Description("The item sales tax represented in percent")]
    public double? SalesTaxPercent { get; init; }

    [JsonPropertyName("isCancelled")]
    [Description("Whether the purchase order detail is canceled")]
    public bool? IsCancelled { get; init; }

    [JsonPropertyName("alternateDescription")]
    [Description("An alternate description for this purchase order")]
    public string? AlternateDescription { get; init; }

    [JsonPropertyName("vendorItemNumber")]
    [Description("The vendor item number")]
    public string? VendorItemNumber { get; init; }
}

public class CreateMaterialPurchaseOrderDetailsActionOutput
{
    [JsonPropertyName("success")]
    [Description("Whether the create was successful")]
    public bool Success { get; init; }

    [JsonPropertyName("materialPurchaseOrderDetail")]
    [Description("The created material purchase order detail")]
    public MaterialPurchaseOrderDetailsDataObject? MaterialPurchaseOrderDetail { get; init; }
}
