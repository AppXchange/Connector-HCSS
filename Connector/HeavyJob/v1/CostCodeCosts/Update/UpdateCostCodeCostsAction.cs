namespace Connector.HeavyJob.v1.CostCodeCosts.Update;

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
[Description("Sets costs for the cost code by creating adjustments")]
public class UpdateCostCodeCostsAction : IStandardAction<UpdateCostCodeCostsActionInput, UpdateCostCodeCostsActionOutput>
{
    public UpdateCostCodeCostsActionInput ActionInput { get; set; } = new();
    public UpdateCostCodeCostsActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class UpdateCostCodeCostsActionInput
{
    [JsonPropertyName("costCodeId")]
    [Required]
    [Description("The cost code ID")]
    public Guid CostCodeId { get; init; }

    [JsonPropertyName("effectiveDate")]
    [Required]
    [Description("The date on which the costs are true")]
    public DateTime EffectiveDate { get; init; }

    [JsonPropertyName("equipmentCost")]
    [Description("The equipment cost")]
    public double? EquipmentCost { get; init; }

    [JsonPropertyName("equipmentHours")]
    [Description("The equipment hours")]
    public double? EquipmentHours { get; init; }

    [JsonPropertyName("laborCost")]
    [Description("The labor cost")]
    public double? LaborCost { get; init; }

    [JsonPropertyName("laborHours")]
    [Description("The labor hours")]
    public double? LaborHours { get; init; }

    [JsonPropertyName("materialCost")]
    [Description("The material cost")]
    public double? MaterialCost { get; init; }

    [JsonPropertyName("subcontractCost")]
    [Description("The subcontract cost")]
    public double? SubcontractCost { get; init; }

    [JsonPropertyName("quantity")]
    [Description("The quantity")]
    public double? Quantity { get; init; }

    [JsonPropertyName("customCostTypeValues")]
    [Description("List of custom-cost-type actual costs")]
    public CustomCostTypeValueWrite[]? CustomCostTypeValues { get; init; }
}

public class CustomCostTypeValueWrite
{
    [JsonPropertyName("costCategoryId")]
    [Description("The cost category ID")]
    public Guid CostCategoryId { get; init; }

    [JsonPropertyName("cost")]
    [Description("The cost value")]
    public double Cost { get; init; }
}

public class UpdateCostCodeCostsActionOutput
{
    [JsonPropertyName("costCodeId")]
    [Description("The cost code ID")]
    public Guid CostCodeId { get; init; }
}
