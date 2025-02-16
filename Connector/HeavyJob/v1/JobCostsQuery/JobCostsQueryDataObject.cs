namespace Connector.HeavyJob.v1.JobCostsQuery;

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
[Description("Job costs query in HeavyJob")]
public class JobCostsQueryDataObject
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

    [JsonPropertyName("entryType")]
    [Description("The entry type")]
    public string? EntryType { get; init; }

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

public class JobCostsQueryResponse
{
    [JsonPropertyName("results")]
    [Required]
    public required JobCostsQueryDataObject[] Results { get; init; }

    [JsonPropertyName("metadata")]
    [Required]
    public required JobCostsQueryMetadata Metadata { get; init; }
}

public class JobCostsQueryMetadata
{
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; init; }
}