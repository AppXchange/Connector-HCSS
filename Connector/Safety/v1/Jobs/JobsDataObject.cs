namespace Connector.Safety.v1.Jobs;

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
[Description("Represents a job in Safety")]
public class JobsDataObject
{
    [JsonPropertyName("id")]
    [Description("The job id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit id that the job belongs to")]
    public Guid? BusinessUnitId { get; init; }

    [JsonPropertyName("code")]
    [Description("The job code")]
    public string? Code { get; init; }

    [JsonPropertyName("description")]
    [Description("The job description")]
    public string? Description { get; init; }

    [JsonPropertyName("status")]
    [Description("The job status")]
    public string? Status { get; init; }

    [JsonPropertyName("latitude")]
    [Description("The job location latitude")]
    [Maximum(90)]
    [Minimum(-90)]
    public double? Latitude { get; init; }

    [JsonPropertyName("longitude")]
    [Description("The job location longitude")]
    [Maximum(180)]
    [Minimum(-180)]
    public double? Longitude { get; init; }

    [JsonPropertyName("locationTypeId")]
    [Description("The job location type id")]
    public int? LocationTypeId { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Whether the job is deleted")]
    public bool IsDeleted { get; init; }

    [JsonPropertyName("startDate")]
    [Description("The job start date")]
    public DateTime? StartDate { get; init; }

    [JsonPropertyName("endDate")]
    [Description("The job end date")]
    public DateTime? EndDate { get; init; }
}