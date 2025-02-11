namespace Connector.Setups.v1;
using Connector.Setups.v1.BulkCostCode.Create;
using Connector.Setups.v1.BusinessUnit.Create;
using Connector.Setups.v1.CostCode.Create;
using Connector.Setups.v1.CostCode.Update;
using Connector.Setups.v1.Employee.Create;
using Connector.Setups.v1.Employee.Update;
using Connector.Setups.v1.Equipment.Create;
using Connector.Setups.v1.Equipment.Update;
using Connector.Setups.v1.Job.Create;
using Connector.Setups.v1.Job.Update;
using Connector.Setups.v1.PayClass.Create;
using Connector.Setups.v1.PayClass.Update;
using Connector.Setups.v1.RateSet.Create;
using Connector.Setups.v1.RateSet.Update;
using Connector.Setups.v1.RateSetCostAdjustment.Create;
using Connector.Setups.v1.RateSetCostAdjustment.Update;
using Connector.Setups.v1.RateSetEquipment.Create;
using Connector.Setups.v1.RateSetEquipment.Update;
using Connector.Setups.v1.RateSetGroup.Create;
using Connector.Setups.v1.RateSetGroup.Update;
using Connector.Setups.v1.RateSetPayClass.Create;
using Connector.Setups.v1.RateSetPayClass.Update;
using Json.Schema.Generation;
using Xchange.Connector.SDK.Action;

/// <summary>
/// Configuration for the Action Processor for this module. This configuration will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// The schema will be used for validation at runtime to make sure the configurations are properly formed. 
/// The schema also helps provide integrators more information for what the values are intended to be.
/// </summary>
[Title("Setups V1 Action Processor Configuration")]
[Description("Configuration of the data object actions for the module.")]
public class SetupsV1ActionProcessorConfig
{
    // Action Handler configuration
    public DefaultActionHandlerConfig CreateBulkCostCodeConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateBusinessUnitConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateCostCodeConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateCostCodeConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateEmployeeConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateEmployeeConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateEquipmentConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateEquipmentConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateJobConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateJobConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreatePayClassConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdatePayClassConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateRateSetConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateRateSetConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateRateSetPayClassConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateRateSetPayClassConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateRateSetEquipmentConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateRateSetEquipmentConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateRateSetCostAdjustmentConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateRateSetCostAdjustmentConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateRateSetGroupConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateRateSetGroupConfig { get; set; } = new();
}