namespace Connector.Telematics.v1;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.Action;

public class TelematicsV1ActionProcessorServiceDefinition : BaseActionHandlerServiceDefinition<TelematicsV1ActionProcessorConfig>
{
    public override string ModuleId => "telematics-1";
    public override Type ServiceType => typeof(GenericActionHandlerService<TelematicsV1ActionProcessorConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var options = new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } };
        var serviceConfig = JsonSerializer.Deserialize<TelematicsV1ActionProcessorConfig>(serviceConfigJson, options);
        serviceCollection.AddSingleton<TelematicsV1ActionProcessorConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericActionHandlerService<TelematicsV1ActionProcessorConfig>>();
        serviceCollection.AddSingleton<IActionHandlerServiceDefinition<TelematicsV1ActionProcessorConfig>>(this);

        // Register Action Handlers as scoped dependencies
    }

    public override void ConfigureService(IActionHandlerService service, TelematicsV1ActionProcessorConfig config)
    {
        // Register Action Handler configurations for the Action Processor Service
    }
}