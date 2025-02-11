namespace Connector.Setups.v1;
using Connector.Setups.v1.BulkCostCode;
using Connector.Setups.v1.BulkCostCode.Create;
using Connector.Setups.v1.BusinessUnit;
using Connector.Setups.v1.BusinessUnit.Create;
using Connector.Setups.v1.CostCode;
using Connector.Setups.v1.CostCode.Create;
using Connector.Setups.v1.CostCode.Update;
using Connector.Setups.v1.Employee;
using Connector.Setups.v1.Employee.Create;
using Connector.Setups.v1.Employee.Update;
using Connector.Setups.v1.Equipment;
using Connector.Setups.v1.Equipment.Create;
using Connector.Setups.v1.Equipment.Update;
using Connector.Setups.v1.Job;
using Connector.Setups.v1.Job.Create;
using Connector.Setups.v1.Job.Update;
using Connector.Setups.v1.PayClass;
using Connector.Setups.v1.PayClass.Create;
using Connector.Setups.v1.PayClass.Update;
using Connector.Setups.v1.RateSet;
using Connector.Setups.v1.RateSet.Create;
using Connector.Setups.v1.RateSet.Update;
using Connector.Setups.v1.RateSetCostAdjustment;
using Connector.Setups.v1.RateSetCostAdjustment.Create;
using Connector.Setups.v1.RateSetCostAdjustment.Update;
using Connector.Setups.v1.RateSetEquipment;
using Connector.Setups.v1.RateSetEquipment.Create;
using Connector.Setups.v1.RateSetEquipment.Update;
using Connector.Setups.v1.RateSetGroup;
using Connector.Setups.v1.RateSetGroup.Create;
using Connector.Setups.v1.RateSetGroup.Update;
using Connector.Setups.v1.RateSetPayClass;
using Connector.Setups.v1.RateSetPayClass.Create;
using Connector.Setups.v1.RateSetPayClass.Update;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.Action;

public class SetupsV1ActionProcessorServiceDefinition : BaseActionHandlerServiceDefinition<SetupsV1ActionProcessorConfig>
{
    public override string ModuleId => "setups-1";
    public override Type ServiceType => typeof(GenericActionHandlerService<SetupsV1ActionProcessorConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var options = new JsonSerializerOptions
        {
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };
        var serviceConfig = JsonSerializer.Deserialize<SetupsV1ActionProcessorConfig>(serviceConfigJson, options);
        serviceCollection.AddSingleton<SetupsV1ActionProcessorConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericActionHandlerService<SetupsV1ActionProcessorConfig>>();
        serviceCollection.AddSingleton<IActionHandlerServiceDefinition<SetupsV1ActionProcessorConfig>>(this);
        // Register Action Handlers as scoped dependencies
        serviceCollection.AddScoped<CreateBulkCostCodeHandler>();
        serviceCollection.AddScoped<CreateBusinessUnitHandler>();
        serviceCollection.AddScoped<CreateCostCodeHandler>();
        serviceCollection.AddScoped<UpdateCostCodeHandler>();
        serviceCollection.AddScoped<CreateEmployeeHandler>();
        serviceCollection.AddScoped<UpdateEmployeeHandler>();
        serviceCollection.AddScoped<CreateEquipmentHandler>();
        serviceCollection.AddScoped<UpdateEquipmentHandler>();
        serviceCollection.AddScoped<CreateJobHandler>();
        serviceCollection.AddScoped<UpdateJobHandler>();
        serviceCollection.AddScoped<CreatePayClassHandler>();
        serviceCollection.AddScoped<UpdatePayClassHandler>();
        serviceCollection.AddScoped<CreateRateSetHandler>();
        serviceCollection.AddScoped<UpdateRateSetHandler>();
        serviceCollection.AddScoped<CreateRateSetPayClassHandler>();
        serviceCollection.AddScoped<UpdateRateSetPayClassHandler>();
        serviceCollection.AddScoped<CreateRateSetEquipmentHandler>();
        serviceCollection.AddScoped<UpdateRateSetEquipmentHandler>();
        serviceCollection.AddScoped<CreateRateSetCostAdjustmentHandler>();
        serviceCollection.AddScoped<UpdateRateSetCostAdjustmentHandler>();
        serviceCollection.AddScoped<CreateRateSetGroupHandler>();
        serviceCollection.AddScoped<UpdateRateSetGroupHandler>();
    }

    public override void ConfigureService(IActionHandlerService service, SetupsV1ActionProcessorConfig config)
    {
        // Register Action Handler configurations for the Action Processor Service
        service.RegisterHandlerForDataObjectAction<CreateBulkCostCodeHandler, BulkCostCodeDataObject>(ModuleId, "bulk-cost-code", "create", config.CreateBulkCostCodeConfig);
        service.RegisterHandlerForDataObjectAction<CreateBusinessUnitHandler, BusinessUnitDataObject>(ModuleId, "business-unit", "create", config.CreateBusinessUnitConfig);
        service.RegisterHandlerForDataObjectAction<CreateCostCodeHandler, CostCodeDataObject>(ModuleId, "cost-code", "create", config.CreateCostCodeConfig);
        service.RegisterHandlerForDataObjectAction<UpdateCostCodeHandler, CostCodeDataObject>(ModuleId, "cost-code", "update", config.UpdateCostCodeConfig);
        service.RegisterHandlerForDataObjectAction<CreateEmployeeHandler, EmployeeDataObject>(ModuleId, "employee", "create", config.CreateEmployeeConfig);
        service.RegisterHandlerForDataObjectAction<UpdateEmployeeHandler, EmployeeDataObject>(ModuleId, "employee", "update", config.UpdateEmployeeConfig);
        service.RegisterHandlerForDataObjectAction<CreateEquipmentHandler, EquipmentDataObject>(ModuleId, "equipment", "create", config.CreateEquipmentConfig);
        service.RegisterHandlerForDataObjectAction<UpdateEquipmentHandler, EquipmentDataObject>(ModuleId, "equipment", "update", config.UpdateEquipmentConfig);
        service.RegisterHandlerForDataObjectAction<CreateJobHandler, JobDataObject>(ModuleId, "job", "create", config.CreateJobConfig);
        service.RegisterHandlerForDataObjectAction<UpdateJobHandler, JobDataObject>(ModuleId, "job", "update", config.UpdateJobConfig);
        service.RegisterHandlerForDataObjectAction<CreatePayClassHandler, PayClassDataObject>(ModuleId, "pay-class", "create", config.CreatePayClassConfig);
        service.RegisterHandlerForDataObjectAction<UpdatePayClassHandler, PayClassDataObject>(ModuleId, "pay-class", "update", config.UpdatePayClassConfig);
        service.RegisterHandlerForDataObjectAction<CreateRateSetHandler, RateSetDataObject>(ModuleId, "rate-set", "create", config.CreateRateSetConfig);
        service.RegisterHandlerForDataObjectAction<UpdateRateSetHandler, RateSetDataObject>(ModuleId, "rate-set", "update", config.UpdateRateSetConfig);
        service.RegisterHandlerForDataObjectAction<CreateRateSetPayClassHandler, RateSetPayClassDataObject>(ModuleId, "rate-set-pay-class", "create", config.CreateRateSetPayClassConfig);
        service.RegisterHandlerForDataObjectAction<UpdateRateSetPayClassHandler, RateSetPayClassDataObject>(ModuleId, "rate-set-pay-class", "update", config.UpdateRateSetPayClassConfig);
        service.RegisterHandlerForDataObjectAction<CreateRateSetEquipmentHandler, RateSetEquipmentDataObject>(ModuleId, "rate-set-equipment", "create", config.CreateRateSetEquipmentConfig);
        service.RegisterHandlerForDataObjectAction<UpdateRateSetEquipmentHandler, RateSetEquipmentDataObject>(ModuleId, "rate-set-equipment", "update", config.UpdateRateSetEquipmentConfig);
        service.RegisterHandlerForDataObjectAction<CreateRateSetCostAdjustmentHandler, RateSetCostAdjustmentDataObject>(ModuleId, "rate-set-cost-adjustment", "create", config.CreateRateSetCostAdjustmentConfig);
        service.RegisterHandlerForDataObjectAction<UpdateRateSetCostAdjustmentHandler, RateSetCostAdjustmentDataObject>(ModuleId, "rate-set-cost-adjustment", "update", config.UpdateRateSetCostAdjustmentConfig);
        service.RegisterHandlerForDataObjectAction<CreateRateSetGroupHandler, RateSetGroupDataObject>(ModuleId, "rate-set-group", "create", config.CreateRateSetGroupConfig);
        service.RegisterHandlerForDataObjectAction<UpdateRateSetGroupHandler, RateSetGroupDataObject>(ModuleId, "rate-set-group", "update", config.UpdateRateSetGroupConfig);
    }
}