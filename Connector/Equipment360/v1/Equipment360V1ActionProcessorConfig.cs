namespace Connector.Equipment360.v1;
using Connector.Equipment360.v1.CustomField.Create;
using Connector.Equipment360.v1.Employee.Create;
using Connector.Equipment360.v1.Employee.Update;
using Connector.Equipment360.v1.Equipment.Create;
using Connector.Equipment360.v1.Equipment.Update;
using Connector.Equipment360.v1.EquipmentTransfer.Update;
using Connector.Equipment360.v1.EquipmentType.Create;
using Connector.Equipment360.v1.Invoice.Create;
using Connector.Equipment360.v1.Invoice.Update;
using Connector.Equipment360.v1.Jobs.Create;
using Connector.Equipment360.v1.Jobs.Update;
using Connector.Equipment360.v1.Locations.Create;
using Connector.Equipment360.v1.Locations.Update;
using Connector.Equipment360.v1.MaintenanceRequest.Create;
using Connector.Equipment360.v1.MeterReading.Create;
using Connector.Equipment360.v1.PartCostEntries.Create;
using Connector.Equipment360.v1.PartCostEntry.Create;
using Connector.Equipment360.v1.PartInventory.Create;
using Connector.Equipment360.v1.Parts.Update;
using Connector.Equipment360.v1.PurchaseOrder.Create;
using Connector.Equipment360.v1.PurchaseOrderDetails.Create;
using Connector.Equipment360.v1.PurchaseOrderNotes.Create;
using Connector.Equipment360.v1.SubletVendorCostEntries.Create;
using Connector.Equipment360.v1.SubletVendorCostEntry.Create;
using Connector.Equipment360.v1.Vendors.Create;
using Connector.Equipment360.v1.Vendors.Update;
using Connector.Equipment360.v1.WorkOrder.Create;
using Connector.Equipment360.v1.WorkOrder.Update;
using Connector.Equipment360.v1.WorkOrderNotes.Create;
using Json.Schema.Generation;
using Xchange.Connector.SDK.Action;

/// <summary>
/// Configuration for the Action Processor for this module. This configuration will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// The schema will be used for validation at runtime to make sure the configurations are properly formed. 
/// The schema also helps provide integrators more information for what the values are intended to be.
/// </summary>
[Title("Equipment360 V1 Action Processor Configuration")]
[Description("Configuration of the data object actions for the module.")]
public class Equipment360V1ActionProcessorConfig
{
    // Action Handler configuration
    public DefaultActionHandlerConfig CreateCustomFieldConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateEmployeeConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateEmployeeConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateEquipmentConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateEquipmentConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateEquipmentTransferConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateEquipmentTypeConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateInvoiceConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateInvoiceConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateJobsConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateJobsConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateLocationsConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateLocationsConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateMaintenanceRequestConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateMeterReadingConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdatePartsConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreatePartCostEntryConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreatePartCostEntriesConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreatePartInventoryConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreatePurchaseOrderConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreatePurchaseOrderDetailsConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreatePurchaseOrderNotesConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateSubletVendorCostEntryConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateSubletVendorCostEntriesConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateVendorsConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateVendorsConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateWorkOrderConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateWorkOrderConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateWorkOrderNotesConfig { get; set; } = new();
}