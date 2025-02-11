namespace Connector.HeavyBidPreConstruction.v1;
using Connector.HeavyBidPreConstruction.v1.Project;
using Connector.HeavyBidPreConstruction.v1.Project.Create;
using Connector.HeavyBidPreConstruction.v1.Project.Delete;
using Connector.HeavyBidPreConstruction.v1.Project.PartialChange;
using Connector.HeavyBidPreConstruction.v1.Project.Update;
using Connector.HeavyBidPreConstruction.v1.Projects;
using Connector.HeavyBidPreConstruction.v1.Projects.Create;
using Connector.HeavyBidPreConstruction.v1.Projects.Delete;
using Connector.HeavyBidPreConstruction.v1.Reports;
using Connector.HeavyBidPreConstruction.v1.Reports.Create;
using Connector.HeavyBidPreConstruction.v1.Schema;
using Connector.HeavyBidPreConstruction.v1.Schema.Update;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.Action;

public class HeavyBidPreConstructionV1ActionProcessorServiceDefinition : BaseActionHandlerServiceDefinition<HeavyBidPreConstructionV1ActionProcessorConfig>
{
    public override string ModuleId => "heavybidpreconstruction-1";
    public override Type ServiceType => typeof(GenericActionHandlerService<HeavyBidPreConstructionV1ActionProcessorConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var options = new JsonSerializerOptions
        {
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };
        var serviceConfig = JsonSerializer.Deserialize<HeavyBidPreConstructionV1ActionProcessorConfig>(serviceConfigJson, options);
        serviceCollection.AddSingleton<HeavyBidPreConstructionV1ActionProcessorConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericActionHandlerService<HeavyBidPreConstructionV1ActionProcessorConfig>>();
        serviceCollection.AddSingleton<IActionHandlerServiceDefinition<HeavyBidPreConstructionV1ActionProcessorConfig>>(this);
        // Register Action Handlers as scoped dependencies
        serviceCollection.AddScoped<CreateProjectHandler>();
        serviceCollection.AddScoped<UpdateProjectHandler>();
        serviceCollection.AddScoped<PartialChangeProjectHandler>();
        serviceCollection.AddScoped<DeleteProjectHandler>();
        serviceCollection.AddScoped<CreateProjectsHandler>();
        serviceCollection.AddScoped<DeleteProjectsHandler>();
        serviceCollection.AddScoped<CreateReportsHandler>();
        serviceCollection.AddScoped<UpdateSchemaHandler>();
    }

    public override void ConfigureService(IActionHandlerService service, HeavyBidPreConstructionV1ActionProcessorConfig config)
    {
        // Register Action Handler configurations for the Action Processor Service
        service.RegisterHandlerForDataObjectAction<CreateProjectHandler, ProjectDataObject>(ModuleId, "project", "create", config.CreateProjectConfig);
        service.RegisterHandlerForDataObjectAction<UpdateProjectHandler, ProjectDataObject>(ModuleId, "project", "update", config.UpdateProjectConfig);
        service.RegisterHandlerForDataObjectAction<PartialChangeProjectHandler, ProjectDataObject>(ModuleId, "project", "partial-change", config.PartialChangeProjectConfig);
        service.RegisterHandlerForDataObjectAction<DeleteProjectHandler, ProjectDataObject>(ModuleId, "project", "delete", config.DeleteProjectConfig);
        service.RegisterHandlerForDataObjectAction<CreateProjectsHandler, ProjectsDataObject>(ModuleId, "projects", "create", config.CreateProjectsConfig);
        service.RegisterHandlerForDataObjectAction<DeleteProjectsHandler, ProjectsDataObject>(ModuleId, "projects", "delete", config.DeleteProjectsConfig);
        service.RegisterHandlerForDataObjectAction<CreateReportsHandler, ReportsDataObject>(ModuleId, "reports", "create", config.CreateReportsConfig);
        service.RegisterHandlerForDataObjectAction<UpdateSchemaHandler, SchemaDataObject>(ModuleId, "schema", "update", config.UpdateSchemaConfig);
    }
}