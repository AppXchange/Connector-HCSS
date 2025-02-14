using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

public class ConnectionConfig
{
    [JsonPropertyName("businessUnitId")]
    [Description("The business unit ID for HeavyBid operations")]
    public Guid BusinessUnitId { get; set; }

    [JsonPropertyName("estimateId")]
    [Description("The estimate ID for HeavyBid operations")]
    public Guid EstimateId { get; set; }
} 