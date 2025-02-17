namespace Connector.HeavyJob.v1.QuantityAdjustment.Create;

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
[Description("Creates a new quantity adjustment for a job")]
public class CreateQuantityAdjustmentAction : IStandardAction<CreateQuantityAdjustmentActionInput, CreateQuantityAdjustmentActionOutput>
{
    public CreateQuantityAdjustmentActionInput ActionInput { get; set; } = new() 
    { 
        JobId = Guid.Empty,
        TransactionDate = DateTime.UtcNow,
        Adjustments = Array.Empty<AdjustmentWrite>()
    };
    public CreateQuantityAdjustmentActionOutput ActionOutput { get; set; } = new() 
    { 
        Success = false 
    };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateQuantityAdjustmentActionInput
{
    [JsonPropertyName("transactionDate")]
    [Description("Date on which the adjustments will be made")]
    [Required]
    public required DateTime TransactionDate { get; init; }

    [JsonPropertyName("foremanId")]
    [Description("Foreman for which the adjustments will be recorded")]
    public Guid? ForemanId { get; init; }

    [JsonPropertyName("jobId")]
    [Description("Job containing the cost codes to be adjusted")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("adjustments")]
    [Description("List of adjustments to be created")]
    [Required]
    public required AdjustmentWrite[] Adjustments { get; init; }
}

public class AdjustmentWrite
{
    [JsonPropertyName("jobCostCodeId")]
    [Description("Id of the cost code for the adjustment")]
    [Required]
    public required Guid JobCostCodeId { get; init; }

    [JsonPropertyName("adjustment")]
    [Description("Quantity adjustment value")]
    [Required]
    public required double Adjustment { get; init; }

    [JsonPropertyName("note")]
    [Description("Note for the adjustment")]
    [MaxLength(500)]
    public string? Note { get; init; }
}

public class CreateQuantityAdjustmentActionOutput
{
    [JsonPropertyName("success")]
    [Description("Whether the create was successful")]
    [Required]
    public required bool Success { get; init; }
}
