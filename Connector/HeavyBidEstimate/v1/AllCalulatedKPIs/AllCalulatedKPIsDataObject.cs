namespace Connector.HeavyBidEstimate.v1.AllCalulatedKPIs;

using Json.Schema.Generation;
using System;
using System.Collections.Generic;
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
[Description("Represents a KPI (Key Performance Indicator) in HeavyBid Estimate")]
public class AllCalulatedKPIsDataObject
{
    [JsonPropertyName("id")]
    [Description("The KPI id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    [Description("KPI name")]
    public string? Name { get; init; }

    [JsonPropertyName("leftField")]
    [Description("Left field name")]
    public string? LeftField { get; init; }

    [JsonPropertyName("rightField")]
    [Description("Right field name")]
    public string? RightField { get; init; }

    [JsonPropertyName("operator")]
    [Description("Operator symbol")]
    public string? Operator { get; init; }

    [JsonPropertyName("values")]
    [Description("Historical values")]
    public List<decimal>? Values { get; init; }

    [JsonPropertyName("stats")]
    [Description("Statistical calculations")]
    public KpiStats? Stats { get; init; }

    [JsonPropertyName("currentValues")]
    [Description("Current calculation values")]
    public KpiCurrentValues? CurrentValues { get; init; }

    [JsonPropertyName("resultDecimals")]
    [Description("Number of decimal places for result")]
    public int ResultDecimals { get; init; }

    [JsonPropertyName("rightDecimals")]
    [Description("Number of decimal places for right field")]
    public int RightDecimals { get; init; }

    [JsonPropertyName("leftDecimals")]
    [Description("Number of decimal places for left field")]
    public int LeftDecimals { get; init; }

    [JsonPropertyName("originType")]
    [Description("Origin type")]
    public int OriginType { get; init; }
}

public class KpiStats
{
    [JsonPropertyName("iqr")]
    public decimal Iqr { get; init; }

    [JsonPropertyName("min")]
    public decimal Min { get; init; }

    [JsonPropertyName("max")]
    public decimal Max { get; init; }

    [JsonPropertyName("q1")]
    public decimal Q1 { get; init; }

    [JsonPropertyName("q2")]
    public decimal Q2 { get; init; }

    [JsonPropertyName("q3")]
    public decimal Q3 { get; init; }

    [JsonPropertyName("lower")]
    public decimal Lower { get; init; }

    [JsonPropertyName("lowerActual")]
    public decimal LowerActual { get; init; }

    [JsonPropertyName("upper")]
    public decimal Upper { get; init; }

    [JsonPropertyName("upperActual")]
    public decimal UpperActual { get; init; }
}

public class KpiCurrentValues
{
    [JsonPropertyName("result")]
    public decimal Result { get; init; }

    [JsonPropertyName("left")]
    public decimal Left { get; init; }

    [JsonPropertyName("right")]
    public decimal Right { get; init; }
}