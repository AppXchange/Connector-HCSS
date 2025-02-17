namespace Connector.HeavyJob.v1.MaterialSubsAndCustomCosts.Update;

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
[Description("Updates or adds new material, subcontract, or custom cost type items")]
public class UpdateMaterialSubsAndCustomCostsAction : IStandardAction<UpdateMaterialSubsAndCustomCostsActionInput, UpdateMaterialSubsAndCustomCostsActionOutput>
{
    public UpdateMaterialSubsAndCustomCostsActionInput ActionInput { get; set; } = new() { 
        BusinessUnitId = Guid.Empty,
        OnExistingLibrartyMaterialCode = "skip"
    };
    public UpdateMaterialSubsAndCustomCostsActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class UpdateMaterialSubsAndCustomCostsActionInput
{
    [JsonPropertyName("businessUnitId")]
    [Description("Id for the material, subcontractor or custom cost type")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("onExistingLibrartyMaterialCode")]
    [Description("Action to take when material code exists")]
    [Required]
    public required string OnExistingLibrartyMaterialCode { get; init; }

    [JsonPropertyName("materialsToUpdate")]
    [Description("MSE elements to be updated")]
    public MseLibraryEntry[]? MaterialsToUpdate { get; init; }
}

public class MseLibraryEntry
{
    [JsonPropertyName("id")]
    [Description("Id of the material, subcontractor or custom cost type")]
    public Guid? Id { get; init; }

    [JsonPropertyName("code")]
    [Description("The code of the material, subcontractor or custom cost type item")]
    public string? Code { get; init; }

    [JsonPropertyName("description")]
    [Description("The description of the material, subcontractor or custom cost type item")]
    public string? Description { get; init; }

    [JsonPropertyName("heavyBidCode")]
    [Description("The HeavyBid code of the material, subcontractor or custom cost type item")]
    public string? HeavyBidCode { get; init; }

    [JsonPropertyName("costTypeCode")]
    [Description("The cost type code of the material, subcontractor or custom cost type item")]
    public string? CostTypeCode { get; init; }
}

public class UpdateMaterialSubsAndCustomCostsActionOutput
{
    [JsonPropertyName("success")]
    [Description("Whether the update was successful")]
    public bool Success { get; init; }
}
