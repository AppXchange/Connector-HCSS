namespace Connector.Safety.v1.Alerts.Create;

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
[Description("Creates a new alert in Safety")]
public class CreateAlertsAction : IStandardAction<CreateAlertsActionInput, CreateAlertsActionOutput>
{
    public CreateAlertsActionInput ActionInput { get; set; } = new()
    {
        FirstName = string.Empty,
        LastName = string.Empty,
        BusinessUnitId = Guid.Empty,
        NearMiss = new() { ReceiveAlert = false },
        Incidents = new() 
        { 
            ReceiveAlert = false,
            ManagerCreated = false,
            ManagerUpdated = false,
            FieldCreated = false,
            FieldUpdated = false,
            SendAllFormTypes = false,
            FormTypes = Array.Empty<string>()
        },
        Inspections = new()
        {
            ReceiveAlert = false,
            AllInspections = false,
            InspectionsType = Array.Empty<string>()
        },
        Observations = new()
        {
            ReceiveAlert = false,
            ObservationAlertFlag = 0,
            SeverityThreshold = 0
        },
        Jobs = new()
        {
            IsAllJobs = false,
            Jobs = Array.Empty<string>()
        }
    };

    public CreateAlertsActionOutput ActionOutput { get; set; } = new()
    {
        Id = Guid.Empty,
        FirstName = string.Empty,
        LastName = string.Empty,
        BusinessUnitId = Guid.Empty,
        NearMiss = new() { ReceiveAlert = false },
        Incidents = new() 
        { 
            ReceiveAlert = false,
            ManagerCreated = false,
            ManagerUpdated = false,
            FieldCreated = false,
            FieldUpdated = false,
            SendAllFormTypes = false,
            FormTypes = Array.Empty<string>()
        },
        Inspections = new()
        {
            ReceiveAlert = false,
            AllInspections = false,
            InspectionsType = Array.Empty<string>()
        },
        Observations = new()
        {
            ReceiveAlert = false,
            ObservationAlertFlag = 0,
            SeverityThreshold = 0
        },
        Jobs = new()
        {
            IsAllJobs = false,
            Jobs = Array.Empty<string>()
        }
    };

    public StandardActionFailure ActionFailure { get; set; } = new();
    public bool CreateRtap => true;
}

public class CreateAlertsActionInput
{
    [JsonPropertyName("email")]
    [Description("The Email to send the alert to")]
    public string? Email { get; init; }

    [JsonPropertyName("phoneNumber")]
    [Description("The phone number to send the alert to")]
    public string? PhoneNumber { get; init; }

    [JsonPropertyName("firstName")]
    [Description("The first name of the person receiving the alert")]
    [Required]
    public required string FirstName { get; init; }

    [JsonPropertyName("lastName")]
    [Description("The last name of the person receiving the alert")]
    [Required]
    public required string LastName { get; init; }

    [JsonPropertyName("providerId")]
    [Description("The id of provider who will send the message")]
    public Guid? ProviderId { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit that the alert belongs to")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("carrierAddressOverride")]
    [Description("Carrier address override if needed (SMS)")]
    public string? CarrierAddressOverride { get; init; }

    [JsonPropertyName("nearMiss")]
    [Description("Near miss settings alert property")]
    [Required]
    public required NearMissSettings NearMiss { get; init; }

    [JsonPropertyName("incidents")]
    [Description("Incident settings alert property")]
    [Required]
    public required IncidentSettings Incidents { get; init; }

    [JsonPropertyName("inspections")]
    [Description("Inspection settings alert property")]
    [Required]
    public required InspectionSettings Inspections { get; init; }

    [JsonPropertyName("observations")]
    [Description("Observation settings alert property")]
    [Required]
    public required ObservationSettings Observations { get; init; }

    [JsonPropertyName("jobs")]
    [Description("Jobs settings alert property")]
    [Required]
    public required JobsSettings Jobs { get; init; }
}

public class CreateAlertsActionOutput
{
    [JsonPropertyName("id")]
    [Description("The alert id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("email")]
    [Description("The Email to send the alert to")]
    public string? Email { get; init; }

    [JsonPropertyName("phoneNumber")]
    [Description("The phone number to send the alert to")]
    public string? PhoneNumber { get; init; }

    [JsonPropertyName("firstName")]
    [Description("The first name of the person receiving the alert")]
    [Required]
    public required string FirstName { get; init; }

    [JsonPropertyName("lastName")]
    [Description("The last name of the person receiving the alert")]
    [Required]
    public required string LastName { get; init; }

    [JsonPropertyName("providerId")]
    [Description("The id of provider who will send the message")]
    public Guid? ProviderId { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit that the alert belongs to")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("carrierAddressOverride")]
    [Description("Carrier address override if needed (SMS)")]
    public string? CarrierAddressOverride { get; init; }

    [JsonPropertyName("nearMiss")]
    [Description("Near miss settings alert property")]
    [Required]
    public required NearMissSettings NearMiss { get; init; }

    [JsonPropertyName("incidents")]
    [Description("Incident settings alert property")]
    [Required]
    public required IncidentSettings Incidents { get; init; }

    [JsonPropertyName("inspections")]
    [Description("Inspection settings alert property")]
    [Required]
    public required InspectionSettings Inspections { get; init; }

    [JsonPropertyName("observations")]
    [Description("Observation settings alert property")]
    [Required]
    public required ObservationSettings Observations { get; init; }

    [JsonPropertyName("jobs")]
    [Description("Jobs settings alert property")]
    [Required]
    public required JobsSettings Jobs { get; init; }
}
