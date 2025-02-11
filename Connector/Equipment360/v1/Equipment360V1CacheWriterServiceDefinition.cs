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
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using Xchange.Connector.SDK.Abstraction.Change;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Hosting.Configuration;

public class Equipment360V1CacheWriterServiceDefinition : BaseCacheWriterServiceDefinition<Equipment360V1CacheWriterConfig>
{
    public override string ModuleId => "equipment360-1";
    public override Type ServiceType => typeof(GenericCacheWriterService<Equipment360V1CacheWriterConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var serviceConfig = JsonSerializer.Deserialize<Equipment360V1CacheWriterConfig>(serviceConfigJson);
        serviceCollection.AddSingleton<Equipment360V1CacheWriterConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericCacheWriterService<Equipment360V1CacheWriterConfig>>();
        serviceCollection.AddSingleton<ICacheWriterServiceDefinition<Equipment360V1CacheWriterConfig>>(this);
        // Register Data Readers as Singletons
        serviceCollection.AddSingleton<BusinessUnitDataReader>();
        serviceCollection.AddSingleton<FuelCostsDataReader>();
        serviceCollection.AddSingleton<WorkOrderCostsDataReader>();
        serviceCollection.AddSingleton<WorkOrderCostsDetailsDataReader>();
        serviceCollection.AddSingleton<CustomFieldDataReader>();
        serviceCollection.AddSingleton<CustomFieldCategoriesDataReader>();
        serviceCollection.AddSingleton<CustomFieldListDataReader>();
        serviceCollection.AddSingleton<EmployeeDataReader>();
        serviceCollection.AddSingleton<EmployeesDataReader>();
        serviceCollection.AddSingleton<EquipmentDataReader>();
        serviceCollection.AddSingleton<AllEquipmentDataReader>();
        serviceCollection.AddSingleton<EquipmentTransferDataReader>();
        serviceCollection.AddSingleton<EquipmentTypeDataReader>();
        serviceCollection.AddSingleton<InvoiceDataReader>();
        serviceCollection.AddSingleton<JobsDataReader>();
        serviceCollection.AddSingleton<LocationsDataReader>();
        serviceCollection.AddSingleton<MaintenanceRequestDataReader>();
        serviceCollection.AddSingleton<MeterReadingDataReader>();
        serviceCollection.AddSingleton<PartsDataReader>();
        serviceCollection.AddSingleton<PartLocationsDataReader>();
        serviceCollection.AddSingleton<PartCostEntryDataReader>();
        serviceCollection.AddSingleton<PartCostEntriesDataReader>();
        serviceCollection.AddSingleton<PartInventoryDataReader>();
        serviceCollection.AddSingleton<PurchaseOrdersDataReader>();
        serviceCollection.AddSingleton<PurchaseOrderDataReader>();
        serviceCollection.AddSingleton<PurchaseOrderDetailsDataReader>();
        serviceCollection.AddSingleton<PurchaseOrderNotesDataReader>();
        serviceCollection.AddSingleton<SubletVendorCostEntryDataReader>();
        serviceCollection.AddSingleton<SubletVendorCostEntriesDataReader>();
        serviceCollection.AddSingleton<TagsDataReader>();
        serviceCollection.AddSingleton<TimeCardDataReader>();
        serviceCollection.AddSingleton<UnitOfMeasureDataReader>();
        serviceCollection.AddSingleton<VendorsDataReader>();
        serviceCollection.AddSingleton<WorkOrderDataReader>();
        serviceCollection.AddSingleton<WorkOrderNotesDataReader>();
        serviceCollection.AddSingleton<WorkOrdersDataReader>();
        serviceCollection.AddSingleton<WorkOrderPurchaseDataReader>();
        serviceCollection.AddSingleton<WorkOrderScheduleDataReader>();
    }

    public override IDataObjectChangeDetectorProvider ConfigureChangeDetectorProvider(IChangeDetectorFactory factory, ConnectorDefinition connectorDefinition)
    {
        var options = factory.CreateProviderOptionsWithNoDefaultResolver();
        // Configure Data Object Keys for Data Objects that do not use the default
        this.RegisterKeysForObject<BusinessUnitDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<FuelCostsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<WorkOrderCostsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<WorkOrderCostsDetailsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<CustomFieldDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<CustomFieldCategoriesDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<CustomFieldListDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<EmployeeDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<EmployeesDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<EquipmentDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<AllEquipmentDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<EquipmentTransferDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<EquipmentTypeDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<InvoiceDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<JobsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<LocationsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<MaintenanceRequestDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<MeterReadingDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<PartsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<PartLocationsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<PartCostEntryDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<PartCostEntriesDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<PartInventoryDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<PurchaseOrdersDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<PurchaseOrderDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<PurchaseOrderDetailsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<PurchaseOrderNotesDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<SubletVendorCostEntryDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<SubletVendorCostEntriesDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<TagsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<TimeCardDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<UnitOfMeasureDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<VendorsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<WorkOrderDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<WorkOrderNotesDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<WorkOrdersDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<WorkOrderPurchaseDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<WorkOrderScheduleDataObject>(options, connectorDefinition);
        return factory.CreateProvider(options);
    }

    public override void ConfigureService(ICacheWriterService service, Equipment360V1CacheWriterConfig config)
    {
        var dataReaderSettings = new DataReaderSettings
        {
            DisableDeletes = false,
            UseChangeDetection = true
        };
        // Register Data Reader configurations for the Cache Writer Service
        service.RegisterDataReader<BusinessUnitDataReader, BusinessUnitDataObject>(ModuleId, config.BusinessUnitConfig, dataReaderSettings);
        service.RegisterDataReader<FuelCostsDataReader, FuelCostsDataObject>(ModuleId, config.FuelCostsConfig, dataReaderSettings);
        service.RegisterDataReader<WorkOrderCostsDataReader, WorkOrderCostsDataObject>(ModuleId, config.WorkOrderCostsConfig, dataReaderSettings);
        service.RegisterDataReader<WorkOrderCostsDetailsDataReader, WorkOrderCostsDetailsDataObject>(ModuleId, config.WorkOrderCostsDetailsConfig, dataReaderSettings);
        service.RegisterDataReader<CustomFieldDataReader, CustomFieldDataObject>(ModuleId, config.CustomFieldConfig, dataReaderSettings);
        service.RegisterDataReader<CustomFieldCategoriesDataReader, CustomFieldCategoriesDataObject>(ModuleId, config.CustomFieldCategoriesConfig, dataReaderSettings);
        service.RegisterDataReader<CustomFieldListDataReader, CustomFieldListDataObject>(ModuleId, config.CustomFieldListConfig, dataReaderSettings);
        service.RegisterDataReader<EmployeeDataReader, EmployeeDataObject>(ModuleId, config.EmployeeConfig, dataReaderSettings);
        service.RegisterDataReader<EmployeesDataReader, EmployeesDataObject>(ModuleId, config.EmployeesConfig, dataReaderSettings);
        service.RegisterDataReader<EquipmentDataReader, EquipmentDataObject>(ModuleId, config.EquipmentConfig, dataReaderSettings);
        service.RegisterDataReader<AllEquipmentDataReader, AllEquipmentDataObject>(ModuleId, config.AllEquipmentConfig, dataReaderSettings);
        service.RegisterDataReader<EquipmentTransferDataReader, EquipmentTransferDataObject>(ModuleId, config.EquipmentTransferConfig, dataReaderSettings);
        service.RegisterDataReader<EquipmentTypeDataReader, EquipmentTypeDataObject>(ModuleId, config.EquipmentTypeConfig, dataReaderSettings);
        service.RegisterDataReader<InvoiceDataReader, InvoiceDataObject>(ModuleId, config.InvoiceConfig, dataReaderSettings);
        service.RegisterDataReader<JobsDataReader, JobsDataObject>(ModuleId, config.JobsConfig, dataReaderSettings);
        service.RegisterDataReader<LocationsDataReader, LocationsDataObject>(ModuleId, config.LocationsConfig, dataReaderSettings);
        service.RegisterDataReader<MaintenanceRequestDataReader, MaintenanceRequestDataObject>(ModuleId, config.MaintenanceRequestConfig, dataReaderSettings);
        service.RegisterDataReader<MeterReadingDataReader, MeterReadingDataObject>(ModuleId, config.MeterReadingConfig, dataReaderSettings);
        service.RegisterDataReader<PartsDataReader, PartsDataObject>(ModuleId, config.PartsConfig, dataReaderSettings);
        service.RegisterDataReader<PartLocationsDataReader, PartLocationsDataObject>(ModuleId, config.PartLocationsConfig, dataReaderSettings);
        service.RegisterDataReader<PartCostEntryDataReader, PartCostEntryDataObject>(ModuleId, config.PartCostEntryConfig, dataReaderSettings);
        service.RegisterDataReader<PartCostEntriesDataReader, PartCostEntriesDataObject>(ModuleId, config.PartCostEntriesConfig, dataReaderSettings);
        service.RegisterDataReader<PartInventoryDataReader, PartInventoryDataObject>(ModuleId, config.PartInventoryConfig, dataReaderSettings);
        service.RegisterDataReader<PurchaseOrdersDataReader, PurchaseOrdersDataObject>(ModuleId, config.PurchaseOrdersConfig, dataReaderSettings);
        service.RegisterDataReader<PurchaseOrderDataReader, PurchaseOrderDataObject>(ModuleId, config.PurchaseOrderConfig, dataReaderSettings);
        service.RegisterDataReader<PurchaseOrderDetailsDataReader, PurchaseOrderDetailsDataObject>(ModuleId, config.PurchaseOrderDetailsConfig, dataReaderSettings);
        service.RegisterDataReader<PurchaseOrderNotesDataReader, PurchaseOrderNotesDataObject>(ModuleId, config.PurchaseOrderNotesConfig, dataReaderSettings);
        service.RegisterDataReader<SubletVendorCostEntryDataReader, SubletVendorCostEntryDataObject>(ModuleId, config.SubletVendorCostEntryConfig, dataReaderSettings);
        service.RegisterDataReader<SubletVendorCostEntriesDataReader, SubletVendorCostEntriesDataObject>(ModuleId, config.SubletVendorCostEntriesConfig, dataReaderSettings);
        service.RegisterDataReader<TagsDataReader, TagsDataObject>(ModuleId, config.TagsConfig, dataReaderSettings);
        service.RegisterDataReader<TimeCardDataReader, TimeCardDataObject>(ModuleId, config.TimeCardConfig, dataReaderSettings);
        service.RegisterDataReader<UnitOfMeasureDataReader, UnitOfMeasureDataObject>(ModuleId, config.UnitOfMeasureConfig, dataReaderSettings);
        service.RegisterDataReader<VendorsDataReader, VendorsDataObject>(ModuleId, config.VendorsConfig, dataReaderSettings);
        service.RegisterDataReader<WorkOrderDataReader, WorkOrderDataObject>(ModuleId, config.WorkOrderConfig, dataReaderSettings);
        service.RegisterDataReader<WorkOrderNotesDataReader, WorkOrderNotesDataObject>(ModuleId, config.WorkOrderNotesConfig, dataReaderSettings);
        service.RegisterDataReader<WorkOrdersDataReader, WorkOrdersDataObject>(ModuleId, config.WorkOrdersConfig, dataReaderSettings);
        service.RegisterDataReader<WorkOrderPurchaseDataReader, WorkOrderPurchaseDataObject>(ModuleId, config.WorkOrderPurchaseConfig, dataReaderSettings);
        service.RegisterDataReader<WorkOrderScheduleDataReader, WorkOrderScheduleDataObject>(ModuleId, config.WorkOrderScheduleConfig, dataReaderSettings);
    }
}