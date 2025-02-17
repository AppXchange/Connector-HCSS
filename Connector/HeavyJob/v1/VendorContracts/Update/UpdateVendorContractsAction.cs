namespace Connector.HeavyJob.v1.VendorContracts.Update;

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
[Description("Updates a vendor contract in HeavyJob")]
public class UpdateVendorContractsAction : IStandardAction<UpdateVendorContractsActionInput, UpdateVendorContractsActionOutput>
{
    public UpdateVendorContractsActionInput ActionInput { get; set; } = new()
    {
        Id = Guid.Empty,
        OrderStatus = "notStarted",
        VendorContract = string.Empty
    };

    public UpdateVendorContractsActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();
    public bool CreateRtap => true;
}

public class UpdateVendorContractsActionInput
{
    [JsonPropertyName("id")]
    [Description("The vendor contract id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("orderStatus")]
    [Description("The order status")]
    public string? OrderStatus { get; init; }

    [JsonPropertyName("dateIssued")]
    [Description("The date vendor contract was issued")]
    public DateTime? DateIssued { get; init; }

    [JsonPropertyName("description")]
    [Description("The vendor contract description")]
    public string? Description { get; init; }

    [JsonPropertyName("vendorContract")]
    [Description("The vendor contract name")]
    public string? VendorContract { get; init; }

    [JsonPropertyName("vendorId")]
    [Description("The vendor id for the vendor contract")]
    public Guid? VendorId { get; init; }
}

public class UpdateVendorContractsActionOutput
{
    // No content returned for 204 response
}
