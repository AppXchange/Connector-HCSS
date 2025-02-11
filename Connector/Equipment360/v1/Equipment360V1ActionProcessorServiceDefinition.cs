namespace Connector.Equipment360.v1;
using Connector.Equipment360.v1.CustomField;
using Connector.Equipment360.v1.CustomField.Create;
using Connector.Equipment360.v1.Employee;
using Connector.Equipment360.v1.Employee.Create;
using Connector.Equipment360.v1.Employee.Update;
using Connector.Equipment360.v1.Equipment;
using Connector.Equipment360.v1.Equipment.Create;
using Connector.Equipment360.v1.Equipment.Update;
using Connector.Equipment360.v1.EquipmentTransfer;
using Connector.Equipment360.v1.EquipmentTransfer.Update;
using Connector.Equipment360.v1.EquipmentType;
using Connector.Equipment360.v1.EquipmentType.Create;
using Connector.Equipment360.v1.Invoice;
using Connector.Equipment360.v1.Invoice.Create;
using Connector.Equipment360.v1.Invoice.Update;
using Connector.Equipment360.v1.Jobs;
using Connector.Equipment360.v1.Jobs.Create;
using Connector.Equipment360.v1.Jobs.Update;
using Connector.Equipment360.v1.Locations;
using Connector.Equipment360.v1.Locations.Create;
using Connector.Equipment360.v1.Locations.Update;
using Connector.Equipment360.v1.MaintenanceRequest;
using Connector.Equipment360.v1.MaintenanceRequest.Create;
using Connector.Equipment360.v1.MeterReading;
using Connector.Equipment360.v1.MeterReading.Create;
using Connector.Equipment360.v1.PartCostEntries;
using Connector.Equipment360.v1.PartCostEntries.Create;
using Connector.Equipment360.v1.PartCostEntry;
using Connector.Equipment360.v1.PartCostEntry.Create;
using Connector.Equipment360.v1.PartInventory;
using Connector.Equipment360.v1.PartInventory.Create;
using Connector.Equipment360.v1.Parts;
using Connector.Equipment360.v1.Parts.Update;
using Connector.Equipment360.v1.PurchaseOrder;
using Connector.Equipment360.v1.PurchaseOrder.Create;
using Connector.Equipment360.v1.PurchaseOrderDetails;
using Connector.Equipment360.v1.PurchaseOrderDetails.Create;
using Connector.Equipment360.v1.PurchaseOrderNotes;
using Connector.Equipment360.v1.PurchaseOrderNotes.Create;
using Connector.Equipment360.v1.SubletVendorCostEntries;
using Connector.Equipment360.v1.SubletVendorCostEntries.Create;
using Connector.Equipment360.v1.SubletVendorCostEntry;
using Connector.Equipment360.v1.SubletVendorCostEntry.Create;
using Connector.Equipment360.v1.Vendors;
using Connector.Equipment360.v1.Vendors.Create;
using Connector.Equipment360.v1.Vendors.Update;
using Connector.Equipment360.v1.WorkOrder;
using Connector.Equipment360.v1.WorkOrder.Create;
using Connector.Equipment360.v1.WorkOrder.Update;
using Connector.Equipment360.v1.WorkOrderNotes;
using Connector.Equipment360.v1.WorkOrderNotes.Create;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.Action;

public class Equipment360V1ActionProcessorServiceDefinition : BaseActionHandlerServiceDefinition<Equipment360V1ActionProcessorConfig>
{
    public override string ModuleId => "equipment360-1";
    public override Type ServiceType => typeof(GenericActionHandlerService<Equipment360V1ActionProcessorConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var options = new JsonSerializerOptions
        {
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };
        var serviceConfig = JsonSerializer.Deserialize<Equipment360V1ActionProcessorConfig>(serviceConfigJson, options);
        serviceCollection.AddSingleton<Equipment360V1ActionProcessorConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericActionHandlerService<Equipment360V1ActionProcessorConfig>>();
        serviceCollection.AddSingleton<IActionHandlerServiceDefinition<Equipment360V1ActionProcessorConfig>>(this);
        // Register Action Handlers as scoped dependencies
        serviceCollection.AddScoped<CreateCustomFieldHandler>();
        serviceCollection.AddScoped<CreateEmployeeHandler>();
        serviceCollection.AddScoped<UpdateEmployeeHandler>();
        serviceCollection.AddScoped<CreateEquipmentHandler>();
        serviceCollection.AddScoped<UpdateEquipmentHandler>();
        serviceCollection.AddScoped<UpdateEquipmentTransferHandler>();
        serviceCollection.AddScoped<CreateEquipmentTypeHandler>();
        serviceCollection.AddScoped<CreateInvoiceHandler>();
        serviceCollection.AddScoped<UpdateInvoiceHandler>();
        serviceCollection.AddScoped<CreateJobsHandler>();
        serviceCollection.AddScoped<UpdateJobsHandler>();
        serviceCollection.AddScoped<CreateLocationsHandler>();
        serviceCollection.AddScoped<UpdateLocationsHandler>();
        serviceCollection.AddScoped<CreateMaintenanceRequestHandler>();
        serviceCollection.AddScoped<CreateMeterReadingHandler>();
        serviceCollection.AddScoped<UpdatePartsHandler>();
        serviceCollection.AddScoped<CreatePartCostEntryHandler>();
        serviceCollection.AddScoped<CreatePartCostEntriesHandler>();
        serviceCollection.AddScoped<CreatePartInventoryHandler>();
        serviceCollection.AddScoped<CreatePurchaseOrderHandler>();
        serviceCollection.AddScoped<CreatePurchaseOrderDetailsHandler>();
        serviceCollection.AddScoped<CreatePurchaseOrderNotesHandler>();
        serviceCollection.AddScoped<CreateSubletVendorCostEntryHandler>();
        serviceCollection.AddScoped<CreateSubletVendorCostEntriesHandler>();
        serviceCollection.AddScoped<CreateVendorsHandler>();
        serviceCollection.AddScoped<UpdateVendorsHandler>();
        serviceCollection.AddScoped<CreateWorkOrderHandler>();
        serviceCollection.AddScoped<UpdateWorkOrderHandler>();
        serviceCollection.AddScoped<CreateWorkOrderNotesHandler>();
    }

    public override void ConfigureService(IActionHandlerService service, Equipment360V1ActionProcessorConfig config)
    {
        // Register Action Handler configurations for the Action Processor Service
        service.RegisterHandlerForDataObjectAction<CreateCustomFieldHandler, CustomFieldDataObject>(ModuleId, "custom-field", "create", config.CreateCustomFieldConfig);
        service.RegisterHandlerForDataObjectAction<CreateEmployeeHandler, EmployeeDataObject>(ModuleId, "employee", "create", config.CreateEmployeeConfig);
        service.RegisterHandlerForDataObjectAction<UpdateEmployeeHandler, EmployeeDataObject>(ModuleId, "employee", "update", config.UpdateEmployeeConfig);
        service.RegisterHandlerForDataObjectAction<CreateEquipmentHandler, EquipmentDataObject>(ModuleId, "equipment", "create", config.CreateEquipmentConfig);
        service.RegisterHandlerForDataObjectAction<UpdateEquipmentHandler, EquipmentDataObject>(ModuleId, "equipment", "update", config.UpdateEquipmentConfig);
        service.RegisterHandlerForDataObjectAction<UpdateEquipmentTransferHandler, EquipmentTransferDataObject>(ModuleId, "equipment-transfer", "update", config.UpdateEquipmentTransferConfig);
        service.RegisterHandlerForDataObjectAction<CreateEquipmentTypeHandler, EquipmentTypeDataObject>(ModuleId, "equipment-type", "create", config.CreateEquipmentTypeConfig);
        service.RegisterHandlerForDataObjectAction<CreateInvoiceHandler, InvoiceDataObject>(ModuleId, "invoice", "create", config.CreateInvoiceConfig);
        service.RegisterHandlerForDataObjectAction<UpdateInvoiceHandler, InvoiceDataObject>(ModuleId, "invoice", "update", config.UpdateInvoiceConfig);
        service.RegisterHandlerForDataObjectAction<CreateJobsHandler, JobsDataObject>(ModuleId, "jobs", "create", config.CreateJobsConfig);
        service.RegisterHandlerForDataObjectAction<UpdateJobsHandler, JobsDataObject>(ModuleId, "jobs", "update", config.UpdateJobsConfig);
        service.RegisterHandlerForDataObjectAction<CreateLocationsHandler, LocationsDataObject>(ModuleId, "locations", "create", config.CreateLocationsConfig);
        service.RegisterHandlerForDataObjectAction<UpdateLocationsHandler, LocationsDataObject>(ModuleId, "locations", "update", config.UpdateLocationsConfig);
        service.RegisterHandlerForDataObjectAction<CreateMaintenanceRequestHandler, MaintenanceRequestDataObject>(ModuleId, "maintenance-request", "create", config.CreateMaintenanceRequestConfig);
        service.RegisterHandlerForDataObjectAction<CreateMeterReadingHandler, MeterReadingDataObject>(ModuleId, "meter-reading", "create", config.CreateMeterReadingConfig);
        service.RegisterHandlerForDataObjectAction<UpdatePartsHandler, PartsDataObject>(ModuleId, "parts", "update", config.UpdatePartsConfig);
        service.RegisterHandlerForDataObjectAction<CreatePartCostEntryHandler, PartCostEntryDataObject>(ModuleId, "part-cost-entry", "create", config.CreatePartCostEntryConfig);
        service.RegisterHandlerForDataObjectAction<CreatePartCostEntriesHandler, PartCostEntriesDataObject>(ModuleId, "part-cost-entries", "create", config.CreatePartCostEntriesConfig);
        service.RegisterHandlerForDataObjectAction<CreatePartInventoryHandler, PartInventoryDataObject>(ModuleId, "part-inventory", "create", config.CreatePartInventoryConfig);
        service.RegisterHandlerForDataObjectAction<CreatePurchaseOrderHandler, PurchaseOrderDataObject>(ModuleId, "purchase-order", "create", config.CreatePurchaseOrderConfig);
        service.RegisterHandlerForDataObjectAction<CreatePurchaseOrderDetailsHandler, PurchaseOrderDetailsDataObject>(ModuleId, "purchase-order-details", "create", config.CreatePurchaseOrderDetailsConfig);
        service.RegisterHandlerForDataObjectAction<CreatePurchaseOrderNotesHandler, PurchaseOrderNotesDataObject>(ModuleId, "purchase-order-notes", "create", config.CreatePurchaseOrderNotesConfig);
        service.RegisterHandlerForDataObjectAction<CreateSubletVendorCostEntryHandler, SubletVendorCostEntryDataObject>(ModuleId, "sublet-vendor-cost-entry", "create", config.CreateSubletVendorCostEntryConfig);
        service.RegisterHandlerForDataObjectAction<CreateSubletVendorCostEntriesHandler, SubletVendorCostEntriesDataObject>(ModuleId, "sublet-vendor-cost-entries", "create", config.CreateSubletVendorCostEntriesConfig);
        service.RegisterHandlerForDataObjectAction<CreateVendorsHandler, VendorsDataObject>(ModuleId, "vendors", "create", config.CreateVendorsConfig);
        service.RegisterHandlerForDataObjectAction<UpdateVendorsHandler, VendorsDataObject>(ModuleId, "vendors", "update", config.UpdateVendorsConfig);
        service.RegisterHandlerForDataObjectAction<CreateWorkOrderHandler, WorkOrderDataObject>(ModuleId, "work-order", "create", config.CreateWorkOrderConfig);
        service.RegisterHandlerForDataObjectAction<UpdateWorkOrderHandler, WorkOrderDataObject>(ModuleId, "work-order", "update", config.UpdateWorkOrderConfig);
        service.RegisterHandlerForDataObjectAction<CreateWorkOrderNotesHandler, WorkOrderNotesDataObject>(ModuleId, "work-order-notes", "create", config.CreateWorkOrderNotesConfig);
    }
}