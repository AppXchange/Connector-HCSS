namespace Connector.HeavyJob.v1.JobEquipment;

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
[Description("Represents a job-equipment relationship in HeavyJob")]
public class JobEquipmentDataObject
{
    [JsonPropertyName("id")]
    [Description("The job-equipment id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit id")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("businessUnitCode")]
    [Description("The business unit code")]
    [Required]
    public required string BusinessUnitCode { get; init; }

    [JsonPropertyName("jobId")]
    [Description("The job id")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("jobCode")]
    [Description("The job code")]
    [Required]
    public required string JobCode { get; init; }

    [JsonPropertyName("equipmentId")]
    [Description("The equipment id")]
    [Required]
    public required Guid EquipmentId { get; init; }

    [JsonPropertyName("equipmentCode")]
    [Description("The equipment code")]
    [Required]
    public required string EquipmentCode { get; init; }

    [JsonPropertyName("equipmentDescription")]
    [Description("The equipment description")]
    public string? EquipmentDescription { get; init; }

    [JsonPropertyName("operatorPayClassId")]
    [Description("The equipment operator pay class id")]
    public Guid? OperatorPayClassId { get; init; }

    [JsonPropertyName("operatorPayClassCode")]
    [Description("The equipment operator pay class code")]
    public string? OperatorPayClassCode { get; init; }

    [JsonPropertyName("isActive")]
    [Description("Whether or not the relationship is active")]
    public bool IsActive { get; init; }
}