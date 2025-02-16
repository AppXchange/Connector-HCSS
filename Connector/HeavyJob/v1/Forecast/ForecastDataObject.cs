namespace Connector.HeavyJob.v1.Forecast;

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
[Description("Forecast details in HeavyJob")]
public class ForecastDataObject
{
    [JsonPropertyName("id")]
    [Description("The forecast guid")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("jobId")]
    [Description("The job guid")]
    [Required] 
    public required Guid JobId { get; init; }

    [JsonPropertyName("forecastDate")]
    [Description("The forecast date")]
    [Required]
    public required DateTime ForecastDate { get; init; }

    [JsonPropertyName("isFinalized")]
    [Description("Whether the forecast is finalized")]
    public bool IsFinalized { get; init; }

    [JsonPropertyName("finalizedDateTime")]
    [Description("The forecast finalized date")]
    public DateTime? FinalizedDateTime { get; init; }

    [JsonPropertyName("createdDateTime")]
    [Description("The forecast created date")]
    [Required]
    public required DateTime CreatedDateTime { get; init; }

    [JsonPropertyName("forecastSourceId")]
    [Description("The source id of the forecast (When forecast is based on a previous forecast)")]
    public Guid? ForecastSourceId { get; init; }

    [JsonPropertyName("productivityType")]
    [Description("The productivity type")]
    public string? ProductivityType { get; init; }

    [JsonPropertyName("createdOnWeb")]
    [Description("Whether the forecast is created on web")]
    public bool CreatedOnWeb { get; init; }

    [JsonPropertyName("lastModifiedBy")]
    [Description("User who last modified the forecast")]
    public LastModifiedByInfo? LastModifiedBy { get; init; }

    [JsonPropertyName("totalBudget")]
    [Description("Total budget")]
    public double? TotalBudget { get; init; }

    [JsonPropertyName("costAtCompletion")]
    [Description("Total cost at the completion. To-date total cost + cost to complete")]
    public double? CostAtCompletion { get; init; }

    [JsonPropertyName("costCodeCosts")]
    [Description("Forecast costs and quantity by cost code")]
    public CostCodeCost[]? CostCodeCosts { get; init; }

    [JsonPropertyName("revenue")]
    [Description("Forecast revenues and quantities by pay item")]
    public RevenueItem[]? Revenue { get; init; }
}

public class LastModifiedByInfo
{
    [JsonPropertyName("id")]
    [Required]
    public required Guid Id { get; init; }

    [JsonPropertyName("firstName")]
    [Required]
    public required string FirstName { get; init; }

    [JsonPropertyName("lastName")]
    public string? LastName { get; init; }

    [JsonPropertyName("email")]
    public string? Email { get; init; }
}

public class CostCodeCost
{
    [JsonPropertyName("costCodeId")]
    public Guid CostCodeId { get; init; }

    [JsonPropertyName("equipmentCost")]
    public double EquipmentCost { get; init; }

    [JsonPropertyName("creationToDateEquipmentCost")]
    public double CreationToDateEquipmentCost { get; init; }

    [JsonPropertyName("equipmentHours")]
    public double EquipmentHours { get; init; }

    [JsonPropertyName("creationToDateEquipmentHours")]
    public double CreationToDateEquipmentHours { get; init; }

    [JsonPropertyName("laborCost")]
    public double LaborCost { get; init; }

    [JsonPropertyName("creationToDateLaborCost")]
    public double CreationToDateLaborCost { get; init; }

    [JsonPropertyName("laborHours")]
    public double LaborHours { get; init; }

    [JsonPropertyName("creationToDateLaborHours")]
    public double CreationToDateLaborHours { get; init; }

    [JsonPropertyName("materialCost")]
    public double MaterialCost { get; init; }

    [JsonPropertyName("creationToDateMaterialCost")]
    public double CreationToDateMaterialCost { get; init; }

    [JsonPropertyName("subcontractCost")]
    public double SubcontractCost { get; init; }

    [JsonPropertyName("creationToDateSubcontractCost")]
    public double CreationToDateSubcontractCost { get; init; }

    [JsonPropertyName("quantity")]
    public double Quantity { get; init; }

    [JsonPropertyName("creationToDateQuantity")]
    public double CreationToDateQuantity { get; init; }

    [JsonPropertyName("customCostTypeValues")]
    public CustomCostTypeValue[]? CustomCostTypeValues { get; init; }
}

public class CustomCostTypeValue
{
    [JsonPropertyName("costCategoryId")]
    public Guid CostCategoryId { get; init; }

    [JsonPropertyName("costCategoryCode")]
    public string? CostCategoryCode { get; init; }

    [JsonPropertyName("costCategoryDescription")]
    public string? CostCategoryDescription { get; init; }

    [JsonPropertyName("cost")]
    public double Cost { get; init; }

    [JsonPropertyName("creationToDateCost")]
    public double CreationToDateCost { get; init; }
}

public class RevenueItem
{
    [JsonPropertyName("revenueId")]
    public Guid RevenueId { get; init; }

    [JsonPropertyName("payItem")]
    public PayItem? PayItem { get; init; }

    [JsonPropertyName("forecastQuantity")]
    public double ForecastQuantity { get; init; }

    [JsonPropertyName("toDateQuantity")]
    public double ToDateQuantity { get; init; }

    [JsonPropertyName("remainingQuantity")]
    public double RemainingQuantity { get; init; }

    [JsonPropertyName("forecastRevenue")]
    public double ForecastRevenue { get; init; }

    [JsonPropertyName("toDateRevenue")]
    public double ToDateRevenue { get; init; }

    [JsonPropertyName("revenueToCompletion")]
    public double RevenueToCompletion { get; init; }

    [JsonPropertyName("originalBidAmount")]
    public double OriginalBidAmount { get; init; }

    [JsonPropertyName("profit")]
    public double Profit { get; init; }

    [JsonPropertyName("variance")]
    public double Variance { get; init; }

    [JsonPropertyName("costAtCompletion")]
    public double CostAtCompletion { get; init; }

    [JsonPropertyName("marginPercent")]
    public double MarginPercent { get; init; }

    [JsonPropertyName("markupPercent")]
    public double MarkupPercent { get; init; }

    [JsonPropertyName("isReviewed")]
    public bool IsReviewed { get; init; }

    [JsonPropertyName("note")]
    public string? Note { get; init; }
}

public class PayItem
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("jobId")]
    public Guid JobId { get; init; }

    [JsonPropertyName("payItem")]
    public string? Code { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("ownerCode")]
    public string? OwnerCode { get; init; }

    [JsonPropertyName("unitOfMeasure")]
    public string? UnitOfMeasure { get; init; }

    [JsonPropertyName("unitPrice")]
    public double UnitPrice { get; init; }

    [JsonPropertyName("contractQuantity")]
    public double ContractQuantity { get; init; }
}