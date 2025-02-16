namespace Connector.HeavyJob.v1.JobCostByCostCode;

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
[PrimaryKey("costCodeId", nameof(CostCodeId))]
[Description("Job costs associated with a cost code in HeavyJob")]
public class JobCostByCostCodeDataObject
{
    [JsonPropertyName("costCodeId")]
    [Description("The cost code id")]
    [Required]
    public required Guid CostCodeId { get; init; }

    [JsonPropertyName("foremanId")]
    [Description("The foreman id")]
    public Guid ForemanId { get; init; }

    [JsonPropertyName("date")]
    [Description("The entry date")]
    public DateTime Date { get; init; }

    [JsonPropertyName("quantity")]
    [Description("The production quantity")]
    public double Quantity { get; init; }

    [JsonPropertyName("equipmentCost")]
    [Description("The equipment cost recorded")]
    public double EquipmentCost { get; init; }

    [JsonPropertyName("equipmentHours")]
    [Description("The equipment hours recorded")]
    public double EquipmentHours { get; init; }

    [JsonPropertyName("laborCost")]
    [Description("The labor cost recorded")]
    public double LaborCost { get; init; }

    [JsonPropertyName("laborHours")]
    [Description("The labor hours recorded")]
    public double LaborHours { get; init; }

    [JsonPropertyName("materialCost")]
    [Description("The material cost recorded")]
    public double MaterialCost { get; init; }

    [JsonPropertyName("subcontractCost")]
    [Description("The subcontract cost recorded")]
    public double SubcontractCost { get; init; }

    [JsonPropertyName("truckingCost")]
    [Description("The trucking cost recorded")]
    public double TruckingCost { get; init; }
}

public class JobCostByCostCodeResponse
{
    [JsonPropertyName("results")]
    [Required]
    public required JobCostByCostCodeDataObject[] Results { get; init; }

    [JsonPropertyName("metadata")]
    [Required]
    public required JobCostByCostCodeMetadata Metadata { get; init; }
}

public class JobCostByCostCodeMetadata
{
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; init; }
}