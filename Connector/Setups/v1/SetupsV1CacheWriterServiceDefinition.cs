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
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using Xchange.Connector.SDK.Abstraction.Change;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Hosting.Configuration;

public class SetupsV1CacheWriterServiceDefinition : BaseCacheWriterServiceDefinition<SetupsV1CacheWriterConfig>
{
    public override string ModuleId => "setups-1";
    public override Type ServiceType => typeof(GenericCacheWriterService<SetupsV1CacheWriterConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var serviceConfig = JsonSerializer.Deserialize<SetupsV1CacheWriterConfig>(serviceConfigJson);
        serviceCollection.AddSingleton<SetupsV1CacheWriterConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericCacheWriterService<SetupsV1CacheWriterConfig>>();
        serviceCollection.AddSingleton<ICacheWriterServiceDefinition<SetupsV1CacheWriterConfig>>(this);
        // Register Data Readers as Singletons
        serviceCollection.AddSingleton<AccountingTemplateDataReader>();
        serviceCollection.AddSingleton<BulkCostCodeDataReader>();
        serviceCollection.AddSingleton<BusinessUnitDataReader>();
        serviceCollection.AddSingleton<BusinessUnitDefaultDataReader>();
        serviceCollection.AddSingleton<CostCodeDataReader>();
        serviceCollection.AddSingleton<EmployeeDataReader>();
        serviceCollection.AddSingleton<EquipmentDataReader>();
        serviceCollection.AddSingleton<JobDataReader>();
        serviceCollection.AddSingleton<PayClassDataReader>();
        serviceCollection.AddSingleton<RateSetDataReader>();
        serviceCollection.AddSingleton<RateSetPayClassDataReader>();
        serviceCollection.AddSingleton<RateSetEquipmentDataReader>();
        serviceCollection.AddSingleton<RateSetCostAdjustmentDataReader>();
        serviceCollection.AddSingleton<RateSetGroupDataReader>();
    }

    public override IDataObjectChangeDetectorProvider ConfigureChangeDetectorProvider(IChangeDetectorFactory factory, ConnectorDefinition connectorDefinition)
    {
        var options = factory.CreateProviderOptionsWithNoDefaultResolver();
        // Configure Data Object Keys for Data Objects that do not use the default
        this.RegisterKeysForObject<AccountingTemplateDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<BulkCostCodeDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<BusinessUnitDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<BusinessUnitDefaultDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<CostCodeDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<EmployeeDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<EquipmentDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<JobDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<PayClassDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<RateSetDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<RateSetPayClassDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<RateSetEquipmentDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<RateSetCostAdjustmentDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<RateSetGroupDataObject>(options, connectorDefinition);
        return factory.CreateProvider(options);
    }

    public override void ConfigureService(ICacheWriterService service, SetupsV1CacheWriterConfig config)
    {
        var dataReaderSettings = new DataReaderSettings
        {
            DisableDeletes = false,
            UseChangeDetection = true
        };
        // Register Data Reader configurations for the Cache Writer Service
        service.RegisterDataReader<AccountingTemplateDataReader, AccountingTemplateDataObject>(ModuleId, config.AccountingTemplateConfig, dataReaderSettings);
        service.RegisterDataReader<BulkCostCodeDataReader, BulkCostCodeDataObject>(ModuleId, config.BulkCostCodeConfig, dataReaderSettings);
        service.RegisterDataReader<BusinessUnitDataReader, BusinessUnitDataObject>(ModuleId, config.BusinessUnitConfig, dataReaderSettings);
        service.RegisterDataReader<BusinessUnitDefaultDataReader, BusinessUnitDefaultDataObject>(ModuleId, config.BusinessUnitDefaultConfig, dataReaderSettings);
        service.RegisterDataReader<CostCodeDataReader, CostCodeDataObject>(ModuleId, config.CostCodeConfig, dataReaderSettings);
        service.RegisterDataReader<EmployeeDataReader, EmployeeDataObject>(ModuleId, config.EmployeeConfig, dataReaderSettings);
        service.RegisterDataReader<EquipmentDataReader, EquipmentDataObject>(ModuleId, config.EquipmentConfig, dataReaderSettings);
        service.RegisterDataReader<JobDataReader, JobDataObject>(ModuleId, config.JobConfig, dataReaderSettings);
        service.RegisterDataReader<PayClassDataReader, PayClassDataObject>(ModuleId, config.PayClassConfig, dataReaderSettings);
        service.RegisterDataReader<RateSetDataReader, RateSetDataObject>(ModuleId, config.RateSetConfig, dataReaderSettings);
        service.RegisterDataReader<RateSetPayClassDataReader, RateSetPayClassDataObject>(ModuleId, config.RateSetPayClassConfig, dataReaderSettings);
        service.RegisterDataReader<RateSetEquipmentDataReader, RateSetEquipmentDataObject>(ModuleId, config.RateSetEquipmentConfig, dataReaderSettings);
        service.RegisterDataReader<RateSetCostAdjustmentDataReader, RateSetCostAdjustmentDataObject>(ModuleId, config.RateSetCostAdjustmentConfig, dataReaderSettings);
        service.RegisterDataReader<RateSetGroupDataReader, RateSetGroupDataObject>(ModuleId, config.RateSetGroupConfig, dataReaderSettings);
    }
}