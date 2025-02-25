namespace Connector.HeavyJob.v1.JobCostsToDate;

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
[PrimaryKey("jobId", nameof(Job.JobId))]
[Description("Job costs to date in HeavyJob")]
public class JobCostsToDateDataObject
{
    [JsonPropertyName("job")]
    [Description("The job information")]
    [Required]
    public required JobInfo Job { get; init; }

    [JsonPropertyName("costCode")]
    [Description("The cost code information")]
    [Required]
    public required CostCodeInfo CostCode { get; init; }

    [JsonPropertyName("foreman")]
    [Description("The foreman information")]
    [Required]
    public required ForemanInfo Foreman { get; init; }

    [JsonPropertyName("totalQuantity")]
    [Description("The total production quantity")]
    public double TotalQuantity { get; init; }

    [JsonPropertyName("reworkQuantity")]
    [Description("The rework quantity")]
    public double ReworkQuantity { get; init; }

    [JsonPropertyName("totalEquipmentCost")]
    [Description("The total equipment cost recorded")]
    public double TotalEquipmentCost { get; init; }

    [JsonPropertyName("totalEquipmentHours")]
    [Description("The total equipment hours recorded")]
    public double TotalEquipmentHours { get; init; }

    [JsonPropertyName("totalLaborCost")]
    [Description("The total labor cost recorded")]
    public double TotalLaborCost { get; init; }

    [JsonPropertyName("totalLaborHours")]
    [Description("The total labor hours recorded")]
    public double TotalLaborHours { get; init; }

    [JsonPropertyName("totalMaterialCost")]
    [Description("The total material cost recorded")]
    public double TotalMaterialCost { get; init; }

    [JsonPropertyName("totalSubcontractCost")]
    [Description("The total subcontract cost recorded")]
    public double TotalSubcontractCost { get; init; }

    [JsonPropertyName("totalTruckingCost")]
    [Description("The total trucking cost recorded")]
    public double TotalTruckingCost { get; init; }
}

public class JobInfo
{
    [JsonPropertyName("jobId")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("jobCode")]
    [Required]
    public required string JobCode { get; init; }

    [JsonPropertyName("jobDescription")]
    [Required]
    public required string JobDescription { get; init; }
}

public class CostCodeInfo
{
    [JsonPropertyName("costCodeId")]
    [Required]
    public required Guid CostCodeId { get; init; }

    [JsonPropertyName("costCodeCode")]
    [Required]
    public required string CostCodeCode { get; init; }

    [JsonPropertyName("costCodeDescription")]
    [Required]
    public required string CostCodeDescription { get; init; }
}

public class ForemanInfo
{
    [JsonPropertyName("employeeId")]
    [Required]
    public required Guid EmployeeId { get; init; }

    [JsonPropertyName("employeeCode")]
    [Required]
    public required string EmployeeCode { get; init; }

    [JsonPropertyName("employeeFirstName")]
    [Required]
    public required string EmployeeFirstName { get; init; }

    [JsonPropertyName("employeeLastName")]
    [Required]
    public required string EmployeeLastName { get; init; }
}

public class JobCostsToDateResponse
{
    [JsonPropertyName("results")]
    [Required]
    public required JobCostsToDateDataObject[] Results { get; init; }

    [JsonPropertyName("metadata")]
    [Required]
    public required JobCostsToDateMetadata Metadata { get; init; }
}

public class JobCostsToDateMetadata
{
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; init; }
}