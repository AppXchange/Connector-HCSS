namespace Connector.Attachments.v1;
using Connector.Attachments.v1.File;
using Connector.Attachments.v1.File.Create;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.Action;

public class AttachmentsV1ActionProcessorServiceDefinition : BaseActionHandlerServiceDefinition<AttachmentsV1ActionProcessorConfig>
{
    public override string ModuleId => "attachments-1";
    public override Type ServiceType => typeof(GenericActionHandlerService<AttachmentsV1ActionProcessorConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var options = new JsonSerializerOptions
        {
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };
        var serviceConfig = JsonSerializer.Deserialize<AttachmentsV1ActionProcessorConfig>(serviceConfigJson, options);
        serviceCollection.AddSingleton<AttachmentsV1ActionProcessorConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericActionHandlerService<AttachmentsV1ActionProcessorConfig>>();
        serviceCollection.AddSingleton<IActionHandlerServiceDefinition<AttachmentsV1ActionProcessorConfig>>(this);
        // Register Action Handlers as scoped dependencies
        serviceCollection.AddScoped<CreateFileHandler>();
    }

    public override void ConfigureService(IActionHandlerService service, AttachmentsV1ActionProcessorConfig config)
    {
        // Register Action Handler configurations for the Action Processor Service
        service.RegisterHandlerForDataObjectAction<CreateFileHandler, FileDataObject>(ModuleId, "file", "create", config.CreateFileConfig);
    }
}