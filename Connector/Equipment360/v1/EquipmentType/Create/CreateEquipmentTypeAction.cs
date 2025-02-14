namespace Connector.Equipment360.v1.EquipmentType.Create;

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
[Description("Create a new equipment type")]
public class CreateEquipmentTypeAction : IStandardAction<CreateEquipmentTypeActionInput, EquipmentTypeDataObject>
{
    public CreateEquipmentTypeActionInput ActionInput { get; set; } = new()
    {
        Name = string.Empty
    };
    public EquipmentTypeDataObject ActionOutput { get; set; } = new() 
    { 
        EquipmentTypeId = 0
    };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateEquipmentTypeActionInput
{
    [JsonPropertyName("name")]
    [Description("The equipment type name")]
    [Required]
    public required string Name { get; init; }

    [JsonPropertyName("description")]
    [Description("The equipment type description")]
    public string? Description { get; init; }

    [JsonPropertyName("ParentType")]
    [Description("The equipment type long description. This will determine the parent (Example: 'Excavator:Mini'), default to All type")]
    public string? ParentType { get; init; }

    [JsonPropertyName("budget")]
    [Description("The equipment type budget")]
    public double Budget { get; init; }

    [JsonPropertyName("utilizedHoursPerYear")]
    [Description("The equipment type utilized hours per year")]
    public int UtilizedHoursPerYear { get; init; }

    [JsonPropertyName("utilizedMilesPerYear")]
    [Description("The equipment type utilized miles per year")]
    public int UtilizedMilesPerYear { get; init; }

    [JsonPropertyName("replacementCycleYears")]
    [Description("The equipment type replacement cycle years")]
    public double ReplacementCycleYears { get; init; }

    [JsonPropertyName("sweetSpotK")]
    [Description("The equipment type sweet spot K")]
    public double SweetSpotK { get; init; }

    [JsonPropertyName("sweetSpotEx")]
    [Description("The equipment type sweet spot ex")]
    public double SweetSpotEx { get; init; }

    [JsonPropertyName("billingRate")]
    [Description("The equipment type billing rate")]
    public double BillingRate { get; init; }

    [JsonPropertyName("avgOperationCostPerHour")]
    [Description("The equipment type average operating cost per hour")]
    public double AvgOperationCostPerHour { get; init; }

    [JsonPropertyName("avgOperationgCostPerOdometer")]
    [Description("The equipment type average operating cost per odometer")]
    public double AvgOperationgCostPerOdometer { get; init; }
}
