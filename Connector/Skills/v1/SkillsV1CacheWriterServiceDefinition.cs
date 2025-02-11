namespace Connector.Skills.v1;
using Connector.Skills.v1.EmployeeSkillImport;
using Connector.Skills.v1.EmployeeSkills;
using Connector.Skills.v1.EmployeeSkillsByEmployee;
using Connector.Skills.v1.EmployeeSkillsBySkill;
using Connector.Skills.v1.Skill;
using Connector.Skills.v1.Skills;
using Connector.Skills.v1.Skillsimport;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using Xchange.Connector.SDK.Abstraction.Change;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Hosting.Configuration;

public class SkillsV1CacheWriterServiceDefinition : BaseCacheWriterServiceDefinition<SkillsV1CacheWriterConfig>
{
    public override string ModuleId => "skills-1";
    public override Type ServiceType => typeof(GenericCacheWriterService<SkillsV1CacheWriterConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var serviceConfig = JsonSerializer.Deserialize<SkillsV1CacheWriterConfig>(serviceConfigJson);
        serviceCollection.AddSingleton<SkillsV1CacheWriterConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericCacheWriterService<SkillsV1CacheWriterConfig>>();
        serviceCollection.AddSingleton<ICacheWriterServiceDefinition<SkillsV1CacheWriterConfig>>(this);
        // Register Data Readers as Singletons
        serviceCollection.AddSingleton<EmployeeSkillsByEmployeeDataReader>();
        serviceCollection.AddSingleton<EmployeeSkillsBySkillDataReader>();
        serviceCollection.AddSingleton<EmployeeSkillsDataReader>();
        serviceCollection.AddSingleton<EmployeeSkillImportDataReader>();
        serviceCollection.AddSingleton<SkillDataReader>();
        serviceCollection.AddSingleton<SkillsDataReader>();
        serviceCollection.AddSingleton<SkillsimportDataReader>();
    }

    public override IDataObjectChangeDetectorProvider ConfigureChangeDetectorProvider(IChangeDetectorFactory factory, ConnectorDefinition connectorDefinition)
    {
        var options = factory.CreateProviderOptionsWithNoDefaultResolver();
        // Configure Data Object Keys for Data Objects that do not use the default
        this.RegisterKeysForObject<EmployeeSkillsByEmployeeDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<EmployeeSkillsBySkillDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<EmployeeSkillsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<EmployeeSkillImportDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<SkillDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<SkillsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<SkillsimportDataObject>(options, connectorDefinition);
        return factory.CreateProvider(options);
    }

    public override void ConfigureService(ICacheWriterService service, SkillsV1CacheWriterConfig config)
    {
        var dataReaderSettings = new DataReaderSettings
        {
            DisableDeletes = false,
            UseChangeDetection = true
        };
        // Register Data Reader configurations for the Cache Writer Service
        service.RegisterDataReader<EmployeeSkillsByEmployeeDataReader, EmployeeSkillsByEmployeeDataObject>(ModuleId, config.EmployeeSkillsByEmployeeConfig, dataReaderSettings);
        service.RegisterDataReader<EmployeeSkillsBySkillDataReader, EmployeeSkillsBySkillDataObject>(ModuleId, config.EmployeeSkillsBySkillConfig, dataReaderSettings);
        service.RegisterDataReader<EmployeeSkillsDataReader, EmployeeSkillsDataObject>(ModuleId, config.EmployeeSkillsConfig, dataReaderSettings);
        service.RegisterDataReader<EmployeeSkillImportDataReader, EmployeeSkillImportDataObject>(ModuleId, config.EmployeeSkillImportConfig, dataReaderSettings);
        service.RegisterDataReader<SkillDataReader, SkillDataObject>(ModuleId, config.SkillConfig, dataReaderSettings);
        service.RegisterDataReader<SkillsDataReader, SkillsDataObject>(ModuleId, config.SkillsConfig, dataReaderSettings);
        service.RegisterDataReader<SkillsimportDataReader, SkillsimportDataObject>(ModuleId, config.SkillsimportConfig, dataReaderSettings);
    }
}