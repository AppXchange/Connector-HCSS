namespace Connector.Setups.v1;
using Connector.Setups.v1.AccountingTemplate;
using Connector.Setups.v1.BulkCostCode;
using Connector.Setups.v1.BusinessUnit;
using Connector.Setups.v1.BusinessUnitDefault;
using Connector.Setups.v1.CostCode;
using Connector.Setups.v1.Employee;
using Connector.Setups.v1.Equipment;
using Connector.Setups.v1.Job;
using Connector.Setups.v1.PayClass;
using Connector.Setups.v1.RateSet;
using Connector.Setups.v1.RateSetCostAdjustment;
using Connector.Setups.v1.RateSetEquipment;
using Connector.Setups.v1.RateSetGroup;
using Connector.Setups.v1.RateSetPayClass;
using ESR.Hosting.CacheWriter;
using Json.Schema.Generation;

/// <summary>
/// Configuration for the Cache writer for this module. This configuration will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// The schema will be used for validation at runtime to make sure the configurations are properly formed. 
/// The schema also helps provide integrators more information for what the values are intended to be.
/// </summary>
[Title("Setups V1 Cache Writer Configuration")]
[Description("Configuration of the data object caches for the module.")]
public class SetupsV1CacheWriterConfig
{
    // Data Reader configuration
    public CacheWriterObjectConfig AccountingTemplateConfig { get; set; } = new();
    public CacheWriterObjectConfig BulkCostCodeConfig { get; set; } = new();
    public CacheWriterObjectConfig BusinessUnitConfig { get; set; } = new();
    public CacheWriterObjectConfig BusinessUnitDefaultConfig { get; set; } = new();
    public CacheWriterObjectConfig CostCodeConfig { get; set; } = new();
    public CacheWriterObjectConfig EmployeeConfig { get; set; } = new();
    public CacheWriterObjectConfig EquipmentConfig { get; set; } = new();
    public CacheWriterObjectConfig JobConfig { get; set; } = new();
    public CacheWriterObjectConfig PayClassConfig { get; set; } = new();
    public CacheWriterObjectConfig RateSetConfig { get; set; } = new();
    public CacheWriterObjectConfig RateSetPayClassConfig { get; set; } = new();
    public CacheWriterObjectConfig RateSetEquipmentConfig { get; set; } = new();
    public CacheWriterObjectConfig RateSetCostAdjustmentConfig { get; set; } = new();
    public CacheWriterObjectConfig RateSetGroupConfig { get; set; } = new();
}