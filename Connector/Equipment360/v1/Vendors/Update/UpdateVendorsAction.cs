namespace Connector.Equipment360.v1.Vendors.Update;

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
[Description("Updates an existing vendor in Equipment360")]
public class UpdateVendorsAction : IStandardAction<UpdateVendorsActionInput, VendorsDataObject>
{
    public UpdateVendorsActionInput ActionInput { get; set; } = new()
    {
        Id = Guid.Empty,
        Name = string.Empty,
        VendorNum = string.Empty
    };
    public VendorsDataObject ActionOutput { get; set; } = new()
    {
        Id = Guid.Empty,
        Name = string.Empty,
        VendorNum = string.Empty
    };
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class UpdateVendorsActionInput
{
    [JsonIgnore]
    [Description("The vendor guid")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    [Description("The vendor name")]
    public string? Name { get; init; }

    [JsonPropertyName("vendorNum")]
    [Description("The vendor number")]
    public string? VendorNum { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("Whether the vendor is marked as deleted")]
    public bool IsDeleted { get; init; }

    [JsonPropertyName("taxRate")]
    [Description("The vendor tax rate")]
    public double? TaxRate { get; init; }

    [JsonPropertyName("isFuel")]
    [Description("The vendor is fuel")]
    public bool? IsFuel { get; init; }

    [JsonPropertyName("isParts")]
    [Description("The vendor is parts")]
    public bool? IsParts { get; init; }

    [JsonPropertyName("isSublet")]
    [Description("The vendor is sublet")]
    public bool? IsSublet { get; init; }

    [JsonPropertyName("isRental")]
    [Description("The vendor is rental")]
    public bool? IsRental { get; init; }
}
