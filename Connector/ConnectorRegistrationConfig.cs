using System.Text.Json.Serialization;
using Connector.Connections;
using Connector.Connections.HeavyBidEstimateConfig;

namespace Connector;

/// <summary>
/// Contains configuration values necessary for the HCSS connector.
/// </summary>
public class ConnectorRegistrationConfig
{
    /// <summary>
    /// Default timeout in seconds for API requests
    /// </summary>
    [JsonPropertyName("requestTimeoutSeconds")]
    public int RequestTimeoutSeconds { get; set; } = 30;

    /// <summary>
    /// Maximum number of retry attempts for failed requests
    /// </summary>
    [JsonPropertyName("maxRetryAttempts")]
    public int MaxRetryAttempts { get; set; } = 3;

    /// <summary>
    /// Available API modules configuration. By default, all modules are disabled and must be explicitly enabled.
    /// </summary>
    [JsonPropertyName("enabledModules")]
    public EnabledModules EnabledModules { get; set; } = new EnabledModules();

    /// <summary>
    /// Rate limiting configuration
    /// </summary>
    [JsonPropertyName("rateLimiting")]
    public RateLimitingConfig RateLimiting { get; set; } = new RateLimitingConfig();

    /// <summary>
    /// Connection configuration
    /// </summary>
    [JsonPropertyName("connectionConfig")]
    public ConnectionConfig? ConnectionConfig { get; set; }
    
    /// <summary>
    /// HeavyBidEstimate configuration
    /// </summary>
    [JsonPropertyName("heavyBidEstimate")]
    public HeavyBidEstimateConfig? HeavyBidEstimate { get; set; }
}

public class EnabledModules
{
    [JsonPropertyName("heavyJob")]
    public bool HeavyJob { get; set; } = false;

    [JsonPropertyName("heavyBidEstimate")]
    public bool HeavyBidEstimate { get; set; } = false;

    [JsonPropertyName("heavyBidPreConstruction")]
    public bool HeavyBidPreConstruction { get; set; } = false;

    [JsonPropertyName("skills")]
    public bool Skills { get; set; } = false;

    [JsonPropertyName("safety")]
    public bool Safety { get; set; } = false;

    [JsonPropertyName("equipment360")]
    public bool Equipment360 { get; set; } = false;

    [JsonPropertyName("telematics")]
    public bool Telematics { get; set; } = false;

    [JsonPropertyName("setups")]
    public bool Setups { get; set; } = false;

    [JsonPropertyName("users")]
    public bool Users { get; set; } = false;

    [JsonPropertyName("contacts")]
    public bool Contacts { get; set; } = false;

    [JsonPropertyName("attachments")]
    public bool Attachments { get; set; } = false;

    [JsonPropertyName("webhooks")]
    public bool Webhooks { get; set; } = false;

    /// <summary>
    /// Validates that at least one module is enabled
    /// </summary>
    public bool HasEnabledModules()
    {
        return HeavyJob || HeavyBidEstimate || HeavyBidPreConstruction || 
               Skills || Safety || Equipment360 || Telematics || 
               Setups || Users || Contacts || Attachments || Webhooks;
    }
}

public class RateLimitingConfig
{
    /// <summary>
    /// Maximum number of requests per minute
    /// </summary>
    [JsonPropertyName("requestsPerMinute")]
    public int RequestsPerMinute { get; set; } = 300;

    /// <summary>
    /// Maximum concurrent requests
    /// </summary>
    [JsonPropertyName("maxConcurrentRequests")]
    public int MaxConcurrentRequests { get; set; } = 10;

    /// <summary>
    /// Delay in milliseconds between retries
    /// </summary>
    [JsonPropertyName("retryDelayMs")]
    public int RetryDelayMs { get; set; } = 1000;
}
