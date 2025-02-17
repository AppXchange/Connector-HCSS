namespace Connector.HeavyJob.v1.PurchaseOrders.Update;

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
[Description("Updates an existing purchase order in HeavyJob")]
public class UpdatePurchaseOrdersAction : IStandardAction<UpdatePurchaseOrdersActionInput, UpdatePurchaseOrdersActionOutput>
{
    public UpdatePurchaseOrdersActionInput ActionInput { get; set; } = new() 
    { 
        Id = Guid.Empty,
        PurchaseOrder = string.Empty,
        OrderStatus = "notStarted"
    };
    public UpdatePurchaseOrdersActionOutput ActionOutput { get; set; } = new() 
    { 
        Success = false 
    };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class UpdatePurchaseOrdersActionInput
{
    [JsonPropertyName("id")]
    [Description("The purchase order id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("purchaseOrder")]
    [Description("The purchase order name")]
    public string? PurchaseOrder { get; init; }

    [JsonPropertyName("orderStatus")]
    [Description("The status of the purchase order")]
    [Required]
    public required string OrderStatus { get; init; }

    [JsonPropertyName("dateIssued")] 
    [Description("The date purchase order was issued")]
    public DateTime? DateIssued { get; init; }

    [JsonPropertyName("description")]
    [Description("The purchase order description")]
    public string? Description { get; init; }

    [JsonPropertyName("vendorId")]
    [Description("The vendor id for the purchase order")]
    public Guid? VendorId { get; init; }
}

public class UpdatePurchaseOrdersActionOutput
{
    [JsonPropertyName("success")]
    [Description("Whether the update was successful")]
    [Required]
    public required bool Success { get; init; }
}
