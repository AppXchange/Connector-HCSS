namespace Connector.Webhooks.v1;
using Connector.Webhooks.v1.HeavyJobSubscription;
using Connector.Webhooks.v1.HeavyJobWebhooks;
using Connector.Webhooks.v1.PreConSubscription;
using Connector.Webhooks.v1.PreConWebhooks;
using Connector.Webhooks.v1.SetupsSubscription;
using Connector.Webhooks.v1.SetupsWebhooks;
using ESR.Hosting.CacheWriter;
using Json.Schema.Generation;

/// <summary>
/// Configuration for the Cache writer for this module. This configuration will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// The schema will be used for validation at runtime to make sure the configurations are properly formed. 
/// The schema also helps provide integrators more information for what the values are intended to be.
/// </summary>
[Title("Webhooks V1 Cache Writer Configuration")]
[Description("Configuration of the data object caches for the module.")]
public class WebhooksV1CacheWriterConfig
{
    // Data Reader configuration
    public CacheWriterObjectConfig SetupsWebhooksConfig { get; set; } = new();
    public CacheWriterObjectConfig SetupsSubscriptionConfig { get; set; } = new();
    public CacheWriterObjectConfig PreConWebhooksConfig { get; set; } = new();
    public CacheWriterObjectConfig PreConSubscriptionConfig { get; set; } = new();
    public CacheWriterObjectConfig HeavyJobWebhooksConfig { get; set; } = new();
    public CacheWriterObjectConfig HeavyJobSubscriptionConfig { get; set; } = new();
}