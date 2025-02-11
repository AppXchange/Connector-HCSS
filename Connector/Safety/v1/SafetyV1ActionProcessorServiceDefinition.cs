namespace Connector.Safety.v1;
using Connector.Safety.v1.Alerts;
using Connector.Safety.v1.Alerts.Create;
using Connector.Safety.v1.Alerts.Delete;
using Connector.Safety.v1.Alerts.Update;
using Connector.Safety.v1.Incident;
using Connector.Safety.v1.Incident.Update;
using Connector.Safety.v1.UserAccessGroups;
using Connector.Safety.v1.UserAccessGroups.Create;
using Connector.Safety.v1.UserAccessGroups.Update;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.Action;

public class SafetyV1ActionProcessorServiceDefinition : BaseActionHandlerServiceDefinition<SafetyV1ActionProcessorConfig>
{
    public override string ModuleId => "safety-1";
    public override Type ServiceType => typeof(GenericActionHandlerService<SafetyV1ActionProcessorConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var options = new JsonSerializerOptions
        {
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };
        var serviceConfig = JsonSerializer.Deserialize<SafetyV1ActionProcessorConfig>(serviceConfigJson, options);
        serviceCollection.AddSingleton<SafetyV1ActionProcessorConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericActionHandlerService<SafetyV1ActionProcessorConfig>>();
        serviceCollection.AddSingleton<IActionHandlerServiceDefinition<SafetyV1ActionProcessorConfig>>(this);
        // Register Action Handlers as scoped dependencies
        serviceCollection.AddScoped<UpdateAlertsHandler>();
        serviceCollection.AddScoped<CreateAlertsHandler>();
        serviceCollection.AddScoped<DeleteAlertsHandler>();
        serviceCollection.AddScoped<UpdateIncidentHandler>();
        serviceCollection.AddScoped<CreateUserAccessGroupsHandler>();
        serviceCollection.AddScoped<UpdateUserAccessGroupsHandler>();
    }

    public override void ConfigureService(IActionHandlerService service, SafetyV1ActionProcessorConfig config)
    {
        // Register Action Handler configurations for the Action Processor Service
        service.RegisterHandlerForDataObjectAction<UpdateAlertsHandler, AlertsDataObject>(ModuleId, "alerts", "update", config.UpdateAlertsConfig);
        service.RegisterHandlerForDataObjectAction<CreateAlertsHandler, AlertsDataObject>(ModuleId, "alerts", "create", config.CreateAlertsConfig);
        service.RegisterHandlerForDataObjectAction<DeleteAlertsHandler, AlertsDataObject>(ModuleId, "alerts", "delete", config.DeleteAlertsConfig);
        service.RegisterHandlerForDataObjectAction<UpdateIncidentHandler, IncidentDataObject>(ModuleId, "incident", "update", config.UpdateIncidentConfig);
        service.RegisterHandlerForDataObjectAction<CreateUserAccessGroupsHandler, UserAccessGroupsDataObject>(ModuleId, "user-access-groups", "create", config.CreateUserAccessGroupsConfig);
        service.RegisterHandlerForDataObjectAction<UpdateUserAccessGroupsHandler, UserAccessGroupsDataObject>(ModuleId, "user-access-groups", "update", config.UpdateUserAccessGroupsConfig);
    }
}