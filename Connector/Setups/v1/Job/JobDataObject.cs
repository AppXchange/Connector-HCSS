namespace Connector.Setups.v1.Job;

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
[Description("Represents a job in HCSS")]
public class JobDataObject
{
    [JsonPropertyName("code")]
    [Description("Gets the job code")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("businessUnitCode")]
    [Description("Gets the business unit")]
    [Required]
    public required string BusinessUnitCode { get; init; }

    [JsonPropertyName("status")]
    [Description("Gets the status. Items Enum: \"A\" for Active, \"C\" for Completed, \"I\" for Inactive")]
    [Required]
    public required string Status { get; init; }

    [JsonPropertyName("id")]
    [Description("The Id of the job")]
    public Guid? Id { get; init; }

    [JsonPropertyName("description")]
    [Description("The description")]
    public string? Description { get; init; }

    [JsonPropertyName("note")]
    [Description("The note")]
    public string? Note { get; init; }

    [JsonPropertyName("address")]
    [Description("The address")]
    public string? Address { get; init; }

    [JsonPropertyName("address2")]
    [Description("The address2 field")]
    public string? Address2 { get; init; }

    [JsonPropertyName("city")]
    [Description("The city")]
    public string? City { get; init; }

    [JsonPropertyName("country")]
    [Description("The country")]
    public string? Country { get; init; }

    [JsonPropertyName("state")]
    [Description("The state")]
    public string? State { get; init; }

    [JsonPropertyName("zipCode")]
    [Description("The zip code")]
    public string? ZipCode { get; init; }

    [JsonPropertyName("laborRateSetGroup")]
    [Description("The labor rateset group name")]
    public string? LaborRateSetGroup { get; init; }

    [JsonPropertyName("equipmentRateSetGroup")]
    [Description("The equipment rateset group name")]
    public string? EquipmentRateSetGroup { get; init; }

    [JsonPropertyName("accountingCode")]
    [Description("The accounting code")]
    public string? AccountingCode { get; init; }

    [JsonPropertyName("accountingState")]
    [Description("The \"StateCode\" accounting field")]
    public string? AccountingState { get; init; }

    [JsonPropertyName("unionClass")]
    [Description("The \"UnionClass\" accounting field")]
    public string? UnionClass { get; init; }

    [JsonPropertyName("unionCode")]
    [Description("The \"Union\" accounting field")]
    public string? UnionCode { get; init; }

    [JsonPropertyName("unionLocal")]
    [Description("The \"UnionLocal\" accounting field")]
    public string? UnionLocal { get; init; }

    [JsonPropertyName("certified")]
    [Description("The \"Certified\" accounting field")]
    public string? Certified { get; init; }

    [JsonPropertyName("company")]
    [Description("The \"Company\" accounting field")]
    public string? Company { get; init; }

    [JsonPropertyName("localTaxCode")]
    [Description("The \"LocalTaxCode\" accounting field")]
    public string? LocalTaxCode { get; init; }

    [JsonPropertyName("location")]
    [Description("The \"Location\" accounting field")]
    public string? Location { get; init; }

    [JsonPropertyName("accountingTemplateName")]
    [Description("The accounting template name")]
    public string? AccountingTemplateName { get; init; }

    [JsonPropertyName("tags")]
    [Description("The job tags")]
    public DisTag[]? Tags { get; init; }

    [JsonPropertyName("premiumFactor")]
    [Description("The premium factor field")]
    public double? PremiumFactor { get; init; }
}

public class DisTag
{
    [JsonPropertyName("group")]
    public string? Group { get; init; }

    [JsonPropertyName("tag")]
    public string? Tag { get; init; }

    [JsonPropertyName("tagDescription")]
    public string? TagDescription { get; init; }

    [JsonPropertyName("id")]
    public Guid? Id { get; init; }
}