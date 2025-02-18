namespace Connector.Safety.v1;
using Connector.Safety.v1.Alerts.Create;
using Connector.Safety.v1.Alerts.Delete;
using Connector.Safety.v1.Alerts.Update;
using Connector.Safety.v1.Incident.Update;
// using Connector.Safety.v1.UserAccessGroups.Create;
using Connector.Safety.v1.UserAccessGroups.Update;
using Json.Schema.Generation;
using Xchange.Connector.SDK.Action;

/// <summary>
/// Configuration for the Action Processor for this module. This configuration will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// The schema will be used for validation at runtime to make sure the configurations are properly formed. 
/// The schema also helps provide integrators more information for what the values are intended to be.
/// </summary>
[Title("Safety V1 Action Processor Configuration")]
[Description("Configuration of the data object actions for the module.")]
public class SafetyV1ActionProcessorConfig
{
    // Action Handler configuration
    public DefaultActionHandlerConfig UpdateAlertsConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateAlertsConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteAlertsConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateIncidentConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateUserAccessGroupsConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateUserAccessGroupsConfig { get; set; } = new();
}