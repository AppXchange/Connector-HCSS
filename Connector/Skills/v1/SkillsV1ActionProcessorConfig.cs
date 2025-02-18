namespace Connector.Skills.v1;
using Connector.Skills.v1.EmployeeSkillImport.Create;
using Connector.Skills.v1.EmployeeSkills.Create;
using Connector.Skills.v1.Skill.Create;
using Connector.Skills.v1.Skill.Delete;
using Connector.Skills.v1.Skill.Update;
using Connector.Skills.v1.Skillsimport.Create;
using Json.Schema.Generation;
using Xchange.Connector.SDK.Action;

/// <summary>
/// Configuration for the Action Processor for this module. This configuration will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// The schema will be used for validation at runtime to make sure the configurations are properly formed. 
/// The schema also helps provide integrators more information for what the values are intended to be.
/// </summary>
[Title("Skills V1 Action Processor Configuration")]
[Description("Configuration of the data object actions for the module.")]
public class SkillsV1ActionProcessorConfig
{
    // Action Handler configuration
    public DefaultActionHandlerConfig CreateEmployeeSkillsConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateEmployeeSkillImportConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateSkillConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteSkillConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateSkillsConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateSkillsimportConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateSkillConfig { get; set; } = new();
}