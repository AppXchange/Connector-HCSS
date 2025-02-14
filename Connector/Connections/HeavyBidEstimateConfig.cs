namespace Connector.Connections.HeavyBidEstimateConfig;

using System;
using System.Text.Json.Serialization;

public class HeavyBidEstimateConfig
{
    [JsonPropertyName("businessUnitId")]
    public Guid BusinessUnitId { get; set; }
} 