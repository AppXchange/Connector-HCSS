namespace Connector.HeavyJob.v1;
using Connector.HeavyJob.v1.AccessGroup;
using Connector.HeavyJob.v1.Accounting;
using Connector.HeavyJob.v1.AdvancedBudgetCustomCostTypeItem;
using Connector.HeavyJob.v1.AdvancedBudgetCustomCostTypes;
using Connector.HeavyJob.v1.AdvancedBudgetMaterial;
// using Connector.HeavyJob.v1.AdvancedBudgetMaterials;
// using Connector.HeavyJob.v1.AdvancedBudgetSubcontract;
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
using Json.Schema.Generation;

/// <summary>
/// Configuration for the Cache writer for this module. This configuration will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// The schema will be used for validation at runtime to make sure the configurations are properly formed. 
/// The schema also helps provide integrators more information for what the values are intended to be.
/// </summary>
[Title("HeavyJob V1 Cache Writer Configuration")]
[Description("Configuration of the data object caches for the module.")]
public class HeavyJobV1CacheWriterConfig
{
    // Data Reader configuration
    public CacheWriterObjectConfig AccessGroupConfig { get; set; } = new();
    public CacheWriterObjectConfig AccountingConfig { get; set; } = new();
    public CacheWriterObjectConfig RateSetGroupAccountingConfig { get; set; } = new();
    public CacheWriterObjectConfig AdvancedBudgetMaterialConfig { get; set; } = new();
    public CacheWriterObjectConfig AdvancedBudgetMaterialsConfig { get; set; } = new();
    public CacheWriterObjectConfig AdvancedBudgetSubcontractConfig { get; set; } = new();
    public CacheWriterObjectConfig AdvancedBudgetSubcontractsConfig { get; set; } = new();
    public CacheWriterObjectConfig AdvancedBudgetCustomCostTypeItemConfig { get; set; } = new();
    public CacheWriterObjectConfig AdvancedBudgetCustomCostTypesConfig { get; set; } = new();
    public CacheWriterObjectConfig AttachmentConfig { get; set; } = new();
    public CacheWriterObjectConfig BulkCreateJobsRequestsConfig { get; set; } = new();
    public CacheWriterObjectConfig BulkCreateJobsRequestConfig { get; set; } = new();
    public CacheWriterObjectConfig BusinessUnitConfig { get; set; } = new();
    public CacheWriterObjectConfig BusinessUnitPreferenceConfig { get; set; } = new();
    public CacheWriterObjectConfig ChangeOrderConfig { get; set; } = new();
    public CacheWriterObjectConfig ChangeOrdersByJobConfig { get; set; } = new();
    public CacheWriterObjectConfig ChangeOrdersByBusinessUnitConfig { get; set; } = new();
    public CacheWriterObjectConfig MobileChangeOrdersByBusinessUnitConfig { get; set; } = new();
    public CacheWriterObjectConfig ChangeOrderIncrementorConfig { get; set; } = new();
    public CacheWriterObjectConfig JobCostsConfig { get; set; } = new();
    public CacheWriterObjectConfig JobCostByCostCodeConfig { get; set; } = new();
    public CacheWriterObjectConfig JobCostsToDateConfig { get; set; } = new();
    public CacheWriterObjectConfig JobCostCustomCostConfig { get; set; } = new();
    public CacheWriterObjectConfig CostCodeCostsConfig { get; set; } = new();
    public CacheWriterObjectConfig CostAdjustmentsConfig { get; set; } = new();
    public CacheWriterObjectConfig CostCodesConfig { get; set; } = new();
    public CacheWriterObjectConfig CostCodeProgressConfig { get; set; } = new();
    public CacheWriterObjectConfig SetupFiltersConfig { get; set; } = new();
    public CacheWriterObjectConfig CostCodeTagsConfig { get; set; } = new();
    public CacheWriterObjectConfig CostCodeTransactionConfig { get; set; } = new();
    public CacheWriterObjectConfig CostCodeTransactionAdjustmentConfig { get; set; } = new();
    public CacheWriterObjectConfig MaterialsInstalledQuantitiesConfig { get; set; } = new();
    public CacheWriterObjectConfig SubcontractWorkQuantitiesConfig { get; set; } = new();
    public CacheWriterObjectConfig QuantityAdjustmentsConfig { get; set; } = new();
    public CacheWriterObjectConfig CustomCostTypeItemReceivedConfig { get; set; } = new();
    public CacheWriterObjectConfig CostCategoriesConfig { get; set; } = new();
    public CacheWriterObjectConfig CustomCostTypeItemsConfig { get; set; } = new();
    public CacheWriterObjectConfig JobCustomCostTypeItemsConfig { get; set; } = new();
    public CacheWriterObjectConfig JobCustomCostTypeItemConfig { get; set; } = new();
    public CacheWriterObjectConfig CustomCostTypeInstalledConfig { get; set; } = new();
    public CacheWriterObjectConfig CustomCostTypeReceivedConfig { get; set; } = new();
    public CacheWriterObjectConfig DiaryConfig { get; set; } = new();
    public CacheWriterObjectConfig DiariesConfig { get; set; } = new();
    public CacheWriterObjectConfig EmployeeConfig { get; set; } = new();
    public CacheWriterObjectConfig EmployeesConfig { get; set; } = new();
    public CacheWriterObjectConfig EmployeesWithDetailsConfig { get; set; } = new();
    public CacheWriterObjectConfig EquipmentConfig { get; set; } = new();
    public CacheWriterObjectConfig EquipmentTypeConfig { get; set; } = new();
    public CacheWriterObjectConfig ForecastInfoConfig { get; set; } = new();
    public CacheWriterObjectConfig ForecastConfig { get; set; } = new();
    public CacheWriterObjectConfig EmployeeHoursConfig { get; set; } = new();
    public CacheWriterObjectConfig EquipmentHoursConfig { get; set; } = new();
    public CacheWriterObjectConfig AttendanceHourTagsConfig { get; set; } = new();
    public CacheWriterObjectConfig NonuseHourTagsConfig { get; set; } = new();
    public CacheWriterObjectConfig JobsConfig { get; set; } = new();
    public CacheWriterObjectConfig JobEmployeesConfig { get; set; } = new();
    public CacheWriterObjectConfig JobEquipmentConfig { get; set; } = new();
    public CacheWriterObjectConfig MaterialsConfig { get; set; } = new();
    public CacheWriterObjectConfig JobMaterialConfig { get; set; } = new();
    public CacheWriterObjectConfig JobMaterialsConfig { get; set; } = new();
    public CacheWriterObjectConfig MaterialsInstalledConfig { get; set; } = new();
    public CacheWriterObjectConfig MaterialsReceivedConfig { get; set; } = new();
    public CacheWriterObjectConfig MaterialSubsAndCustomCostsConfig { get; set; } = new();
    public CacheWriterObjectConfig PayClassConfig { get; set; } = new();
    public CacheWriterObjectConfig PayItemsConfig { get; set; } = new();
    public CacheWriterObjectConfig PurchaseOrdersConfig { get; set; } = new();
    public CacheWriterObjectConfig PurchaseOrderItemsConfig { get; set; } = new();
    public CacheWriterObjectConfig MaterialPurchaseOrderDetailsConfig { get; set; } = new();
    public CacheWriterObjectConfig QuantityAdjustmentConfig { get; set; } = new();
    public CacheWriterObjectConfig ReleaseOrderApprovalRuleConfig { get; set; } = new();
    public CacheWriterObjectConfig SubcontractsConfig { get; set; } = new();
    public CacheWriterObjectConfig JobSubcontractConfig { get; set; } = new();
    public CacheWriterObjectConfig JobSubcontractsConfig { get; set; } = new();
    public CacheWriterObjectConfig SubcontractTransactionsConfig { get; set; } = new();
    public CacheWriterObjectConfig TimeCardApprovalConfig { get; set; } = new();
    public CacheWriterObjectConfig TimeCardInfoConfig { get; set; } = new();
    public CacheWriterObjectConfig TimeCardConfig { get; set; } = new();
    public CacheWriterObjectConfig MissingTimeCardForemenConfig { get; set; } = new();
    public CacheWriterObjectConfig TimeCardsForEquipmentConfig { get; set; } = new();
    public CacheWriterObjectConfig UserConfig { get; set; } = new();
    public CacheWriterObjectConfig UserAccessGroupConfig { get; set; } = new();
    public CacheWriterObjectConfig VendorsConfig { get; set; } = new();
    public CacheWriterObjectConfig VendorContractsConfig { get; set; } = new();
    public CacheWriterObjectConfig VendorContractDetailsConfig { get; set; } = new();
    public CacheWriterObjectConfig VendorContractItemsConfig { get; set; } = new();
    public CacheWriterObjectConfig EmployeesAdvancedConfig { get; set; } = new();
    public CacheWriterObjectConfig JobCostsQueryConfig { get; set; } = new();
}