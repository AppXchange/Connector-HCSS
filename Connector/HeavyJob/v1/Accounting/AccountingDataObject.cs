namespace Connector.HeavyJob.v1.Accounting;

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
[PrimaryKey("accountingValueId", nameof(AccountingValueId))]
[Description("Represents an accounting value in HeavyJob")]
public class AccountingDataObject
{
    [JsonPropertyName("value")]
    [Description("The accounting value")]
    public string? Value { get; init; }

    [JsonPropertyName("description")]
    [Description("The description of the accounting value")]
    public string? Description { get; init; }

    [JsonPropertyName("code")]
    [Description("The accounting code")]
    public string? Code { get; init; }

    [JsonPropertyName("accountingValueId")]
    [Description("The unique identifier of the accounting value")]
    [Required]
    public required Guid AccountingValueId { get; init; }

    [JsonPropertyName("parentId")]
    [Description("The parent accounting value ID")]
    public Guid? ParentId { get; init; }

    [JsonPropertyName("dataType")]
    [Description("The data type of the accounting value")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public AccountingDataType DataType { get; init; }
}

public enum AccountingDataType
{
    Unknown
}

public enum AccountingEntityType
{
    PayClass,
    Labor,
    Equipment,
    Trucking,
    Material,
    Subcontract,
    Supplies,
    X1,
    X2,
    X3,
    Job,
    PayAdjustments,
    BusinessUnit,
    CostCode,
    WorkersComp,
    CustomCostType,
    PurchaseOrder,
    PurchaseOrderDetail,
    VendorContract,
    VendorContractDetail,
    PayItem,
    JobLabor,
    JobEquipment,
    Unknown
}