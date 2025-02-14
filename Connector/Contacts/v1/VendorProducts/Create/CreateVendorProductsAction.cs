namespace Connector.Contacts.v1.VendorProducts.Create;

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
[Description("Creates a new product for a vendor")]
public class CreateVendorProductsAction : IStandardAction<CreateVendorProductsActionInput, CreateVendorProductsActionOutput>
{
    public CreateVendorProductsActionInput ActionInput { get; set; } = new() { VendorId = Guid.Empty, ProductTypeId = Guid.Empty };
    public CreateVendorProductsActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateVendorProductsActionInput
{
    [JsonPropertyName("vendorId")]
    [Description("The vendor's unique identifier")]
    [System.ComponentModel.DataAnnotations.Required]
    public required Guid VendorId { get; init; }

    [JsonPropertyName("productTypeId")]
    [Description("The product type's unique identifier")]
    [System.ComponentModel.DataAnnotations.Required]
    public required Guid ProductTypeId { get; init; }

    [JsonPropertyName("regionId")]
    [Description("The product region's unique identifier")]
    public Guid? RegionId { get; init; }

    [JsonPropertyName("date")]
    [Description("The date")]
    public DateTime? Date { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit's guid")]
    public Guid? BusinessUnitId { get; init; }
}

public class CreateVendorProductsActionOutput
{
    [JsonPropertyName("id")]
    [Description("The created product's unique identifier")]
    public Guid Id { get; init; }
}
