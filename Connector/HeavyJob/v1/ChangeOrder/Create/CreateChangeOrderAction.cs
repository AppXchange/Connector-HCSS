namespace Connector.HeavyJob.v1.ChangeOrder.Create;

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
[Description("Creates a change order in HeavyJob")]
public class CreateChangeOrderAction : IStandardAction<CreateChangeOrderActionInput, CreateChangeOrderActionOutput>
{
    public CreateChangeOrderActionInput ActionInput { get; set; } = new()
    {
        ChangeOrderNumber = 0,
        Subject = string.Empty,
        JobId = Guid.Empty
    };
    public CreateChangeOrderActionOutput ActionOutput { get; set; } = new()
    {
        Id = Guid.Empty,
        ChangeOrderNumber = 0,
        Subject = string.Empty
    };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateChangeOrderActionInput
{
    [JsonPropertyName("changeOrderNumber")]
    [Description("The change order number")]
    [Required]
    public required int ChangeOrderNumber { get; init; }

    [JsonPropertyName("subject")]
    [Description("The subject")]
    [Required]
    public required string Subject { get; init; }

    [JsonPropertyName("description")]
    [Description("The change order description")]
    public string? Description { get; init; }

    [JsonPropertyName("ownerNumber")]
    [Description("The owner Number")]
    public string? OwnerNumber { get; init; }

    [JsonPropertyName("subSupplierNumber")]
    [Description("The sub/supplier number")]
    public string? SubSupplierNumber { get; init; }

    [JsonPropertyName("showInMobile")]
    [Description("Is the change order shown on mobile devices?")]
    public bool ShowInMobile { get; init; }

    [JsonPropertyName("statusId")]
    [Description("The StatusId")]
    public Guid? StatusId { get; init; }

    [JsonPropertyName("roughOrderOfMagnitude")]
    [Description("The estimated ROM of how impactful this change will be")]
    public double? RoughOrderOfMagnitude { get; init; }

    [JsonPropertyName("costImpactEvaluation")]
    [Description("The cost impact evaluation")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ChangeOrderImpactEvaluation CostImpactEvaluation { get; init; }

    [JsonPropertyName("costImpactDescription")]
    [Description("The description of this change's impact on cost")]
    public string? CostImpactDescription { get; init; }

    [JsonPropertyName("scheduleImpactEvaluation")]
    [Description("The schedule impact evaluation")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ChangeOrderImpactEvaluation ScheduleImpactEvaluation { get; init; }

    [JsonPropertyName("scheduleImpactDescription")]
    [Description("The description of this change's impact on schedule")]
    public string? ScheduleImpactDescription { get; init; }

    [JsonPropertyName("actualCost")]
    [Description("The change order actual cost")]
    public double? ActualCost { get; init; }

    [JsonPropertyName("productionQuantityChange")]
    [Description("The change order Production Quantity Change")]
    public double? ProductionQuantityChange { get; init; }

    [JsonPropertyName("otherDrawings")]
    [Description("Other Drawings associated with the change order")]
    public string[]? OtherDrawings { get; init; }

    [JsonPropertyName("jobId")]
    [Description("The change order job ID")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("managedByUserId")]
    [Description("The ID of the user managing change order")]
    public Guid? ManagedByUserId { get; init; }
}

public class CreateChangeOrderActionOutput : ChangeOrderDataObject
{
}
