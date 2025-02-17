namespace Connector.HeavyJob.v1.MobileChangeOrdersByBusinessUnit;

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
[Description("Represents a mobile change order in HeavyJob")]
public class MobileChangeOrdersByBusinessUnitDataObject
{
    [JsonPropertyName("id")]
    [Description("The change order ID")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("lastUpdatedDate")]
    [Description("The datetime when this change order was last modified")]
    [Required]
    public required DateTime LastUpdatedDate { get; init; }

    [JsonPropertyName("managedByUser")]
    [Description("A POCO that represents a user's basic information")]
    public UserSlimRead? ManagedByUser { get; init; }

    [JsonPropertyName("job")]
    [Description("A POCO that represents a job's basic information")]
    public JobCompactRead? Job { get; init; }

    [JsonPropertyName("subject")]
    [Description("The subject")]
    [Required]
    public required string Subject { get; init; }

    [JsonPropertyName("changeOrderNumber")]
    [Description("The change order number")]
    [Required]
    public required int ChangeOrderNumber { get; init; }

    [JsonPropertyName("description")]
    [Description("The change order description")]
    public string? Description { get; init; }

    [JsonPropertyName("status")]
    [Description("A POCO that represents a change order status's basic information")]
    public ChangeOrderStatusCompactRead? Status { get; init; }

    [JsonPropertyName("scheduleImpactEvaluation")]
    [Description("The schedule impact evaluation")]
    public string? ScheduleImpactEvaluation { get; init; }

    [JsonPropertyName("scheduleImpactDescription")]
    [Description("The description of this change's impact on schedule")]
    public string? ScheduleImpactDescription { get; init; }

    [JsonPropertyName("isDeleted")]
    [Description("The deleted status of the change order")]
    public bool IsDeleted { get; init; }

    [JsonPropertyName("showInMobile")]
    [Description("Should the PCO show in mobile")]
    public bool ShowInMobile { get; init; }

    [JsonPropertyName("otherDrawings")]
    [Description("Related drawings")]
    public string[]? OtherDrawings { get; init; }

    [JsonPropertyName("costCodes")]
    [Description("Related Cost Codes")]
    public Guid[]? CostCodes { get; init; }

    [JsonPropertyName("attachments")]
    [Description("Related Attachments")]
    public ChangeOrderAttachmentCompactRead[]? Attachments { get; init; }

    [JsonPropertyName("plansSheets")]
    [Description("Related plans")]
    public ChangeOrderPlansSheetRead[]? PlansSheets { get; init; }

    [JsonPropertyName("linkedItems")]
    [Description("Linked items")]
    public ChangeOrderLinkedItemRead[]? LinkedItems { get; init; }
}

public class UserSlimRead
{
    [JsonPropertyName("id")]
    [Description("The user id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("firstName")]
    [Description("The first name")]
    [Required]
    public required string FirstName { get; init; }

    [JsonPropertyName("lastName")]
    [Description("The last name")]
    public string? LastName { get; init; }

    [JsonPropertyName("email")]
    [Description("The email")]
    public string? Email { get; init; }
}

public class JobCompactRead
{
    [JsonPropertyName("id")]
    [Description("The job guid")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("code")]
    [Description("The job's code")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("description")]
    [Description("The job's description")]
    [Required]
    public required string Description { get; init; }
}

public class ChangeOrderStatusCompactRead
{
    [JsonPropertyName("id")]
    [Description("The change order status guid")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    [Description("The change order status name")]
    [Required]
    public required string Name { get; init; }

    [JsonPropertyName("value")]
    [Description("The change order status value")]
    [Required]
    public required string Value { get; init; }
}

public class ChangeOrderAttachmentCompactRead
{
    [JsonPropertyName("id")]
    [Description("Attachment Id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("fileName")]
    [Description("Attachment file name")]
    public string? FileName { get; init; }
}

public class ChangeOrderPlansSheetRead
{
    [JsonPropertyName("sheetId")]
    [Description("The sheet ID")]
    [Required]
    public required Guid SheetId { get; init; }

    [JsonPropertyName("sheetName")]
    [Description("The sheet name")]
    public string? SheetName { get; init; }

    [JsonPropertyName("projectId")]
    [Description("The project ID")]
    [Required]
    public required Guid ProjectId { get; init; }

    [JsonPropertyName("id")]
    [Description("The ID")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("lastUpdatedDate")]
    [Description("The datetime when this change order plans sheet was last modified")]
    [Required]
    public required DateTime LastUpdatedDate { get; init; }

    [JsonPropertyName("lastUpdatedByUser")]
    [Description("A POCO that represents a user's basic information")]
    public UserSlimRead? LastUpdatedByUser { get; init; }
}

public class ChangeOrderLinkedItemRead
{
    [JsonPropertyName("itemId")]
    [Description("The change order linked Item ID")]
    [Required]
    public required Guid ItemId { get; init; }

    [JsonPropertyName("type")]
    [Description("The linked item type")]
    public string? Type { get; init; }

    [JsonPropertyName("id")]
    [Description("The ID")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("lastUpdatedDate")]
    [Description("The datetime when this change order linked item was last modified")]
    [Required]
    public required DateTime LastUpdatedDate { get; init; }

    [JsonPropertyName("lastUpdatedByUser")]
    [Description("A POCO that represents a user's basic information")]
    public UserSlimRead? LastUpdatedByUser { get; init; }
}