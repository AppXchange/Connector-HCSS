namespace Connector.Safety.v1.Incidents;

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
[Description("Represents an incident case in Safety")]
public class IncidentsDataObject
{
    [JsonPropertyName("id")]
    [Description("The HCSS unique identifier for the incident")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("createdDateUtc")]
    [Description("The UTC date and time the incident record was created")]
    public DateTime CreatedDateUtc { get; init; }

    [JsonPropertyName("lastModifiedUtc")]
    [Description("The UTC date and time of the last modification to the incident")]
    public DateTime LastModifiedUtc { get; init; }

    [JsonPropertyName("businessUnitDescription")]
    [Description("The description for the business unit associated with this incident")]
    public string? BusinessUnitDescription { get; init; }

    [JsonPropertyName("reportingStatus")]
    [Description("Insurance claim reporting status for this incident")]
    public string? ReportingStatus { get; init; }

    [JsonPropertyName("insuranceCompanyName")]
    [Description("Insurance claim company name for this incident")]
    public string? InsuranceCompanyName { get; init; }

    [JsonPropertyName("insuranceClaimTypes")]
    [Description("Insurance claims for this incident")]
    public string[]? InsuranceClaimTypes { get; init; }

    [JsonPropertyName("claimNumber")]
    [Description("Insurance claim number for this incident")]
    public string? ClaimNumber { get; init; }

    [JsonPropertyName("adjuster")]
    [Description("Adjuster for this incident")]
    public string? Adjuster { get; init; }

    [JsonPropertyName("adjusterEmail")]
    [Description("Adjuster email for this incident")]
    public string? AdjusterEmail { get; init; }

    [JsonPropertyName("adjusterPhone")]
    [Description("Adjuster phone for this incident")]
    public string? AdjusterPhone { get; init; }

    [JsonPropertyName("adjusterNotes")]
    [Description("Adjuster notes for this incident")]
    public string? AdjusterNotes { get; init; }

    [JsonPropertyName("dateInvestigationBegan")]
    [Description("Date the MSHA Investigation Began")]
    public DateTime? DateInvestigationBegan { get; init; }

    [JsonPropertyName("caseNumber")]
    [Description("The user-entered unique identifier for the incident")]
    [MaxLength(100)]
    public string? CaseNumber { get; init; }

    [JsonPropertyName("description")]
    [Description("Description of the incident")]
    [Required]
    [MaxLength(2000)]
    public required string Description { get; init; }

    [JsonPropertyName("notes")]
    [Description("Notes about this incident")]
    [Required]
    public required string Notes { get; init; }

    [JsonPropertyName("fieldNotes")]
    [Description("Field Notes about this incident")]
    [Required]
    public required string FieldNotes { get; init; }

    [JsonPropertyName("jobCode")]
    [Description("The code for the job where the incident occurred")]
    [Required]
    public required string JobCode { get; init; }

    [JsonPropertyName("businessUnitCode")]
    [Description("The code for the business unit associated with this incident")]
    public string? BusinessUnitCode { get; init; }

    [JsonPropertyName("locationDescription")]
    [Description("A description of the location where the incident occurred")]
    [Required]
    [MaxLength(2000)]
    public required string LocationDescription { get; init; }

    [JsonPropertyName("reportedDateUtc")]
    [Description("The UTC date and time when the incident was reported")]
    [Required]
    public required DateTime ReportedDateUtc { get; init; }

    [JsonPropertyName("recorderCode")]
    [Description("The employee code of the person who recorded the incident")]
    [Required]
    public required string RecorderCode { get; init; }

    [JsonPropertyName("personInChargeCode")]
    [Description("The employee code of the employee in charge when the incident occurred")]
    [Required]
    public required string PersonInChargeCode { get; init; }

    [JsonPropertyName("incidentDateUtc")]
    [Description("The UTC date and time when the incident occurred")]
    [Required]
    public required DateTime IncidentDateUtc { get; init; }

    [JsonPropertyName("status")]
    [Description("Incident Status for this incident")]
    public string? Status { get; init; }

    [JsonPropertyName("latitude")]
    [Description("The incident location latitude")]
    [Maximum(90)]
    [Minimum(-90)]
    public double? Latitude { get; init; }

    [JsonPropertyName("longitude")]
    [Description("The incident location longitude")]
    [Maximum(180)]
    [Minimum(-180)]
    public double? Longitude { get; init; }

    [JsonPropertyName("weather")]
    [Description("Weather conditions at the time of the incident")]
    [MaxLength(500)]
    public string? Weather { get; init; }

    [JsonPropertyName("personMostFamiliarCode")]
    [Description("The employee code for the person most familiar with the incident")]
    public string? PersonMostFamiliarCode { get; init; }

    [JsonPropertyName("recordedEmail")]
    [Description("Email of the person who recorded the incident")]
    public string? RecordedEmail { get; init; }

    [JsonPropertyName("recordedPhoneNumber")]
    [Description("Phone Number of the person who recorded the incident")]
    public string? RecordedPhoneNumber { get; init; }

    [JsonPropertyName("personInChargeEmail")]
    [Description("Email of the person in charge when the incident occurred")]
    public string? PersonInChargeEmail { get; init; }

    [JsonPropertyName("personInChargePhoneNumber")]
    [Description("Phone Number of the person in charge when the incident occurred")]
    public string? PersonInChargePhoneNumber { get; init; }

    [JsonPropertyName("personMostFamiliarEmail")]
    [Description("Email of the person most familiar with the incident")]
    public string? PersonMostFamiliarEmail { get; init; }

    [JsonPropertyName("personMostFamiliarPhoneNumber")]
    [Description("Phone Number of the person most familiar with the incident")]
    public string? PersonMostFamiliarPhoneNumber { get; init; }

    [JsonPropertyName("estimatedCost")]
    [Description("Estimated cost of this incident")]
    public double? EstimatedCost { get; init; }

    [JsonPropertyName("actualCost")]
    [Description("Actual cost of this incident")]
    public double? ActualCost { get; init; }

    [JsonPropertyName("isMSHAInvestigation")]
    [Description("Did the incident required a MSHA Investigation")]
    public bool IsMSHAInvestigation { get; init; }

    [JsonPropertyName("individuals")]
    [Description("Individuals list for MSHA Investigation. Separated by semi-colon (;)")]
    public string? Individuals { get; init; }

    [JsonPropertyName("siteDescription")]
    [Description("Site description")]
    public string? SiteDescription { get; init; }

    [JsonPropertyName("accidentInjuryExplanation")]
    [Description("Accident/Injury Explanation")]
    public string? AccidentInjuryExplanation { get; init; }

    [JsonPropertyName("stepsToPreventFutureOccurrences")]
    [Description("Steps to Prevent Future Occurrences")]
    public string? StepsToPreventFutureOccurrences { get; init; }
}