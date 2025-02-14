namespace Connector.Equipment360.v1.CustomField.Create;

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
[Description("Creates a new custom field record")]
public class CreateCustomFieldAction : IStandardAction<CreateCustomFieldActionInput, CustomFieldDataObject>
{
    public CreateCustomFieldActionInput ActionInput { get; set; } = new(
        customFieldCategoryId: 0,
        entityGuid: Guid.Empty,
        value: string.Empty);
    public CustomFieldDataObject ActionOutput { get; set; } = new() { Id = Guid.Empty };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateCustomFieldActionInput
{
    public CreateCustomFieldActionInput(int customFieldCategoryId, Guid entityGuid, string value)
    {
        CustomFieldCategoryId = customFieldCategoryId;
        EntityGuid = entityGuid;
        Value = value;
    }

    [JsonPropertyName("customFieldCategoryId")]
    [Description("The custom field category ID the custom field record is being created for")]
    [Required]
    public int CustomFieldCategoryId { get; init; }

    [JsonPropertyName("entityGuid")]
    [Description("The ID of the target the custom field record is being created for")]
    [Required]
    public Guid EntityGuid { get; init; }

    [JsonPropertyName("value")]
    [Description("The value being assigned to the custom field record")]
    [Required]
    public string Value { get; init; }
}
