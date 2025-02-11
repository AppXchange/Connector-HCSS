namespace Connector.HeavyBidEstimate.v1;
using Connector.HeavyBidEstimate.v1.MaterialCodebook;
using Connector.HeavyBidEstimate.v1.MaterialCodebook.Update;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.Action;

public class HeavyBidEstimateV1ActionProcessorServiceDefinition : BaseActionHandlerServiceDefinition<HeavyBidEstimateV1ActionProcessorConfig>
{
    public override string ModuleId => "heavybidestimate-1";
    public override Type ServiceType => typeof(GenericActionHandlerService<HeavyBidEstimateV1ActionProcessorConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var options = new JsonSerializerOptions
        {
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };
        var serviceConfig = JsonSerializer.Deserialize<HeavyBidEstimateV1ActionProcessorConfig>(serviceConfigJson, options);
        serviceCollection.AddSingleton<HeavyBidEstimateV1ActionProcessorConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericActionHandlerService<HeavyBidEstimateV1ActionProcessorConfig>>();
        serviceCollection.AddSingleton<IActionHandlerServiceDefinition<HeavyBidEstimateV1ActionProcessorConfig>>(this);
        // Register Action Handlers as scoped dependencies
        serviceCollection.AddScoped<UpdateMaterialCodebookHandler>();
    }

    public override void ConfigureService(IActionHandlerService service, HeavyBidEstimateV1ActionProcessorConfig config)
    {
        // Register Action Handler configurations for the Action Processor Service
        service.RegisterHandlerForDataObjectAction<UpdateMaterialCodebookHandler, MaterialCodebookDataObject>(ModuleId, "material-codebook", "update", config.UpdateMaterialCodebookConfig);
    }
}