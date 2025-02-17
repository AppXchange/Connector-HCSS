namespace Connector.HeavyJob.v1.JobsAdvanced;

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
[Description("Represents a job in HeavyJob with advanced filtering")]
public class JobsAdvancedDataObject
{
    [JsonPropertyName("id")]
    [Description("The master id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("legacyId")]
    [Description("The legacy system ID. Primarily for internal HJ usage")]
    [Required]
    public required Guid LegacyId { get; init; }

    [JsonPropertyName("code")]
    [Description("The code (user-specified shorthand)")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("description")]
    [Description("An optional description")]
    public string? Description { get; init; }

    [JsonPropertyName("createdDate")]
    [Description("The created date time")]
    public DateTime? CreatedDate { get; init; }

    [JsonPropertyName("payItemSetupType")]
    [Description("The pay item setup type")]
    public string PayItemSetupType { get; init; } = "costCodeDriven";

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit guid")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("status")]
    [Description("The job status")]
    [Required]
    public required string Status { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Whether the job is deleted")]
    public bool IsDeleted { get; init; }

    [JsonPropertyName("latitude")]
    [Description("The job latitude")]
    public double? Latitude { get; init; }

    [JsonPropertyName("longitude")]
    [Description("The job longitude")]
    public double? Longitude { get; init; }

    [JsonPropertyName("startofpayweek")]
    [Description("The start of pay week")]
    public string StartOfPayWeek { get; init; } = "monday";

    [JsonPropertyName("truckingCostTypeId")]
    [Description("The job's trucking cost type id for non-web-only company")]
    public Guid? TruckingCostTypeId { get; init; }

    [JsonPropertyName("jobNote")]
    [Description("The note for the job")]
    public string? JobNote { get; init; }

    [JsonPropertyName("relatedEstimateCodes")]
    [Description("The related estimate codes for the job")]
    public string[]? RelatedEstimateCodes { get; init; }

    [JsonPropertyName("address1")]
    [Description("The street address (e.g., 123 Main St)")]
    public string? Address1 { get; init; }

    [JsonPropertyName("address2")]
    [Description("The secondary address info (suite, apartment, PO box numbers etc.)")]
    public string? Address2 { get; init; }

    [JsonPropertyName("city")]
    [Description("The city")]
    public string? City { get; init; }

    [JsonPropertyName("state")]
    [Description("The state abbreviation")]
    [MaxLength(2)]
    public string? State { get; init; }

    [JsonPropertyName("zip")]
    [Description("The zip code")]
    public string? Zip { get; init; }

    [JsonPropertyName("country")]
    [Description("The country")]
    public string? Country { get; init; }
}