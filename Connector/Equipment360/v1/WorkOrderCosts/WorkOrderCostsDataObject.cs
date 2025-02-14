namespace Connector.Equipment360.v1.WorkOrderCosts;

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
[PrimaryKey("jobCode", nameof(JobCode))]
[Description("Represents work order costs in Equipment360")]
public class WorkOrderCostsDataObject
{
    [JsonPropertyName("jobCode")]
    [Description("The job to which the work order costs belong")]
    public string? JobCode { get; init; }

    [JsonPropertyName("laborCost")]
    [Description("The total labor cost across all work orders filtered by the given jobCode, equipmentId, or tag")]
    public double LaborCost { get; init; }

    [JsonPropertyName("estimatedLaborCost")]
    [Description("The total estimated labor cost across all work orders filtered by the given jobCode, equipmentId, or tag")]
    public double EstimatedLaborCost { get; init; }

    [JsonPropertyName("partCost")]
    [Description("The total parts cost across all work orders filtered by the given jobCode, equipmentId, or tag")]
    public double PartCost { get; init; }

    [JsonPropertyName("estimatedPartCost")]
    [Description("The total estimated parts cost across all work orders filtered by the given jobCode, equipmentId, or tag")]
    public double EstimatedPartCost { get; init; }

    [JsonPropertyName("otherCost")]
    [Description("The total sublet vendor cost and other cost across all work orders filtered by the given jobCode, equipmentId, or tag")]
    public double OtherCost { get; init; }

    [JsonPropertyName("estimatedOtherCost")]
    [Description("The total estimated sublet vendor and other cost across all work orders filtered by the given jobCode, equipmentId, or tag")]
    public double EstimatedOtherCost { get; init; }

    [JsonPropertyName("totalCost")]
    [Description("The sum of labor, part, and sublet vendor and other costs across all work orders filtered by the given jobCode, equipmentId, or tag")]
    public double TotalCost { get; init; }

    [JsonPropertyName("estimatedTotalCost")]
    [Description("The sum of estimated labor, part, sublet vendor and other costs across all work orders filtered by the given jobCode, equipmentId, or tag")]
    public double EstimatedTotalCost { get; init; }
}