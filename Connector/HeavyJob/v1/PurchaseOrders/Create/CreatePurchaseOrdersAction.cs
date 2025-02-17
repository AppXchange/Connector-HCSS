namespace Connector.HeavyJob.v1.PurchaseOrders.Create;

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
[Description("Creates a new purchase order in HeavyJob")]
public class CreatePurchaseOrdersAction : IStandardAction<CreatePurchaseOrdersActionInput, CreatePurchaseOrdersActionOutput>
{
    public CreatePurchaseOrdersActionInput ActionInput { get; set; } = new() 
    { 
        JobId = Guid.Empty,
        PurchaseOrder = string.Empty 
    };
    public CreatePurchaseOrdersActionOutput ActionOutput { get; set; } = new()
    {
        Id = Guid.Empty,
        JobId = Guid.Empty,
        OrderStatus = "notStarted",
        DateIssued = DateTime.UtcNow,
        PurchaseOrder = string.Empty
    };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreatePurchaseOrdersActionInput
{
    [JsonPropertyName("jobId")]
    [Description("The job id on which to create the purchase order")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("purchaseOrder")]
    [Description("The purchase order name")]
    [Required]
    public required string PurchaseOrder { get; init; }

    [JsonPropertyName("orderStatus")]
    [Description("The status of the purchase order")]
    public string? OrderStatus { get; init; }

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

public class CreatePurchaseOrdersActionOutput
{
    [JsonPropertyName("id")]
    [Description("The purchase order id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("jobId")]
    [Description("The job id")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("orderStatus")]
    [Description("The status of the purchase order")]
    [Required]
    public required string OrderStatus { get; init; }

    [JsonPropertyName("dateIssued")]
    [Description("The date purchase order was issued")]
    [Required]
    public required DateTime DateIssued { get; init; }

    [JsonPropertyName("vendorName")]
    [Description("The name of the vendor of the purchase order")]
    public string? VendorName { get; init; }

    [JsonPropertyName("vendorDescription")]
    [Description("The description of the vendor for the purchase order")]
    public string? VendorDescription { get; init; }

    [JsonPropertyName("purchaseOrder")]
    [Description("The purchase order name")]
    [Required]
    public required string PurchaseOrder { get; init; }

    [JsonPropertyName("description")]
    [Description("The purchase order description")]
    public string? Description { get; init; }

    [JsonPropertyName("vendorId")]
    [Description("The vendor id for the purchase order")]
    public Guid? VendorId { get; init; }
}
