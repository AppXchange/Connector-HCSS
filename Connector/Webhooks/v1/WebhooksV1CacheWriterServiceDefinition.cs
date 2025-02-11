namespace Connector.Webhooks.v1;
using Connector.Webhooks.v1.HeavyJobSubscription;
using Connector.Webhooks.v1.HeavyJobWebhooks;
using Connector.Webhooks.v1.PreConSubscription;
using Connector.Webhooks.v1.PreConWebhooks;
using Connector.Webhooks.v1.SetupsSubscription;
using Connector.Webhooks.v1.SetupsWebhooks;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using Xchange.Connector.SDK.Abstraction.Change;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Hosting.Configuration;

public class WebhooksV1CacheWriterServiceDefinition : BaseCacheWriterServiceDefinition<WebhooksV1CacheWriterConfig>
{
    public override string ModuleId => "webhooks-1";
    public override Type ServiceType => typeof(GenericCacheWriterService<WebhooksV1CacheWriterConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var serviceConfig = JsonSerializer.Deserialize<WebhooksV1CacheWriterConfig>(serviceConfigJson);
        serviceCollection.AddSingleton<WebhooksV1CacheWriterConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericCacheWriterService<WebhooksV1CacheWriterConfig>>();
        serviceCollection.AddSingleton<ICacheWriterServiceDefinition<WebhooksV1CacheWriterConfig>>(this);
        // Register Data Readers as Singletons
        serviceCollection.AddSingleton<SetupsWebhooksDataReader>();
        serviceCollection.AddSingleton<SetupsSubscriptionDataReader>();
        serviceCollection.AddSingleton<PreConWebhooksDataReader>();
        serviceCollection.AddSingleton<PreConSubscriptionDataReader>();
        serviceCollection.AddSingleton<HeavyJobWebhooksDataReader>();
        serviceCollection.AddSingleton<HeavyJobSubscriptionDataReader>();
    }

    public override IDataObjectChangeDetectorProvider ConfigureChangeDetectorProvider(IChangeDetectorFactory factory, ConnectorDefinition connectorDefinition)
    {
        var options = factory.CreateProviderOptionsWithNoDefaultResolver();
        // Configure Data Object Keys for Data Objects that do not use the default
        this.RegisterKeysForObject<SetupsWebhooksDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<SetupsSubscriptionDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<PreConWebhooksDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<PreConSubscriptionDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<HeavyJobWebhooksDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<HeavyJobSubscriptionDataObject>(options, connectorDefinition);
        return factory.CreateProvider(options);
    }

    public override void ConfigureService(ICacheWriterService service, WebhooksV1CacheWriterConfig config)
    {
        var dataReaderSettings = new DataReaderSettings
        {
            DisableDeletes = false,
            UseChangeDetection = true
        };
        // Register Data Reader configurations for the Cache Writer Service
        service.RegisterDataReader<SetupsWebhooksDataReader, SetupsWebhooksDataObject>(ModuleId, config.SetupsWebhooksConfig, dataReaderSettings);
        service.RegisterDataReader<SetupsSubscriptionDataReader, SetupsSubscriptionDataObject>(ModuleId, config.SetupsSubscriptionConfig, dataReaderSettings);
        service.RegisterDataReader<PreConWebhooksDataReader, PreConWebhooksDataObject>(ModuleId, config.PreConWebhooksConfig, dataReaderSettings);
        service.RegisterDataReader<PreConSubscriptionDataReader, PreConSubscriptionDataObject>(ModuleId, config.PreConSubscriptionConfig, dataReaderSettings);
        service.RegisterDataReader<HeavyJobWebhooksDataReader, HeavyJobWebhooksDataObject>(ModuleId, config.HeavyJobWebhooksConfig, dataReaderSettings);
        service.RegisterDataReader<HeavyJobSubscriptionDataReader, HeavyJobSubscriptionDataObject>(ModuleId, config.HeavyJobSubscriptionConfig, dataReaderSettings);
    }
}