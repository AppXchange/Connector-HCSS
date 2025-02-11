namespace Connector.Skills.v1;
using Connector.Skills.v1.EmployeeSkillImport;
using Connector.Skills.v1.EmployeeSkillImport.Create;
using Connector.Skills.v1.EmployeeSkills;
using Connector.Skills.v1.EmployeeSkills.Create;
using Connector.Skills.v1.Skill;
using Connector.Skills.v1.Skill.Delete;
using Connector.Skills.v1.Skill.Update;
using Connector.Skills.v1.Skills;
using Connector.Skills.v1.Skills.Create;
using Connector.Skills.v1.Skillsimport;
using Connector.Skills.v1.Skillsimport.Create;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.Action;

public class SkillsV1ActionProcessorServiceDefinition : BaseActionHandlerServiceDefinition<SkillsV1ActionProcessorConfig>
{
    public override string ModuleId => "skills-1";
    public override Type ServiceType => typeof(GenericActionHandlerService<SkillsV1ActionProcessorConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var options = new JsonSerializerOptions
        {
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };
        var serviceConfig = JsonSerializer.Deserialize<SkillsV1ActionProcessorConfig>(serviceConfigJson, options);
        serviceCollection.AddSingleton<SkillsV1ActionProcessorConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericActionHandlerService<SkillsV1ActionProcessorConfig>>();
        serviceCollection.AddSingleton<IActionHandlerServiceDefinition<SkillsV1ActionProcessorConfig>>(this);
        // Register Action Handlers as scoped dependencies
        serviceCollection.AddScoped<CreateEmployeeSkillsHandler>();
        serviceCollection.AddScoped<CreateEmployeeSkillImportHandler>();
        serviceCollection.AddScoped<UpdateSkillHandler>();
        serviceCollection.AddScoped<DeleteSkillHandler>();
        serviceCollection.AddScoped<CreateSkillsHandler>();
        serviceCollection.AddScoped<CreateSkillsimportHandler>();
    }

    public override void ConfigureService(IActionHandlerService service, SkillsV1ActionProcessorConfig config)
    {
        // Register Action Handler configurations for the Action Processor Service
        service.RegisterHandlerForDataObjectAction<CreateEmployeeSkillsHandler, EmployeeSkillsDataObject>(ModuleId, "employee-skills", "create", config.CreateEmployeeSkillsConfig);
        service.RegisterHandlerForDataObjectAction<CreateEmployeeSkillImportHandler, EmployeeSkillImportDataObject>(ModuleId, "employee-skill-import", "create", config.CreateEmployeeSkillImportConfig);
        service.RegisterHandlerForDataObjectAction<UpdateSkillHandler, SkillDataObject>(ModuleId, "skill", "update", config.UpdateSkillConfig);
        service.RegisterHandlerForDataObjectAction<DeleteSkillHandler, SkillDataObject>(ModuleId, "skill", "delete", config.DeleteSkillConfig);
        service.RegisterHandlerForDataObjectAction<CreateSkillsHandler, SkillsDataObject>(ModuleId, "skills", "create", config.CreateSkillsConfig);
        service.RegisterHandlerForDataObjectAction<CreateSkillsimportHandler, SkillsimportDataObject>(ModuleId, "skillsimport", "create", config.CreateSkillsimportConfig);
    }
}