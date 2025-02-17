namespace Connector.HeavyJob.v1.Jobs.Update;

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
[Description("Upserts multiple jobs")]
public class UpdateJobsAction : IStandardAction<UpdateJobsActionInput, UpdateJobsActionOutput>
{
    public UpdateJobsActionInput ActionInput { get; set; } = new() { 
        BusinessUnitId = Guid.Empty,
        Jobs = Array.Empty<JobWrite>()
    };
    public UpdateJobsActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class JobWrite
{
    [JsonPropertyName("code")]
    [Description("The job code")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("description")]
    [Description("The job description")]
    public string? Description { get; init; }

    [JsonPropertyName("laborRateSetGroupCode")]
    [Description("The labor rate set group code")]
    public string? LaborRateSetGroupCode { get; init; }

    [JsonPropertyName("equipmentRateSetGroupCode")]
    [Description("The equipment rate set group code")]
    public string? EquipmentRateSetGroupCode { get; init; }

    [JsonPropertyName("jobStatus")]
    [Description("The job status")]
    public string? JobStatus { get; init; }

    [JsonPropertyName("latitude")]
    [Description("The job latitude")]
    public string? Latitude { get; init; }

    [JsonPropertyName("longitude")]
    [Description("The job longitude")]
    public string? Longitude { get; init; }

    [JsonPropertyName("address1")]
    [Description("The street address")]
    public string? Address1 { get; init; }

    [JsonPropertyName("address2")]
    [Description("The secondary address")]
    public string? Address2 { get; init; }

    [JsonPropertyName("city")]
    [Description("The city")]
    public string? City { get; init; }

    [JsonPropertyName("state")]
    [Description("The state")]
    public string? State { get; init; }

    [JsonPropertyName("zip")]
    [Description("The zip code")]
    public string? Zip { get; init; }

    [JsonPropertyName("country")]
    [Description("The country")]
    public string? Country { get; init; }
}

public class UpdateJobsActionInput
{
    [JsonPropertyName("businessUnitId")]
    [Description("Business Unit ID")]
    [Required]
    public required Guid BusinessUnitId { get; init; }

    [JsonPropertyName("canOverwrite")]
    [Description("Can overwrite flag")]
    public bool CanOverwrite { get; init; }

    [JsonPropertyName("sourceJobId")]
    [Description("The source job id to copy")]
    public Guid? SourceJobId { get; init; }

    [JsonPropertyName("sourceFile")]
    [Description("Name of the file used for upload")]
    public string? SourceFile { get; init; }

    [JsonPropertyName("jobs")]
    [Description("List of jobs to be created")]
    [Required]
    [MaxLength(10000)]
    public required JobWrite[] Jobs { get; init; }
}

public class UpdateJobsActionOutput
{
    [JsonPropertyName("id")]
    [Description("The job id")]
    public Guid Id { get; init; }
}
