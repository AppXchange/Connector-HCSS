namespace Connector.HeavyJob.v1.AdvancedBudgetMaterial.Create;

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
[Description("Creates a new material advanced budget")]
public class CreateAdvancedBudgetMaterialAction : IStandardAction<CreateAdvancedBudgetMaterialActionInput, CreateAdvancedBudgetMaterialActionOutput>
{
    public CreateAdvancedBudgetMaterialActionInput ActionInput { get; set; } = new() { CostCodeId = Guid.Empty, PurchaseOrderDetailId = Guid.Empty };
    public CreateAdvancedBudgetMaterialActionOutput ActionOutput { get; set; } = new() 
    { 
        Id = Guid.Empty,
        CostCodeId = Guid.Empty,
        JobMaterialId = Guid.Empty,
        PurchaseOrderDetailId = Guid.Empty
    };
    public StandardActionFailure ActionFailure { get; set; } = new();
    public bool CreateRtap => true;
}

public class CreateAdvancedBudgetMaterialActionInput
{
    [JsonPropertyName("costCodeId")]
    [Description("The cost code id")]
    [Required]
    public required Guid CostCodeId { get; init; }

    [JsonPropertyName("purchaseOrderDetailId")]
    [Description("The purchase order detail id")]
    [Required]
    public required Guid PurchaseOrderDetailId { get; init; }

    [JsonPropertyName("status")]
    [Description("The status of the material")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MaterialStatus Status { get; init; }

    [JsonPropertyName("quantity")]
    [Description("The quantity of the material")]
    public double Quantity { get; init; }
}

public class CreateAdvancedBudgetMaterialActionOutput : AdvancedBudgetMaterialDataObject
{
}
