namespace Connector.Skills.v1.Skillsimport.Create;

using Json.Schema.Generation;
using System;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.Action;

/// <summary>
/// Action object that will represent an action in the Xchange system. This will contain an input object type,
/// an output object type, and a Action failure type (this will default to <see cref="StandardActionFailure"/>
/// but that can be overridden with your own preferred type). These objects will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// These types will be used for validation at runtime to make sure the objects being passed through the system 
/// are properly formed. The schema also helps provide integrators more information for what the values 
/// are intended to be.
/// </summary>
[Description("Imports a list of skills in HCSS")]
public class CreateSkillsimportAction : IStandardAction<CreateSkillsimportActionInput, CreateSkillsimportActionOutput>
{
    public CreateSkillsimportActionInput ActionInput { get; set; } = new()
    {
        Skills = Array.Empty<SkillsimportDataObject>()
    };
    public CreateSkillsimportActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();
    public bool CreateRtap => true;
}

public class CreateSkillsimportActionInput
{
    [JsonPropertyName("skills")]
    [Description("The list of skills to import")]
    [Required]
    public required SkillsimportDataObject[] Skills { get; init; }
}

public class CreateSkillsimportActionOutput
{
    [JsonPropertyName("results")]
    [Description("The import results")]
    public ImportResult[]? Results { get; init; }
}

public class ImportResult
{
    [JsonPropertyName("error")]
    public bool Error { get; init; }

    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; init; }

    [JsonPropertyName("code")]
    public string? Code { get; init; }

    [JsonPropertyName("skillInserted")]
    public bool SkillInserted { get; init; }
}
