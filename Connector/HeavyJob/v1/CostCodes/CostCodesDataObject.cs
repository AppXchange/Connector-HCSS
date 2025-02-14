namespace Connector.HeavyJob.v1.CostCodes;

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
[Description("Represents a cost code in HeavyJob")]
public class CostCodesDataObject
{
    [JsonPropertyName("id")]
    [Description("The cost code ID")]
    [Required]
    public Guid Id { get; init; }

    [JsonPropertyName("code")]
    [Description("The cost code code")]
    [Required]
    public string Code { get; init; } = string.Empty;

    [JsonPropertyName("description")]
    [Description("The cost code description")]
    [Required]
    public string Description { get; init; } = string.Empty;

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit ID")]
    [Required]
    public Guid BusinessUnitId { get; init; }

    [JsonPropertyName("businessUnitCode")]
    [Description("The business unit code")]
    public string BusinessUnitCode { get; init; } = string.Empty;

    [JsonPropertyName("jobId")]
    [Description("The job ID")]
    public Guid JobId { get; init; }

    [JsonPropertyName("jobCode")]
    [Description("The job code")]
    public string JobCode { get; init; } = string.Empty;

    [JsonPropertyName("isHiddenFromMobile")]
    [Description("Whether the cost code is hidden from mobile")]
    public bool IsHiddenFromMobile { get; init; }

    [JsonPropertyName("quantity")]
    [Description("The quantity")]
    public double Quantity { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The unit of measure")]
    public string? UnitOfMeasure { get; init; }

    [JsonPropertyName("status")]
    [Description("The status")]
    public string Status { get; init; } = string.Empty;

    [JsonPropertyName("isDeleted")]
    [Description("Whether the cost code is deleted")]
    public bool IsDeleted { get; init; }

    [JsonPropertyName("accountingCode")]
    [Description("The accounting code")]
    public string? AccountingCode { get; init; }
}

public class CostCodesResponse
{
    [JsonPropertyName("results")]
    [Required]
    public CostCodesDataObject[] Results { get; init; } = Array.Empty<CostCodesDataObject>();

    [JsonPropertyName("metadata")]
    [Required]
    public CostCodesMetadata Metadata { get; init; } = new();
}

public class CostCodesMetadata
{
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; init; }
}