namespace Connector.Equipment360.v1;
using Connector.Equipment360.v1.AllEquipment;
using Connector.Equipment360.v1.BusinessUnit;
using Connector.Equipment360.v1.CustomField;
using Connector.Equipment360.v1.CustomFieldCategories;
using Connector.Equipment360.v1.CustomFieldList;
using Connector.Equipment360.v1.Employee;
using Connector.Equipment360.v1.Employees;
using Connector.Equipment360.v1.Equipment;
using Connector.Equipment360.v1.EquipmentTransfer;
using Connector.Equipment360.v1.EquipmentType;
using Connector.Equipment360.v1.FuelCosts;
using Connector.Equipment360.v1.Invoice;
using Connector.Equipment360.v1.Jobs;
using Connector.Equipment360.v1.Locations;
using Connector.Equipment360.v1.MaintenanceRequest;
using Connector.Equipment360.v1.MeterReading;
using Connector.Equipment360.v1.PartCostEntries;
using Connector.Equipment360.v1.PartCostEntry;
using Connector.Equipment360.v1.PartInventory;
using Connector.Equipment360.v1.PartLocations;
using Connector.Equipment360.v1.Parts;
using Connector.Equipment360.v1.PurchaseOrder;
using Connector.Equipment360.v1.PurchaseOrderDetails;
using Connector.Equipment360.v1.PurchaseOrderNotes;
using Connector.Equipment360.v1.PurchaseOrders;
using Connector.Equipment360.v1.SubletVendorCostEntries;
using Connector.Equipment360.v1.SubletVendorCostEntry;
using Connector.Equipment360.v1.Tags;
using Connector.Equipment360.v1.TimeCard;
using Connector.Equipment360.v1.UnitOfMeasure;
using Connector.Equipment360.v1.Vendors;
using Connector.Equipment360.v1.WorkOrder;
using Connector.Equipment360.v1.WorkOrderCosts;
using Connector.Equipment360.v1.WorkOrderCostsDetails;
using Connector.Equipment360.v1.WorkOrderNotes;
using Connector.Equipment360.v1.WorkOrderPurchase;
using Connector.Equipment360.v1.WorkOrders;
using Connector.Equipment360.v1.WorkOrderSchedule;
using ESR.Hosting.CacheWriter;
using Json.Schema.Generation;

/// <summary>
/// Configuration for the Cache writer for this module. This configuration will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// The schema will be used for validation at runtime to make sure the configurations are properly formed. 
/// The schema also helps provide integrators more information for what the values are intended to be.
/// </summary>
[Title("Equipment360 V1 Cache Writer Configuration")]
[Description("Configuration of the data object caches for the module.")]
public class Equipment360V1CacheWriterConfig
{
    // Data Reader configuration
    public CacheWriterObjectConfig BusinessUnitConfig { get; set; } = new();
    public CacheWriterObjectConfig FuelCostsConfig { get; set; } = new();
    public CacheWriterObjectConfig WorkOrderCostsConfig { get; set; } = new();
    public CacheWriterObjectConfig WorkOrderCostsDetailsConfig { get; set; } = new();
    public CacheWriterObjectConfig CustomFieldConfig { get; set; } = new();
    public CacheWriterObjectConfig CustomFieldCategoriesConfig { get; set; } = new();
    public CacheWriterObjectConfig CustomFieldListConfig { get; set; } = new();
    public CacheWriterObjectConfig EmployeeConfig { get; set; } = new();
    public CacheWriterObjectConfig EmployeesConfig { get; set; } = new();
    public CacheWriterObjectConfig EquipmentConfig { get; set; } = new();
    public CacheWriterObjectConfig AllEquipmentConfig { get; set; } = new();
    public CacheWriterObjectConfig EquipmentTransferConfig { get; set; } = new();
    public CacheWriterObjectConfig EquipmentTypeConfig { get; set; } = new();
    public CacheWriterObjectConfig InvoiceConfig { get; set; } = new();
    public CacheWriterObjectConfig JobsConfig { get; set; } = new();
    public CacheWriterObjectConfig LocationsConfig { get; set; } = new();
    public CacheWriterObjectConfig MaintenanceRequestConfig { get; set; } = new();
    public CacheWriterObjectConfig MeterReadingConfig { get; set; } = new();
    public CacheWriterObjectConfig PartsConfig { get; set; } = new();
    public CacheWriterObjectConfig PartLocationsConfig { get; set; } = new();
    public CacheWriterObjectConfig PartCostEntryConfig { get; set; } = new();
    public CacheWriterObjectConfig PartCostEntriesConfig { get; set; } = new();
    public CacheWriterObjectConfig PartInventoryConfig { get; set; } = new();
    public CacheWriterObjectConfig PurchaseOrdersConfig { get; set; } = new();
    public CacheWriterObjectConfig PurchaseOrderConfig { get; set; } = new();
    public CacheWriterObjectConfig PurchaseOrderDetailsConfig { get; set; } = new();
    public CacheWriterObjectConfig PurchaseOrderNotesConfig { get; set; } = new();
    public CacheWriterObjectConfig SubletVendorCostEntryConfig { get; set; } = new();
    public CacheWriterObjectConfig SubletVendorCostEntriesConfig { get; set; } = new();
    public CacheWriterObjectConfig TagsConfig { get; set; } = new();
    public CacheWriterObjectConfig TimeCardConfig { get; set; } = new();
    public CacheWriterObjectConfig UnitOfMeasureConfig { get; set; } = new();
    public CacheWriterObjectConfig VendorsConfig { get; set; } = new();
    public CacheWriterObjectConfig WorkOrderConfig { get; set; } = new();
    public CacheWriterObjectConfig WorkOrderNotesConfig { get; set; } = new();
    public CacheWriterObjectConfig WorkOrdersConfig { get; set; } = new();
    public CacheWriterObjectConfig WorkOrderPurchaseConfig { get; set; } = new();
    public CacheWriterObjectConfig WorkOrderScheduleConfig { get; set; } = new();
}