namespace Connector.Users.v1;
using Connector.Users.v1.BusinessUnits;
using Connector.Users.v1.Jobs;
using Connector.Users.v1.Roles;
using Connector.Users.v1.SubscriptionGroups;
using Connector.Users.v1.User;
using Connector.Users.v1.Username;
using Connector.Users.v1.Users;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using Xchange.Connector.SDK.Abstraction.Change;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Hosting.Configuration;

public class UsersV1CacheWriterServiceDefinition : BaseCacheWriterServiceDefinition<UsersV1CacheWriterConfig>
{
    public override string ModuleId => "users-1";
    public override Type ServiceType => typeof(GenericCacheWriterService<UsersV1CacheWriterConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var serviceConfig = JsonSerializer.Deserialize<UsersV1CacheWriterConfig>(serviceConfigJson);
        serviceCollection.AddSingleton<UsersV1CacheWriterConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericCacheWriterService<UsersV1CacheWriterConfig>>();
        serviceCollection.AddSingleton<ICacheWriterServiceDefinition<UsersV1CacheWriterConfig>>(this);
        // Register Data Readers as Singletons
        serviceCollection.AddSingleton<BusinessUnitsDataReader>();
        serviceCollection.AddSingleton<JobsDataReader>();
        serviceCollection.AddSingleton<RolesDataReader>();
        serviceCollection.AddSingleton<SubscriptionGroupsDataReader>();
        serviceCollection.AddSingleton<UsersDataReader>();
        serviceCollection.AddSingleton<UserDataReader>();
        serviceCollection.AddSingleton<UsernameDataReader>();
    }

    public override IDataObjectChangeDetectorProvider ConfigureChangeDetectorProvider(IChangeDetectorFactory factory, ConnectorDefinition connectorDefinition)
    {
        var options = factory.CreateProviderOptionsWithNoDefaultResolver();
        // Configure Data Object Keys for Data Objects that do not use the default
        this.RegisterKeysForObject<BusinessUnitsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<JobsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<RolesDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<SubscriptionGroupsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<UsersDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<UserDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<UsernameDataObject>(options, connectorDefinition);
        return factory.CreateProvider(options);
    }

    public override void ConfigureService(ICacheWriterService service, UsersV1CacheWriterConfig config)
    {
        var dataReaderSettings = new DataReaderSettings
        {
            DisableDeletes = false,
            UseChangeDetection = true
        };
        // Register Data Reader configurations for the Cache Writer Service
        service.RegisterDataReader<BusinessUnitsDataReader, BusinessUnitsDataObject>(ModuleId, config.BusinessUnitsConfig, dataReaderSettings);
        service.RegisterDataReader<JobsDataReader, JobsDataObject>(ModuleId, config.JobsConfig, dataReaderSettings);
        service.RegisterDataReader<RolesDataReader, RolesDataObject>(ModuleId, config.RolesConfig, dataReaderSettings);
        service.RegisterDataReader<SubscriptionGroupsDataReader, SubscriptionGroupsDataObject>(ModuleId, config.SubscriptionGroupsConfig, dataReaderSettings);
        service.RegisterDataReader<UsersDataReader, UsersDataObject>(ModuleId, config.UsersConfig, dataReaderSettings);
        service.RegisterDataReader<UserDataReader, UserDataObject>(ModuleId, config.UserConfig, dataReaderSettings);
        service.RegisterDataReader<UsernameDataReader, UsernameDataObject>(ModuleId, config.UsernameConfig, dataReaderSettings);
    }
}