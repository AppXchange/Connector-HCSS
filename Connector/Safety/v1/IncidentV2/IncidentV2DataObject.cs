namespace Connector.Safety.v1.IncidentV2;

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
[Description("Represents an incident case in Safety V2")]
public class IncidentV2DataObject
{
    [JsonPropertyName("id")]
    [Description("The HCSS unique identifier for the incident")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("incidentForms")]
    [Description("Detailed list of all forms on this incident")]
    public ApiIncidentForm[]? IncidentForms { get; init; }

    [JsonPropertyName("createdDateUtc")]
    [Description("The UTC date and time the incident record was created")]
    public DateTime CreatedDateUtc { get; init; }

    [JsonPropertyName("lastModifiedUtc")]
    [Description("The UTC date and time of the last modification to the incident")]
    public DateTime LastModifiedUtc { get; init; }

    // ... Include all base incident properties
}

public class ApiIncidentForm
{
    [JsonPropertyName("formName")]
    [Description("Incident form name")]
    public string? FormName { get; init; }

    [JsonPropertyName("sections")]
    [Description("Sections on the incident form")]
    public ApiIncidentFormSection[]? Sections { get; init; }
}

public class ApiIncidentFormSection
{
    [JsonPropertyName("section")]
    [Description("Section name")]
    public string? Section { get; init; }

    [JsonPropertyName("questions")]
    [Description("Questions and answers on the incident form")]
    public ApiIncidentFormQuestion[]? Questions { get; init; }
}

public class ApiIncidentFormQuestion
{
    [JsonPropertyName("question")]
    [Description("Incident form question")]
    public string? Question { get; init; }

    [JsonPropertyName("answer")]
    [Description("Incident form answer")]
    public string? Answer { get; init; }

    [JsonPropertyName("attachments")]
    [Description("If answer has attachments, list of attachments")]
    public ApiAttachment[]? Attachments { get; init; }

    [JsonPropertyName("passengers")]
    [Description("If answer has passengers, list of passengers")]
    public ApiPassenger[]? Passengers { get; init; }

    [JsonPropertyName("otherVehicles")]
    [Description("If answer has other vehicles, list of other vehicles")]
    public ApiOtherVehicle[]? OtherVehicles { get; init; }

    [JsonPropertyName("otherPassengers")]
    [Description("If answer has other passengers, list of other passengers")]
    public ApiOtherPassenger[]? OtherPassengers { get; init; }

    [JsonPropertyName("items")]
    [Description("If answer has items, list of items")]
    public ApiItem[]? Items { get; init; }

    [JsonPropertyName("daysInterval")]
    [Description("Days interval information")]
    public ApiDaysInterval? DaysInterval { get; init; }
}

public class ApiAttachment
{
    [JsonPropertyName("attachmentUrl")]
    [Description("Url of the attachment")]
    [Required]
    public required string AttachmentUrl { get; init; }

    [JsonPropertyName("name")]
    [Description("Display name of the attachment")]
    [Required]
    public required string Name { get; init; }

    [JsonPropertyName("mimeType")]
    [Description("MimeType examples: application/pdf image/png image/jpeg")]
    [Required]
    public required string MimeType { get; init; }
}

public class ApiPassenger
{
    [JsonPropertyName("name")]
    [Description("Name of the passenger")]
    public string? Name { get; init; }

    [JsonPropertyName("address")]
    [Description("Address of the passenger")]
    public string? Address { get; init; }

    [JsonPropertyName("address2")]
    [Description("Address 2 of the passenger")]
    public string? Address2 { get; init; }

    [JsonPropertyName("city")]
    [Description("City of the passenger")]
    public string? City { get; init; }

    [JsonPropertyName("state")]
    [Description("State of the passenger")]
    public string? State { get; init; }

    [JsonPropertyName("zipCode")]
    [Description("Zip code of the passenger")]
    public string? ZipCode { get; init; }

    [JsonPropertyName("country")]
    [Description("Country of the passenger")]
    public string? Country { get; init; }

    [JsonPropertyName("mobilePhone")]
    [Description("Mobile phone of the passenger")]
    public string? MobilePhone { get; init; }

    [JsonPropertyName("homePhone")]
    [Description("Home phone of the passenger")]
    public string? HomePhone { get; init; }
}

public class ApiOtherVehicle
{
    [JsonPropertyName("driverName")]
    [Description("Name of the driver")]
    public string? DriverName { get; init; }

    [JsonPropertyName("make")]
    [Description("The make of the other vehicle")]
    public string? Make { get; init; }

    [JsonPropertyName("model")]
    [Description("The model of the other vehicle")]
    public string? Model { get; init; }

    [JsonPropertyName("year")]
    [Description("The year of the other vehicle")]
    public string? Year { get; init; }

    [JsonPropertyName("licensePlate")]
    [Description("The license plate of the other vehicle")]
    public string? LicensePlate { get; init; }

    [JsonPropertyName("vinNumber")]
    [Description("The VIN number of the other vehicle")]
    public string? VinNumber { get; init; }

    [JsonPropertyName("state")]
    [Description("The state/territory of the other vehicle")]
    public string? State { get; init; }

    [JsonPropertyName("carrier")]
    [Description("The insurance carrier for the other vehicle")]
    public string? Carrier { get; init; }

    [JsonPropertyName("policyNumber")]
    [Description("The insurance policy number for the other vehicle")]
    public string? PolicyNumber { get; init; }
}

public class ApiOtherPassenger
{
    [JsonPropertyName("vehicle")]
    [Description("The other vehicle")]
    public string? Vehicle { get; init; }

    [JsonPropertyName("name")]
    [Description("Name of the other vehicle passenger")]
    public string? Name { get; init; }

    [JsonPropertyName("mobilePhone")]
    [Description("Mobile phone of the other vehicle passenger")]
    public string? MobilePhone { get; init; }

    [JsonPropertyName("homePhone")]
    [Description("Home phone of the other vehicle passenger")]
    public string? HomePhone { get; init; }

    [JsonPropertyName("address1")]
    [Description("Address line 1 of the other vehicle passenger")]
    public string? Address1 { get; init; }

    [JsonPropertyName("address2")]
    [Description("Address line 2 of the other vehicle passenger")]
    public string? Address2 { get; init; }

    [JsonPropertyName("city")]
    [Description("City of the other vehicle passenger")]
    public string? City { get; init; }

    [JsonPropertyName("state")]
    [Description("State of the other vehicle passenger")]
    public string? State { get; init; }

    [JsonPropertyName("zip")]
    [Description("Zip of the other vehicle passenger")]
    public string? Zip { get; init; }

    [JsonPropertyName("country")]
    [Description("Country of the other vehicle passenger")]
    public string? Country { get; init; }
}

public class ApiItem
{
    [JsonPropertyName("itemDescription")]
    [Description("Description of the reported item")]
    public string? ItemDescription { get; init; }

    [JsonPropertyName("estimatedValue")]
    [Description("Estimated value of the reported item")]
    public string? EstimatedValue { get; init; }
}

public class ApiDaysInterval
{
    [JsonPropertyName("firstDay")]
    [Description("First day away")]
    public string? FirstDay { get; init; }

    [JsonPropertyName("lastDay")]
    [Description("Last day away")]
    public string? LastDay { get; init; }

    [JsonPropertyName("daysAway")]
    [Description("Total days away")]
    public int DaysAway { get; init; }

    [JsonPropertyName("includeWeekends")]
    [Description("If weekends are included in calculating total days away")]
    public bool IncludeWeekends { get; init; }
}