namespace Connector.Webhooks.v1.HeavyJobSubscription.Create;

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
[Description("Creates a new webhook subscription for HeavyJob events")]
public class CreateHeavyJobSubscriptionAction : IStandardAction<CreateHeavyJobSubscriptionActionInput, CreateHeavyJobSubscriptionActionOutput>
{
    public CreateHeavyJobSubscriptionActionInput ActionInput { get; set; } = new()
    {
        Url = string.Empty,
        EventTypes = Array.Empty<string>()
    };
    
    public CreateHeavyJobSubscriptionActionOutput ActionOutput { get; set; } = new()
    {
        SecretKey = string.Empty
    };
    
    public StandardActionFailure ActionFailure { get; set; } = new();

    public bool CreateRtap => true;
}

public class CreateHeavyJobSubscriptionActionInput
{
    [JsonPropertyName("url")]
    [Description("The callback URL where webhook notifications will be sent")]
    [Required]
    public required string Url { get; init; }

    [JsonPropertyName("eventTypes")]
    [Description("The event types to subscribe to")]
    [Required]
    public required string[] EventTypes { get; init; }

    [JsonPropertyName("secretKey")]
    [Description("Optional secret key for webhook payload validation")]
    public string? SecretKey { get; init; }

    [JsonPropertyName("jobIds")]
    [Description("Optional job IDs to filter events")]
    public Guid[]? JobIds { get; init; }
}

public class CreateHeavyJobSubscriptionActionOutput
{
    [JsonPropertyName("secretKey")]
    [Description("The secret key to use for webhook payload validation")]
    public required string SecretKey { get; init; }
}
