namespace Connector.Contacts.v1.Office.Create;

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
[Description("Creates a new office location for a vendor")]
public class CreateOfficeAction : IStandardAction<CreateOfficeActionInput, CreateOfficeActionOutput>
{
    public CreateOfficeActionInput ActionInput { get; set; } = new() { VendorId = Guid.Empty };
    public CreateOfficeActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateOfficeActionInput
{
    [JsonPropertyName("vendorId")]
    [Description("The vendor's unique id")]
    [Required]
    public required Guid VendorId { get; init; }

    [JsonPropertyName("address")]
    [Description("The office address")]
    public AddressDto? Address { get; init; }

    [JsonPropertyName("phoneNumber")]
    [Description("The vendor location's phonenumber")]
    public string? PhoneNumber { get; init; }

    [JsonPropertyName("faxNumber")]
    [Description("The vendor location's faxnumber")]
    public string? FaxNumber { get; init; }

    [JsonPropertyName("webAddress")]
    [Description("The vendor location's website address")]
    public string? WebAddress { get; init; }

    [JsonPropertyName("regionId")]
    [Description("The unique identifier of the region the vendor location operates in")]
    public Guid? RegionId { get; init; }

    [JsonPropertyName("nickname")]
    [Description("The nickname for a vendor location")]
    public string? Nickname { get; init; }

    [JsonPropertyName("isQualified")]
    [Description("A flag if a vendor location is qualified")]
    public bool IsQualified { get; init; }

    [JsonPropertyName("isBlacklisted")]
    [Description("A flag if a vendor location is blacklisted")]
    public bool IsBlacklisted { get; init; }

    [JsonPropertyName("communicationMethod")]
    [Description("The preferred communication method")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CommunicationMethod CommunicationMethod { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit's guid")]
    public Guid? BusinessUnitId { get; init; }
}

public class CreateOfficeActionOutput
{
    [JsonPropertyName("id")]
    [Description("The created office's unique identifier")]
    public Guid Id { get; init; }
}
