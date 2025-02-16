namespace Connector.HeavyJob.v1.JobCosts;

using Json.Schema.Generation;
using System;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.CacheWriter;

/// <summary>
/// Data object that will represent an object in the Xchange system. This will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// These types will be used for validation at runtime to make sure the objects being passed through the system 
/// are properly formed. The schema also helps provide integrators more information for what the values 
/// are intended to be.
/// </summary>
[PrimaryKey("jobId", nameof(JobId))]
[Description("Job costs in HeavyJob")]
public class JobCostsDataObject
{
    [JsonPropertyName("jobId")]
    [Description("The job id")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("totalCost")]
    [Description("The total cost")]
    [Required]
    public required double TotalCost { get; init; }

    [JsonPropertyName("costCodeCosts")]
    [Description("The cost code costs")]
    [Required]
    public required CostCodeCost[] CostCodeCosts { get; init; }
}

public class CostCodeCost
{
    [JsonPropertyName("costCodeId")]
    [Description("The cost code id")]
    public Guid CostCodeId { get; init; }

    [JsonPropertyName("equipmentCost")]
    [Description("The equipment cost")]
    public double EquipmentCost { get; init; }

    [JsonPropertyName("equipmentHours")]
    [Description("The equipment hours")]
    public double EquipmentHours { get; init; }

    [JsonPropertyName("laborCost")]
    [Description("The labor cost")]
    public double LaborCost { get; init; }

    [JsonPropertyName("laborHours")]
    [Description("The labor hours")]
    public double LaborHours { get; init; }

    [JsonPropertyName("materialCost")]
    [Description("The material cost")]
    public double MaterialCost { get; init; }

    [JsonPropertyName("subcontractCost")]
    [Description("The subcontract cost")]
    public double SubcontractCost { get; init; }

    [JsonPropertyName("truckingCost")]
    [Description("The trucking cost")]
    public double TruckingCost { get; init; }

    [JsonPropertyName("quantity")]
    [Description("The quantity")]
    public double Quantity { get; init; }

    [JsonPropertyName("customCostTypeValues")]
    [Description("List of custom-cost-type actual costs")]
    public CustomCostTypeValue[]? CustomCostTypeValues { get; init; }
}

public class CustomCostTypeValue
{
    [JsonPropertyName("costCategoryCode")]
    public string? CostCategoryCode { get; init; }

    [JsonPropertyName("costCategoryDescription")]
    public string? CostCategoryDescription { get; init; }

    [JsonPropertyName("costCategoryId")]
    public Guid CostCategoryId { get; init; }

    [JsonPropertyName("cost")]
    public double Cost { get; init; }
}