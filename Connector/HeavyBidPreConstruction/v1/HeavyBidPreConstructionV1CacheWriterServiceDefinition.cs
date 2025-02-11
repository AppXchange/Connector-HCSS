namespace Connector.HeavyBidPreConstruction.v1;
using Connector.HeavyBidPreConstruction.v1.BusinessUnit;
using Connector.HeavyBidPreConstruction.v1.Project;
using Connector.HeavyBidPreConstruction.v1.Projects;
using Connector.HeavyBidPreConstruction.v1.Reports;
using Connector.HeavyBidPreConstruction.v1.Schema;
using Connector.HeavyBidPreConstruction.v1.Schemas;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using Xchange.Connector.SDK.Abstraction.Change;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Hosting.Configuration;

public class HeavyBidPreConstructionV1CacheWriterServiceDefinition : BaseCacheWriterServiceDefinition<HeavyBidPreConstructionV1CacheWriterConfig>
{
    public override string ModuleId => "heavybidpreconstruction-1";
    public override Type ServiceType => typeof(GenericCacheWriterService<HeavyBidPreConstructionV1CacheWriterConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var serviceConfig = JsonSerializer.Deserialize<HeavyBidPreConstructionV1CacheWriterConfig>(serviceConfigJson);
        serviceCollection.AddSingleton<HeavyBidPreConstructionV1CacheWriterConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericCacheWriterService<HeavyBidPreConstructionV1CacheWriterConfig>>();
        serviceCollection.AddSingleton<ICacheWriterServiceDefinition<HeavyBidPreConstructionV1CacheWriterConfig>>(this);
        // Register Data Readers as Singletons
        serviceCollection.AddSingleton<BusinessUnitDataReader>();
        serviceCollection.AddSingleton<ProjectsDataReader>();
        serviceCollection.AddSingleton<ProjectDataReader>();
        serviceCollection.AddSingleton<ReportsDataReader>();
        serviceCollection.AddSingleton<SchemasDataReader>();
        serviceCollection.AddSingleton<SchemaDataReader>();
    }

    public override IDataObjectChangeDetectorProvider ConfigureChangeDetectorProvider(IChangeDetectorFactory factory, ConnectorDefinition connectorDefinition)
    {
        var options = factory.CreateProviderOptionsWithNoDefaultResolver();
        // Configure Data Object Keys for Data Objects that do not use the default
        this.RegisterKeysForObject<BusinessUnitDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ProjectsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ProjectDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ReportsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<SchemasDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<SchemaDataObject>(options, connectorDefinition);
        return factory.CreateProvider(options);
    }

    public override void ConfigureService(ICacheWriterService service, HeavyBidPreConstructionV1CacheWriterConfig config)
    {
        var dataReaderSettings = new DataReaderSettings
        {
            DisableDeletes = false,
            UseChangeDetection = true
        };
        // Register Data Reader configurations for the Cache Writer Service
        service.RegisterDataReader<BusinessUnitDataReader, BusinessUnitDataObject>(ModuleId, config.BusinessUnitConfig, dataReaderSettings);
        service.RegisterDataReader<ProjectsDataReader, ProjectsDataObject>(ModuleId, config.ProjectsConfig, dataReaderSettings);
        service.RegisterDataReader<ProjectDataReader, ProjectDataObject>(ModuleId, config.ProjectConfig, dataReaderSettings);
        service.RegisterDataReader<ReportsDataReader, ReportsDataObject>(ModuleId, config.ReportsConfig, dataReaderSettings);
        service.RegisterDataReader<SchemasDataReader, SchemasDataObject>(ModuleId, config.SchemasConfig, dataReaderSettings);
        service.RegisterDataReader<SchemaDataReader, SchemaDataObject>(ModuleId, config.SchemaConfig, dataReaderSettings);
    }
}