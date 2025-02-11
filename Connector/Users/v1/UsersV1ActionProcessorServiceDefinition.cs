namespace Connector.Users.v1;
using Connector.Users.v1.User;
using Connector.Users.v1.User.Create;
using Connector.Users.v1.User.Delete;
using Connector.Users.v1.User.Update;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.Action;

public class UsersV1ActionProcessorServiceDefinition : BaseActionHandlerServiceDefinition<UsersV1ActionProcessorConfig>
{
    public override string ModuleId => "users-1";
    public override Type ServiceType => typeof(GenericActionHandlerService<UsersV1ActionProcessorConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var options = new JsonSerializerOptions
        {
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };
        var serviceConfig = JsonSerializer.Deserialize<UsersV1ActionProcessorConfig>(serviceConfigJson, options);
        serviceCollection.AddSingleton<UsersV1ActionProcessorConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericActionHandlerService<UsersV1ActionProcessorConfig>>();
        serviceCollection.AddSingleton<IActionHandlerServiceDefinition<UsersV1ActionProcessorConfig>>(this);
        // Register Action Handlers as scoped dependencies
        serviceCollection.AddScoped<CreateUserHandler>();
        serviceCollection.AddScoped<UpdateUserHandler>();
        serviceCollection.AddScoped<DeleteUserHandler>();
    }

    public override void ConfigureService(IActionHandlerService service, UsersV1ActionProcessorConfig config)
    {
        // Register Action Handler configurations for the Action Processor Service
        service.RegisterHandlerForDataObjectAction<CreateUserHandler, UserDataObject>(ModuleId, "user", "create", config.CreateUserConfig);
        service.RegisterHandlerForDataObjectAction<UpdateUserHandler, UserDataObject>(ModuleId, "user", "update", config.UpdateUserConfig);
        service.RegisterHandlerForDataObjectAction<DeleteUserHandler, UserDataObject>(ModuleId, "user", "delete", config.DeleteUserConfig);
    }
}