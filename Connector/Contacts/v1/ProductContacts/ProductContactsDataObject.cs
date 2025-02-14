namespace Connector.Contacts.v1.ProductContacts;

using Json.Schema.Generation;
using System;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.CacheWriter;

/// <summary>
/// Data object that will represent an object in the Xchange system. This will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// These types will be used for validation at runtime to make sure the objects being passed through the system 
/// are properly formed. The schema also helps provide integrators more information for what the values 
/// are intended to be.
/// </summary>
[PrimaryKey("id", nameof(Id))]
//[AlternateKey("alt-key-id", nameof(CompanyId), nameof(EquipmentNumber))]
[Description("Represents a contact associated with a product type")]
public class ProductContactsDataObject
{
    [JsonPropertyName("id")]
    [Description("Contact's unique identifier")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("companyId")]
    [Description("Company's unique identifier")]
    [Required]
    public required Guid CompanyId { get; init; }

    [JsonPropertyName("companyName")]
    [Description("Company's name")]
    public string? CompanyName { get; init; }

    [JsonPropertyName("firstName")]
    [Description("Contact's first name")]
    public string? FirstName { get; init; }

    [JsonPropertyName("lastName")]
    [Description("Contact's last name")]
    public string? LastName { get; init; }

    [JsonPropertyName("title")]
    [Description("Contact's title")]
    public string? Title { get; init; }

    [JsonPropertyName("phoneNumber")]
    [Description("Contact's phone number")]
    public string? PhoneNumber { get; init; }

    [JsonPropertyName("faxNumber")]
    [Description("Contact's fax number")]
    public string? FaxNumber { get; init; }

    [JsonPropertyName("cellPhoneNumber")]
    [Description("Contact's cell phone number")]
    public string? CellPhoneNumber { get; init; }

    [JsonPropertyName("emailAddress")]
    [Description("Contact's email address")]
    public string? EmailAddress { get; init; }

    [JsonPropertyName("isMainContact")]
    [Description("Whether it is the main contact")]
    public bool IsMainContact { get; init; }

    [JsonPropertyName("note")]
    [Description("Note on the contact")]
    public string? Note { get; init; }

    [JsonPropertyName("role")]
    [Description("A string specifying a contact's role")]
    public string? Role { get; init; }

    [JsonPropertyName("lastContacted")]
    [Description("A DateTime when this contact was last contacted")]
    public DateTime? LastContacted { get; init; }

    [JsonPropertyName("vendorLocationId")]
    [Description("A LocationId this contact tie to")]
    public Guid? VendorLocationId { get; init; }
}