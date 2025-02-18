namespace Connector.Setups.v1.BulkCostCode.Create;

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
[Description("Creates multiple cost codes in HCSS")]
public class CreateBulkCostCodeAction : IStandardAction<CreateBulkCostCodeActionInput, CreateBulkCostCodeActionOutput>
{
    public CreateBulkCostCodeActionInput ActionInput { get; set; } = new() 
    { 
        CostCodes = Array.Empty<BulkCostCodeDataObject>() 
    };
    public CreateBulkCostCodeActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateBulkCostCodeActionInput
{
    [JsonPropertyName("costCodes")]
    [Description("The list of cost codes to create (up to 100 items)")]
    [Required]
    [MaxItems(100)]
    [MinItems(1)]
    public required BulkCostCodeDataObject[] CostCodes { get; init; }
}

public class CreateBulkCostCodeActionOutput
{
    // No content returned for 204 response
}
