namespace Connector.HeavyJob.v1.PayItems.Update;

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
[Description("Bulk upsert pay items by code and job id")]
public class UpdatePayItemsAction : IStandardAction<UpdatePayItemsActionInput, UpdatePayItemsActionOutput>
{
    public UpdatePayItemsActionInput ActionInput { get; set; } = new() { 
        PayItems = Array.Empty<PayItemUpdate>()
    };
    public UpdatePayItemsActionOutput ActionOutput { get; set; } = new() {
        Success = false
    };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class UpdatePayItemsActionInput
{
    [JsonPropertyName("payItems")]
    [Description("The pay items to update")]
    [Required]
    [MaxItems(10000)]
    public required PayItemUpdate[] PayItems { get; init; }

    [JsonPropertyName("createOnly")]
    [Description("If true, no updates will be performed, and existing records will be kept as-is")]
    public bool CreateOnly { get; init; }

    [JsonPropertyName("addToExisting")]
    [Description("If true, the passed quantity will be added to the existing quantity")]
    public bool AddToExisting { get; init; }
}

public class PayItemUpdate
{
    [JsonPropertyName("jobId")]
    [Description("The job that this pay item is associated with")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("payItem")]
    [Description("A unique code that describes this pay item")]
    [Required]
    [MaxLength(50)]
    [MinLength(1)]
    public required string PayItem { get; init; }

    [JsonPropertyName("status")]
    [Description("The pay item status")]
    [Required]
    public required string Status { get; init; }

    [JsonPropertyName("description")]
    [Description("A description for this pay item")]
    [MaxLength(200)]
    public string? Description { get; init; }

    [JsonPropertyName("ownerCode")]
    [Description("The associated pay item code in the owner's system")]
    [MaxLength(50)]
    public string? OwnerCode { get; init; }

    [JsonPropertyName("contractQuantity")]
    [Description("The agreed-to quantity between the owner and the company")]
    public double? ContractQuantity { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The unit of measure used to bill the owner for this pay item")]
    [MaxLength(50)]
    public string? UnitOfMeasure { get; init; }

    [JsonPropertyName("unitPrice")]
    [Description("The unit price used to bill the owner for this pay item")]
    public double? UnitPrice { get; init; }

    [JsonPropertyName("stopOverruns")]
    [Description("Whether to cap the billable quantity at the ContractQuantity")]
    public bool? StopOverruns { get; init; }

    [JsonPropertyName("notes")]
    [Description("Notes associated with this pay item")]
    [MaxLength(500)]
    public string? Notes { get; init; }
}

public class UpdatePayItemsActionOutput
{
    [JsonPropertyName("success")]
    [Description("Whether the update was successful")]
    public bool Success { get; init; }
}
