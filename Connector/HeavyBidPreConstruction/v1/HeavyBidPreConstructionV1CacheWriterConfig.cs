namespace Connector.HeavyBidPreConstruction.v1;
using Connector.HeavyBidPreConstruction.v1.BusinessUnit;
using Connector.HeavyBidPreConstruction.v1.Project;
using Connector.HeavyBidPreConstruction.v1.Projects;
using Connector.HeavyBidPreConstruction.v1.Reports;
using Connector.HeavyBidPreConstruction.v1.Schema;
using Connector.HeavyBidPreConstruction.v1.Schemas;
using ESR.Hosting.CacheWriter;
using Json.Schema.Generation;

/// <summary>
/// Configuration for the Cache writer for this module. This configuration will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// The schema will be used for validation at runtime to make sure the configurations are properly formed. 
/// The schema also helps provide integrators more information for what the values are intended to be.
/// </summary>
[Title("HeavyBidPreConstruction V1 Cache Writer Configuration")]
[Description("Configuration of the data object caches for the module.")]
public class HeavyBidPreConstructionV1CacheWriterConfig
{
    // Data Reader configuration
    public CacheWriterObjectConfig BusinessUnitConfig { get; set; } = new();
    public CacheWriterObjectConfig ProjectsConfig { get; set; } = new();
    public CacheWriterObjectConfig ProjectConfig { get; set; } = new();
    public CacheWriterObjectConfig ReportsConfig { get; set; } = new();
    public CacheWriterObjectConfig SchemasConfig { get; set; } = new();
    public CacheWriterObjectConfig SchemaConfig { get; set; } = new();
}