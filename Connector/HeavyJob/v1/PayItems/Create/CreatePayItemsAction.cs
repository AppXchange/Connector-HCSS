namespace Connector.HeavyJob.v1.PayItems.Create;

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
[Description("Creates a new pay item in HeavyJob")]
public class CreatePayItemsAction : IStandardAction<CreatePayItemsActionInput, CreatePayItemsActionOutput>
{
    public CreatePayItemsActionInput ActionInput { get; set; } = new() { 
        JobId = Guid.Empty,
        PayItem = string.Empty,
        Status = "active"
    };
    public CreatePayItemsActionOutput ActionOutput { get; set; } = new() {
        Id = Guid.Empty,
        JobId = Guid.Empty,
        PayItem = string.Empty,
        Status = "active",
        ContractQuantity = 0,
        UnitPrice = 0,
        StopOverruns = false
    };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreatePayItemsActionInput
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

public class CreatePayItemsActionOutput
{
    [JsonPropertyName("id")]
    [Description("The id of this pay item")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("jobId")]
    [Description("The job that this pay item is associated with")]
    [Required]
    public required Guid JobId { get; init; }

    [JsonPropertyName("payItem")]
    [Description("A unique code that describes this pay item")]
    [Required]
    public required string PayItem { get; init; }

    [JsonPropertyName("description")]
    [Description("A description for this pay item")]
    public string? Description { get; init; }

    [JsonPropertyName("status")]
    [Description("The pay item status")]
    [Required]
    public required string Status { get; init; }

    [JsonPropertyName("ownerCode")]
    [Description("The associated pay item code in the owner's system")]
    public string? OwnerCode { get; init; }

    [JsonPropertyName("contractQuantity")]
    [Description("The agreed-to quantity between the owner and the company")]
    [Required]
    public required double ContractQuantity { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The unit of measure used to bill the owner for this pay item")]
    public string? UnitOfMeasure { get; init; }

    [JsonPropertyName("unitPrice")]
    [Description("The unit price used to bill the owner for this pay item")]
    [Required]
    public required double UnitPrice { get; init; }

    [JsonPropertyName("stopOverruns")]
    [Description("Whether to cap the billable quantity at the ContractQuantity")]
    [Required]
    public required bool StopOverruns { get; init; }

    [JsonPropertyName("notes")]
    [Description("Notes associated with this pay item")]
    public string? Notes { get; init; }

    [JsonPropertyName("linkedCostCodes")]
    [Description("Cost Codes linked to the Pay Item")]
    public CostCodeCompactWithPayItemRead[]? LinkedCostCodes { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Whether the Pay Item is soft deleted")]
    public bool IsDeleted { get; init; }
}
