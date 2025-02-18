namespace Connector.Safety.v1.Alerts;

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
[Description("Represents an alert in Safety")]
public class AlertsDataObject
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

public class NearMissSettings
{
    [JsonPropertyName("receiveAlert")]
    [Description("The alert should trigger in near misses (isReceiveNearMisses)")]
    public bool ReceiveAlert { get; init; }
}

public class IncidentSettings
{
    [JsonPropertyName("receiveAlert")]
    [Description("The alert should trigger in incidents (isReceiveIncidents)")]
    public bool ReceiveAlert { get; init; }

    [JsonPropertyName("managerCreated")]
    [Description("The alert will be sent when manager creates an incident (sendIncidentAlertForManager)")]
    public bool ManagerCreated { get; init; }

    [JsonPropertyName("managerUpdated")]
    [Description("The alert will be sent when manager updates an incident (sendIncidentAlertForUpdates)")]
    public bool ManagerUpdated { get; init; }

    [JsonPropertyName("fieldCreated")]
    [Description("The alert should be sent when field app creates an incident (sendIncidentAlertForCreateField)")]
    public bool FieldCreated { get; init; }

    [JsonPropertyName("fieldUpdated")]
    [Description("The alert should be sent to when the field app updates an incident (sendIncidentAlertForUpdateField)")]
    public bool FieldUpdated { get; init; }

    [JsonPropertyName("sendAllFormTypes")]
    [Description("The alert should trigger for incidents of all forms types (IsAllIncidentFormTypes)")]
    public bool SendAllFormTypes { get; init; }

    [JsonPropertyName("formTypes")]
    [Description("The list of all form types that should trigger the alert (if SendAllFormTypes is true will be empty)")]
    public string[] FormTypes { get; init; } = Array.Empty<string>();
}

public class InspectionSettings
{
    [JsonPropertyName("receiveAlert")]
    [Description("The alert should trigger in inspections (isReceiveInspections)")]
    public bool ReceiveAlert { get; init; }

    [JsonPropertyName("allInspections")]
    [Description("The alert should trigger for all inspections types (isAllInspectionTypes)")]
    public bool AllInspections { get; init; }

    [JsonPropertyName("inspectionsType")]
    [Description("The list of all inspections type that should trigger the alert (if AllInspections is true will be empty)")]
    public string[] InspectionsType { get; init; } = Array.Empty<string>();
}

public class ObservationSettings
{
    [JsonPropertyName("receiveAlert")]
    [Description("The alert should trigger observations")]
    public bool ReceiveAlert { get; init; }

    [JsonPropertyName("observationAlertFlag")]
    [Description("For no observations enter 0, only positive observations enter 3, for only negative observations enter 5, for both, enter 7.")]
    public int ObservationAlertFlag { get; init; }

    [JsonPropertyName("severityThreshold")]
    [Description("The severity of observation that should trigger the alert (severityThreshold)")]
    public int SeverityThreshold { get; init; }
}

public class JobsSettings
{
    [JsonPropertyName("isAllJobs")]
    [Description("The alert should trigger in all Jobs (IsAllJobs)")]
    public bool IsAllJobs { get; init; }

    [JsonPropertyName("jobs")]
    [Description("The list of all jobs that should trigger the alert (if isAllJobs is true will be empty)")]
    public string[] Jobs { get; init; } = Array.Empty<string>();
}