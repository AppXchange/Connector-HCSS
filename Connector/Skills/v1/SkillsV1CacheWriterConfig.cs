namespace Connector.Skills.v1;
using Connector.Skills.v1.EmployeeSkillImport;
using Connector.Skills.v1.EmployeeSkills;
using Connector.Skills.v1.EmployeeSkillsByEmployee;
using Connector.Skills.v1.EmployeeSkillsBySkill;
using Connector.Skills.v1.Skill;
using Connector.Skills.v1.Skills;
using Connector.Skills.v1.Skillsimport;
using ESR.Hosting.CacheWriter;
using Json.Schema.Generation;

/// <summary>
/// Configuration for the Cache writer for this module. This configuration will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// The schema will be used for validation at runtime to make sure the configurations are properly formed. 
/// The schema also helps provide integrators more information for what the values are intended to be.
/// </summary>
[Title("Skills V1 Cache Writer Configuration")]
[Description("Configuration of the data object caches for the module.")]
public class SkillsV1CacheWriterConfig
{
    // Data Reader configuration
    public CacheWriterObjectConfig EmployeeSkillsByEmployeeConfig { get; set; } = new();
    public CacheWriterObjectConfig EmployeeSkillsBySkillConfig { get; set; } = new();
    public CacheWriterObjectConfig EmployeeSkillsConfig { get; set; } = new();
    public CacheWriterObjectConfig EmployeeSkillImportConfig { get; set; } = new();
    public CacheWriterObjectConfig SkillConfig { get; set; } = new();
    public CacheWriterObjectConfig SkillsConfig { get; set; } = new();
    public CacheWriterObjectConfig SkillsimportConfig { get; set; } = new();
}