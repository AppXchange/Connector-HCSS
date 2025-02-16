namespace Connector.HeavyJob.v1.JobCostCustomCost;

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
[Description("Job cost custom costs in HeavyJob")]
public class JobCostCustomCostDataObject
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

    [JsonPropertyName("businessUnitCostType")]
    [Description("The business unit cost type information")]
    public BusinessUnitCostTypeInfo? BusinessUnitCostType { get; init; }

    [JsonPropertyName("date")]
    [Description("The entry date")]
    public DateTime Date { get; init; }

    [JsonPropertyName("cost")]
    [Description("The cost amount")]
    public double Cost { get; init; }
}

public class JobInfo
{
    [JsonPropertyName("jobId")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("jobCode")]
    public string? JobCode { get; init; }

    [JsonPropertyName("jobDescription")]
    public string? JobDescription { get; init; }
}

public class CostCodeInfo
{
    [JsonPropertyName("costCodeId")]
    [Required]
    public required Guid CostCodeId { get; init; }

    [JsonPropertyName("costCodeCode")]
    public string? CostCodeCode { get; init; }

    [JsonPropertyName("costCodeDescription")]
    public string? CostCodeDescription { get; init; }
}

public class ForemanInfo
{
    [JsonPropertyName("employeeId")]
    [Required]
    public required Guid EmployeeId { get; init; }

    [JsonPropertyName("employeeCode")]
    public string? EmployeeCode { get; init; }

    [JsonPropertyName("employeeFirstName")]
    public string? EmployeeFirstName { get; init; }

    [JsonPropertyName("employeeLastName")]
    public string? EmployeeLastName { get; init; }
}

public class BusinessUnitCostTypeInfo
{
    [JsonPropertyName("id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("code")]
    public string? Code { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("isDeleted")]
    public bool IsDeleted { get; init; }
}

public class JobCostCustomCostResponse
{
    [JsonPropertyName("results")]
    [Required]
    public required JobCostCustomCostDataObject[] Results { get; init; }

    [JsonPropertyName("metadata")]
    [Required]
    public required JobCostCustomCostMetadata Metadata { get; init; }
}

public class JobCostCustomCostMetadata
{
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; init; }
}