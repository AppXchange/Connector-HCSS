namespace Connector.HeavyJob.v1.VendorContractDetails.Create;

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
[Description("Creates a new vendor contract detail in HeavyJob")]
public class CreateVendorContractDetailsAction : IStandardAction<CreateVendorContractDetailsActionInput, CreateVendorContractDetailsActionOutput>
{
    public CreateVendorContractDetailsActionInput ActionInput { get; set; } = new()
    {
        VendorContractId = Guid.Empty,
        JobSubcontractId = Guid.Empty,
        Sequence = 0,
        Quantity = 0,
        UnitCost = 0,
        UnitOfMeasure = string.Empty
    };

    public CreateVendorContractDetailsActionOutput ActionOutput { get; set; } = new()
    {
        Id = Guid.Empty,
        VendorContractId = Guid.Empty,
        JobSubcontractId = Guid.Empty,
        Sequence = 0,
        Quantity = 0,
        UnitCost = 0,
        UnitOfMeasure = string.Empty
    };

    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateVendorContractDetailsActionInput
{
    [JsonPropertyName("vendorContractId")]
    [Description("The vendor contract id")]
    [Required]
    public required Guid VendorContractId { get; init; }

    [JsonPropertyName("jobSubcontractId")]
    [Description("The job subcontract id")]
    [Required]
    public required Guid JobSubcontractId { get; init; }

    [JsonPropertyName("sequence")]
    [Description("The sequence number of the vendor contract detail")]
    [Required]
    public required double Sequence { get; init; }

    [JsonPropertyName("isComplete")]
    [Description("Whether the work item is complete")]
    public bool? IsComplete { get; init; }

    [JsonPropertyName("note")]
    [Description("The note")]
    public string? Note { get; init; }

    [JsonPropertyName("quantity")]
    [Description("The item quantity")]
    [Required]
    public required double Quantity { get; init; }

    [JsonPropertyName("unitCost")]
    [Description("The item unit cost")]
    [Required]
    public required double UnitCost { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The item unit of measure")]
    [Required]
    public required string UnitOfMeasure { get; init; }

    [JsonPropertyName("salesTaxPercent")]
    [Description("The item sales tax represented in percent")]
    public double? SalesTaxPercent { get; init; }

    [JsonPropertyName("isCancelled")]
    [Description("Whether the vendor contract detail is canceled")]
    public bool? IsCancelled { get; init; }

    [JsonPropertyName("alternateDescription")]
    [Description("An alternate description for this vendor contract detail")]
    public string? AlternateDescription { get; init; }

    [JsonPropertyName("vendorItemNumber")]
    [Description("The vendor item number")]
    public string? VendorItemNumber { get; init; }
}

public class CreateVendorContractDetailsActionOutput
{
    [JsonPropertyName("id")]
    [Description("The vendor contract id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("vendorContractId")]
    [Description("The vendor contract id")]
    [Required]
    public required Guid VendorContractId { get; init; }

    [JsonPropertyName("jobSubcontractId")]
    [Description("The job subcontract id")]
    [Required]
    public required Guid JobSubcontractId { get; init; }

    [JsonPropertyName("sequence")]
    [Description("The sequence number of the vendor contract detail")]
    [Required]
    public required double Sequence { get; init; }

    [JsonPropertyName("isComplete")]
    [Description("Whether the work item is complete")]
    public bool IsComplete { get; init; }

    [JsonPropertyName("note")]
    [Description("The note")]
    public string? Note { get; init; }

    [JsonPropertyName("quantity")]
    [Description("The item quantity")]
    [Required]
    public required double Quantity { get; init; }

    [JsonPropertyName("unitCost")]
    [Description("The item unit cost")]
    [Required]
    public required double UnitCost { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    [Description("The item unit of measure")]
    [Required]
    public required string UnitOfMeasure { get; init; }

    [JsonPropertyName("salesTaxPercent")]
    [Description("The item sales tax represented in percent")]
    public double? SalesTaxPercent { get; init; }

    [JsonPropertyName("isCancelled")]
    [Description("Whether the vendor contract detail is canceled")]
    public bool IsCancelled { get; init; }

    [JsonPropertyName("alternateDescription")]
    [Description("An alternate description for this vendor contract detail")]
    public string? AlternateDescription { get; init; }

    [JsonPropertyName("vendorItemNumber")]
    [Description("The vendor item number")]
    public string? VendorItemNumber { get; init; }
}
