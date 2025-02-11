namespace Connector.Webhooks.v1;
using Connector.Webhooks.v1.HeavyJobSubscription;
using Connector.Webhooks.v1.HeavyJobSubscription.Create;
using Connector.Webhooks.v1.HeavyJobSubscription.Delete;
using Connector.Webhooks.v1.HeavyJobSubscription.Update;
using Connector.Webhooks.v1.PreConSubscription;
using Connector.Webhooks.v1.PreConSubscription.Create;
using Connector.Webhooks.v1.PreConSubscription.Delete;
using Connector.Webhooks.v1.PreConSubscription.Update;
using Connector.Webhooks.v1.SetupsSubscription;
using Connector.Webhooks.v1.SetupsSubscription.Create;
using Connector.Webhooks.v1.SetupsSubscription.Delete;
using Connector.Webhooks.v1.SetupsSubscription.Update;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.Action;

public class WebhooksV1ActionProcessorServiceDefinition : BaseActionHandlerServiceDefinition<WebhooksV1ActionProcessorConfig>
{
    public override string ModuleId => "webhooks-1";
    public override Type ServiceType => typeof(GenericActionHandlerService<WebhooksV1ActionProcessorConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var options = new JsonSerializerOptions
        {
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };
        var serviceConfig = JsonSerializer.Deserialize<WebhooksV1ActionProcessorConfig>(serviceConfigJson, options);
        serviceCollection.AddSingleton<WebhooksV1ActionProcessorConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericActionHandlerService<WebhooksV1ActionProcessorConfig>>();
        serviceCollection.AddSingleton<IActionHandlerServiceDefinition<WebhooksV1ActionProcessorConfig>>(this);
        // Register Action Handlers as scoped dependencies
        serviceCollection.AddScoped<CreateSetupsSubscriptionHandler>();
        serviceCollection.AddScoped<UpdateSetupsSubscriptionHandler>();
        serviceCollection.AddScoped<DeleteSetupsSubscriptionHandler>();
        serviceCollection.AddScoped<CreatePreConSubscriptionHandler>();
        serviceCollection.AddScoped<UpdatePreConSubscriptionHandler>();
        serviceCollection.AddScoped<DeletePreConSubscriptionHandler>();
        serviceCollection.AddScoped<CreateHeavyJobSubscriptionHandler>();
        serviceCollection.AddScoped<UpdateHeavyJobSubscriptionHandler>();
        serviceCollection.AddScoped<DeleteHeavyJobSubscriptionHandler>();
    }

    public override void ConfigureService(IActionHandlerService service, WebhooksV1ActionProcessorConfig config)
    {
        // Register Action Handler configurations for the Action Processor Service
        service.RegisterHandlerForDataObjectAction<CreateSetupsSubscriptionHandler, SetupsSubscriptionDataObject>(ModuleId, "setups-subscription", "create", config.CreateSetupsSubscriptionConfig);
        service.RegisterHandlerForDataObjectAction<UpdateSetupsSubscriptionHandler, SetupsSubscriptionDataObject>(ModuleId, "setups-subscription", "update", config.UpdateSetupsSubscriptionConfig);
        service.RegisterHandlerForDataObjectAction<DeleteSetupsSubscriptionHandler, SetupsSubscriptionDataObject>(ModuleId, "setups-subscription", "delete", config.DeleteSetupsSubscriptionConfig);
        service.RegisterHandlerForDataObjectAction<CreatePreConSubscriptionHandler, PreConSubscriptionDataObject>(ModuleId, "pre-con-subscription", "create", config.CreatePreConSubscriptionConfig);
        service.RegisterHandlerForDataObjectAction<UpdatePreConSubscriptionHandler, PreConSubscriptionDataObject>(ModuleId, "pre-con-subscription", "update", config.UpdatePreConSubscriptionConfig);
        service.RegisterHandlerForDataObjectAction<DeletePreConSubscriptionHandler, PreConSubscriptionDataObject>(ModuleId, "pre-con-subscription", "delete", config.DeletePreConSubscriptionConfig);
        service.RegisterHandlerForDataObjectAction<CreateHeavyJobSubscriptionHandler, HeavyJobSubscriptionDataObject>(ModuleId, "heavy-job-subscription", "create", config.CreateHeavyJobSubscriptionConfig);
        service.RegisterHandlerForDataObjectAction<UpdateHeavyJobSubscriptionHandler, HeavyJobSubscriptionDataObject>(ModuleId, "heavy-job-subscription", "update", config.UpdateHeavyJobSubscriptionConfig);
        service.RegisterHandlerForDataObjectAction<DeleteHeavyJobSubscriptionHandler, HeavyJobSubscriptionDataObject>(ModuleId, "heavy-job-subscription", "delete", config.DeleteHeavyJobSubscriptionConfig);
    }
}