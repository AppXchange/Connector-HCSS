namespace Connector.HeavyJob.v1.Materials.Create;

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
[Description("Creates a material for the specified business unit")]
public class CreateMaterialsAction : IStandardAction<CreateMaterialsActionInput, CreateMaterialsActionOutput>
{
    public CreateMaterialsActionInput ActionInput { get; set; } = new() { 
        BusinessUnitId = Guid.Empty,
        Code = string.Empty,
        IsStockpiled = false
    };
    public CreateMaterialsActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateMaterialsActionInput
{
    [JsonPropertyName("businessUnitId")]
    [Description("The business unit id")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("code")]
    [Description("The code")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("description")]
    [Description("The description")]
    public string? Description { get; init; }

    [JsonPropertyName("isStockpiled")]
    [Description("Flag indicating whether the material is used immediately (e.g., installed), or added to the stockpile for later")]
    [Required]
    public required bool IsStockpiled { get; init; }

    [JsonPropertyName("heavyBidCode")]
    [Description("The HeavyBid code")]
    public string? HeavyBidCode { get; init; }
}

public class CreateMaterialsActionOutput
{
    [JsonPropertyName("success")]
    [Description("Whether the create was successful")]
    public bool Success { get; init; }

    [JsonPropertyName("material")]
    [Description("The created material")]
    public MaterialsDataObject? Material { get; init; }
}
