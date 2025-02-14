namespace Connector.HeavyJob.v1.CostCodeTransactionAdjustment;

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
[PrimaryKey("id", nameof(Id))]
//[AlternateKey("alt-key-id", nameof(CompanyId), nameof(EquipmentNumber))]
[Description("Represents a cost code transaction adjustment in HeavyJob")]
public class CostCodeTransactionAdjustmentDataObject
{
    [JsonPropertyName("id")]
    [Description("The adjustment ID")]
    [Required]
    public Guid Id { get; init; }

    [JsonPropertyName("job")]
    [Description("The job details")]
    public JobInfo Job { get; init; } = new();

    [JsonPropertyName("foreman")]
    [Description("The foreman details")]
    public ForemanInfo Foreman { get; init; } = new();

    [JsonPropertyName("date")]
    [Description("The transaction date")]
    public DateTime Date { get; init; }

    [JsonPropertyName("costCode")]
    [Description("The cost code details")]
    public CostCodeInfo CostCode { get; init; } = new();

    [JsonPropertyName("businessUnitCostType")]
    [Description("The business unit cost type")]
    public BusinessUnitCostType BusinessUnitCostType { get; init; } = new();

    [JsonPropertyName("entryType")]
    [Description("The entry type")]
    public string EntryType { get; init; } = string.Empty;

    [JsonPropertyName("adjustmentTransactionType")]
    [Description("The adjustment transaction type")]
    public string AdjustmentTransactionType { get; init; } = string.Empty;

    [JsonPropertyName("value")]
    [Description("The adjustment value")]
    public double Value { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The unit of measure")]
    public string UnitOfMeasure { get; init; } = string.Empty;

    [JsonPropertyName("note")]
    [Description("The note")]
    public string Note { get; init; } = string.Empty;

    [JsonPropertyName("sourceName")]
    [Description("The source name")]
    public string SourceName { get; init; } = string.Empty;

    [JsonPropertyName("syncTimestamp")]
    [Description("When the adjustment was last synced")]
    public DateTime SyncTimestamp { get; init; }
}

public class JobInfo
{
    [JsonPropertyName("jobId")]
    public Guid JobId { get; init; }

    [JsonPropertyName("jobCode")]
    public string JobCode { get; init; } = string.Empty;

    [JsonPropertyName("jobDescription")]
    public string JobDescription { get; init; } = string.Empty;
}

public class ForemanInfo
{
    [JsonPropertyName("employeeId")]
    public Guid EmployeeId { get; init; }

    [JsonPropertyName("employeeCode")]
    public string EmployeeCode { get; init; } = string.Empty;

    [JsonPropertyName("employeeFirstName")]
    public string EmployeeFirstName { get; init; } = string.Empty;

    [JsonPropertyName("employeeLastName")]
    public string EmployeeLastName { get; init; } = string.Empty;
}

public class CostCodeInfo
{
    [JsonPropertyName("costCodeId")]
    public Guid CostCodeId { get; init; }

    [JsonPropertyName("costCodeCode")]
    public string CostCodeCode { get; init; } = string.Empty;

    [JsonPropertyName("costCodeDescription")]
    public string CostCodeDescription { get; init; } = string.Empty;
}

public class BusinessUnitCostType
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("code")]
    public string Code { get; init; } = string.Empty;

    [JsonPropertyName("businessUnitId")]
    public Guid BusinessUnitId { get; init; }

    [JsonPropertyName("description")]
    public string Description { get; init; } = string.Empty;

    [JsonPropertyName("isDeleted")]
    public bool IsDeleted { get; init; }
}

public class CostCodeTransactionAdjustmentResponse
{
    [JsonPropertyName("results")]
    [Required]
    public CostCodeTransactionAdjustmentDataObject[] Results { get; init; } = Array.Empty<CostCodeTransactionAdjustmentDataObject>();

    [JsonPropertyName("metadata")]
    [Required]
    public CostCodeTransactionAdjustmentMetadata Metadata { get; init; } = new();
}

public class CostCodeTransactionAdjustmentMetadata
{
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; init; }
}