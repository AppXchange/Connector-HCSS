namespace Connector.HeavyJob.v1;
using Connector.HeavyJob.v1.AdvancedBudgetCustomCostTypeItem.Create;
using Connector.HeavyJob.v1.AdvancedBudgetMaterial.Create;
using Connector.HeavyJob.v1.AdvancedBudgetSubcontract.Create;
using Connector.HeavyJob.v1.Attachment.Create;
using Connector.HeavyJob.v1.BulkCreateJobsRequest.Create;
using Connector.HeavyJob.v1.BulkCreateJobsRequests.Create;
using Connector.HeavyJob.v1.BusinessUnitPreference.Update;
using Connector.HeavyJob.v1.ChangeOrder.Create;
using Connector.HeavyJob.v1.ChangeOrder.Delete;
using Connector.HeavyJob.v1.ChangeOrder.Update;
using Connector.HeavyJob.v1.CostAdjustments.Create;
using Connector.HeavyJob.v1.CostAdjustments.Delete;
using Connector.HeavyJob.v1.CostAdjustments.Update;
using Connector.HeavyJob.v1.CostCategories.Create;
using Connector.HeavyJob.v1.CostCodeCosts.Update;
using Connector.HeavyJob.v1.CostCodeProgress.Create;
using Connector.HeavyJob.v1.CostCodes.Create;
using Connector.HeavyJob.v1.CostCodes.Update;
using Connector.HeavyJob.v1.CostCodeTags.Create;
using Connector.HeavyJob.v1.CostCodeTags.Delete;
using Connector.HeavyJob.v1.CostCodeTags.Update;
using Connector.HeavyJob.v1.CostCodeTransaction.Create;
using Connector.HeavyJob.v1.CostCodeTransactionAdjustment.Create;
using Connector.HeavyJob.v1.CustomCostTypeInstalled.Create;
using Connector.HeavyJob.v1.CustomCostTypeItemReceived.Update;
using Connector.HeavyJob.v1.CustomCostTypeItems.Create;
using Connector.HeavyJob.v1.CustomCostTypeItems.Delete;
using Connector.HeavyJob.v1.CustomCostTypeItems.Update;
using Connector.HeavyJob.v1.CustomCostTypeReceived.Create;
using Connector.HeavyJob.v1.Diaries.Create;
using Connector.HeavyJob.v1.Diary.Create;
using Connector.HeavyJob.v1.Employee.Delete;
using Connector.HeavyJob.v1.EmployeeHours.Create;
using Connector.HeavyJob.v1.Employees.Create;
using Connector.HeavyJob.v1.Equipment.Create;
using Connector.HeavyJob.v1.Equipment.Update;
using Connector.HeavyJob.v1.EquipmentHours.Create;
using Connector.HeavyJob.v1.EquipmentType.Create;
using Connector.HeavyJob.v1.JobCostCustomCost.Create;
using Connector.HeavyJob.v1.JobCosts.Create;
using Connector.HeavyJob.v1.JobCostsToDate.Create;
using Connector.HeavyJob.v1.JobCustomCostTypeItem.Create;
using Connector.HeavyJob.v1.JobCustomCostTypeItem.Delete;
using Connector.HeavyJob.v1.JobCustomCostTypeItem.Update;
using Connector.HeavyJob.v1.JobEmployees.Delete;
using Connector.HeavyJob.v1.JobEmployees.Update;
using Connector.HeavyJob.v1.JobEquipment.Delete;
using Connector.HeavyJob.v1.JobEquipment.Update;
using Connector.HeavyJob.v1.JobMaterial.Create;
using Connector.HeavyJob.v1.JobMaterial.Delete;
using Connector.HeavyJob.v1.JobMaterial.Update;
using Connector.HeavyJob.v1.Jobs.Create;
using Connector.HeavyJob.v1.Jobs.Update;
using Connector.HeavyJob.v1.JobSubcontract.Create;
using Connector.HeavyJob.v1.JobSubcontract.Delete;
using Connector.HeavyJob.v1.JobSubcontract.Update;
using Connector.HeavyJob.v1.MaterialPurchaseOrderDetails.Create;
using Connector.HeavyJob.v1.MaterialPurchaseOrderDetails.Update;
using Connector.HeavyJob.v1.Materials.Create;
using Connector.HeavyJob.v1.Materials.Delete;
using Connector.HeavyJob.v1.Materials.Update;
using Connector.HeavyJob.v1.MaterialsInstalled.Create;
using Connector.HeavyJob.v1.MaterialsReceived.Create;
using Connector.HeavyJob.v1.MaterialSubsAndCustomCosts.Update;
using Connector.HeavyJob.v1.PayClass.Update;
using Connector.HeavyJob.v1.PayItems.Create;
using Connector.HeavyJob.v1.PayItems.Update;
using Connector.HeavyJob.v1.PurchaseOrders.Create;
using Connector.HeavyJob.v1.PurchaseOrders.Update;
using Connector.HeavyJob.v1.QuantityAdjustment.Create;
using Connector.HeavyJob.v1.ReleaseOrderApprovalRule.Delete;
using Connector.HeavyJob.v1.Subcontracts.Create;
using Connector.HeavyJob.v1.Subcontracts.Delete;
using Connector.HeavyJob.v1.Subcontracts.Update;
using Connector.HeavyJob.v1.SubcontractTransactions.Create;
using Connector.HeavyJob.v1.TimeCard.Update;
using Connector.HeavyJob.v1.UserAccessGroup.Create;
using Connector.HeavyJob.v1.UserAccessGroup.Update;
using Connector.HeavyJob.v1.VendorContractDetails.Create;
using Connector.HeavyJob.v1.VendorContractDetails.Update;
using Connector.HeavyJob.v1.VendorContracts.Create;
using Connector.HeavyJob.v1.VendorContracts.Update;
using Connector.HeavyJob.v1.Vendors.Create;
using Connector.HeavyJob.v1.Vendors.Delete;
using Connector.HeavyJob.v1.Vendors.Update;
using Json.Schema.Generation;
using Xchange.Connector.SDK.Action;

/// <summary>
/// Configuration for the Action Processor for this module. This configuration will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// The schema will be used for validation at runtime to make sure the configurations are properly formed. 
/// The schema also helps provide integrators more information for what the values are intended to be.
/// </summary>
[Title("HeavyJob V1 Action Processor Configuration")]
[Description("Configuration of the data object actions for the module.")]
public class HeavyJobV1ActionProcessorConfig
{
    // Action Handler configuration
    public DefaultActionHandlerConfig CreateAdvancedBudgetMaterialConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateAdvancedBudgetSubcontractConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateAdvancedBudgetCustomCostTypeItemConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateAttachmentConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateBulkCreateJobsRequestsConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateBulkCreateJobsRequestConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateBusinessUnitPreferenceConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteChangeOrderConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateChangeOrderConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateChangeOrderConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateJobCostsConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateJobCostsToDateConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateJobCostCustomCostConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateCostCodeCostsConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateCostAdjustmentsConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateCostAdjustmentsConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteCostAdjustmentsConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateCostCodesConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateCostCodesConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateCostCodeProgressConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteCostCodeTagsConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateCostCodeTagsConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateCostCodeTagsConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateCostCodeTransactionConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateCostCodeTransactionAdjustmentConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateCustomCostTypeItemReceivedConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateCostCategoriesConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateCustomCostTypeItemsConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateCustomCostTypeItemsConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteCustomCostTypeItemsConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateJobCustomCostTypeItemConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateJobCustomCostTypeItemConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteJobCustomCostTypeItemConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateCustomCostTypeInstalledConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateCustomCostTypeReceivedConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateDiaryConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateDiariesConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateEmployeesConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteEmployeeConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateEquipmentConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateEquipmentConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateEquipmentTypeConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateEmployeeHoursConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateEquipmentHoursConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateJobsConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateJobsConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteJobEmployeesConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateJobEmployeesConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateJobEquipmentConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteJobEquipmentConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateMaterialsConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateMaterialsConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteMaterialsConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateJobMaterialConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateJobMaterialConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteJobMaterialConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateMaterialsInstalledConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateMaterialsReceivedConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateMaterialSubsAndCustomCostsConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdatePayClassConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreatePayItemsConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdatePayItemsConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreatePurchaseOrdersConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdatePurchaseOrdersConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateMaterialPurchaseOrderDetailsConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateMaterialPurchaseOrderDetailsConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateQuantityAdjustmentConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteReleaseOrderApprovalRuleConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateSubcontractsConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateSubcontractsConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteSubcontractsConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateJobSubcontractConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateJobSubcontractConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteJobSubcontractConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateSubcontractTransactionsConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateTimeCardConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateUserAccessGroupConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateUserAccessGroupConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateVendorsConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateVendorsConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteVendorsConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateVendorContractsConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateVendorContractsConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateVendorContractDetailsConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateVendorContractDetailsConfig { get; set; } = new();
}