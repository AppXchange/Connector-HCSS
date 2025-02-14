namespace Connector.Contacts.v1.Contact.Update;

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
[Description("Updates an existing contact that is associated with a vendor")]
public class UpdateContactAction : IStandardAction<UpdateContactActionInput, UpdateContactActionOutput>
{
    public UpdateContactActionInput ActionInput { get; set; } = new() { VendorId = Guid.Empty, ContactId = Guid.Empty };
    public UpdateContactActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class UpdateContactActionInput
{
    [JsonPropertyName("vendorId")]
    [Description("The vendor's unique identifier")]
    [Required]
    public required Guid VendorId { get; init; }

    [JsonPropertyName("contactId")]
    [Description("The contact's unique identifier")]
    [Required]
    public required Guid ContactId { get; init; }

    [JsonPropertyName("firstName")]
    [Description("The contact's first name")]
    public string? FirstName { get; init; }

    [JsonPropertyName("lastName")]
    [Description("The contact's last name")]
    public string? LastName { get; init; }

    [JsonPropertyName("title")]
    [Description("The contact's title")]
    public string? Title { get; init; }

    [JsonPropertyName("phoneNumber")]
    [Description("The contact's phone number")]
    public string? PhoneNumber { get; init; }

    [JsonPropertyName("faxNumber")]
    [Description("The contact's fax number")]
    public string? FaxNumber { get; init; }

    [JsonPropertyName("cellPhoneNumber")]
    [Description("The contact's cell phone number")]
    public string? CellPhoneNumber { get; init; }

    [JsonPropertyName("emailAddress")]
    [Description("The contact's email address")]
    public string? EmailAddress { get; init; }

    [JsonPropertyName("note")]
    [Description("The contact's note")]
    public string? Note { get; init; }

    [JsonPropertyName("isMainContact")]
    [Description("Whether this contact is the company's main contact")]
    public bool IsMainContact { get; init; }

    [JsonPropertyName("role")]
    [Description("A string specifying a contact's role")]
    [MaxLength(30)]
    public string? Role { get; init; }

    [JsonPropertyName("lastContacted")]
    [Description("A DateTime when this contact was last contacted")]
    public DateTime? LastContacted { get; init; }

    [JsonPropertyName("vendorLocationId")]
    [Description("A Location tie to this contact")]
    public Guid? VendorLocationId { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit's guid")]
    public Guid? BusinessUnitId { get; init; }

    [JsonPropertyName("moveVendorContact")]
    [Description("Option to move the contact to another vendor")]
    public bool? MoveVendorContact { get; init; }
}

public class UpdateContactActionOutput
{
    [JsonPropertyName("id")]
    [Description("The unique identifier of the updated contact")]
    public Guid Id { get; init; }
}
