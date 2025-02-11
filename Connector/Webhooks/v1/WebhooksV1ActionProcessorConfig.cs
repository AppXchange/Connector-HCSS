namespace Connector.Webhooks.v1;
using Connector.Webhooks.v1.HeavyJobSubscription.Create;
using Connector.Webhooks.v1.HeavyJobSubscription.Delete;
using Connector.Webhooks.v1.HeavyJobSubscription.Update;
using Connector.Webhooks.v1.PreConSubscription.Create;
using Connector.Webhooks.v1.PreConSubscription.Delete;
using Connector.Webhooks.v1.PreConSubscription.Update;
using Connector.Webhooks.v1.SetupsSubscription.Create;
using Connector.Webhooks.v1.SetupsSubscription.Delete;
using Connector.Webhooks.v1.SetupsSubscription.Update;
using Json.Schema.Generation;
using Xchange.Connector.SDK.Action;

/// <summary>
/// Configuration for the Action Processor for this module. This configuration will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// The schema will be used for validation at runtime to make sure the configurations are properly formed. 
/// The schema also helps provide integrators more information for what the values are intended to be.
/// </summary>
[Title("Webhooks V1 Action Processor Configuration")]
[Description("Configuration of the data object actions for the module.")]
public class WebhooksV1ActionProcessorConfig
{
    // Action Handler configuration
    public DefaultActionHandlerConfig CreateSetupsSubscriptionConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateSetupsSubscriptionConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteSetupsSubscriptionConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreatePreConSubscriptionConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdatePreConSubscriptionConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeletePreConSubscriptionConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateHeavyJobSubscriptionConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateHeavyJobSubscriptionConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteHeavyJobSubscriptionConfig { get; set; } = new();
}