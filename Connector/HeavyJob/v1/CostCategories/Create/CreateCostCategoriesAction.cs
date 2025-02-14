namespace Connector.HeavyJob.v1.CostCategories.Create;

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
[Description("Creates a cost category on a business unit")]
public class CreateCostCategoriesAction : IStandardAction<CreateCostCategoriesActionInput, CreateCostCategoriesActionOutput>
{
    public CreateCostCategoriesActionInput ActionInput { get; set; } = new();
    public CreateCostCategoriesActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateCostCategoriesActionInput
{
    [JsonPropertyName("businessUnitId")]
    [Required]
    [Description("The business unit ID")]
    public Guid BusinessUnitId { get; init; }

    [JsonPropertyName("code")]
    [Required]
    [Description("The cost category code")]
    public string Code { get; init; } = string.Empty;

    [JsonPropertyName("description")]
    [Required]
    [Description("The cost category description")]
    public string Description { get; init; } = string.Empty;
}

public class CreateCostCategoriesActionOutput
{
    [JsonPropertyName("id")]
    [Description("The cost category ID")]
    public Guid Id { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit ID")]
    public Guid BusinessUnitId { get; init; }

    [JsonPropertyName("costTypeId")]
    [Description("The cost type ID")]
    public Guid CostTypeId { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Whether the cost category is deleted")]
    public bool IsDeleted { get; init; }

    [JsonPropertyName("code")]
    [Description("The cost category code")]
    public string Code { get; init; } = string.Empty;

    [JsonPropertyName("description")]
    [Description("The cost category description")]
    public string Description { get; init; } = string.Empty;
}
