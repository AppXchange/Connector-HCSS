namespace Connector.Safety.v1;
using Connector.Safety.v1.AccessGroups;
using Connector.Safety.v1.Alerts;
using Connector.Safety.v1.Incident;
using Connector.Safety.v1.IncidentFormTypes;
using Connector.Safety.v1.Incidents;
using Connector.Safety.v1.IncidentV2;
using Connector.Safety.v1.InspectionTypes;
using Connector.Safety.v1.Jobs;
using Connector.Safety.v1.Meetings;
using Connector.Safety.v1.Providers;
using Connector.Safety.v1.UserAccessGroups;
using Connector.Safety.v1.Users;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using Xchange.Connector.SDK.Abstraction.Change;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Hosting.Configuration;

public class SafetyV1CacheWriterServiceDefinition : BaseCacheWriterServiceDefinition<SafetyV1CacheWriterConfig>
{
    public override string ModuleId => "safety-1";
    public override Type ServiceType => typeof(GenericCacheWriterService<SafetyV1CacheWriterConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var serviceConfig = JsonSerializer.Deserialize<SafetyV1CacheWriterConfig>(serviceConfigJson);
        serviceCollection.AddSingleton<SafetyV1CacheWriterConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericCacheWriterService<SafetyV1CacheWriterConfig>>();
        serviceCollection.AddSingleton<ICacheWriterServiceDefinition<SafetyV1CacheWriterConfig>>(this);
        // Register Data Readers as Singletons
        serviceCollection.AddSingleton<AccessGroupsDataReader>();
        serviceCollection.AddSingleton<AlertsDataReader>();
        serviceCollection.AddSingleton<IncidentFormTypesDataReader>();
        serviceCollection.AddSingleton<IncidentDataReader>();
        serviceCollection.AddSingleton<IncidentsDataReader>();
        serviceCollection.AddSingleton<IncidentV2DataReader>();
        serviceCollection.AddSingleton<InspectionTypesDataReader>();
        serviceCollection.AddSingleton<JobsDataReader>();
        serviceCollection.AddSingleton<MeetingsDataReader>();
        serviceCollection.AddSingleton<ProvidersDataReader>();
        serviceCollection.AddSingleton<UserAccessGroupsDataReader>();
        serviceCollection.AddSingleton<UsersDataReader>();
    }

    public override IDataObjectChangeDetectorProvider ConfigureChangeDetectorProvider(IChangeDetectorFactory factory, ConnectorDefinition connectorDefinition)
    {
        var options = factory.CreateProviderOptionsWithNoDefaultResolver();
        // Configure Data Object Keys for Data Objects that do not use the default
        this.RegisterKeysForObject<AccessGroupsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<AlertsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<IncidentFormTypesDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<IncidentDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<IncidentsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<IncidentV2DataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<InspectionTypesDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<JobsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<MeetingsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ProvidersDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<UserAccessGroupsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<UsersDataObject>(options, connectorDefinition);
        return factory.CreateProvider(options);
    }

    public override void ConfigureService(ICacheWriterService service, SafetyV1CacheWriterConfig config)
    {
        var dataReaderSettings = new DataReaderSettings
        {
            DisableDeletes = false,
            UseChangeDetection = true
        };
        // Register Data Reader configurations for the Cache Writer Service
        service.RegisterDataReader<AccessGroupsDataReader, AccessGroupsDataObject>(ModuleId, config.AccessGroupsConfig, dataReaderSettings);
        service.RegisterDataReader<AlertsDataReader, AlertsDataObject>(ModuleId, config.AlertsConfig, dataReaderSettings);
        service.RegisterDataReader<IncidentFormTypesDataReader, IncidentFormTypesDataObject>(ModuleId, config.IncidentFormTypesConfig, dataReaderSettings);
        service.RegisterDataReader<IncidentDataReader, IncidentDataObject>(ModuleId, config.IncidentConfig, dataReaderSettings);
        service.RegisterDataReader<IncidentsDataReader, IncidentsDataObject>(ModuleId, config.IncidentsConfig, dataReaderSettings);
        service.RegisterDataReader<IncidentV2DataReader, IncidentV2DataObject>(ModuleId, config.IncidentV2Config, dataReaderSettings);
        service.RegisterDataReader<InspectionTypesDataReader, InspectionTypesDataObject>(ModuleId, config.InspectionTypesConfig, dataReaderSettings);
        service.RegisterDataReader<JobsDataReader, JobsDataObject>(ModuleId, config.JobsConfig, dataReaderSettings);
        service.RegisterDataReader<MeetingsDataReader, MeetingsDataObject>(ModuleId, config.MeetingsConfig, dataReaderSettings);
        service.RegisterDataReader<ProvidersDataReader, ProvidersDataObject>(ModuleId, config.ProvidersConfig, dataReaderSettings);
        service.RegisterDataReader<UserAccessGroupsDataReader, UserAccessGroupsDataObject>(ModuleId, config.UserAccessGroupsConfig, dataReaderSettings);
        service.RegisterDataReader<UsersDataReader, UsersDataObject>(ModuleId, config.UsersConfig, dataReaderSettings);
    }
}