namespace Connector.Webhooks.v1.SetupsSubscription;

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
[Description("Represents a Setups webhook subscription")]
public class SetupsSubscriptionDataObject
{
    [JsonPropertyName("id")]
    [Description("Unique identifier for the webhook subscription")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("companyId")]
    [Description("The company ID associated with the subscription")]
    [Required]
    public required Guid CompanyId { get; init; }

    [JsonPropertyName("businessUnitId")]
    [Description("The business unit ID associated with the subscription")]
    public Guid? BusinessUnitId { get; init; }

    [JsonPropertyName("eventType")]
    [Description("The type of event being subscribed to")]
    [Required]
    public required string EventType { get; init; }

    [JsonPropertyName("callbackUrl")]
    [Description("The URL where webhook notifications will be sent")]
    [Required]
    public required string CallbackUrl { get; init; }

    [JsonPropertyName("dateCreated")]
    [Description("When the subscription was created")]
    [Required]
    public required DateTime DateCreated { get; init; }

    [JsonPropertyName("clientId")]
    [Description("The client ID associated with the subscription")]
    [Required]
    public required string ClientId { get; init; }

    [JsonPropertyName("status")]
    [Description("Current status of the subscription")]
    [Required]
    public required string Status { get; init; }

    [JsonPropertyName("secretKey")]
    [Description("Secret key used to validate webhook payloads")]
    [Required]
    public required string SecretKey { get; init; }
}