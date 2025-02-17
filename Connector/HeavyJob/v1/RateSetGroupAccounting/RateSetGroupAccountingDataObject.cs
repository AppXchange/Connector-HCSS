namespace Connector.HeavyJob.v1.RateSetGroupAccounting;

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
[PrimaryKey("accountingValueId", nameof(AccountingValueId))]
[Description("Represents a rate set group accounting value in HeavyJob")]
public class RateSetGroupAccountingDataObject
{
    [JsonPropertyName("value")]
    [Description("The value")]
    public string? Value { get; init; }

    [JsonPropertyName("description")]
    [Description("The custom description of the accounting value")]
    public string? Description { get; init; }

    [JsonPropertyName("code")]
    [Description("The code")]
    public string? Code { get; init; }

    [JsonPropertyName("accountingValueId")]
    [Description("The Id for the accounting value")]
    [Required]
    public required Guid AccountingValueId { get; init; }

    [JsonPropertyName("parentId")]
    [Description("The Id of the parent entity")]
    public Guid? ParentId { get; init; }

    [JsonPropertyName("dataType")]
    [Description("The data type")]
    [Required]
    public required string DataType { get; init; }
}