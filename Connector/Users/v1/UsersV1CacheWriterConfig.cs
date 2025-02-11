namespace Connector.Users.v1;
using Connector.Users.v1.BusinessUnits;
using Connector.Users.v1.Jobs;
using Connector.Users.v1.Roles;
using Connector.Users.v1.SubscriptionGroups;
using Connector.Users.v1.User;
using Connector.Users.v1.Username;
using Connector.Users.v1.Users;
using ESR.Hosting.CacheWriter;
using Json.Schema.Generation;

/// <summary>
/// Configuration for the Cache writer for this module. This configuration will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// The schema will be used for validation at runtime to make sure the configurations are properly formed. 
/// The schema also helps provide integrators more information for what the values are intended to be.
/// </summary>
[Title("Users V1 Cache Writer Configuration")]
[Description("Configuration of the data object caches for the module.")]
public class UsersV1CacheWriterConfig
{
    // Data Reader configuration
    public CacheWriterObjectConfig BusinessUnitsConfig { get; set; } = new();
    public CacheWriterObjectConfig JobsConfig { get; set; } = new();
    public CacheWriterObjectConfig RolesConfig { get; set; } = new();
    public CacheWriterObjectConfig SubscriptionGroupsConfig { get; set; } = new();
    public CacheWriterObjectConfig UsersConfig { get; set; } = new();
    public CacheWriterObjectConfig UserConfig { get; set; } = new();
    public CacheWriterObjectConfig UsernameConfig { get; set; } = new();
}