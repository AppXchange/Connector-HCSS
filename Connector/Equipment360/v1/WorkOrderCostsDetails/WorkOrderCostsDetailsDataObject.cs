namespace Connector.Equipment360.v1.WorkOrderCostsDetails;

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
[PrimaryKey("workOrderNumber", nameof(WorkOrderNumber))]
[Description("Represents detailed work order costs in Equipment360")]
public class WorkOrderCostsDetailsDataObject
{
    [JsonPropertyName("workOrderNumber")]
    [Description("The work order number")]
    [Required]
    public required int WorkOrderNumber { get; init; }

    [JsonPropertyName("workOrderDescription")]
    [Description("The work order description")]
    public string? WorkOrderDescription { get; init; }

    [JsonPropertyName("workOrderCreatedDate")]
    [Description("The work order creation date")]
    public DateTime WorkOrderCreatedDate { get; init; }

    [JsonPropertyName("workOrderStatusCode")]
    [Description("The work order status code")]
    public string? WorkOrderStatusCode { get; init; }

    [JsonPropertyName("hasWorkOrderDamageTag")]
    [Description("Whether the work order has a damage tag")]
    public bool HasWorkOrderDamageTag { get; init; }

    [JsonPropertyName("jobCode")]
    [Description("The job code")]
    public string? JobCode { get; init; }

    [JsonPropertyName("laborCost")]
    [Description("The total labor cost")]
    public double LaborCost { get; init; }

    [JsonPropertyName("partCost")]
    [Description("The total parts cost")]
    public double PartCost { get; init; }

    [JsonPropertyName("otherCost")]
    [Description("The total other costs")]
    public double OtherCost { get; init; }

    [JsonPropertyName("totalCost")]
    [Description("The sum of all costs")]
    public double TotalCost { get; init; }

    [JsonPropertyName("estimatedLaborCost")]
    [Description("The total estimated labor cost")]
    public double EstimatedLaborCost { get; init; }

    [JsonPropertyName("estimatedPartCost")]
    [Description("The total estimated parts cost")]
    public double EstimatedPartCost { get; init; }

    [JsonPropertyName("estimatedOtherCost")]
    [Description("The total estimated other costs")]
    public double EstimatedOtherCost { get; init; }

    [JsonPropertyName("estimatedTotalCost")]
    [Description("The sum of all estimated costs")]
    public double EstimatedTotalCost { get; init; }
}