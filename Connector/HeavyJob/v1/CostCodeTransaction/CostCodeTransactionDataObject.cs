namespace Connector.HeavyJob.v1.CostCodeTransaction;

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
[PrimaryKey("timeCardCostCodeId", nameof(TimeCardCostCodeId))]
[Description("Represents a cost code time card transaction in HeavyJob")]
public class CostCodeTransactionDataObject
{
    [JsonPropertyName("timeCardCostCodeId")]
    [Description("The time card cost code ID")]
    [Required]
    public Guid TimeCardCostCodeId { get; init; }

    [JsonPropertyName("timeCardId")]
    [Description("The time card ID")]
    public Guid TimeCardId { get; init; }

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

    [JsonPropertyName("timeCardShift")]
    [Description("The time card shift")]
    public int TimeCardShift { get; init; }

    [JsonPropertyName("isTm")]
    [Description("Whether this is a T&M transaction")]
    public bool IsTm { get; init; }

    [JsonPropertyName("isRework")]
    [Description("Whether this is rework")]
    public bool IsRework { get; init; }

    [JsonPropertyName("isMseDriven")]
    [Description("Whether this is MSE driven")]
    public bool IsMseDriven { get; init; }

    [JsonPropertyName("quantity")]
    [Description("The quantity")]
    public double Quantity { get; init; }

    [JsonPropertyName("slot")]
    [Description("The slot number")]
    public int Slot { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The unit of measure")]
    public string UnitOfMeasure { get; init; } = string.Empty;

    [JsonPropertyName("laborHours")]
    [Description("The labor hours")]
    public double LaborHours { get; init; }

    [JsonPropertyName("equipmentHours")]
    [Description("The equipment hours")]
    public double EquipmentHours { get; init; }

    [JsonPropertyName("laborCost")]
    [Description("The labor cost")]
    public double LaborCost { get; init; }

    [JsonPropertyName("equipmentCost")]
    [Description("The equipment cost")]
    public double EquipmentCost { get; init; }

    [JsonPropertyName("publicNote")]
    [Description("The public note")]
    public string PublicNote { get; init; } = string.Empty;

    [JsonPropertyName("internalNote")]
    [Description("The internal note")]
    public string InternalNote { get; init; } = string.Empty;

    [JsonPropertyName("tags")]
    [Description("The transaction tags")]
    public TransactionTag[] Tags { get; init; } = Array.Empty<TransactionTag>();

    [JsonPropertyName("syncTimestamp")]
    [Description("When the transaction was last synced")]
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

public class TransactionTag
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("code")]
    public string Code { get; init; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; init; } = string.Empty;

    [JsonPropertyName("note")]
    public string Note { get; init; } = string.Empty;

    [JsonPropertyName("groupId")]
    public Guid GroupId { get; init; }

    [JsonPropertyName("groupCode")]
    public string GroupCode { get; init; } = string.Empty;
}

public class CostCodeTransactionResponse
{
    [JsonPropertyName("results")]
    [Required]
    public CostCodeTransactionDataObject[] Results { get; init; } = Array.Empty<CostCodeTransactionDataObject>();

    [JsonPropertyName("metadata")]
    [Required]
    public CostCodeTransactionMetadata Metadata { get; init; } = new();
}

public class CostCodeTransactionMetadata
{
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; init; }
}