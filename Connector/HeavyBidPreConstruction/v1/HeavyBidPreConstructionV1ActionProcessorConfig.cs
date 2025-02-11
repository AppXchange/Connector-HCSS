namespace Connector.HeavyBidPreConstruction.v1;
using Connector.HeavyBidPreConstruction.v1.Project.Create;
using Connector.HeavyBidPreConstruction.v1.Project.Delete;
using Connector.HeavyBidPreConstruction.v1.Project.PartialChange;
using Connector.HeavyBidPreConstruction.v1.Project.Update;
using Connector.HeavyBidPreConstruction.v1.Projects.Create;
using Connector.HeavyBidPreConstruction.v1.Projects.Delete;
using Connector.HeavyBidPreConstruction.v1.Reports.Create;
using Connector.HeavyBidPreConstruction.v1.Schema.Update;
using Json.Schema.Generation;
using Xchange.Connector.SDK.Action;

/// <summary>
/// Configuration for the Action Processor for this module. This configuration will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// The schema will be used for validation at runtime to make sure the configurations are properly formed. 
/// The schema also helps provide integrators more information for what the values are intended to be.
/// </summary>
[Title("HeavyBidPreConstruction V1 Action Processor Configuration")]
[Description("Configuration of the data object actions for the module.")]
public class HeavyBidPreConstructionV1ActionProcessorConfig
{
    // Action Handler configuration
    public DefaultActionHandlerConfig CreateProjectConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateProjectConfig { get; set; } = new();
    public DefaultActionHandlerConfig PartialChangeProjectConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteProjectConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateProjectsConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteProjectsConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateReportsConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateSchemaConfig { get; set; } = new();
}