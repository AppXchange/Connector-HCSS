namespace Connector.HeavyJob.v1.VendorContracts;

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
[Description("Represents a vendor contract in HeavyJob")]
public class VendorContractsDataObject
{
    [JsonPropertyName("id")]
    [Description("The vendor contract id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("jobId")]
    [Description("The job id")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("job")]
    [Description("A POCO that represents a job's basic information")]
    [Required]
    public required JobCompactRead Job { get; init; }

    [JsonPropertyName("vendorContract")]
    [Description("The vendor contract number")]
    public string? VendorContract { get; init; }

    [JsonPropertyName("description")]
    [Description("The vendor contract description")]
    public string? Description { get; init; }

    [JsonPropertyName("orderStatus")]
    [Description("The order status")]
    [Required]
    public required string OrderStatus { get; init; }

    [JsonPropertyName("dateIssued")]
    [Description("The date vendor contract was issued")]
    public DateTime? DateIssued { get; init; }

    [JsonPropertyName("vendorId")]
    [Description("The vendor id")]
    public Guid? VendorId { get; init; }

    [JsonPropertyName("vendor")]
    [Description("A POCO that represents a slice of vendor state returned by the API")]
    public VendorCompactRead? Vendor { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Flags if the vendor contract is deleted")]
    public bool IsDeleted { get; init; }
}

public class JobCompactRead
{
    [JsonPropertyName("jobId")]
    [Description("The job guid")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("jobCode")]
    [Description("The job's code")]
    [Required]
    public required string JobCode { get; init; }

    [JsonPropertyName("jobDescription")]
    [Description("The job's description")]
    [Required]
    public required string JobDescription { get; init; }
}

public class VendorCompactRead
{
    [JsonPropertyName("id")]
    [Description("Vendor ID")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    [Description("The name of the vendor")]
    [Required]
    public required string Name { get; init; }

    [JsonPropertyName("description")]
    [Description("The description of the vendor")]
    public string? Description { get; init; }
}