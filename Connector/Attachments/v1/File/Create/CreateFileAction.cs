namespace Connector.Attachments.v1.File.Create;

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
[Description("Creates a new file in the HCSS system")]
public class CreateFileAction : IStandardAction<CreateFileActionInput, CreateFileActionOutput>
{
    public CreateFileActionInput ActionInput { get; set; } = new(
        Array.Empty<byte>(),
        string.Empty,
        Guid.Empty,
        Guid.Empty);
    public CreateFileActionOutput ActionOutput { get; set; } = new();
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateFileActionInput
{
    [JsonPropertyName("file")]
    [Description("The binary data of the file")]
    public byte[] FileData { get; set; } = Array.Empty<byte>();

    [JsonPropertyName("fileName")]
    [Description("The name of the file")]
    public string FileName { get; set; } = string.Empty;

    [JsonPropertyName("businessUnitId")]
    [Description("The unique identifier of the business unit")]
    public Guid BusinessUnitId { get; set; }

    [JsonPropertyName("jobId")]
    [Description("The unique identifier of the job")]
    public Guid JobId { get; set; }

    public CreateFileActionInput(byte[] fileData, string fileName, Guid businessUnitId, Guid jobId)
    {
        FileData = fileData;
        FileName = fileName;
        BusinessUnitId = businessUnitId;
        JobId = jobId;
    }
}

public class CreateFileActionOutput
{
    [JsonPropertyName("id")]
    [Description("The unique identifier of the created file")]
    public Guid Id { get; set; }
}
