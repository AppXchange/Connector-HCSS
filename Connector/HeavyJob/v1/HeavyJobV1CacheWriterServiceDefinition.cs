namespace Connector.HeavyJob.v1;
using Connector.HeavyJob.v1.AccessGroup;
using Connector.HeavyJob.v1.Accounting;
using Connector.HeavyJob.v1.AdvancedBudgetCustomCostTypeItem;
using Connector.HeavyJob.v1.AdvancedBudgetCustomCostTypes;
using Connector.HeavyJob.v1.AdvancedBudgetMaterial;
// using Connector.HeavyJob.v1.AdvancedBudgetMaterials;
using Connector.HeavyJob.v1.AdvancedBudgetSubcontract;
// using Connector.HeavyJob.v1.AdvancedBudgetSubcontracts;
using Connector.HeavyJob.v1.Attachment;
using Connector.HeavyJob.v1.AttendanceHourTags;
// using Connector.HeavyJob.v1.BulkCreateJobsRequest;
// using Connector.HeavyJob.v1.BulkCreateJobsRequests;
using Connector.HeavyJob.v1.BusinessUnit;
using Connector.HeavyJob.v1.BusinessUnitPreference;
using Connector.HeavyJob.v1.ChangeOrder;
using Connector.HeavyJob.v1.ChangeOrderIncrementor;
using Connector.HeavyJob.v1.ChangeOrdersByBusinessUnit;
using Connector.HeavyJob.v1.ChangeOrdersByJob;
using Connector.HeavyJob.v1.CostAdjustments;
using Connector.HeavyJob.v1.CostCategories;
using Connector.HeavyJob.v1.CostCodeCosts;
using Connector.HeavyJob.v1.CostCodeProgress;
using Connector.HeavyJob.v1.CostCodes;
using Connector.HeavyJob.v1.CostCodeTags;
using Connector.HeavyJob.v1.CostCodeTransaction;
using Connector.HeavyJob.v1.CostCodeTransactionAdjustment;
using Connector.HeavyJob.v1.CustomCostTypeInstalled;
using Connector.HeavyJob.v1.CustomCostTypeItemReceived;
using Connector.HeavyJob.v1.CustomCostTypeItems;
// using Connector.HeavyJob.v1.CustomCostTypeReceived;
using Connector.HeavyJob.v1.Diaries;
using Connector.HeavyJob.v1.Diary;
using Connector.HeavyJob.v1.EmployeeHours;
using Connector.HeavyJob.v1.Employees;
using Connector.HeavyJob.v1.EmployeesAdvanced;
using Connector.HeavyJob.v1.EmployeesWithDetails;
using Connector.HeavyJob.v1.Equipment;
using Connector.HeavyJob.v1.EquipmentHours;
using Connector.HeavyJob.v1.EquipmentType;
using Connector.HeavyJob.v1.Forecast;
using Connector.HeavyJob.v1.ForecastInfo;
using Connector.HeavyJob.v1.JobCostByCostCode;
using Connector.HeavyJob.v1.JobCostCustomCost;
using Connector.HeavyJob.v1.JobCosts;
using Connector.HeavyJob.v1.JobCostsQuery;
using Connector.HeavyJob.v1.JobCostsToDate;
using Connector.HeavyJob.v1.JobCustomCostTypeItem;
using Connector.HeavyJob.v1.JobCustomCostTypeItems;
using Connector.HeavyJob.v1.JobEmployees;
using Connector.HeavyJob.v1.JobEquipment;
using Connector.HeavyJob.v1.JobMaterial;
using Connector.HeavyJob.v1.JobMaterials;
using Connector.HeavyJob.v1.Jobs;
using Connector.HeavyJob.v1.JobsAdvanced;
using Connector.HeavyJob.v1.JobSubcontract;
using Connector.HeavyJob.v1.JobSubcontracts;
using Connector.HeavyJob.v1.MaterialPurchaseOrderDetails;
using Connector.HeavyJob.v1.Materials;
using Connector.HeavyJob.v1.MaterialsInstalled;
using Connector.HeavyJob.v1.MaterialsInstalledQuantities;
using Connector.HeavyJob.v1.MaterialsReceived;
using Connector.HeavyJob.v1.MaterialSubsAndCustomCosts;
using Connector.HeavyJob.v1.MissingTimeCardForemen;
using Connector.HeavyJob.v1.MobileChangeOrdersByBusinessUnit;
using Connector.HeavyJob.v1.NonuseHourTags;
using Connector.HeavyJob.v1.PayClass;
using Connector.HeavyJob.v1.PayItems;
using Connector.HeavyJob.v1.PurchaseOrderItems;
using Connector.HeavyJob.v1.PurchaseOrders;
using Connector.HeavyJob.v1.QuantityAdjustment;
using Connector.HeavyJob.v1.QuantityAdjustments;
using Connector.HeavyJob.v1.RateSetGroupAccounting;
using Connector.HeavyJob.v1.ReleaseOrderApprovalRule;
using Connector.HeavyJob.v1.SetupFilters;
using Connector.HeavyJob.v1.Subcontracts;
using Connector.HeavyJob.v1.SubcontractTransactions;
using Connector.HeavyJob.v1.SubcontractWorkQuantities;
using Connector.HeavyJob.v1.TimeCard;
using Connector.HeavyJob.v1.TimeCardApproval;
using Connector.HeavyJob.v1.TimeCardInfo;
using Connector.HeavyJob.v1.TimeCardsForEquipment;
using Connector.HeavyJob.v1.User;
using Connector.HeavyJob.v1.UserAccessGroup;
using Connector.HeavyJob.v1.VendorContractDetails;
using Connector.HeavyJob.v1.VendorContractItems;
using Connector.HeavyJob.v1.VendorContracts;
using Connector.HeavyJob.v1.Vendors;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using Xchange.Connector.SDK.Abstraction.Change;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Hosting.Configuration;

public class HeavyJobV1CacheWriterServiceDefinition : BaseCacheWriterServiceDefinition<HeavyJobV1CacheWriterConfig>
{
    public override string ModuleId => "heavyjob-1";
    public override Type ServiceType => typeof(GenericCacheWriterService<HeavyJobV1CacheWriterConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var serviceConfig = JsonSerializer.Deserialize<HeavyJobV1CacheWriterConfig>(serviceConfigJson);
        serviceCollection.AddSingleton<HeavyJobV1CacheWriterConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericCacheWriterService<HeavyJobV1CacheWriterConfig>>();
        serviceCollection.AddSingleton<ICacheWriterServiceDefinition<HeavyJobV1CacheWriterConfig>>(this);
        // Register Data Readers as Singletons
        serviceCollection.AddSingleton<AccessGroupDataReader>();
        serviceCollection.AddSingleton<AccountingDataReader>();
        serviceCollection.AddSingleton<RateSetGroupAccountingDataReader>();
        serviceCollection.AddSingleton<AdvancedBudgetMaterialDataReader>();
        // serviceCollection.AddSingleton<AdvancedBudgetMaterialsDataReader>();
        serviceCollection.AddSingleton<AdvancedBudgetSubcontractDataReader>();
        // serviceCollection.AddSingleton<AdvancedBudgetSubcontractsDataReader>();
        serviceCollection.AddSingleton<AdvancedBudgetCustomCostTypeItemDataReader>();
        serviceCollection.AddSingleton<AdvancedBudgetCustomCostTypesDataReader>();
        serviceCollection.AddSingleton<AttachmentDataReader>();
        // serviceCollection.AddSingleton<BulkCreateJobsRequestsDataReader>();
        // serviceCollection.AddSingleton<BulkCreateJobsRequestDataReader>();
        serviceCollection.AddSingleton<BusinessUnitDataReader>();
        serviceCollection.AddSingleton<BusinessUnitPreferenceDataReader>();
        serviceCollection.AddSingleton<ChangeOrderDataReader>();
        serviceCollection.AddSingleton<ChangeOrdersByJobDataReader>();
        serviceCollection.AddSingleton<ChangeOrdersByBusinessUnitDataReader>();
        serviceCollection.AddSingleton<MobileChangeOrdersByBusinessUnitDataReader>();
        serviceCollection.AddSingleton<ChangeOrderIncrementorDataReader>();
        serviceCollection.AddSingleton<JobCostsDataReader>();
        serviceCollection.AddSingleton<JobCostByCostCodeDataReader>();
        serviceCollection.AddSingleton<JobCostsToDateDataReader>();
        serviceCollection.AddSingleton<JobCostCustomCostDataReader>();
        serviceCollection.AddSingleton<CostCodeCostsDataReader>();
        serviceCollection.AddSingleton<CostAdjustmentsDataReader>();
        serviceCollection.AddSingleton<CostCodesDataReader>();
        serviceCollection.AddSingleton<CostCodeProgressDataReader>();
        serviceCollection.AddSingleton<SetupFiltersDataReader>();
        serviceCollection.AddSingleton<CostCodeTagsDataReader>();
        serviceCollection.AddSingleton<CostCodeTransactionDataReader>();
        serviceCollection.AddSingleton<CostCodeTransactionAdjustmentDataReader>();
        serviceCollection.AddSingleton<MaterialsInstalledQuantitiesDataReader>();
        serviceCollection.AddSingleton<SubcontractWorkQuantitiesDataReader>();
        serviceCollection.AddSingleton<QuantityAdjustmentsDataReader>();
        serviceCollection.AddSingleton<CustomCostTypeItemReceivedDataReader>();
        serviceCollection.AddSingleton<CostCategoriesDataReader>();
        serviceCollection.AddSingleton<CustomCostTypeItemsDataReader>();
        serviceCollection.AddSingleton<JobCustomCostTypeItemsDataReader>();
        serviceCollection.AddSingleton<JobCustomCostTypeItemDataReader>();
        serviceCollection.AddSingleton<CustomCostTypeInstalledDataReader>();
        // serviceCollection.AddSingleton<CustomCostTypeReceivedDataReader>();
        serviceCollection.AddSingleton<DiaryDataReader>();
        serviceCollection.AddSingleton<DiariesDataReader>();
        serviceCollection.AddSingleton<EmployeesDataReader>();
        serviceCollection.AddSingleton<EmployeesWithDetailsDataReader>();
        serviceCollection.AddSingleton<EquipmentDataReader>();
        serviceCollection.AddSingleton<EquipmentTypeDataReader>();
        serviceCollection.AddSingleton<ForecastInfoDataReader>();
        serviceCollection.AddSingleton<ForecastDataReader>();
        serviceCollection.AddSingleton<EmployeeHoursDataReader>();
        serviceCollection.AddSingleton<EquipmentHoursDataReader>();
        serviceCollection.AddSingleton<AttendanceHourTagsDataReader>();
        serviceCollection.AddSingleton<NonuseHourTagsDataReader>();
        serviceCollection.AddSingleton<JobsDataReader>();
        serviceCollection.AddSingleton<JobEmployeesDataReader>();
        serviceCollection.AddSingleton<JobEquipmentDataReader>();
        serviceCollection.AddSingleton<MaterialsDataReader>();
        serviceCollection.AddSingleton<JobMaterialDataReader>();
        serviceCollection.AddSingleton<JobMaterialsDataReader>();
        serviceCollection.AddSingleton<MaterialsInstalledDataReader>();
        serviceCollection.AddSingleton<MaterialsReceivedDataReader>();
        serviceCollection.AddSingleton<MaterialSubsAndCustomCostsDataReader>();
        serviceCollection.AddSingleton<PayClassDataReader>();
        serviceCollection.AddSingleton<PayItemsDataReader>();
        serviceCollection.AddSingleton<PurchaseOrdersDataReader>();
        serviceCollection.AddSingleton<PurchaseOrderItemsDataReader>();
        serviceCollection.AddSingleton<MaterialPurchaseOrderDetailsDataReader>();
        serviceCollection.AddSingleton<QuantityAdjustmentDataReader>();
        serviceCollection.AddSingleton<ReleaseOrderApprovalRuleDataReader>();
        serviceCollection.AddSingleton<SubcontractsDataReader>();
        serviceCollection.AddSingleton<JobSubcontractDataReader>();
        serviceCollection.AddSingleton<JobSubcontractsDataReader>();
        serviceCollection.AddSingleton<SubcontractTransactionsDataReader>();
        serviceCollection.AddSingleton<TimeCardApprovalDataReader>();
        serviceCollection.AddSingleton<TimeCardInfoDataReader>();
        serviceCollection.AddSingleton<TimeCardDataReader>();
        serviceCollection.AddSingleton<MissingTimeCardForemenDataReader>();
        serviceCollection.AddSingleton<TimeCardsForEquipmentDataReader>();
        serviceCollection.AddSingleton<UserDataReader>();
        serviceCollection.AddSingleton<UserAccessGroupDataReader>();
        serviceCollection.AddSingleton<VendorsDataReader>();
        serviceCollection.AddSingleton<VendorContractsDataReader>();
        serviceCollection.AddSingleton<VendorContractDetailsDataReader>();
        serviceCollection.AddSingleton<VendorContractItemsDataReader>();
        serviceCollection.AddSingleton<EmployeesAdvancedDataReader>();
        serviceCollection.AddSingleton<JobCostsQueryDataReader>();
        serviceCollection.AddSingleton<JobsAdvancedDataReader>();
    }

    public override IDataObjectChangeDetectorProvider ConfigureChangeDetectorProvider(IChangeDetectorFactory factory, ConnectorDefinition connectorDefinition)
    {
        var options = factory.CreateProviderOptionsWithNoDefaultResolver();
        // Configure Data Object Keys for Data Objects that do not use the default
        this.RegisterKeysForObject<AccessGroupDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<AccountingDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<RateSetGroupAccountingDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<AdvancedBudgetMaterialDataObject>(options, connectorDefinition);
        // this.RegisterKeysForObject<AdvancedBudgetMaterialsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<AdvancedBudgetSubcontractDataObject>(options, connectorDefinition);
        // this.RegisterKeysForObject<AdvancedBudgetSubcontractsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<AdvancedBudgetCustomCostTypeItemDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<AdvancedBudgetCustomCostTypesDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<AttachmentDataObject>(options, connectorDefinition);
        // this.RegisterKeysForObject<BulkCreateJobsRequestsDataObject>(options, connectorDefinition);
        // this.RegisterKeysForObject<BulkCreateJobsRequestDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<BusinessUnitDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<BusinessUnitPreferenceDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ChangeOrderDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ChangeOrdersByJobDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ChangeOrdersByBusinessUnitDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<MobileChangeOrdersByBusinessUnitDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ChangeOrderIncrementorDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<JobCostsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<JobCostByCostCodeDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<JobCostsToDateDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<JobCostCustomCostDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<CostCodeCostsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<CostAdjustmentsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<CostCodesDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<CostCodeProgressDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<SetupFiltersDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<CostCodeTagsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<CostCodeTransactionDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<CostCodeTransactionAdjustmentDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<MaterialsInstalledQuantitiesDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<SubcontractWorkQuantitiesDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<QuantityAdjustmentsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<CustomCostTypeItemReceivedDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<CostCategoriesDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<CustomCostTypeItemsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<JobCustomCostTypeItemsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<JobCustomCostTypeItemDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<CustomCostTypeInstalledDataObject>(options, connectorDefinition);
        // this.RegisterKeysForObject<CustomCostTypeReceivedDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<DiaryDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<DiariesDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<EmployeesDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<EmployeesWithDetailsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<EquipmentDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<EquipmentTypeDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ForecastInfoDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ForecastDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<EmployeeHoursDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<EquipmentHoursDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<AttendanceHourTagsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<NonuseHourTagsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<JobsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<JobEmployeesDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<JobEquipmentDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<MaterialsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<JobMaterialDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<JobMaterialsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<MaterialsInstalledDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<MaterialsReceivedDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<MaterialSubsAndCustomCostsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<PayClassDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<PayItemsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<PurchaseOrdersDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<PurchaseOrderItemsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<MaterialPurchaseOrderDetailsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<QuantityAdjustmentDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ReleaseOrderApprovalRuleDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<SubcontractsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<JobSubcontractDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<JobSubcontractsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<SubcontractTransactionsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<TimeCardApprovalDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<TimeCardInfoDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<TimeCardDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<MissingTimeCardForemenDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<TimeCardsForEquipmentDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<UserDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<UserAccessGroupDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<VendorsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<VendorContractsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<VendorContractDetailsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<VendorContractItemsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<EmployeesAdvancedDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<JobCostsQueryDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<JobsAdvancedDataObject>(options, connectorDefinition);
        return factory.CreateProvider(options);
    }

    public override void ConfigureService(ICacheWriterService service, HeavyJobV1CacheWriterConfig config)
    {
        var dataReaderSettings = new DataReaderSettings
        {
            DisableDeletes = false,
            UseChangeDetection = true
        };
        // Register Data Reader configurations for the Cache Writer Service
        service.RegisterDataReader<AccessGroupDataReader, AccessGroupDataObject>(ModuleId, config.AccessGroupConfig, dataReaderSettings);
        service.RegisterDataReader<AccountingDataReader, AccountingDataObject>(ModuleId, config.AccountingConfig, dataReaderSettings);
        service.RegisterDataReader<RateSetGroupAccountingDataReader, RateSetGroupAccountingDataObject>(ModuleId, config.RateSetGroupAccountingConfig, dataReaderSettings);
        service.RegisterDataReader<AdvancedBudgetMaterialDataReader, AdvancedBudgetMaterialDataObject>(ModuleId, config.AdvancedBudgetMaterialConfig, dataReaderSettings);
        // service.RegisterDataReader<AdvancedBudgetMaterialsDataReader, AdvancedBudgetMaterialsDataObject>(ModuleId, config.AdvancedBudgetMaterialsConfig, dataReaderSettings);
        service.RegisterDataReader<AdvancedBudgetSubcontractDataReader, AdvancedBudgetSubcontractDataObject>(ModuleId, config.AdvancedBudgetSubcontractConfig, dataReaderSettings);
        // service.RegisterDataReader<AdvancedBudgetSubcontractsDataReader, AdvancedBudgetSubcontractsDataObject>(ModuleId, config.AdvancedBudgetSubcontractsConfig, dataReaderSettings);
        service.RegisterDataReader<AdvancedBudgetCustomCostTypeItemDataReader, AdvancedBudgetCustomCostTypeItemDataObject>(ModuleId, config.AdvancedBudgetCustomCostTypeItemConfig, dataReaderSettings);
        service.RegisterDataReader<AdvancedBudgetCustomCostTypesDataReader, AdvancedBudgetCustomCostTypesDataObject>(ModuleId, config.AdvancedBudgetCustomCostTypesConfig, dataReaderSettings);
        service.RegisterDataReader<AttachmentDataReader, AttachmentDataObject>(ModuleId, config.AttachmentConfig, dataReaderSettings);
        // service.RegisterDataReader<BulkCreateJobsRequestsDataReader, BulkCreateJobsRequestsDataObject>(ModuleId, config.BulkCreateJobsRequestsConfig, dataReaderSettings);
        // service.RegisterDataReader<BulkCreateJobsRequestDataReader, BulkCreateJobsRequestDataObject>(ModuleId, config.BulkCreateJobsRequestConfig, dataReaderSettings);
        service.RegisterDataReader<BusinessUnitDataReader, BusinessUnitDataObject>(ModuleId, config.BusinessUnitConfig, dataReaderSettings);
        service.RegisterDataReader<BusinessUnitPreferenceDataReader, BusinessUnitPreferenceDataObject>(ModuleId, config.BusinessUnitPreferenceConfig, dataReaderSettings);
        service.RegisterDataReader<ChangeOrderDataReader, ChangeOrderDataObject>(ModuleId, config.ChangeOrderConfig, dataReaderSettings);
        service.RegisterDataReader<ChangeOrdersByJobDataReader, ChangeOrdersByJobDataObject>(ModuleId, config.ChangeOrdersByJobConfig, dataReaderSettings);
        service.RegisterDataReader<ChangeOrdersByBusinessUnitDataReader, ChangeOrdersByBusinessUnitDataObject>(ModuleId, config.ChangeOrdersByBusinessUnitConfig, dataReaderSettings);
        service.RegisterDataReader<MobileChangeOrdersByBusinessUnitDataReader, MobileChangeOrdersByBusinessUnitDataObject>(ModuleId, config.MobileChangeOrdersByBusinessUnitConfig, dataReaderSettings);
        service.RegisterDataReader<ChangeOrderIncrementorDataReader, ChangeOrderIncrementorDataObject>(ModuleId, config.ChangeOrderIncrementorConfig, dataReaderSettings);
        service.RegisterDataReader<JobCostsDataReader, JobCostsDataObject>(ModuleId, config.JobCostsConfig, dataReaderSettings);
        service.RegisterDataReader<JobCostByCostCodeDataReader, JobCostByCostCodeDataObject>(ModuleId, config.JobCostByCostCodeConfig, dataReaderSettings);
        service.RegisterDataReader<JobCostsToDateDataReader, JobCostsToDateDataObject>(ModuleId, config.JobCostsToDateConfig, dataReaderSettings);
        service.RegisterDataReader<JobCostCustomCostDataReader, JobCostCustomCostDataObject>(ModuleId, config.JobCostCustomCostConfig, dataReaderSettings);
        service.RegisterDataReader<CostCodeCostsDataReader, CostCodeCostsDataObject>(ModuleId, config.CostCodeCostsConfig, dataReaderSettings);
        service.RegisterDataReader<CostAdjustmentsDataReader, CostAdjustmentsDataObject>(ModuleId, config.CostAdjustmentsConfig, dataReaderSettings);
        service.RegisterDataReader<CostCodesDataReader, CostCodesDataObject>(ModuleId, config.CostCodesConfig, dataReaderSettings);
        service.RegisterDataReader<CostCodeProgressDataReader, CostCodeProgressDataObject>(ModuleId, config.CostCodeProgressConfig, dataReaderSettings);
        service.RegisterDataReader<SetupFiltersDataReader, SetupFiltersDataObject>(ModuleId, config.SetupFiltersConfig, dataReaderSettings);
        service.RegisterDataReader<CostCodeTagsDataReader, CostCodeTagsDataObject>(ModuleId, config.CostCodeTagsConfig, dataReaderSettings);
        service.RegisterDataReader<CostCodeTransactionDataReader, CostCodeTransactionDataObject>(ModuleId, config.CostCodeTransactionConfig, dataReaderSettings);
        service.RegisterDataReader<CostCodeTransactionAdjustmentDataReader, CostCodeTransactionAdjustmentDataObject>(ModuleId, config.CostCodeTransactionAdjustmentConfig, dataReaderSettings);
        service.RegisterDataReader<MaterialsInstalledQuantitiesDataReader, MaterialsInstalledQuantitiesDataObject>(ModuleId, config.MaterialsInstalledQuantitiesConfig, dataReaderSettings);
        service.RegisterDataReader<SubcontractWorkQuantitiesDataReader, SubcontractWorkQuantitiesDataObject>(ModuleId, config.SubcontractWorkQuantitiesConfig, dataReaderSettings);
        service.RegisterDataReader<QuantityAdjustmentsDataReader, QuantityAdjustmentsDataObject>(ModuleId, config.QuantityAdjustmentsConfig, dataReaderSettings);
        service.RegisterDataReader<CustomCostTypeItemReceivedDataReader, CustomCostTypeItemReceivedDataObject>(ModuleId, config.CustomCostTypeItemReceivedConfig, dataReaderSettings);
        service.RegisterDataReader<CostCategoriesDataReader, CostCategoriesDataObject>(ModuleId, config.CostCategoriesConfig, dataReaderSettings);
        service.RegisterDataReader<CustomCostTypeItemsDataReader, CustomCostTypeItemsDataObject>(ModuleId, config.CustomCostTypeItemsConfig, dataReaderSettings);
        service.RegisterDataReader<JobCustomCostTypeItemsDataReader, JobCustomCostTypeItemsDataObject>(ModuleId, config.JobCustomCostTypeItemsConfig, dataReaderSettings);
        service.RegisterDataReader<JobCustomCostTypeItemDataReader, JobCustomCostTypeItemDataObject>(ModuleId, config.JobCustomCostTypeItemConfig, dataReaderSettings);
        service.RegisterDataReader<CustomCostTypeInstalledDataReader, CustomCostTypeInstalledDataObject>(ModuleId, config.CustomCostTypeInstalledConfig, dataReaderSettings);
        // service.RegisterDataReader<CustomCostTypeReceivedDataReader, CustomCostTypeReceivedDataObject>(ModuleId, config.CustomCostTypeReceivedConfig, dataReaderSettings);
        service.RegisterDataReader<DiaryDataReader, DiaryDataObject>(ModuleId, config.DiaryConfig, dataReaderSettings);
        service.RegisterDataReader<DiariesDataReader, DiariesDataObject>(ModuleId, config.DiariesConfig, dataReaderSettings);
        service.RegisterDataReader<EmployeesDataReader, EmployeesDataObject>(ModuleId, config.EmployeesConfig, dataReaderSettings);
        service.RegisterDataReader<EmployeesWithDetailsDataReader, EmployeesWithDetailsDataObject>(ModuleId, config.EmployeesWithDetailsConfig, dataReaderSettings);
        service.RegisterDataReader<EquipmentDataReader, EquipmentDataObject>(ModuleId, config.EquipmentConfig, dataReaderSettings);
        service.RegisterDataReader<EquipmentTypeDataReader, EquipmentTypeDataObject>(ModuleId, config.EquipmentTypeConfig, dataReaderSettings);
        service.RegisterDataReader<ForecastInfoDataReader, ForecastInfoDataObject>(ModuleId, config.ForecastInfoConfig, dataReaderSettings);
        service.RegisterDataReader<ForecastDataReader, ForecastDataObject>(ModuleId, config.ForecastConfig, dataReaderSettings);
        service.RegisterDataReader<EmployeeHoursDataReader, EmployeeHoursDataObject>(ModuleId, config.EmployeeHoursConfig, dataReaderSettings);
        service.RegisterDataReader<EquipmentHoursDataReader, EquipmentHoursDataObject>(ModuleId, config.EquipmentHoursConfig, dataReaderSettings);
        service.RegisterDataReader<AttendanceHourTagsDataReader, AttendanceHourTagsDataObject>(ModuleId, config.AttendanceHourTagsConfig, dataReaderSettings);
        service.RegisterDataReader<NonuseHourTagsDataReader, NonuseHourTagsDataObject>(ModuleId, config.NonuseHourTagsConfig, dataReaderSettings);
        service.RegisterDataReader<JobsDataReader, JobsDataObject>(ModuleId, config.JobsConfig, dataReaderSettings);
        service.RegisterDataReader<JobEmployeesDataReader, JobEmployeesDataObject>(ModuleId, config.JobEmployeesConfig, dataReaderSettings);
        service.RegisterDataReader<JobEquipmentDataReader, JobEquipmentDataObject>(ModuleId, config.JobEquipmentConfig, dataReaderSettings);
        service.RegisterDataReader<MaterialsDataReader, MaterialsDataObject>(ModuleId, config.MaterialsConfig, dataReaderSettings);
        service.RegisterDataReader<JobMaterialDataReader, JobMaterialDataObject>(ModuleId, config.JobMaterialConfig, dataReaderSettings);
        service.RegisterDataReader<JobMaterialsDataReader, JobMaterialsDataObject>(ModuleId, config.JobMaterialsConfig, dataReaderSettings);
        service.RegisterDataReader<MaterialsInstalledDataReader, MaterialsInstalledDataObject>(ModuleId, config.MaterialsInstalledConfig, dataReaderSettings);
        service.RegisterDataReader<MaterialsReceivedDataReader, MaterialsReceivedDataObject>(ModuleId, config.MaterialsReceivedConfig, dataReaderSettings);
        service.RegisterDataReader<MaterialSubsAndCustomCostsDataReader, MaterialSubsAndCustomCostsDataObject>(ModuleId, config.MaterialSubsAndCustomCostsConfig, dataReaderSettings);
        service.RegisterDataReader<PayClassDataReader, PayClassDataObject>(ModuleId, config.PayClassConfig, dataReaderSettings);
        service.RegisterDataReader<PayItemsDataReader, PayItemsDataObject>(ModuleId, config.PayItemsConfig, dataReaderSettings);
        service.RegisterDataReader<PurchaseOrdersDataReader, PurchaseOrdersDataObject>(ModuleId, config.PurchaseOrdersConfig, dataReaderSettings);
        service.RegisterDataReader<PurchaseOrderItemsDataReader, PurchaseOrderItemsDataObject>(ModuleId, config.PurchaseOrderItemsConfig, dataReaderSettings);
        service.RegisterDataReader<MaterialPurchaseOrderDetailsDataReader, MaterialPurchaseOrderDetailsDataObject>(ModuleId, config.MaterialPurchaseOrderDetailsConfig, dataReaderSettings);
        service.RegisterDataReader<QuantityAdjustmentDataReader, QuantityAdjustmentDataObject>(ModuleId, config.QuantityAdjustmentConfig, dataReaderSettings);
        service.RegisterDataReader<ReleaseOrderApprovalRuleDataReader, ReleaseOrderApprovalRuleDataObject>(ModuleId, config.ReleaseOrderApprovalRuleConfig, dataReaderSettings);
        service.RegisterDataReader<SubcontractsDataReader, SubcontractsDataObject>(ModuleId, config.SubcontractsConfig, dataReaderSettings);
        service.RegisterDataReader<JobSubcontractDataReader, JobSubcontractDataObject>(ModuleId, config.JobSubcontractConfig, dataReaderSettings);
        service.RegisterDataReader<JobSubcontractsDataReader, JobSubcontractsDataObject>(ModuleId, config.JobSubcontractsConfig, dataReaderSettings);
        service.RegisterDataReader<SubcontractTransactionsDataReader, SubcontractTransactionsDataObject>(ModuleId, config.SubcontractTransactionsConfig, dataReaderSettings);
        service.RegisterDataReader<TimeCardApprovalDataReader, TimeCardApprovalDataObject>(ModuleId, config.TimeCardApprovalConfig, dataReaderSettings);
        service.RegisterDataReader<TimeCardInfoDataReader, TimeCardInfoDataObject>(ModuleId, config.TimeCardInfoConfig, dataReaderSettings);
        service.RegisterDataReader<TimeCardDataReader, TimeCardDataObject>(ModuleId, config.TimeCardConfig, dataReaderSettings);
        service.RegisterDataReader<MissingTimeCardForemenDataReader, MissingTimeCardForemenDataObject>(ModuleId, config.MissingTimeCardForemenConfig, dataReaderSettings);
        service.RegisterDataReader<TimeCardsForEquipmentDataReader, TimeCardsForEquipmentDataObject>(ModuleId, config.TimeCardsForEquipmentConfig, dataReaderSettings);
        service.RegisterDataReader<UserDataReader, UserDataObject>(ModuleId, config.UserConfig, dataReaderSettings);
        service.RegisterDataReader<UserAccessGroupDataReader, UserAccessGroupDataObject>(ModuleId, config.UserAccessGroupConfig, dataReaderSettings);
        service.RegisterDataReader<VendorsDataReader, VendorsDataObject>(ModuleId, config.VendorsConfig, dataReaderSettings);
        service.RegisterDataReader<VendorContractsDataReader, VendorContractsDataObject>(ModuleId, config.VendorContractsConfig, dataReaderSettings);
        service.RegisterDataReader<VendorContractDetailsDataReader, VendorContractDetailsDataObject>(ModuleId, config.VendorContractDetailsConfig, dataReaderSettings);
        service.RegisterDataReader<VendorContractItemsDataReader, VendorContractItemsDataObject>(ModuleId, config.VendorContractItemsConfig, dataReaderSettings);
        service.RegisterDataReader<EmployeesAdvancedDataReader, EmployeesAdvancedDataObject>(ModuleId, config.EmployeesAdvancedConfig, dataReaderSettings);
        service.RegisterDataReader<JobCostsQueryDataReader, JobCostsQueryDataObject>(ModuleId, config.JobCostsQueryConfig, dataReaderSettings);
        service.RegisterDataReader<JobsAdvancedDataReader, JobsAdvancedDataObject>(ModuleId, config.JobsAdvancedConfig, dataReaderSettings);
    }
}