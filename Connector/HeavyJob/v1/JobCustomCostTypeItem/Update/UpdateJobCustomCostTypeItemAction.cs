namespace Connector.HeavyJob.v1.JobCustomCostTypeItem.Update;

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
[Description("Updates an existing job custom cost type item")]
public class UpdateJobCustomCostTypeItemAction : IStandardAction<UpdateJobCustomCostTypeItemActionInput, UpdateJobCustomCostTypeItemActionOutput>
{
    public UpdateJobCustomCostTypeItemActionInput ActionInput { get; set; } = new()
    {
        Id = Guid.Empty,
        CustomCostTypeItemId = Guid.Empty
    };
    public UpdateJobCustomCostTypeItemActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class UpdateJobCustomCostTypeItemActionInput
{
    [JsonPropertyName("id")]
    [Description("The job custom cost type item id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("customCostTypeItemId")]
    [Description("The custom cost type item id")]
    [Required]
    public required Guid CustomCostTypeItemId { get; init; }

    [JsonPropertyName("description")]
    [Description("The description")]
    public string? Description { get; init; }

    [JsonPropertyName("salesTaxPercent")]
    [Description("The sales tax, expressed as a percent (e.g., 8 means 8% sales tax)")]
    public double? SalesTaxPercent { get; init; }

    [JsonPropertyName("unitCost")]
    [Description("The cost per unit of measure, in dollars")]
    public double? UnitCost { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The unit of measure")]
    public string? UnitOfMeasure { get; init; }

    [JsonPropertyName("accountingCode")]
    [Description("The accounting code")]
    public string? AccountingCode { get; init; }
}

public class UpdateJobCustomCostTypeItemActionOutput
{
    [JsonPropertyName("id")]
    [Description("The updated job custom cost type item id")]
    public Guid Id { get; init; }
}
