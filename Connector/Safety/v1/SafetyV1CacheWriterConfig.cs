namespace Connector.Safety.v1;
using Connector.Safety.v1.AccessGroups;
using Connector.Safety.v1.Alerts;
using Connector.Safety.v1.Incident;
using Connector.Safety.v1.IncidentFormTypes;
using Connector.Safety.v1.Incidents;
using Connector.Safety.v1.IncidentV2;
using Connector.Safety.v1.InspectionTypes;
using Connector.Safety.v1.Jobs;
using Connector.Safety.v1.Meetings;
using Connector.Safety.v1.Providers;
using Connector.Safety.v1.UserAccessGroups;
using Connector.Safety.v1.Users;
using ESR.Hosting.CacheWriter;
using Json.Schema.Generation;

/// <summary>
/// Configuration for the Cache writer for this module. This configuration will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// The schema will be used for validation at runtime to make sure the configurations are properly formed. 
/// The schema also helps provide integrators more information for what the values are intended to be.
/// </summary>
[Title("Safety V1 Cache Writer Configuration")]
[Description("Configuration of the data object caches for the module.")]
public class SafetyV1CacheWriterConfig
{
    // Data Reader configuration
    public CacheWriterObjectConfig AccessGroupsConfig { get; set; } = new();
    public CacheWriterObjectConfig AlertsConfig { get; set; } = new();
    public CacheWriterObjectConfig IncidentFormTypesConfig { get; set; } = new();
    public CacheWriterObjectConfig IncidentConfig { get; set; } = new();
    public CacheWriterObjectConfig IncidentsConfig { get; set; } = new();
    public CacheWriterObjectConfig IncidentV2Config { get; set; } = new();
    public CacheWriterObjectConfig InspectionTypesConfig { get; set; } = new();
    public CacheWriterObjectConfig JobsConfig { get; set; } = new();
    public CacheWriterObjectConfig MeetingsConfig { get; set; } = new();
    public CacheWriterObjectConfig ProvidersConfig { get; set; } = new();
    public CacheWriterObjectConfig UserAccessGroupsConfig { get; set; } = new();
    public CacheWriterObjectConfig UsersConfig { get; set; } = new();
}