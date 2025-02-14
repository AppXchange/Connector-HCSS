namespace Connector.HeavyJob.v1.CostCodes.Update;

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
[Description("Creates or updates budgets for a list of cost code and custom cost type combination")]
public class UpdateCostCodesAction : IStandardAction<UpdateCostCodesActionInput, UpdateCostCodesActionOutput>
{
    public UpdateCostCodesActionInput ActionInput { get; set; } = new();
    public UpdateCostCodesActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CostCodeBudget
{
    [JsonPropertyName("costCodeId")]
    [Required]
    [Description("The cost code id")]
    public Guid CostCodeId { get; init; }

    [JsonPropertyName("customCostTypeId")]
    [Required]
    [Description("The custom cost type id")]
    public Guid CustomCostTypeId { get; init; }

    [JsonPropertyName("budgetedCost")]
    [Required]
    [Description("The custom cost type budgeted cost")]
    public double BudgetedCost { get; init; }
}

public class UpdateCostCodesActionInput
{
    [Required]
    [Description("The list of cost codes to update")]
    public CostCodeBudget[] Budgets { get; init; } = Array.Empty<CostCodeBudget>();
}

public class UpdateCostCodesActionOutput
{
    // No output properties needed since API returns 204 No Content
}
