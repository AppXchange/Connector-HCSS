namespace Connector.Contacts.v1.ContactProducts.Create;

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
[Description("Creates a new product to be associated with a contact")]
public class CreateContactProductsAction : IStandardAction<CreateContactProductsActionInput, CreateContactProductsActionOutput>
{
    public CreateContactProductsActionInput ActionInput { get; set; } = new() 
    { 
        VendorId = Guid.Empty, 
        ContactId = Guid.Empty,
        VendorProductId = Guid.Empty 
    };
    public CreateContactProductsActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateContactProductsActionInput
{
    [JsonPropertyName("vendorId")]
    [Description("The vendor's unique identifier")]
    [Required]
    public required Guid VendorId { get; init; }

    [JsonPropertyName("contactId")]
    [Description("The contact's unique identifier")]
    [Required]
    public required Guid ContactId { get; init; }

    [JsonPropertyName("vendorProductId")]
    [Description("The vendor product's unique identifier")]
    [Required]
    public required Guid VendorProductId { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit's guid")]
    public Guid? BusinessUnitId { get; init; }
}

public class CreateContactProductsActionOutput
{
    [JsonPropertyName("id")]
    [Description("The created product's unique identifier")]
    public Guid Id { get; init; }
}
