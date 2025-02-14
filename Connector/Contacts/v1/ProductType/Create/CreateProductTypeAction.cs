namespace Connector.Contacts.v1.ProductType.Create;

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
[Description("Creates a new product type")]
public class CreateProductTypeAction : IStandardAction<CreateProductTypeActionInput, CreateProductTypeActionOutput>
{
    public CreateProductTypeActionInput ActionInput { get; set; } = new() { Code = string.Empty };
    public CreateProductTypeActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateProductTypeActionInput
{
    [JsonPropertyName("code")]
    [Description("A unique product type code")]
    [Required]
    [MinLength(1)]
    public required string Code { get; init; }

    [JsonPropertyName("description")]
    [Description("The product type's description")]
    public string? Description { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit's guid")]
    public Guid? BusinessUnitId { get; init; }
}

public class CreateProductTypeActionOutput
{
    [JsonPropertyName("id")]
    [Description("The created product type's unique identifier")]
    public Guid Id { get; init; }
}
