namespace Connector.HeavyJob.v1.JobCustomCostTypeItem.Create;

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
[Description("Creates a job custom cost type item on the specified job")]
public class CreateJobCustomCostTypeItemAction : IStandardAction<CreateJobCustomCostTypeItemActionInput, JobCustomCostTypeItemDataObject>
{
    public CreateJobCustomCostTypeItemActionInput ActionInput { get; set; } = new()
    {
        JobId = Guid.Empty,
        CustomCostTypeItemId = Guid.Empty
    };

    public JobCustomCostTypeItemDataObject ActionOutput { get; set; } = new()
    {
        Id = Guid.Empty,
        Code = string.Empty,
        CustomCostTypeItemId = Guid.Empty,
        JobId = Guid.Empty,
        BusinessUnitCostType = new BusinessUnitCostTypeInfo
        {
            Id = Guid.Empty,
            Code = string.Empty,
            BusinessUnitId = Guid.Empty,
            Description = string.Empty,
            IsDeleted = false
        },
        BusinessUnitCostTypeItem = new BusinessUnitCostTypeItemInfo
        {
            Id = Guid.Empty,
            Type = string.Empty,
            Code = string.Empty,
            Description = string.Empty,
            IsDeleted = false
        },
        IsDiscontinued = false,
        IsDeleted = false
    };

    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateJobCustomCostTypeItemActionInput
{
    [JsonPropertyName("jobId")]
    [Description("The job id")]
    [Required]
    public required Guid JobId { get; init; }

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
