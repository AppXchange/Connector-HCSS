using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using System;
using Connector.Attachments.v1.File;
using Connector.Contacts.v1.Contact;
using Connector.Contacts.v1.Contact.Create;
using Connector.Contacts.v1.Contact.Update;
using Connector.Contacts.v1.ContactProducts;
using Connector.Contacts.v1.ContactProducts.Create;
using Connector.Contacts.v1.ContactProducts.Delete;
using Connector.Contacts.v1.Contacts;
using Connector.Contacts.v1.Office;
using Connector.Contacts.v1.Office.Create;
using Connector.Contacts.v1.Office.Delete;
using Connector.Contacts.v1.Office.Update;
using Connector.Contacts.v1.Offices;
using Connector.Contacts.v1.ProductContacts;
using Connector.Contacts.v1.Products;
using Connector.Contacts.v1.ProductType;
using Connector.Contacts.v1.ProductType.Create;
using Connector.Contacts.v1.ProductType.Delete;
using Connector.Contacts.v1.ProductType.Update;
using Connector.Contacts.v1.ProductVendors;
using Connector.Contacts.v1.Vendor;
using Connector.Contacts.v1.Vendor.Create;
using Connector.Contacts.v1.Vendor.Delete;
using Connector.Contacts.v1.Vendor.Update;
using Connector.Contacts.v1.VendorProducts;
using Connector.Contacts.v1.VendorProducts.Create;
using Connector.Contacts.v1.Vendors;
using Connector.Equipment360.v1.AllEquipment;
using Connector.Client.Equipment360;
using System.Linq;
using System.Text.Json.Serialization;
using Connector.Equipment360.v1.BusinessUnit;
using Connector.Equipment360.v1.CustomField;
using Connector.Equipment360.v1.CustomField.Create;
using Connector.Equipment360.v1.CustomFieldCategories;
using Connector.Equipment360.v1.CustomFieldList;
using Connector.Equipment360.v1.Employee;
using Connector.Equipment360.v1.Employee.Create;
using Connector.Equipment360.v1.Employee.Update;
using Connector.Equipment360.v1.Employees;
using Connector.Equipment360.v1.Equipment;
using Connector.Equipment360.v1.Equipment.Create;
using Connector.Equipment360.v1.Equipment.Update;
using Connector.Equipment360.v1.EquipmentTransfer;
using Connector.Equipment360.v1.EquipmentTransfer.Create;
using Connector.Equipment360.v1.EquipmentType;
using Connector.Equipment360.v1.EquipmentType.Create;
using Connector.Equipment360.v1.FuelCosts;
using Connector.Equipment360.v1.Invoice;
using Connector.Equipment360.v1.Invoice.Create;
using Connector.Equipment360.v1.Invoice.Update;
using Connector.Equipment360.v1.Jobs;
using Connector.Equipment360.v1.Jobs.Create;
using Connector.Equipment360.v1.Jobs.Update;
using Connector.Equipment360.v1.Locations;
using Connector.Equipment360.v1.Locations.Create;
using Connector.Equipment360.v1.Locations.Update;
using Connector.Equipment360.v1.MaintenanceRequest;
using Connector.Equipment360.v1.MaintenanceRequest.Create;
using Connector.Equipment360.v1.MeterReading;
using Connector.Equipment360.v1.MeterReading.Create;
using Connector.Equipment360.v1.PartCostEntries.Create;
using Connector.Equipment360.v1.PartCostEntries;
using Connector.Equipment360.v1.PartCostEntry;
using Connector.Equipment360.v1.PartCostEntry.Create;
using Connector.Equipment360.v1.PartInventory;
using Connector.Equipment360.v1.PartInventory.Create;
using Connector.Equipment360.v1.PartLocations;
using Connector.Equipment360.v1.Parts;
using Connector.Equipment360.v1.Parts.Update;
using Connector.Equipment360.v1.PurchaseOrder;
using Connector.Equipment360.v1.PurchaseOrder.Create;
using Connector.Equipment360.v1.PurchaseOrderDetails;
using Connector.Equipment360.v1.PurchaseOrderDetails.Create;
using Connector.Equipment360.v1.PurchaseOrderNotes;
using Connector.Equipment360.v1.PurchaseOrderNotes.Create;
using Connector.Equipment360.v1.PurchaseOrders;
using Connector.Equipment360.v1.SubletVendorCostEntries;
using Connector.Equipment360.v1.SubletVendorCostEntries.Create;
using Connector.Equipment360.v1.SubletVendorCostEntry;
using Connector.Equipment360.v1.SubletVendorCostEntry.Create;
using Connector.Equipment360.v1.Tags;
using Connector.Equipment360.v1.TimeCard;
using Connector.Equipment360.v1.UnitOfMeasure;
using Connector.Equipment360.v1.Vendors;
using Connector.Equipment360.v1.Vendors.Update;
using Connector.Equipment360.v1.WorkOrder;
using Connector.Equipment360.v1.WorkOrder.Create;
using Connector.Equipment360.v1.WorkOrder.Update;
using Connector.Equipment360.v1.WorkOrderCosts;
using Connector.Equipment360.v1.WorkOrderCostsDetails;
using Connector.Equipment360.v1.WorkOrderNotes;
using Connector.Equipment360.v1.WorkOrderNotes.Create;
using Connector.Equipment360.v1.WorkOrderPurchase;
using Connector.Equipment360.v1.WorkOrders;
using Connector.Equipment360.v1.WorkOrderSchedule;
using Connector.HeavyBidEstimate.v1.Activities;
using Connector.HeavyBidEstimate.v1.Activity;
using Connector.HeavyBidEstimate.v1.ActivityCodeBook;
using Connector.HeavyBidEstimate.v1.ActivityCodebookResource;
using Connector.HeavyBidEstimate.v1.ActivityCodebookResources;
using Connector.HeavyBidEstimate.v1.ActivityCodeBooks;
using Connector.HeavyBidEstimate.v1.AllBiditemCodebook;
using Connector.HeavyBidEstimate.v1.AllCalulatedKPIs;
using Connector.HeavyBidEstimate.v1.AllMaterialCodebook;
using Connector.HeavyBidEstimate.v1.Biditem;
using Connector.HeavyBidEstimate.v1.BiditemCodebook;
using Connector.HeavyBidEstimate.v1.Biditems;
using Connector.HeavyBidEstimate.v1.BusinessUnits;
using Connector.HeavyBidEstimate.v1.DownloadEstimateAttachment;
using System.IO;
using Connector.HeavyBidEstimate.v1.Estimate;
using Connector.HeavyBidEstimate.v1.EstimateAttachments;
using Connector.HeavyBidEstimate.v1.Estimates;
using Connector.HeavyBidEstimate.v1.MaterialCodebook;
using Connector.HeavyBidEstimate.v1.MaterialCodebook.Update;
using Connector.HeavyBidEstimate.v1.Materials;
using Connector.HeavyBidEstimate.v1.Partition;
using Connector.HeavyBidEstimate.v1.Partitions;
using Connector.HeavyBidEstimate.v1.QuoteFolder;
using Connector.HeavyBidEstimate.v1.QuoteFolders;
using Connector.HeavyBidEstimate.v1.Resource;
using Connector.HeavyBidEstimate.v1.Resources;
using Connector.HeavyBidPreConstruction.v1.BusinessUnit;
using Connector.HeavyBidPreConstruction.v1.Project;
using Connector.HeavyBidPreConstruction.v1.Project.Create;
using Connector.HeavyBidPreConstruction.v1.Project.Update;
using Connector.HeavyBidPreConstruction.v1.Project.PartialChange;
using Connector.HeavyBidPreConstruction.v1.Projects;
using Connector.HeavyBidPreConstruction.v1.Projects.Create;
using Connector.HeavyBidPreConstruction.v1.Projects.Delete;
using Connector.HeavyBidPreConstruction.v1.Reports.Create;
using Connector.HeavyBidPreConstruction.v1.Schema;
using Connector.HeavyBidPreConstruction.v1.Schemas;
using Connector.HeavyJob.v1.AccessGroup;
using Connector.HeavyJob.v1.Accounting;
using Connector.HeavyJob.v1.AdvancedBudgetCustomCostTypeItem.Create;
using Connector.HeavyJob.v1.AdvancedBudgetCustomCostTypes;
using Connector.HeavyJob.v1.AdvancedBudgetMaterial;
using Connector.HeavyJob.v1.AdvancedBudgetMaterial.Create;
using Connector.HeavyJob.v1.AdvancedBudgetSubcontract;
using Connector.HeavyJob.v1.AdvancedBudgetSubcontract.Create;
using Connector.HeavyJob.v1.Attachment;
using Connector.HeavyJob.v1.Attachment.Create;
using Connector.HeavyJob.v1.AttendanceHourTags;
using Connector.HeavyJob.v1.BusinessUnitPreference;
using Connector.HeavyJob.v1.BusinessUnitPreference.Update;
using Connector.HeavyJob.v1.ChangeOrder;
using Connector.HeavyJob.v1.ChangeOrder.Create;
using Connector.HeavyJob.v1.ChangeOrder.Delete;
using Connector.HeavyJob.v1.ChangeOrder.Update;
using Connector.HeavyJob.v1.ChangeOrderIncrementor;
using Connector.HeavyJob.v1.ChangeOrdersByBusinessUnit;
using Connector.HeavyJob.v1.ChangeOrdersByJob;
using Connector.HeavyJob.v1.CostAdjustments;
using Connector.HeavyJob.v1.CostAdjustments.Create;
using Connector.HeavyJob.v1.CostAdjustments.Update;
using Connector.HeavyJob.v1.CostCategories;
using Connector.HeavyJob.v1.CostCategories.Create;
using Connector.HeavyJob.v1.CostCodeCosts;
using Connector.HeavyJob.v1.CostCodeCosts.Update;
using Connector.HeavyJob.v1.CostCodeProgress;
using Connector.HeavyJob.v1.CostCodes;
using Connector.HeavyJob.v1.CostCodes.Create;
using Connector.HeavyJob.v1.CostCodes.Update;
using Connector.HeavyJob.v1.CostCodeTags;
using Connector.HeavyJob.v1.CostCodeTags.Create;
using Connector.HeavyJob.v1.CostCodeTags.Delete;
using Connector.HeavyJob.v1.CostCodeTags.Update;
using Connector.HeavyJob.v1.CostCodeTransaction;
using Connector.HeavyJob.v1.CostCodeTransactionAdjustment;
using Connector.HeavyJob.v1.CustomCostTypeInstalled;
using Connector.HeavyJob.v1.CustomCostTypeItemReceived;
using Connector.HeavyJob.v1.CustomCostTypeItems;
using Connector.HeavyJob.v1.CustomCostTypeItems.Create;
using Connector.HeavyJob.v1.CustomCostTypeItems.Update;
using Connector.HeavyJob.v1.Diaries;
using Connector.HeavyJob.v1.Diary;
using Connector.HeavyJob.v1.EmployeeHours;
using Connector.HeavyJob.v1.Employees;
using Connector.HeavyJob.v1.EmployeesAdvanced;
using Connector.HeavyJob.v1.EmployeesWithDetails;
using System.ComponentModel.DataAnnotations;
using Connector.HeavyJob.v1.Equipment.Create;  // Add this line
using Connector.HeavyJob.v1.Equipment.Update;
using Connector.HeavyJob.v1.EquipmentHours;  // Add this line
using Connector.HeavyJob.v1.EquipmentType;
using Connector.HeavyJob.v1.EquipmentType.Create;
using Connector.HeavyJob.v1.Forecast;
using Connector.HeavyJob.v1.ForecastInfo;
using Connector.HeavyJob.v1.JobCostByCostCode;
using Connector.HeavyJob.v1.JobCostCustomCost;
using Connector.HeavyJob.v1.JobCosts;
using Connector.HeavyJob.v1.JobCostsQuery;
using Connector.HeavyJob.v1.JobCostsToDate;
using Connector.HeavyJob.v1.JobCustomCostTypeItem;
using Connector.HeavyJob.v1.JobCustomCostTypeItem.Create;
using Connector.HeavyJob.v1.JobCustomCostTypeItem.Delete;
using System.Text;
using Connector.HeavyJob.v1.JobCustomCostTypeItem.Update;
using System.Text.Json;
using Connector.HeavyJob.v1.JobCustomCostTypeItems;
using Connector.HeavyJob.v1.JobEmployees;
using Connector.HeavyJob.v1.JobEmployees.Update;
using Connector.HeavyJob.v1.JobEquipment;
using Connector.HeavyJob.v1.JobEquipment.Update;
using Connector.HeavyJob.v1.JobMaterial;
using Connector.HeavyJob.v1.JobMaterial.Create;
using Connector.HeavyJob.v1.JobMaterial.Update;
using Connector.HeavyJob.v1.JobMaterials;
using Connector.HeavyJob.v1.JobsAdvanced;
using Connector.HeavyJob.v1.JobSubcontract;
using Connector.HeavyJob.v1.JobSubcontract.Create;
using Connector.HeavyJob.v1.JobSubcontract.Update;
using Connector.HeavyJob.v1.JobSubcontracts;
using Connector.HeavyJob.v1.MaterialPurchaseOrderDetails;
using Connector.HeavyJob.v1.MaterialPurchaseOrderDetails.Create;
using Connector.HeavyJob.v1.MaterialPurchaseOrderDetails.Update;
using Connector.HeavyJob.v1.Materials;
using Connector.HeavyJob.v1.Materials.Create;
using Connector.HeavyJob.v1.Materials.Update;
using Connector.HeavyJob.v1.MaterialsInstalled;
using Connector.HeavyJob.v1.MaterialsInstalledQuantities;
using Connector.HeavyJob.v1.MaterialsReceived;
using Connector.HeavyJob.v1.MaterialSubsAndCustomCosts.Update;
using Connector.HeavyJob.v1.MissingTimeCardForemen;
using Connector.HeavyJob.v1.MobileChangeOrdersByBusinessUnit;
using Connector.HeavyJob.v1.NonuseHourTags;
using Connector.HeavyJob.v1.PayClass;
using Connector.HeavyJob.v1.PayClass.Update;
using Connector.HeavyJob.v1.PayItems;
using Connector.HeavyJob.v1.PayItems.Create;
using Connector.HeavyJob.v1.PayItems.Update;
using Connector.HeavyJob.v1.PurchaseOrderItems;
using Connector.HeavyJob.v1.PurchaseOrders.Create;
using Connector.HeavyJob.v1.PurchaseOrders.Update;
using Connector.HeavyJob.v1.QuantityAdjustment.Create;
using Connector.HeavyJob.v1.QuantityAdjustments;
using Connector.HeavyJob.v1.RateSetGroupAccounting;
using Connector.HeavyJob.v1.SetupFilters;
using Connector.HeavyJob.v1.Subcontracts;
using Connector.HeavyJob.v1.Subcontracts.Create;
using Connector.HeavyJob.v1.Subcontracts.Update;
using Connector.HeavyJob.v1.SubcontractTransactions;
using Connector.HeavyJob.v1.SubcontractWorkQuantities;
using Connector.HeavyJob.v1.TimeCard.Update;
using Connector.HeavyJob.v1.TimeCardApproval;
using Connector.HeavyJob.v1.TimeCardInfo;
using Connector.HeavyJob.v1.TimeCardsForEquipment;
using Connector.HeavyJob.v1.User;
using Connector.HeavyJob.v1.UserAccessGroup;
using Connector.HeavyJob.v1.UserAccessGroup.Update;
using Connector.HeavyJob.v1.VendorContractDetails;
using Connector.HeavyJob.v1.VendorContractDetails.Create;
using Connector.HeavyJob.v1.VendorContractDetails.Update;
using Connector.HeavyJob.v1.VendorContractItems;
using Connector.HeavyJob.v1.VendorContracts;
using Connector.HeavyJob.v1.VendorContracts.Create;
using Connector.HeavyJob.v1.VendorContracts.Update;
using Connector.HeavyJob.v1.Vendors.Create;
using Connector.HeavyJob.v1.Vendors.Delete;
using Connector.Safety.v1.AccessGroups;
using Connector.Safety.v1.Alerts;
using Connector.Safety.v1.Alerts.Create;
using Connector.Safety.v1.Alerts.Delete;
using Connector.Safety.v1.Alerts.Update;
using Connector.Safety.v1.Incident;
using Connector.Safety.v1.Incident.Update;
using Connector.Safety.v1.IncidentFormTypes;
using Connector.Safety.v1.Incidents;
using Connector.Safety.v1.IncidentV2;
using Connector.Safety.v1.InspectionTypes;
using Connector.Safety.v1.UserAccessGroups.Update;
using Connector.Safety.v1.Users;
using Connector.Setups.v1.AccountingTemplate;
using Connector.Setups.v1.BulkCostCode;
using Connector.Setups.v1.BusinessUnit.Create;
using Connector.Setups.v1.BusinessUnitDefault;
using Connector.Setups.v1.CostCode;
using Connector.Setups.v1.CostCode.Create;
using Connector.Setups.v1.CostCode.Update;
using Connector.Setups.v1.Job;
using Connector.Setups.v1.Job.Create;
using Connector.Setups.v1.Job.Update;
using Connector.Setups.v1.PayClass.Create;
using Connector.Setups.v1.PayClass.Update;
using Connector.Setups.v1.RateSet;
using Connector.Setups.v1.RateSet.Create;
using Connector.Setups.v1.RateSet.Update;
using Connector.Setups.v1.RateSetCostAdjustment;
using Connector.Setups.v1.RateSetCostAdjustment.Create;
using Connector.Setups.v1.RateSetCostAdjustment.Update;
using Connector.Setups.v1.RateSetEquipment;
using Connector.Setups.v1.RateSetEquipment.Create;
using Connector.Setups.v1.RateSetEquipment.Update;
using Connector.Setups.v1.RateSetGroup;
using Connector.Setups.v1.RateSetGroup.Create;
using Connector.Setups.v1.RateSetGroup.Update;
using Connector.Setups.v1.RateSetPayClass;
using Connector.Setups.v1.RateSetPayClass.Create;
using Connector.Setups.v1.RateSetPayClass.Update;
using Connector.Skills.v1.EmployeeSkillImport;
using Connector.Skills.v1.EmployeeSkills;
using Connector.Skills.v1.EmployeeSkills.Create;
using Connector.Skills.v1.EmployeeSkillsByEmployee;
using Connector.Skills.v1.EmployeeSkillsBySkill;
using Connector.Skills.v1.Skill;
using Connector.Skills.v1.Skill.Create;
using Connector.Skills.v1.Skill.Update;
using Connector.Skills.v1.Skills;
using Connector.Skills.v1.Skillsimport.Create;
using Connector.Skills.v1.Skillsimport;

namespace Connector.Client;

/// <summary>
/// A client for interfacing with the API via the HTTP protocol.
/// </summary>
public class ApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient (HttpClient httpClient, string baseUrl)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new System.Uri(baseUrl);
    }

    private async Task<ApiResponse<T>> CreateApiResponseAsync<T>(HttpResponseMessage response)
    {
        return new ApiResponse<T>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<T>(cancellationToken: default) 
                : default,
            RawResult = await response.Content.ReadAsStreamAsync()
        };
    }

    // Example of a paginated response.
    public async Task<ApiResponse<PaginatedResponse<T>>> GetRecords<T>(string relativeUrl, int page, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync($"{relativeUrl}?page={page}", cancellationToken: cancellationToken).ConfigureAwait(false);
        return new ApiResponse<PaginatedResponse<T>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<PaginatedResponse<T>>(cancellationToken: cancellationToken) : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }

    public async Task<ApiResponse> GetNoContent(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient
            .GetAsync("no-content", cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken: cancellationToken)
        };
    }

    public async Task<ApiResponse> TestConnection(CancellationToken cancellationToken = default)
    {
        // The purpose of this method is to validate that successful and authorized requests can be made to the API.
        // In this example, we are using the GET "oauth/me" endpoint.
        // Choose any endpoint that you consider suitable for testing the connection with the API.

        var response = await _httpClient
            .GetAsync($"oauth/me", cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
        };
    }

    /// <summary>
    /// Retrieves metadata for a specific file
    /// </summary>
    /// <param name="fileId">The unique identifier of the file</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>API response containing file metadata</returns>
    public async Task<ApiResponse<FileDataObject>> GetFileMetadata(
        Guid fileId,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient
            .GetAsync($"attachments/api/v1/Files/{fileId}", cancellationToken)
            .ConfigureAwait(false);

        return new ApiResponse<FileDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<FileDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<Guid>> CreateFile(
        byte[] fileData,
        string fileName,
        Guid businessUnitId,
        Guid jobId,
        CancellationToken cancellationToken = default)
    {
        using var content = new MultipartFormDataContent();
        using var fileContent = new ByteArrayContent(fileData);
        content.Add(fileContent, "File", fileName);
        content.Add(new StringContent(businessUnitId.ToString()), "BusinessUnitId");
        content.Add(new StringContent(jobId.ToString()), "JobId");

        var response = await _httpClient
            .PostAsync("attachments/api/v1/Files", content, cancellationToken)
            .ConfigureAwait(false);

        return new ApiResponse<Guid>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<Guid>(cancellationToken: cancellationToken) 
                : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<ContactDataObject>> GetContact(
        Guid contactId,
        Guid? businessUnitId = null,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, $"contacts/api/v1/contacts/{contactId}");
        
        if (businessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", businessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<ContactDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<ContactDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<Guid>> CreateContact(
        CreateContactActionInput input,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "contacts/api/v1/contacts")
        {
            Content = JsonContent.Create(input)
        };

        if (input.BusinessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", input.BusinessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<Guid>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<Guid>(cancellationToken: cancellationToken) 
                : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse> DeleteContact(
        Guid contactId,
        Guid? businessUnitId = null,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Delete, $"contacts/api/v1/contacts/{contactId}");
        
        if (businessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", businessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<ContactDataObject>> UpdateContact(
        UpdateContactActionInput input,
        CancellationToken cancellationToken = default)
    {
        var queryString = $"?vendorId={input.VendorId}";
        if (input.MoveVendorContact.HasValue)
        {
            queryString += $"&moveVendorContact={input.MoveVendorContact.Value}";
        }

        using var request = new HttpRequestMessage(HttpMethod.Put, $"contacts/api/v1/contacts/{input.ContactId}{queryString}")
        {
            Content = JsonContent.Create(input)
        };

        if (input.BusinessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", input.BusinessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<ContactDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<ContactDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<ContactProductsDataObject>>> GetContactProducts(
        Guid contactId,
        Guid? businessUnitId = null,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, $"contacts/api/v1/products/{contactId}/products");
        
        if (businessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", businessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<IEnumerable<ContactProductsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<ContactProductsDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<Guid>> CreateContactProduct(
        CreateContactProductsActionInput input,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, $"contacts/api/v1/products/{input.ContactId}/products")
        {
            Content = JsonContent.Create(input)
        };

        if (input.BusinessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", input.BusinessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<Guid>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<Guid>(cancellationToken: cancellationToken) 
                : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse> DeleteContactProduct(
        DeleteContactProductsActionInput input,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Delete, $"contacts/api/v1/products/{input.ContactId}/products")
        {
            Content = JsonContent.Create(input, mediaType: new("application/json-patch+json"))
        };

        if (input.BusinessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", input.BusinessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<ContactsDataObject>>> GetContacts(
        Guid vendorId,
        Guid? businessUnitId = null,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, $"contacts/api/v1/contacts?vendorId={vendorId}");
        
        if (businessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", businessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<IEnumerable<ContactsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<ContactsDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<OfficeDataObject>> GetOffice(
        Guid officeId,
        Guid? businessUnitId = null,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, $"contacts/api/v1/offices/{officeId}");
        
        if (businessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", businessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<OfficeDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<OfficeDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<Guid>> CreateOffice(
        CreateOfficeActionInput input,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "contacts/api/v1/offices")
        {
            Content = JsonContent.Create(input, mediaType: new("application/json-patch+json"))
        };

        if (input.BusinessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", input.BusinessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<Guid>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<Guid>(cancellationToken: cancellationToken) 
                : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse> DeleteOffice(
        DeleteOfficeActionInput input,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Delete, $"contacts/api/v1/offices/{input.OfficeId}");

        if (input.BusinessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", input.BusinessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<OfficeDataObject>> UpdateOffice(
        UpdateOfficeActionInput input,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Put, $"contacts/api/v1/offices/{input.Id}")
        {
            Content = JsonContent.Create(input)
        };

        if (input.BusinessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", input.BusinessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<OfficeDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<OfficeDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<OfficesDataObject>>> GetOffices(
        Guid vendorId,
        Guid? businessUnitId = null,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, $"contacts/api/v1/offices?vendorId={vendorId}");
        
        if (businessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", businessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<IEnumerable<OfficesDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<OfficesDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<ProductContactsDataObject>>> GetProductContacts(
        Guid productTypeId,
        Guid? businessUnitId = null,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, $"contacts/api/v1/products/{productTypeId}/contacts");
        
        if (businessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", businessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<IEnumerable<ProductContactsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<ProductContactsDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<ProductsDataObject>>> GetProducts(
        Guid? businessUnitId = null,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, "contacts/api/v1/products");
        
        if (businessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", businessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<IEnumerable<ProductsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<ProductsDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<ProductTypeDataObject>> GetProductType(
        Guid productTypeId,
        Guid? businessUnitId = null,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, $"contacts/api/v1/producttypes/{productTypeId}");
        
        if (businessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", businessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<ProductTypeDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<ProductTypeDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<Guid>> CreateProductType(
        CreateProductTypeActionInput input,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "contacts/api/v1/producttypes")
        {
            Content = JsonContent.Create(new { input.Code, input.Description })
        };

        if (input.BusinessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", input.BusinessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<Guid>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<Guid>(cancellationToken: cancellationToken) 
                : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse> DeleteProductType(
        DeleteProductTypeActionInput input,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Delete, $"contacts/api/v1/producttypes/{input.ProductTypeId}");
        
        if (input.BusinessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", input.BusinessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<ProductTypeDataObject>> UpdateProductType(
        UpdateProductTypeActionInput input,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Put, $"contacts/api/v1/producttypes/{input.Id}")
        {
            Content = JsonContent.Create(new { input.Id, input.Code, input.Description })
        };

        if (input.BusinessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", input.BusinessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<ProductTypeDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<ProductTypeDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<ProductVendorsDataObject>>> GetProductVendors(
        Guid productTypeId,
        Guid? businessUnitId = null,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, $"contacts/api/v1/products/{productTypeId}/vendors");
        
        if (businessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", businessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<IEnumerable<ProductVendorsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<ProductVendorsDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<VendorDataObject>> GetVendor(
        Guid vendorId,
        Guid? businessUnitId = null,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, $"contacts/api/v1/vendors/{vendorId}");
        
        if (businessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", businessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<VendorDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<VendorDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<Guid>> CreateVendor(
        CreateVendorActionInput input,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "contacts/api/v1/vendors")
        {
            Content = JsonContent.Create(new
            {
                input.Code,
                input.Name,
                input.TypeId,
                input.RegionId,
                input.CommunicationMethod,
                input.WebAddress,
                input.IsBonded,
                input.BondRate,
                input.Note,
                input.IsUnion,
                input.ExperienceModificationRating,
                input.Rating,
                input.AccountingCode
            })
        };

        if (input.BusinessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", input.BusinessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<Guid>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<Guid>(cancellationToken: cancellationToken) 
                : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse> DeleteVendor(
        DeleteVendorActionInput input,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Delete, $"contacts/api/v1/vendors/{input.VendorId}");
        
        if (input.BusinessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", input.BusinessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<VendorDataObject>> UpdateVendor(
        UpdateVendorActionInput input,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Put, $"contacts/api/v1/vendors/{input.Id}")
        {
            Content = JsonContent.Create(new
            {
                input.Id,
                input.Code,
                input.Name,
                input.TypeId,
                input.RegionId,
                input.CommunicationMethod,
                input.WebAddress,
                input.IsBonded,
                input.BondRate,
                input.Note,
                input.IsUnion,
                input.ExperienceModificationRating,
                input.Rating,
                input.AccountingCode
            })
        };

        if (input.BusinessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", input.BusinessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<VendorDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<VendorDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<VendorProductsDataObject>>> GetVendorProducts(
        Guid vendorId,
        Guid? businessUnitId = null,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, $"contacts/api/v1/vendors/{vendorId}/products");
        
        if (businessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", businessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<IEnumerable<VendorProductsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<VendorProductsDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<Guid>> CreateVendorProduct(
        CreateVendorProductsActionInput input,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, $"contacts/api/v1/vendors/{input.VendorId}/products")
        {
            Content = JsonContent.Create(new
            {
                input.VendorId,
                input.ProductTypeId,
                input.RegionId,
                input.Date
            })
        };

        if (input.BusinessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", input.BusinessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<Guid>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<Guid>(cancellationToken: cancellationToken) 
                : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<Contacts.v1.Vendors.VendorsDataObject>>> GetVendors(
        Guid? businessUnitId = null,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, "contacts/api/v1/vendors");
        
        if (businessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", businessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<IEnumerable<Contacts.v1.Vendors.VendorsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<Contacts.v1.Vendors.VendorsDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<Equipment360PaginatedResponse<AllEquipmentDataObject>>> GetEquipment(
        Guid? businessUnitId = null,
        string? equipmentCode = null,
        string? accountingCode = null,
        string? status = null,
        int? count = null,
        int? cursor = null,
        bool? includeDeleted = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (businessUnitId.HasValue)
            queryParams.Add($"businessUnitId={businessUnitId}");
        if (!string.IsNullOrEmpty(equipmentCode))
            queryParams.Add($"equipmentCode={Uri.EscapeDataString(equipmentCode)}");
        if (!string.IsNullOrEmpty(accountingCode))
            queryParams.Add($"accountingCode={Uri.EscapeDataString(accountingCode)}");
        if (!string.IsNullOrEmpty(status))
            queryParams.Add($"status={Uri.EscapeDataString(status)}");
        if (count.HasValue)
            queryParams.Add($"count={count}");
        if (cursor.HasValue)
            queryParams.Add($"cursor={cursor}");
        if (includeDeleted.HasValue)
            queryParams.Add($"includeDeleted={includeDeleted.Value.ToString().ToLower()}");

        var url = "e360/api/v1/equipment";
        if (queryParams.Any())
        {
            url += "?" + string.Join("&", queryParams);
        }

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<Equipment360PaginatedResponse<AllEquipmentDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<Equipment360PaginatedResponse<AllEquipmentDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<Connector.Equipment360.v1.BusinessUnit.BusinessUnitDataObject>>> GetBusinessUnits(
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync("e360/api/v1/businessUnits", cancellationToken);

        return new ApiResponse<IEnumerable<Connector.Equipment360.v1.BusinessUnit.BusinessUnitDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<Connector.Equipment360.v1.BusinessUnit.BusinessUnitDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<CustomFieldDataObject>>> GetCustomFields(
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync("e360/api/v1/customField", cancellationToken);

        return new ApiResponse<IEnumerable<CustomFieldDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<CustomFieldDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CustomFieldDataObject>> CreateCustomField(
        CreateCustomFieldActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync(
            "e360/api/v1/customField",
            JsonContent.Create(new
            {
                customFieldCategoryId = input.CustomFieldCategoryId,
                entityGuid = input.EntityGuid,
                value = input.Value
            }),
            cancellationToken);

        return new ApiResponse<CustomFieldDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CustomFieldDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<CustomFieldCategoriesDataObject>>> GetCustomFieldCategories(
        string? categoryType = null,
        CancellationToken cancellationToken = default)
    {
        var url = "e360/api/v1/customFieldCategories";
        if (!string.IsNullOrEmpty(categoryType))
        {
            url += $"?categoryType={Uri.EscapeDataString(categoryType)}";
        }

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<CustomFieldCategoriesDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<CustomFieldCategoriesDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<CustomFieldListDataObject>>> GetCustomFieldList(
        int? categoryId = null,
        CancellationToken cancellationToken = default)
    {
        var url = "e360/api/v1/customFieldList";
        if (categoryId.HasValue)
        {
            url += $"?categoryId={categoryId.Value}";
        }

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<CustomFieldListDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<CustomFieldListDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<Connector.Equipment360.v1.Employees.EmployeesDataObject>>> GetEmployees(
        Guid? businessUnitId = null,
        int? employeeId = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (businessUnitId.HasValue)
            queryParams.Add($"businessUnitId={businessUnitId}");
        if (employeeId.HasValue)
            queryParams.Add($"employeeId={employeeId}");

        var url = "e360/api/v1/employees";
        if (queryParams.Any())
        {
            url += "?" + string.Join("&", queryParams);
        }

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<Connector.Equipment360.v1.Employees.EmployeesDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<Connector.Equipment360.v1.Employees.EmployeesDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<EmployeeDataObject>> CreateEmployee(
        CreateEmployeeActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync(
            "e360/api/v1/employees",
            JsonContent.Create(new
            {
                businessUnitId = input.BusinessUnitId,
                code = input.Code,
                firstName = input.FirstName,
                lastName = input.LastName,
                types = input.Types,
                payclass = input.Payclass,
                address = input.Address,
                hireDate = input.HireDate,
                mobilePhone = input.MobilePhone,
                homePhone = input.HomePhone,
                officePhone = input.OfficePhone,
                homeEmail = input.HomeEmail,
                officeEmail = input.OfficeEmail,
                region = input.Region,
                division = input.Division,
                accountingCode = input.AccountingCode,
                onLoanBusinessUnitId = input.OnLoanBusinessUnitId
            }),
            cancellationToken);

        return new ApiResponse<EmployeeDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<EmployeeDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<EmployeeDataObject>> UpdateEmployee(
        UpdateEmployeeActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsync(
            $"e360/api/v1/employees/{input.Id}",
            JsonContent.Create(new
            {
                code = input.Code,
                firstName = input.FirstName,
                lastName = input.LastName,
                types = input.Types,
                payclass = input.Payclass,
                address = input.Address,
                hireDate = input.HireDate,
                mobilePhone = input.MobilePhone,
                homePhone = input.HomePhone,
                officePhone = input.OfficePhone,
                homeEmail = input.HomeEmail,
                officeEmail = input.OfficeEmail,
                region = input.Region,
                division = input.Division,
                accountingCode = input.AccountingCode,
                onLoanBusinessUnitId = input.OnLoanBusinessUnitId
            }),
            cancellationToken);

        return new ApiResponse<EmployeeDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<EmployeeDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<EmployeeDataObject>> GetEmployee(
        Guid contactId,
        Guid? businessUnitId = null,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, $"e360/api/v1/employees/{contactId}");
        
        if (businessUnitId.HasValue)
        {
            request.Headers.Add("BusinessUnitId", businessUnitId.Value.ToString());
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<EmployeeDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<EmployeeDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<EquipmentDataObject>> GetEquipmentById(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync($"e360/api/v1/equipment/{id}", cancellationToken);

        return new ApiResponse<EquipmentDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<EquipmentDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<EquipmentDataObject>> CreateEquipment(
        Connector.Equipment360.v1.Equipment.Create.CreateEquipmentActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync(
            "e360/api/v1/equipment",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<EquipmentDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<EquipmentDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<EquipmentDataObject>> UpdateEquipment(
        Guid id,
        Connector.Equipment360.v1.Equipment.Update.UpdateEquipmentActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsync(
            $"e360/api/v1/equipment/{id}",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<EquipmentDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<EquipmentDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<EquipmentTransferDataObject>>> GetEquipmentTransfers(
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync("e360/api/v1/equipmentTransfer", cancellationToken);

        return new ApiResponse<IEnumerable<EquipmentTransferDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<EquipmentTransferDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<EquipmentTransferDataObject>> CreateEquipmentTransfer(
        CreateEquipmentTransferActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync(
            "e360/api/v1/equipmentTransfer",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<EquipmentTransferDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<EquipmentTransferDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<Connector.Equipment360.v1.EquipmentType.EquipmentTypeDataObject>>> GetEquipment360Types(
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync("e360/api/v1/equipmentType", cancellationToken);

        return new ApiResponse<IEnumerable<Connector.Equipment360.v1.EquipmentType.EquipmentTypeDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<Connector.Equipment360.v1.EquipmentType.EquipmentTypeDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<Connector.Equipment360.v1.EquipmentType.EquipmentTypeDataObject>> CreateEquipmentType(
        Connector.Equipment360.v1.EquipmentType.Create.CreateEquipmentTypeActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync(
            "e360/api/v1/equipmentType",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<Connector.Equipment360.v1.EquipmentType.EquipmentTypeDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<Connector.Equipment360.v1.EquipmentType.EquipmentTypeDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<FuelCostsDataObject>>> GetFuelCosts(
        CancellationToken cancellationToken = default,
        DateTime? startDate = null,
        DateTime? endDate = null,
        string? jobCode = null,
        Guid? businessUnitId = null)
    {
        var queryParams = new List<string>();
        if (startDate.HasValue)
            queryParams.Add($"startDate={Uri.EscapeDataString(startDate.Value.ToString("O"))}");
        if (endDate.HasValue)
            queryParams.Add($"endDate={Uri.EscapeDataString(endDate.Value.ToString("O"))}");
        if (!string.IsNullOrEmpty(jobCode))
            queryParams.Add($"jobCode={Uri.EscapeDataString(jobCode)}");
        if (businessUnitId.HasValue)
            queryParams.Add($"businessUnitId={businessUnitId}");

        var url = "e360/api/v1/costs/fuel";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<FuelCostsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<FuelCostsDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<InvoiceDataObject>>> GetInvoices(
        CancellationToken cancellationToken = default,
        DateTime? receivalDate = null,
        DateTime? modifiedDateTime = null,
        string? invoiceStatus = null,
        string? invoiceNumber = null,
        string? referenceNumber = null)
    {
        var queryParams = new List<string>();
        if (receivalDate.HasValue)
            queryParams.Add($"receivalDate={Uri.EscapeDataString(receivalDate.Value.ToString("O"))}");
        if (modifiedDateTime.HasValue)
            queryParams.Add($"modifiedDateTime={Uri.EscapeDataString(modifiedDateTime.Value.ToString("O"))}");
        if (!string.IsNullOrEmpty(invoiceStatus))
            queryParams.Add($"invoiceStatus={Uri.EscapeDataString(invoiceStatus)}");
        if (!string.IsNullOrEmpty(invoiceNumber))
            queryParams.Add($"invoiceNumber={Uri.EscapeDataString(invoiceNumber)}");
        if (!string.IsNullOrEmpty(referenceNumber))
            queryParams.Add($"referenceNumber={Uri.EscapeDataString(referenceNumber)}");

        var url = "e360/api/v1/invoice";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<InvoiceDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<InvoiceDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<InvoiceDataObject>> CreateInvoice(
        CreateInvoiceActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync(
            "e360/api/v1/invoice",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<InvoiceDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<InvoiceDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<InvoiceDataObject>> UpdateInvoice(
        UpdateInvoiceActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsync(
            "e360/api/v1/invoice",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<InvoiceDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<InvoiceDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<JobsDataObject>>> GetJobs(
        Guid? businessUnitId = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (businessUnitId.HasValue)
            queryParams.Add($"businessUnitId={businessUnitId}");

        var url = "e360/api/v1/jobs";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<JobsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<JobsDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<JobsDataObject>> CreateJob(
        CreateJobsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync(
            "e360/api/v1/jobs",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<JobsDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<JobsDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<JobsDataObject>> UpdateJob(
        Guid id,
        UpdateJobsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsync(
            $"e360/api/v1/jobs/{id}",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<JobsDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<JobsDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<LocationsDataObject>>> GetLocations(
        Guid? businessUnitId = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (businessUnitId.HasValue)
            queryParams.Add($"businessUnitId={businessUnitId}");

        var url = "e360/api/v1/locations";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<LocationsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<LocationsDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<LocationsDataObject>> CreateLocation(
        CreateLocationsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync(
            "e360/api/v1/locations",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<LocationsDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<LocationsDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<LocationsDataObject>> UpdateLocation(
        Guid id,
        UpdateLocationsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsync(
            $"e360/api/v1/locations/{id}",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<LocationsDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<LocationsDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<Equipment360PaginatedResponse<MaintenanceRequestDataObject>>> GetMaintenanceRequests(
        string? equipmentCode = null,
        Guid? businessUnitId = null,
        string? businessUnitCode = null,
        DateTime? changesSinceDate = null,
        int? count = null,
        int? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (!string.IsNullOrEmpty(equipmentCode))
            queryParams.Add($"equipmentCode={Uri.EscapeDataString(equipmentCode)}");
        if (businessUnitId.HasValue)
            queryParams.Add($"businessUnitId={businessUnitId}");
        if (!string.IsNullOrEmpty(businessUnitCode))
            queryParams.Add($"businessUnitCode={Uri.EscapeDataString(businessUnitCode)}");
        if (changesSinceDate.HasValue)
            queryParams.Add($"changesSinceDate={Uri.EscapeDataString(changesSinceDate.Value.ToString("O"))}");
        if (count.HasValue)
            queryParams.Add($"count={count}");
        if (cursor.HasValue)
            queryParams.Add($"cursor={cursor}");

        var url = "e360/api/v1/maintenanceRequest";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<Equipment360PaginatedResponse<MaintenanceRequestDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<Equipment360PaginatedResponse<MaintenanceRequestDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<MaintenanceRequestDataObject>> CreateMaintenanceRequest(
        CreateMaintenanceRequestActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync(
            "e360/api/v1/maintenanceRequest",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<MaintenanceRequestDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<MaintenanceRequestDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<MeterReadingDataObject>>> GetMeterReadings(
        Guid? businessUnitId = null,
        string? equipmentCode = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (businessUnitId.HasValue)
            queryParams.Add($"businessUnitId={businessUnitId}");
        if (!string.IsNullOrEmpty(equipmentCode))
            queryParams.Add($"equipmentCode={Uri.EscapeDataString(equipmentCode)}");

        var url = "e360/api/v1/meterReading";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<MeterReadingDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<MeterReadingDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CreateMeterReadingActionOutput>> CreateMeterReading(
        CreateMeterReadingActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync(
            "e360/api/v1/meterReading",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<CreateMeterReadingActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CreateMeterReadingActionOutput>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<PartCostEntriesDataObject>> CreatePartCostEntryDetail(
        Guid partCostEntryId,
        CreatePartCostEntriesActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync(
            $"e360/api/v1/partCostEntries/{partCostEntryId}/details",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<PartCostEntriesDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<PartCostEntriesDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<PartCostEntryDataObject>> CreatePartCostEntry(
        CreatePartCostEntryActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync(
            "e360/api/v1/partCostEntry",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<PartCostEntryDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<PartCostEntryDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<Equipment360PaginatedResponse<PartInventoryDataObject>>> GetPartInventory(
        Guid businessUnitId,
        string partNum,
        string? partLocationCode = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>
        {
            $"businessUnitId={businessUnitId}",
            $"partNum={Uri.EscapeDataString(partNum)}"
        };
        if (!string.IsNullOrEmpty(partLocationCode))
            queryParams.Add($"partLocationCode={Uri.EscapeDataString(partLocationCode)}");

        var url = "e360/api/v1/partInventory";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<Equipment360PaginatedResponse<PartInventoryDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<Equipment360PaginatedResponse<PartInventoryDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<Equipment360PaginatedResponse<PartInventoryDataObject>>> CreatePartInventory(
        CreatePartInventoryActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync(
            "e360/api/v1/partInventory",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<Equipment360PaginatedResponse<PartInventoryDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<Equipment360PaginatedResponse<PartInventoryDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<PartLocationsDataObject>>> GetPartLocations(
        Guid? businessUnitId = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (businessUnitId.HasValue)
            queryParams.Add($"businessUnitId={businessUnitId}");

        var url = "e360/api/v1/partLocations";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<PartLocationsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<PartLocationsDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<PartsDataObject>>> GetParts(
        string? partNumber = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (!string.IsNullOrEmpty(partNumber))
            queryParams.Add($"partNumber={Uri.EscapeDataString(partNumber)}");

        var url = "e360/api/v1/parts";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<PartsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<PartsDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<PartsDataObject>> UpdatePart(
        Guid id,
        UpdatePartsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsync(
            $"e360/api/v1/parts/{id}",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<PartsDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<PartsDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<PurchaseOrderDataObject>>> GetPurchaseOrderDetails(
        Guid purchaseOrderId,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(
            $"e360/api/v1/purchaseOrders/{purchaseOrderId}/details",
            cancellationToken);

        return new ApiResponse<IEnumerable<PurchaseOrderDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<PurchaseOrderDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<PurchaseOrdersDataObject>>> GetPurchaseOrders(
        string? approvalStatus = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (!string.IsNullOrEmpty(approvalStatus))
            queryParams.Add($"approvalStatus={Uri.EscapeDataString(approvalStatus)}");

        var url = "e360/api/v1/purchaseOrders";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<PurchaseOrdersDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<PurchaseOrdersDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CreatePurchaseOrderResponse>> CreatePurchaseOrder(
        CreatePurchaseOrderActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync(
            "e360/api/v1/purchaseOrder",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<CreatePurchaseOrderResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CreatePurchaseOrderResponse>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<PurchaseOrderDetailsDataObject>> CreatePurchaseOrderDetail(
        Guid purchaseOrderId,
        CreatePurchaseOrderDetailsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync(
            $"e360/api/v1/purchaseOrders/{purchaseOrderId}/details",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<PurchaseOrderDetailsDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<PurchaseOrderDetailsDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<PurchaseOrderNotesDataObject>> CreatePurchaseOrderNote(
        Guid purchaseOrderId,
        CreatePurchaseOrderNotesActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync(
            $"e360/api/v1/purchaseOrders/{purchaseOrderId}/notes",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<PurchaseOrderNotesDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<PurchaseOrderNotesDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<SubletVendorCostEntriesDataObject>> CreateSubletVendorCostEntryDetail(
        Guid subletVendorCostEntryId,
        CreateSubletVendorCostEntriesActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync(
            $"e360/api/v1/subletVendorCostEntries/{subletVendorCostEntryId}/details",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<SubletVendorCostEntriesDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<SubletVendorCostEntriesDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }
    public async Task<ApiResponse<SubletVendorCostEntryDataObject>> CreateSubletVendorCostEntry(
        CreateSubletVendorCostEntryActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync(
            "e360/api/v1/subletVendorCostEntry",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<SubletVendorCostEntryDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<SubletVendorCostEntryDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<TagsDataObject>>> GetTags(
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(
            "e360/api/v1/tags",
            cancellationToken);

        return new ApiResponse<IEnumerable<TagsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<TagsDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<PaginatedResponse<TimeCardDataObject>>> GetTimeCards(
        string? status = null,
        int? count = null,
        int? cursor = null,
        DateTime? beginDate = null,
        DateTime? endDate = null,
        Guid? mechanicId = null,
        bool? includeShiftDetails = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (!string.IsNullOrEmpty(status))
            queryParams.Add($"status={Uri.EscapeDataString(status)}");
        if (count.HasValue)
            queryParams.Add($"count={count}");
        if (cursor.HasValue)
            queryParams.Add($"cursor={cursor}");
        if (beginDate.HasValue)
            queryParams.Add($"beginDate={Uri.EscapeDataString(beginDate.Value.ToString("O"))}");
        if (endDate.HasValue)
            queryParams.Add($"endDate={Uri.EscapeDataString(endDate.Value.ToString("O"))}");
        if (mechanicId.HasValue)
            queryParams.Add($"mechanicId={mechanicId}");
        if (includeShiftDetails.HasValue)
            queryParams.Add($"includeShiftDetails={includeShiftDetails.Value.ToString().ToLower()}");

        var url = "e360/api/v1/timeCards";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<PaginatedResponse<TimeCardDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<PaginatedResponse<TimeCardDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<UnitOfMeasureDataObject>>> GetUnitOfMeasures(
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(
            "e360/api/v1/unitOfMeasure",
            cancellationToken);

        return new ApiResponse<IEnumerable<UnitOfMeasureDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<UnitOfMeasureDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<Connector.Equipment360.v1.Vendors.VendorsDataObject>>> GetEquipment360Vendors(
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(
            "e360/api/v1/vendors",
            cancellationToken);

        return new ApiResponse<IEnumerable<Connector.Equipment360.v1.Vendors.VendorsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<Connector.Equipment360.v1.Vendors.VendorsDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<Connector.Equipment360.v1.Vendors.VendorsDataObject>> CreateEquipment360Vendor(
        Connector.Equipment360.v1.Vendors.Create.CreateVendorsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync(
            "e360/api/v1/vendors",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<Connector.Equipment360.v1.Vendors.VendorsDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<Connector.Equipment360.v1.Vendors.VendorsDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<Connector.Equipment360.v1.Vendors.VendorsDataObject>> UpdateEquipment360Vendor(
        Guid id,
        UpdateVendorsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsync(
            $"e360/api/v1/vendors/{id}",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<Connector.Equipment360.v1.Vendors.VendorsDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<Connector.Equipment360.v1.Vendors.VendorsDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<PaginatedResponse<WorkOrderDataObject>>> GetWorkOrders(
        string? status = null,
        int? count = null,
        int? cursor = null,
        string? sortBy = null,
        string? sortOrder = null,
        string? equipmentCode = null,
        bool? isPreventiveMaintenance = null,
        bool? includeNotes = null,
        Guid? businessUnitId = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (!string.IsNullOrEmpty(status))
            queryParams.Add($"status={Uri.EscapeDataString(status)}");
        if (count.HasValue)
            queryParams.Add($"count={count}");
        if (cursor.HasValue)
            queryParams.Add($"cursor={cursor}");
        if (!string.IsNullOrEmpty(sortBy))
            queryParams.Add($"sortBy={Uri.EscapeDataString(sortBy)}");
        if (!string.IsNullOrEmpty(sortOrder))
            queryParams.Add($"sortOrder={Uri.EscapeDataString(sortOrder)}");
        if (!string.IsNullOrEmpty(equipmentCode))
            queryParams.Add($"equipmentCode={Uri.EscapeDataString(equipmentCode)}");
        if (isPreventiveMaintenance.HasValue)
            queryParams.Add($"isPreventiveMaintenance={isPreventiveMaintenance.Value.ToString().ToLower()}");
        if (includeNotes.HasValue)
            queryParams.Add($"includeNotes={includeNotes.Value.ToString().ToLower()}");
        if (businessUnitId.HasValue)
            queryParams.Add($"businessUnitId={businessUnitId}");

        var url = "e360/api/v1/workOrders";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<PaginatedResponse<WorkOrderDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<PaginatedResponse<WorkOrderDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<WorkOrderDataObject>> CreateWorkOrder(
        CreateWorkOrderActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "e360/api/v1/workOrders";
        if (input.BusinessUnitId.HasValue)
        {
            url += $"?businessUnitId={input.BusinessUnitId}";
        }

        var response = await _httpClient.PostAsync(
            url,
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<WorkOrderDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<WorkOrderDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<WorkOrderDataObject>> UpdateWorkOrder(
        Guid id,
        UpdateWorkOrderActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsync(
            $"e360/api/v1/workOrder/{id}",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<WorkOrderDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<WorkOrderDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<WorkOrderCostsDataObject>> GetWorkOrderCosts(
        Guid businessUnitId,
        string? jobCode = null,
        Guid? equipmentId = null,
        string? tag = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>
        {
            $"businessUnitId={businessUnitId}"
        };
        
        if (!string.IsNullOrEmpty(jobCode))
            queryParams.Add($"jobCode={Uri.EscapeDataString(jobCode)}");
        if (equipmentId.HasValue)
            queryParams.Add($"equipmentId={equipmentId}");
        if (!string.IsNullOrEmpty(tag))
            queryParams.Add($"tag={Uri.EscapeDataString(tag)}");

        var url = "e360/api/v1/costs/workOrders";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<WorkOrderCostsDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<WorkOrderCostsDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<PaginatedResponse<WorkOrderCostsDetailsDataObject>>> GetWorkOrderCostsDetails(
        Guid businessUnitId,
        string? jobCode = null,
        Guid? equipmentId = null,
        string? tag = null,
        int? count = null,
        int? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>
        {
            $"businessUnitId={businessUnitId}"
        };
        
        if (!string.IsNullOrEmpty(jobCode))
            queryParams.Add($"jobCode={Uri.EscapeDataString(jobCode)}");
        if (equipmentId.HasValue)
            queryParams.Add($"equipmentId={equipmentId}");
        if (!string.IsNullOrEmpty(tag))
            queryParams.Add($"tag={Uri.EscapeDataString(tag)}");
        if (count.HasValue)
            queryParams.Add($"count={count}");
        if (cursor.HasValue)
            queryParams.Add($"cursor={cursor}");

        var url = "e360/api/v1/costs/workOrdersExtended";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<PaginatedResponse<WorkOrderCostsDetailsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<PaginatedResponse<WorkOrderCostsDetailsDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<WorkOrderNotesDataObject>> CreateWorkOrderNote(
        Guid workOrderId,
        CreateWorkOrderNotesActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync(
            $"e360/api/v1/workOrders/{workOrderId}/notes",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<WorkOrderNotesDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<WorkOrderNotesDataObject>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<PaginatedResponse<WorkOrderPurchaseDataObject>>> GetWorkOrderPurchases(
        int? workOrderNumber = null,
        int? count = null,
        int? cursor = null,
        DateTime? minModifiedTimestamp = null,
        DateTime? minPurchaseDate = null,
        bool? isReconciled = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (workOrderNumber.HasValue)
            queryParams.Add($"workOrderNumber={workOrderNumber}");
        if (count.HasValue)
            queryParams.Add($"count={count}");
        if (cursor.HasValue)
            queryParams.Add($"cursor={cursor}");
        if (minModifiedTimestamp.HasValue)
            queryParams.Add($"minModifiedTimestamp={Uri.EscapeDataString(minModifiedTimestamp.Value.ToString("O"))}");
        if (minPurchaseDate.HasValue)
            queryParams.Add($"minPurchaseDate={Uri.EscapeDataString(minPurchaseDate.Value.ToString("O"))}");
        if (isReconciled.HasValue)
            queryParams.Add($"isReconciled={isReconciled.Value.ToString().ToLower()}");

        var url = "e360/api/v1/workOrderPurchases";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<PaginatedResponse<WorkOrderPurchaseDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<PaginatedResponse<WorkOrderPurchaseDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<PaginatedResponse<WorkOrdersDataObject>>> GetWorkOrdersList(
        string? status = null,
        int? count = null,
        int? cursor = null,
        string? sortBy = null,
        string? sortOrder = null,
        string? equipmentCode = null,
        bool? isPreventiveMaintenance = null,
        bool? includeNotes = null,
        Guid? businessUnitId = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (!string.IsNullOrEmpty(status))
            queryParams.Add($"status={Uri.EscapeDataString(status)}");
        if (count.HasValue)
            queryParams.Add($"count={count}");
        if (cursor.HasValue)
            queryParams.Add($"cursor={cursor}");
        if (!string.IsNullOrEmpty(sortBy))
            queryParams.Add($"sortBy={Uri.EscapeDataString(sortBy)}");
        if (!string.IsNullOrEmpty(sortOrder))
            queryParams.Add($"sortOrder={Uri.EscapeDataString(sortOrder)}");
        if (!string.IsNullOrEmpty(equipmentCode))
            queryParams.Add($"equipmentCode={Uri.EscapeDataString(equipmentCode)}");
        if (isPreventiveMaintenance.HasValue)
            queryParams.Add($"isPreventiveMaintenance={isPreventiveMaintenance.Value.ToString().ToLower()}");
        if (includeNotes.HasValue)
            queryParams.Add($"includeNotes={includeNotes.Value.ToString().ToLower()}");
        if (businessUnitId.HasValue)
            queryParams.Add($"businessUnitId={businessUnitId}");

        var url = "e360/api/v1/workOrders";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<PaginatedResponse<WorkOrdersDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<PaginatedResponse<WorkOrdersDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<PaginatedResponse<WorkOrderScheduleDataObject>>> GetWorkOrderSchedules(
        int? count = null,
        int? cursor = null,
        int? workOrderNumber = null,
        Guid? mechanicId = null,
        Guid? subletVendorId = null,
        DateTime? minimumScheduledDate = null,
        DateTime? maximumScheduledDate = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (count.HasValue)
            queryParams.Add($"count={count}");
        if (cursor.HasValue)
            queryParams.Add($"cursor={cursor}");
        if (workOrderNumber.HasValue)
            queryParams.Add($"workOrderNumber={workOrderNumber}");
        if (mechanicId.HasValue)
            queryParams.Add($"mechanic_Id={mechanicId}");
        if (subletVendorId.HasValue)
            queryParams.Add($"subletVendor_Id={subletVendorId}");
        if (minimumScheduledDate.HasValue)
            queryParams.Add($"minimum_ScheduledDate={Uri.EscapeDataString(minimumScheduledDate.Value.ToString("O"))}");
        if (maximumScheduledDate.HasValue)
            queryParams.Add($"maximum_ScheduledDate={Uri.EscapeDataString(maximumScheduledDate.Value.ToString("O"))}");

        var url = "e360/api/v1/workOrderSchedules";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<PaginatedResponse<WorkOrderScheduleDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<PaginatedResponse<WorkOrderScheduleDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public class HeavyBidResponse<T>
    {
        [JsonPropertyName("data")]
        public T[]? Data { get; init; }

        [JsonPropertyName("currentTopValue")]
        public int? CurrentTopValue { get; init; }

        [JsonPropertyName("currentSkipValue")]
        public int? CurrentSkipValue { get; init; }

        [JsonPropertyName("nextSkipValue")]
        public int? NextSkipValue { get; init; }
    }

    public async Task<ApiResponse<HeavyBidResponse<ActivitiesDataObject>>> GetActivities(
        Guid businessUnitId,
        int? top = null,
        int? skip = null,
        string? filter = null,
        string? orderby = null,
        bool? includeExcludedEstimates = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (top.HasValue)
            queryParams.Add($"$top={top}");
        if (skip.HasValue)
            queryParams.Add($"$skip={skip}");
        if (!string.IsNullOrEmpty(filter))
            queryParams.Add($"$filter={Uri.EscapeDataString(filter)}");
        if (!string.IsNullOrEmpty(orderby))
            queryParams.Add($"$orderby={Uri.EscapeDataString(orderby)}");
        if (includeExcludedEstimates.HasValue)
            queryParams.Add($"includeExcludedEstimates={includeExcludedEstimates.Value.ToString().ToLower()}");

        var url = $"heavybid/api/v2/integration/businessunits/{businessUnitId}/activities";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<HeavyBidResponse<ActivitiesDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<HeavyBidResponse<ActivitiesDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public class SingleResponse<T>
    {
        [JsonPropertyName("data")]
        public T? Data { get; init; }
    }

    public async Task<ApiResponse<SingleResponse<ActivityDataObject>>> GetActivity(
        Guid id,
        Guid businessUnitId,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavybid/api/v2/integration/businessunits/{businessUnitId}/activities/{id}";
        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<SingleResponse<ActivityDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<SingleResponse<ActivityDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<SingleResponse<ActivityCodeBookDataObject>>> GetActivityCodeBook(
        Guid id,
        Guid businessUnitId,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavybid/api/v2/integration/businessunits/{businessUnitId}/activitycodebook/{id}";
        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<SingleResponse<ActivityCodeBookDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<SingleResponse<ActivityCodeBookDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<SingleResponse<ActivityCodebookResourceDataObject>>> GetActivityCodebookResource(
        Guid id,
        Guid businessUnitId,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavybid/api/v2/integration/businessunits/{businessUnitId}/activitycodebookresource/{id}";
        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<SingleResponse<ActivityCodebookResourceDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<SingleResponse<ActivityCodebookResourceDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<HeavyBidResponse<ActivityCodebookResourcesDataObject>>> GetActivityCodebookResources(
        Guid businessUnitId,
        int? top = null,
        int? skip = null,
        string? filter = null,
        string? orderby = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (top.HasValue)
            queryParams.Add($"$top={top}");
        if (skip.HasValue)
            queryParams.Add($"$skip={skip}");
        if (!string.IsNullOrEmpty(filter))
            queryParams.Add($"$filter={Uri.EscapeDataString(filter)}");
        if (!string.IsNullOrEmpty(orderby))
            queryParams.Add($"$orderby={Uri.EscapeDataString(orderby)}");

        var url = $"heavybid/api/v2/integration/businessunits/{businessUnitId}/activitycodebookresource";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<HeavyBidResponse<ActivityCodebookResourcesDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<HeavyBidResponse<ActivityCodebookResourcesDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<HeavyBidResponse<ActivityCodeBooksDataObject>>> GetActivityCodeBooks(
        Guid businessUnitId,
        int? top = null,
        int? skip = null,
        string? filter = null,
        string? orderby = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (top.HasValue)
            queryParams.Add($"$top={top}");
        if (skip.HasValue)
            queryParams.Add($"$skip={skip}");
        if (!string.IsNullOrEmpty(filter))
            queryParams.Add($"$filter={Uri.EscapeDataString(filter)}");
        if (!string.IsNullOrEmpty(orderby))
            queryParams.Add($"$orderby={Uri.EscapeDataString(orderby)}");

        var url = $"heavybid/api/v2/integration/businessunits/{businessUnitId}/activitycodebook";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<HeavyBidResponse<ActivityCodeBooksDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<HeavyBidResponse<ActivityCodeBooksDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<HeavyBidResponse<AllBiditemCodebookDataObject>>> GetAllBiditemCodebooks(
        Guid businessUnitId,
        int? top = null,
        int? skip = null,
        string? filter = null,
        string? orderby = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (top.HasValue)
            queryParams.Add($"$top={top}");
        if (skip.HasValue)
            queryParams.Add($"$skip={skip}");
        if (!string.IsNullOrEmpty(filter))
            queryParams.Add($"$filter={Uri.EscapeDataString(filter)}");
        if (!string.IsNullOrEmpty(orderby))
            queryParams.Add($"$orderby={Uri.EscapeDataString(orderby)}");

        var url = $"heavybid/api/v2/integration/businessunits/{businessUnitId}/biditemcodebook";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<HeavyBidResponse<AllBiditemCodebookDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<HeavyBidResponse<AllBiditemCodebookDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<HeavyBidResponse<AllCalulatedKPIsDataObject>>> GetAllCalculatedKPIs(
        Guid businessUnitId,
        Guid estimateId,
        int? top = null,
        int? skip = null,
        string? filter = null,
        string? orderby = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (top.HasValue)
            queryParams.Add($"$top={top}");
        if (skip.HasValue)
            queryParams.Add($"$skip={skip}");
        if (!string.IsNullOrEmpty(filter))
            queryParams.Add($"$filter={Uri.EscapeDataString(filter)}");
        if (!string.IsNullOrEmpty(orderby))
            queryParams.Add($"$orderby={Uri.EscapeDataString(orderby)}");

        var url = $"heavybid/api/v2/integration/businessunits/{businessUnitId}/estimates/{estimateId}/kpis";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<HeavyBidResponse<AllCalulatedKPIsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<HeavyBidResponse<AllCalulatedKPIsDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<HeavyBidResponse<AllMaterialCodebookDataObject>>> GetAllMaterialCodebooks(
        Guid businessUnitId,
        int? top = null,
        int? skip = null,
        string? filter = null,
        string? orderby = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (top.HasValue)
            queryParams.Add($"$top={top}");
        if (skip.HasValue)
            queryParams.Add($"$skip={skip}");
        if (!string.IsNullOrEmpty(filter))
            queryParams.Add($"$filter={Uri.EscapeDataString(filter)}");
        if (!string.IsNullOrEmpty(orderby))
            queryParams.Add($"$orderby={Uri.EscapeDataString(orderby)}");

        var url = $"heavybid/api/v2/integration/businessunits/{businessUnitId}/materialcodebook";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<HeavyBidResponse<AllMaterialCodebookDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<HeavyBidResponse<AllMaterialCodebookDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<HeavyBidResponse<BiditemDataObject>>> GetBiditem(
        Guid businessUnitId,
        int? top = null,
        int? skip = null,
        string? filter = null,
        string? orderby = null,
        bool? includeExcludedEstimates = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (top.HasValue)
            queryParams.Add($"$top={top}");
        if (skip.HasValue)
            queryParams.Add($"$skip={skip}");
        if (!string.IsNullOrEmpty(filter))
            queryParams.Add($"$filter={Uri.EscapeDataString(filter)}");
        if (!string.IsNullOrEmpty(orderby))
            queryParams.Add($"$orderby={Uri.EscapeDataString(orderby)}");
        if (includeExcludedEstimates.HasValue)
            queryParams.Add($"includeExcludedEstimates={includeExcludedEstimates.Value.ToString().ToLower()}");

        var url = $"heavybid/api/v2/integration/businessunits/{businessUnitId}/biditems";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<HeavyBidResponse<BiditemDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<HeavyBidResponse<BiditemDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<HeavyBidResponse<BiditemCodebookDataObject>>> GetBiditemCodebooks(
        Guid businessUnitId,
        int? top = null,
        int? skip = null,
        string? filter = null,
        string? orderby = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (top.HasValue)
            queryParams.Add($"$top={top}");
        if (skip.HasValue)
            queryParams.Add($"$skip={skip}");
        if (!string.IsNullOrEmpty(filter))
            queryParams.Add($"$filter={Uri.EscapeDataString(filter)}");
        if (!string.IsNullOrEmpty(orderby))
            queryParams.Add($"$orderby={Uri.EscapeDataString(orderby)}");

        var url = $"heavybid/api/v2/integration/businessunits/{businessUnitId}/biditemcodebook";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<HeavyBidResponse<BiditemCodebookDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<HeavyBidResponse<BiditemCodebookDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<HeavyBidResponse<BiditemsDataObject>>> GetBiditems(
        Guid businessUnitId,
        int? top = null,
        int? skip = null,
        string? filter = null,
        string? orderby = null,
        bool? includeExcludedEstimates = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (top.HasValue)
            queryParams.Add($"$top={top}");
        if (skip.HasValue)
            queryParams.Add($"$skip={skip}");
        if (!string.IsNullOrEmpty(filter))
            queryParams.Add($"$filter={Uri.EscapeDataString(filter)}");
        if (!string.IsNullOrEmpty(orderby))
            queryParams.Add($"$orderby={Uri.EscapeDataString(orderby)}");
        if (includeExcludedEstimates.HasValue)
            queryParams.Add($"includeExcludedEstimates={includeExcludedEstimates.Value.ToString().ToLower()}");

        var url = $"heavybid/api/v2/integration/businessunits/{businessUnitId}/biditems";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<HeavyBidResponse<BiditemsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<HeavyBidResponse<BiditemsDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<HeavyBidResponse<BusinessUnitsDataObject>>> GetBusinessUnits(
        int top,
        int skip,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(
            $"heavybid/api/v2/integration/businessunits?$top={top}&$skip={skip}",
            cancellationToken);

        return await CreateApiResponseAsync<HeavyBidResponse<BusinessUnitsDataObject>>(response);
    }

    public async Task<ApiResponse<HeavyBidResponse<EstimateAttachmentsDataObject>>> GetEstimateAttachments(
        Guid businessUnitId,
        int top,
        int skip,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(
            $"heavybid/api/v2/integration/businessunits/{businessUnitId}/estimates/attachments?$top={top}&$skip={skip}",
            cancellationToken);

        return await CreateApiResponseAsync<HeavyBidResponse<EstimateAttachmentsDataObject>>(response);
    }

    public async Task<ApiResponse<Stream>> DownloadEstimateAttachment(
        Guid businessUnitId,
        Guid estimateId,
        Guid attachmentId,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(
            $"heavybid/api/v2/integration/businessunits/{businessUnitId}/estimates/{estimateId}/attachments/{attachmentId}",
            cancellationToken);

        return new ApiResponse<Stream>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? await response.Content.ReadAsStreamAsync(cancellationToken) : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<HeavyBidResponse<EstimateDataObject>>> GetEstimates(
        Guid businessUnitId,
        int top,
        int skip,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(
            $"heavybid/api/v2/integration/businessunits/{businessUnitId}/estimates?$top={top}&$skip={skip}",
            cancellationToken);

        return await CreateApiResponseAsync<HeavyBidResponse<EstimateDataObject>>(response);
    }

    public async Task<ApiResponse<SingleResponse<EstimateDataObject>>> GetEstimate(
        Guid businessUnitId,
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(
            $"heavybid/api/v2/integration/businessunits/{businessUnitId}/estimates/{id}",
            cancellationToken);

        return await CreateApiResponseAsync<SingleResponse<EstimateDataObject>>(response);
    }

    public async Task<ApiResponse<SingleResponse<MaterialCodebookDataObject>>> GetMaterialCodebook(
        Guid id,
        Guid businessUnitId,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavybid/api/v2/integration/businessunits/{businessUnitId}/materialcodebook/{id}";
        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<SingleResponse<MaterialCodebookDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<SingleResponse<MaterialCodebookDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<HeavyBidResponse<MaterialCodebookDataObject>>> GetMaterialCodebooks(
        Guid businessUnitId,
        int? top = null,
        int? skip = null,
        string? filter = null,
        string? orderby = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (top.HasValue)
            queryParams.Add($"$top={top}");
        if (skip.HasValue)
            queryParams.Add($"$skip={skip}");
        if (!string.IsNullOrEmpty(filter))
            queryParams.Add($"$filter={Uri.EscapeDataString(filter)}");
        if (!string.IsNullOrEmpty(orderby))
            queryParams.Add($"$orderby={Uri.EscapeDataString(orderby)}");

        var url = $"heavybid/api/v2/integration/businessunits/{businessUnitId}/materialcodebook";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<HeavyBidResponse<MaterialCodebookDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<HeavyBidResponse<MaterialCodebookDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<SingleResponse<MaterialCodebookDataObject>>> UpdateMaterialCodebook(
        Guid id,
        Guid businessUnitId,
        UpdateMaterialCodebookActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavybid/api/v2/integration/businessunits/{businessUnitId}/materialcodebook/{id}";
        var response = await _httpClient.PutAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<SingleResponse<MaterialCodebookDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<SingleResponse<MaterialCodebookDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<HeavyBidResponse<HeavyBidEstimate.v1.Materials.MaterialsDataObject>>> GetMaterials(
        Guid businessUnitId,
        Guid estimateId,
        string materialType,
        int? top = null,
        int? skip = null,
        string? filter = null,
        string? orderby = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (top.HasValue)
            queryParams.Add($"$top={top}");
        if (skip.HasValue)
            queryParams.Add($"$skip={skip}");
        if (!string.IsNullOrEmpty(filter))
            queryParams.Add($"$filter={Uri.EscapeDataString(filter)}");
        if (!string.IsNullOrEmpty(orderby))
            queryParams.Add($"$orderby={Uri.EscapeDataString(orderby)}");

        var url = $"heavybid/api/v2/integration/businessunits/{businessUnitId}/estimates/{estimateId}/materials/{materialType}";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<HeavyBidResponse<HeavyBidEstimate.v1.Materials.MaterialsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<HeavyBidResponse<HeavyBidEstimate.v1.Materials.MaterialsDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<HeavyBidResponse<PartitionDataObject>>> GetPartitions(
        Guid businessUnitId,
        int? top = null,
        int? skip = null,
        string? filter = null,
        string? orderby = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (top.HasValue)
            queryParams.Add($"$top={top}");
        if (skip.HasValue)
            queryParams.Add($"$skip={skip}");
        if (!string.IsNullOrEmpty(filter))
            queryParams.Add($"$filter={Uri.EscapeDataString(filter)}");
        if (!string.IsNullOrEmpty(orderby))
            queryParams.Add($"$orderby={Uri.EscapeDataString(orderby)}");

        var url = $"heavybid/api/v2/integration/businessunits/{businessUnitId}/partitions";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<HeavyBidResponse<PartitionDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<HeavyBidResponse<PartitionDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<HeavyBidResponse<PartitionsDataObject>>> GetAllPartitions(
        Guid businessUnitId,
        int? top = null,
        int? skip = null,
        string? filter = null,
        string? orderby = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (top.HasValue)
            queryParams.Add($"$top={top}");
        if (skip.HasValue)
            queryParams.Add($"$skip={skip}");
        if (!string.IsNullOrEmpty(filter))
            queryParams.Add($"$filter={Uri.EscapeDataString(filter)}");
        if (!string.IsNullOrEmpty(orderby))
            queryParams.Add($"$orderby={Uri.EscapeDataString(orderby)}");

        var url = $"heavybid/api/v2/integration/businessunits/{businessUnitId}/partitions";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<HeavyBidResponse<PartitionsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<HeavyBidResponse<PartitionsDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<HeavyBidResponse<QuoteFolderDataObject>>> GetQuoteFolders(
        Guid businessUnitId,
        Guid estimateId,
        int? top = null,
        int? skip = null,
        string? filter = null,
        string? orderby = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (top.HasValue)
            queryParams.Add($"$top={top}");
        if (skip.HasValue)
            queryParams.Add($"$skip={skip}");
        if (!string.IsNullOrEmpty(filter))
            queryParams.Add($"$filter={Uri.EscapeDataString(filter)}");
        if (!string.IsNullOrEmpty(orderby))
            queryParams.Add($"$orderby={Uri.EscapeDataString(orderby)}");

        var url = $"heavybid/api/v2/integration/businessunits/{businessUnitId}/estimates/{estimateId}/quoteFolders";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<HeavyBidResponse<QuoteFolderDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<HeavyBidResponse<QuoteFolderDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<HeavyBidResponse<QuoteFoldersDataObject>>> GetAllQuoteFolders(
        Guid businessUnitId,
        Guid estimateId,
        int? top = null,
        int? skip = null,
        string? filter = null,
        string? orderby = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (top.HasValue)
            queryParams.Add($"$top={top}");
        if (skip.HasValue)
            queryParams.Add($"$skip={skip}");
        if (!string.IsNullOrEmpty(filter))
            queryParams.Add($"$filter={Uri.EscapeDataString(filter)}");
        if (!string.IsNullOrEmpty(orderby))
            queryParams.Add($"$orderby={Uri.EscapeDataString(orderby)}");

        var url = $"heavybid/api/v2/integration/businessunits/{businessUnitId}/estimates/{estimateId}/quoteFolders";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<HeavyBidResponse<QuoteFoldersDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<HeavyBidResponse<QuoteFoldersDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<HeavyBidResponse<ResourceDataObject>>> GetResource(
        Guid businessUnitId,
        int? top = null,
        int? skip = null,
        string? filter = null,
        string? orderby = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        if (top.HasValue)
            queryParams.Add($"$top={top}");
        if (skip.HasValue)
            queryParams.Add($"$skip={skip}");
        if (!string.IsNullOrEmpty(filter))
            queryParams.Add($"$filter={Uri.EscapeDataString(filter)}");
        if (!string.IsNullOrEmpty(orderby))
            queryParams.Add($"$orderby={Uri.EscapeDataString(orderby)}");

        var url = $"heavybid/api/v2/integration/businessunits/{businessUnitId}/resources";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<HeavyBidResponse<ResourceDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<HeavyBidResponse<ResourceDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<HeavyBidResponse<ResourcesDataObject>>> GetAllResources(
        Guid businessUnitId,
        bool includeExcludedEstimates = false,
        int? top = null,
        int? skip = null,
        string? filter = null,
        string? orderby = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        queryParams.Add($"includeExcludedEstimates={includeExcludedEstimates.ToString().ToLower()}");
        if (top.HasValue)
            queryParams.Add($"$top={top}");
        if (skip.HasValue)
            queryParams.Add($"$skip={skip}");
        if (!string.IsNullOrEmpty(filter))
            queryParams.Add($"$filter={Uri.EscapeDataString(filter)}");
        if (!string.IsNullOrEmpty(orderby))
            queryParams.Add($"$orderby={Uri.EscapeDataString(orderby)}");

        var url = $"heavybid/api/v2/integration/businessunits/{businessUnitId}/resources";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<HeavyBidResponse<ResourcesDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<HeavyBidResponse<ResourcesDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    // Add this class to handle the business unit response
    public class BusinessUnitResponse
    {
        [JsonPropertyName("results")]
        public IEnumerable<HeavyBidPreConstruction.v1.BusinessUnit.BusinessUnitDataObject>? Results { get; init; }

        [JsonPropertyName("nextPageToken")] 
        public string? NextPageToken { get; init; }

        [JsonPropertyName("hasNextPage")]
        public bool HasNextPage { get; init; }
    }

    // Add this method to the ApiClient class
    public async Task<ApiResponse<BusinessUnitResponse>> GetBusinessUnit(
        string? pageToken = null,
        CancellationToken cancellationToken = default)
    {
        var url = "precon/api/v1/businessUnits";
        if (!string.IsNullOrEmpty(pageToken))
        {
            url += $"?pageToken={Uri.EscapeDataString(pageToken)}";
        }

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<BusinessUnitResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<BusinessUnitResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    // Add this class to handle the project response
    public class ProjectResponse
    {
        [JsonPropertyName("results")]
        public IEnumerable<ProjectDataObject>? Results { get; init; }

        [JsonPropertyName("nextPageToken")] 
        public string? NextPageToken { get; init; }

        [JsonPropertyName("hasNextPage")]
        public bool HasNextPage { get; init; }
    }

    // Add this method to the ApiClient class
    public async Task<ApiResponse<ProjectResponse>> GetProjects(
        Guid businessUnitId,
        string? pageToken = null,
        CancellationToken cancellationToken = default)
    {
        var url = $"precon/api/v1/businessUnits/{businessUnitId}/projects";
        if (!string.IsNullOrEmpty(pageToken))
        {
            url += $"?pageToken={Uri.EscapeDataString(pageToken)}";
        }

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<ProjectResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<ProjectResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CreateProjectActionOutput>> CreateProject(
        Guid businessUnitId,
        CreateProjectActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"precon/api/v1/businessUnits/{businessUnitId}/projects";
        
        var response = await _httpClient.PostAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<CreateProjectActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CreateProjectActionOutput>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<object>> DeleteProject(
        Guid businessUnitId,
        Guid projectId,
        CancellationToken cancellationToken = default)
    {
        var url = $"precon/api/v1/businessUnits/{businessUnitId}/projects/{projectId}";
        
        var response = await _httpClient.DeleteAsync(url, cancellationToken);

        return new ApiResponse<object>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<UpdateProjectActionOutput>> UpdateProject(
        Guid businessUnitId,
        Guid projectId,
        UpdateProjectActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"precon/api/v1/businessUnits/{businessUnitId}/projects/{projectId}";
        
        var response = await _httpClient.PutAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<UpdateProjectActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<UpdateProjectActionOutput>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<PartialChangeProjectActionOutput>> PartialChangeProject(
        Guid businessUnitId,
        Guid projectId,
        List<PatchOperation> changes,
        CancellationToken cancellationToken = default)
    {
        var url = $"precon/api/v1/businessUnits/{businessUnitId}/projects/{projectId}";
        
        var response = await _httpClient.PatchAsJsonAsync(url, changes, cancellationToken);

        return new ApiResponse<PartialChangeProjectActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<PartialChangeProjectActionOutput>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<ProjectListResponse>> GetProjectsList(
        Guid businessUnitId,
        string? continuationToken = null,
        int? top = null,
        bool includeDynamicFields = true,
        bool includeArchived = false,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (!string.IsNullOrEmpty(continuationToken))
            queryParams.Add($"continuationToken={Uri.EscapeDataString(continuationToken)}");
        if (top.HasValue)
            queryParams.Add($"top={top}");
        
        queryParams.Add($"includeDynamicFields={includeDynamicFields}");
        queryParams.Add($"includeArchived={includeArchived}");

        var url = $"precon/api/v1/businessUnits/{businessUnitId}/projects";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<ProjectListResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<ProjectListResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public class ProjectListResponse
    {
        [JsonPropertyName("results")]
        public IEnumerable<ProjectsDataObject>? Results { get; init; }

        [JsonPropertyName("nextPageToken")]
        public string? NextPageToken { get; init; }

        [JsonPropertyName("hasNextPage")]
        public bool HasNextPage { get; init; }
    }

    public async Task<ApiResponse<CreateProjectsActionOutput>> CreateProjects(
        Guid businessUnitId,
        List<Connector.HeavyBidPreConstruction.v1.Projects.Create.ProjectCreate> projects,
        bool skipInvalidFields = false,
        CancellationToken cancellationToken = default)
    {
        var url = $"precon/api/v1/businessUnits/{businessUnitId}/projects/range";
        if (skipInvalidFields)
            url += "?skipInvalidFields=true";

        var response = await _httpClient.PostAsJsonAsync(url, projects, cancellationToken);

        return new ApiResponse<CreateProjectsActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CreateProjectsActionOutput>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<DeleteProjectsActionOutput>> DeleteProjects(
        Guid businessUnitId,
        List<string> projectIds,
        CancellationToken cancellationToken = default)
    {
        var url = $"precon/api/v1/businessUnits/{businessUnitId}/projects/range";
        
        var request = new HttpRequestMessage(HttpMethod.Delete, url)
        {
            Content = JsonContent.Create(projectIds)
        };

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<DeleteProjectsActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<DeleteProjectsActionOutput>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CreateReportsActionOutput>> GenerateProjectReport(
        Guid businessUnitId,
        Guid projectId,
        List<string>? hiddenProjectFields = null,
        List<string>? hiddenEstimateColumns = null,
        ReportSettings? settings = null,
        CancellationToken cancellationToken = default)
    {
        var url = $"precon/api/v1/businessUnits/{businessUnitId}/reports/projects/{projectId}/projectDetails";
        
        var request = new
        {
            hiddenProjectFields,
            hiddenEstimateColumns,
            settings
        };

        var response = await _httpClient.PostAsJsonAsync(url, request, cancellationToken);
        var content = await response.Content.ReadAsByteArrayAsync(cancellationToken);

        return new ApiResponse<CreateReportsActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? new CreateReportsActionOutput { ReportContent = content }
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    // For getting all schemas (plural)
    public async Task<ApiResponse<SchemasListResponse>> GetSchemas(
        Guid businessUnitId,
        string? continuationToken = null,
        int? top = null,
        string? orderByFieldId = null,
        bool? orderByAscending = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (!string.IsNullOrEmpty(continuationToken))
            queryParams.Add($"continuationToken={Uri.EscapeDataString(continuationToken)}");
        if (top.HasValue)
            queryParams.Add($"top={top}");
        if (!string.IsNullOrEmpty(orderByFieldId))
            queryParams.Add($"orderBy.fieldId={Uri.EscapeDataString(orderByFieldId)}");
        if (orderByAscending.HasValue)
            queryParams.Add($"orderBy.ascending={orderByAscending.Value}");

        var url = $"precon/api/v1/businessUnits/{businessUnitId}/schemas";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<SchemasListResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<SchemasListResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    // For getting a single schema by ID
    public async Task<ApiResponse<SchemaDataObject>> GetSchema(
        Guid businessUnitId,
        Guid schemaId,
        CancellationToken cancellationToken = default)
    {
        var url = $"precon/api/v1/businessUnits/{businessUnitId}/schemas/{schemaId}";

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<SchemaDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<SchemaDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public class SchemasListResponse
    {
        [JsonPropertyName("results")]
        public IEnumerable<SchemasDataObject>? Results { get; init; }

        [JsonPropertyName("nextPageToken")]
        public string? NextPageToken { get; init; }

        [JsonPropertyName("hasNextPage")]
        public bool HasNextPage { get; init; }
    }

    public async Task<ApiResponse<object>> UpdateSchemaFieldAlias(
        Guid businessUnitId,
        string existingFieldAlias,
        string newFieldAlias,
        CancellationToken cancellationToken = default)
    {
        var url = $"precon/api/v1/businessUnits/{businessUnitId}/schemas/updateFieldAlias";
        
        var request = new
        {
            existingFieldAlias,
            newFieldAlias
        };

        var response = await _httpClient.PostAsJsonAsync(url, request, cancellationToken);

        return new ApiResponse<object>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<AccessGroupDataObject>>> GetAccessGroups(
        bool includeDeleted = false,
        CancellationToken cancellationToken = default)
    {
        var url = "heavyjob/api/v1/accessGroup";
        if (includeDeleted)
        {
            url += "?isDeleted=true";
        }

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<AccessGroupDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<AccessGroupDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<AccountingValuesResponse>> SearchAccountingValues(
        Guid businessUnitId,
        IEnumerable<Guid>? entityIds = null,
        string? cursor = null,
        int? limit = null,
        AccountingEntityType? entityType = null,
        CancellationToken cancellationToken = default)
    {
        var request = new
        {
            businessUnitId,
            entityIds,
            cursor,
            limit,
            entityType = entityType?.ToString().ToLowerInvariant()
        };

        var url = "heavyjob/api/v1/accountingValues/search";
        var response = await _httpClient.PostAsJsonAsync(url, request, cancellationToken);

        return new ApiResponse<AccountingValuesResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<AccountingValuesResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public class AccountingValuesResponse
    {
        [JsonPropertyName("results")]
        public IEnumerable<AccountingDataObject>? Results { get; init; }

        [JsonPropertyName("metadata")]
        public AccountingValuesMetadata? Metadata { get; init; }
    }

    public class AccountingValuesMetadata
    {
        [JsonPropertyName("nextCursor")]
        public string? NextCursor { get; init; }
    }

    public async Task<ApiResponse<CreateAdvancedBudgetCustomCostTypeItemActionOutput>> CreateAdvancedBudgetCustomCostTypeItem(
        CreateAdvancedBudgetCustomCostTypeItemActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "heavyjob/api/v1/advancedBudgets/custom";

        var request = new
        {
            costCodeId = input.CostCodeId,
            purchaseOrderDetailId = input.PurchaseOrderDetailId,
            status = input.Status.ToString().ToLowerInvariant(),
            quantity = input.Quantity
        };

        var response = await _httpClient.PostAsJsonAsync(url, request, cancellationToken);

        return new ApiResponse<CreateAdvancedBudgetCustomCostTypeItemActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CreateAdvancedBudgetCustomCostTypeItemActionOutput>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<AdvancedBudgetCustomCostTypesDataObject>>> GetAdvancedBudgetCustomCostTypes(
        Guid jobId,
        Guid? purchaseOrderId = null,
        bool? isDiscontinued = null,
        bool? includeDeleted = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (purchaseOrderId.HasValue)
            queryParams.Add($"purchaseOrderId={purchaseOrderId}");
        if (isDiscontinued.HasValue)
            queryParams.Add($"isDiscontinued={isDiscontinued.Value}");
        if (includeDeleted.HasValue)
            queryParams.Add($"isDeleted={includeDeleted.Value}");

        var url = $"heavyjob/api/v1/jobs/{jobId}/advancedBudgets/custom";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<AdvancedBudgetCustomCostTypesDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<AdvancedBudgetCustomCostTypesDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<AdvancedBudgetMaterialDataObject>>> GetAdvancedBudgetMaterials(
        Guid jobId,
        Guid? purchaseOrderId = null,
        bool? isDiscontinued = null,
        bool? includeDeleted = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (purchaseOrderId.HasValue)
            queryParams.Add($"purchaseOrderId={purchaseOrderId}");
        if (isDiscontinued.HasValue)
            queryParams.Add($"isDiscontinued={isDiscontinued.Value}");
        if (includeDeleted.HasValue)
            queryParams.Add($"isDeleted={includeDeleted.Value}");

        var url = $"heavyjob/api/v1/jobs/{jobId}/advancedBudgets/material";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<AdvancedBudgetMaterialDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<AdvancedBudgetMaterialDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CreateAdvancedBudgetMaterialActionOutput>> CreateAdvancedBudgetMaterial(
        CreateAdvancedBudgetMaterialActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "heavyjob/api/v1/advancedBudgets/material";

        var request = new
        {
            costCodeId = input.CostCodeId,
            purchaseOrderDetailId = input.PurchaseOrderDetailId,
            status = input.Status.ToString().ToLowerInvariant(),
            quantity = input.Quantity
        };

        var response = await _httpClient.PostAsJsonAsync(url, request, cancellationToken);

        return new ApiResponse<CreateAdvancedBudgetMaterialActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CreateAdvancedBudgetMaterialActionOutput>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<AdvancedBudgetSubcontractDataObject>>> GetAdvancedBudgetSubcontracts(
        Guid jobId,
        Guid? vendorContractId = null,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/jobs/{jobId}/advancedBudgets/subcontract";
        if (vendorContractId.HasValue)
            url += $"?vendorContractId={vendorContractId}";

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<AdvancedBudgetSubcontractDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<AdvancedBudgetSubcontractDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CreateAdvancedBudgetSubcontractActionOutput>> CreateAdvancedBudgetSubcontract(
        CreateAdvancedBudgetSubcontractActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "heavyjob/api/v1/advancedBudgets/subcontract";

        var request = new
        {
            costCodeId = input.CostCodeId,
            vendorContractDetailId = input.VendorContractDetailId,
            status = input.Status.ToString().ToLowerInvariant(),
            quantity = input.Quantity
        };

        var response = await _httpClient.PostAsJsonAsync(url, request, cancellationToken);

        return new ApiResponse<CreateAdvancedBudgetSubcontractActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CreateAdvancedBudgetSubcontractActionOutput>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<AttachmentDataObject>>> GetAttachments(
        Guid jobId,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/jobs/{jobId}/attachments";

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<AttachmentDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<AttachmentDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CreateAttachmentActionOutput>> CreateAttachment(
        CreateAttachmentActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "heavyjob/api/v1/attachment";

        var response = await _httpClient.PostAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<CreateAttachmentActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CreateAttachmentActionOutput>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<AttendanceHourTagsDataObject>>> GetAttendanceHourTags(
        Guid businessUnitId,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/businessUnits/{businessUnitId}/attendanceHourTags";

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<AttendanceHourTagsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<AttendanceHourTagsDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<HeavyJob.v1.BusinessUnit.BusinessUnitDataObject>>> GetBusinessUnit(
        CancellationToken cancellationToken = default)
    {
        var url = "heavyjob/api/v1/businessUnits";

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<HeavyJob.v1.BusinessUnit.BusinessUnitDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<HeavyJob.v1.BusinessUnit.BusinessUnitDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<BusinessUnitPreferenceDataObject>> GetBusinessUnitPreferences(
        Guid businessUnitId,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/businessUnits/{businessUnitId}/preferences";

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<BusinessUnitPreferenceDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<BusinessUnitPreferenceDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<BusinessUnitPreferenceDataObject>> UpdateBusinessUnitPreferences(
        UpdateBusinessUnitPreferenceActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/businessUnits/{input.BusinessUnitId}/preferences";

        var request = new
        {
            defaultLaborRateSetId = input.DefaultLaborRateSetId,
            defaultEquipmentRateSetId = input.DefaultEquipmentRateSetId,
            startOfPayWeek = input.StartOfPayWeek.ToString().ToLowerInvariant()
        };

        var response = await _httpClient.PutAsJsonAsync(url, request, cancellationToken);

        return new ApiResponse<BusinessUnitPreferenceDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = null, // PUT returns 204 No Content
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<ChangeOrderDataObject>>> GetChangeOrder(
        Guid businessUnitId,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/changeOrder?id={businessUnitId}";

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<ChangeOrderDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<ChangeOrderDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<ChangeOrderDataObject>> CreateChangeOrder(
        CreateChangeOrderActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "heavyjob/api/v1/changeOrder";

        var response = await _httpClient.PostAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<ChangeOrderDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<ChangeOrderDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<DeleteChangeOrderActionOutput>> DeleteChangeOrder(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/changeOrder?id={id}";

        var response = await _httpClient.DeleteAsync(url, cancellationToken);

        return new ApiResponse<DeleteChangeOrderActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? new DeleteChangeOrderActionOutput { Id = id }
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<ChangeOrderDataObject>> UpdateChangeOrder(
        UpdateChangeOrderActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "heavyjob/api/v1/changeOrder";

        var response = await _httpClient.PatchAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<ChangeOrderDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = null, // PATCH returns 204 No Content
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<ChangeOrderIncrementorDataObject>>> GetChangeOrderIncrementor(
        Guid businessUnitId,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/changeOrderIncrementor?id={businessUnitId}";

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<ChangeOrderIncrementorDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<ChangeOrderIncrementorDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<ChangeOrdersByBusinessUnitDataObject>>> GetChangeOrdersByBusinessUnit(
        Guid businessUnitId,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/changeOrdersByBU?id={businessUnitId}";

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<ChangeOrdersByBusinessUnitDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<ChangeOrdersByBusinessUnitDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<ChangeOrdersByJobDataObject>>> GetChangeOrdersByJob(
        Guid jobId,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/changeOrdersByJob?id={jobId}";

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<ChangeOrdersByJobDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<ChangeOrdersByJobDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<CostAdjustmentsDataObject>>> GetCostAdjustments(
        Guid businessUnitId,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/businessUnits/{businessUnitId}/costAdjustments";

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<CostAdjustmentsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<CostAdjustmentsDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CostAdjustmentsDataObject>> CreateCostAdjustment(
        CreateCostAdjustmentsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/businessUnits/{input.BusinessUnitId}/costAdjustments";

        var response = await _httpClient.PostAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<CostAdjustmentsDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CostAdjustmentsDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse> DeleteCostAdjustment(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.DeleteAsync(
            $"heavyjob/api/v1/costAdjustments/{id}",
            cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse> UpdateCostAdjustment(
        UpdateCostAdjustmentsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsJsonAsync(
            $"heavyjob/api/v1/costAdjustments/{input.Id}",
            input,
            cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<CostCategoriesDataObject>>> GetCostCategories(
        Guid businessUnitId,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(
            $"heavyjob/api/v1/businessUnits/{businessUnitId}/costCategories",
            cancellationToken);

        return new ApiResponse<IEnumerable<CostCategoriesDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<CostCategoriesDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CreateCostCategoriesActionOutput>> CreateCostCategory(
        CreateCostCategoriesActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync(
            $"heavyjob/api/v1/businessUnits/{input.BusinessUnitId}/costCategories",
            new { code = input.Code, description = input.Description },
            cancellationToken);

        return new ApiResponse<CreateCostCategoriesActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CreateCostCategoriesActionOutput>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CostCodeCostsDataObject>> GetCostCodeCosts(
        Guid costCodeId,
        DateTime? effectiveDate = null,
        DateTime? startDate = null,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/costCodes/{costCodeId}/costs";
        var queryParams = new List<string>();
        
        if (effectiveDate.HasValue)
            queryParams.Add($"effectiveDate={effectiveDate.Value:yyyy-MM-ddTHH:mm:ssZ}");
        if (startDate.HasValue)
            queryParams.Add($"startDate={startDate.Value:yyyy-MM-ddTHH:mm:ssZ}");

        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<CostCodeCostsDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CostCodeCostsDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse> UpdateCostCodeCosts(
        UpdateCostCodeCostsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsJsonAsync(
            $"heavyjob/api/v1/costCodes/{input.CostCodeId}/costs",
            input,
            cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CostCodeProgressResponse>> GetCostCodeProgress(
        Guid jobId,
        string? cursor = null,
        int? limit = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        Guid[]? costCodeIds = null,
        Guid[]? costCodeTagIds = null,
        Guid[]? costCodeTransactionTagIds = null,
        CancellationToken cancellationToken = default)
    {
        var request = new
        {
            jobId,
            startDate,
            endDate,
            costCodeIds,
            costCodeTagIds,
            costCodeTransactionTagIds,
            cursor,
            limit
        };

        var response = await _httpClient.PostAsJsonAsync(
            "heavyjob/api/v1/costCode/progress/advancedRequest",
            request,
            cancellationToken);

        return new ApiResponse<CostCodeProgressResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CostCodeProgressResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CostCodesResponse>> GetCostCodes(
        string? accountingTemplateName = null,
        Guid? jobId = null,
        Guid? businessUnitId = null,
        Guid? costCodeId = null,
        bool? isDeleted = null,
        int? limit = null,
        string? cursor = null,
        DateTime? modifiedSince = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (!string.IsNullOrEmpty(accountingTemplateName))
            queryParams.Add($"accountingTemplateName={accountingTemplateName}");
        if (jobId.HasValue)
            queryParams.Add($"jobId={jobId}");
        if (businessUnitId.HasValue)
            queryParams.Add($"businessUnitId={businessUnitId}");
        if (costCodeId.HasValue)
            queryParams.Add($"costCodeId={costCodeId}");
        if (isDeleted.HasValue)
            queryParams.Add($"isDeleted={isDeleted.Value.ToString().ToLower()}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit}");
        if (!string.IsNullOrEmpty(cursor))
            queryParams.Add($"cursor={cursor}");
        if (modifiedSince.HasValue)
            queryParams.Add($"modifiedSince={modifiedSince.Value:yyyy-MM-ddTHH:mm:ssZ}");

        var url = "heavyjob/api/v2/costCodes";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<CostCodesResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CostCodesResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CostCodesResponse>> GetCostCodesAdvanced(
        CreateCostCodesActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "heavyjob/api/v2/costCodes/advancedRequest",
            new
            {
                businessUnitId = input.BusinessUnitId,
                jobIds = input.JobIds,
                costCodeIds = input.CostCodeIds,
                cursor = input.Cursor,
                accountingTemplateName = input.AccountingTemplateName,
                limit = input.Limit
            },
            cancellationToken);

        return new ApiResponse<CostCodesResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CostCodesResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse> UpdateCostCodeBudgets(
        CostCodeBudget[] budgets,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PatchAsJsonAsync(
            "heavyjob/api/v1/costCodes/customCostTypes",
            budgets,
            cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CostCodeTagsResponse>> GetCostCodeTags(
        Guid? jobId = null,
        Guid? costCodeId = null,
        Guid? tagId = null,
        DateTime? modifiedSince = null,
        int? limit = null,
        string? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (jobId.HasValue)
            queryParams.Add($"jobId={jobId}");
        if (costCodeId.HasValue)
            queryParams.Add($"costCodeId={costCodeId}");
        if (tagId.HasValue)
            queryParams.Add($"tagId={tagId}");
        if (modifiedSince.HasValue)
            queryParams.Add($"modifiedSince={modifiedSince.Value:yyyy-MM-ddTHH:mm:ssZ}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit}");
        if (!string.IsNullOrEmpty(cursor))
            queryParams.Add($"cursor={cursor}");

        var url = "heavyjob/api/v1/costCodeTags";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<CostCodeTagsResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CostCodeTagsResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CostCodeTagsResponse>> GetCostCodeTagsAdvanced(
        CreateCostCodeTagsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "heavyjob/api/v1/costCodeTags/advancedRequest",
            new
            {
                costCodeIds = input.CostCodeIds,
                jobIds = input.JobIds,
                tagIds = input.TagIds,
                modifiedSince = input.ModifiedSince,
                cursor = input.Cursor,
                limit = input.Limit
            },
            cancellationToken);

        return new ApiResponse<CostCodeTagsResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CostCodeTagsResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse> DeleteCostCodeTags(
        DeleteCostCodeTagsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>
        {
            $"jobId={input.JobId}",
            $"costCodeId={input.CostCodeId}",
            $"tagId={input.TagId}"
        };

        var url = "heavyjob/api/v1/costCodeTags?" + string.Join("&", queryParams);
        var response = await _httpClient.DeleteAsync(url, cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse> UpdateCostCodeTags(
        CostCodeTagUpdate[] updates,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PatchAsJsonAsync(
            "heavyjob/api/v1/costCodeTags",
            updates,
            cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CostCodeTransactionResponse>> GetCostCodeTransactions(
        Guid? businessUnitId = null,
        Guid[]? jobIds = null,
        Guid[]? jobTagIds = null,
        Guid[]? foremanIds = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        string? cursor = null,
        int? limit = null,
        Guid[]? costCodeIds = null,
        bool includeCostsAndHours = false,
        CancellationToken cancellationToken = default)
    {
        var request = new
        {
            businessUnitId,
            jobIds,
            jobTagIds,
            foremanIds,
            startDate,
            endDate,
            cursor,
            limit,
            costCodeIds
        };

        var url = "heavyjob/api/v1/costCodeTimeCardTransactions/advancedRequest";
        if (includeCostsAndHours)
            url += "?includeCostsAndHours=true";

        var response = await _httpClient.PostAsJsonAsync(url, request, cancellationToken);

        return new ApiResponse<CostCodeTransactionResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CostCodeTransactionResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CostCodeTransactionAdjustmentResponse>> GetCostCodeTransactionAdjustments(
        Guid? businessUnitId = null,
        Guid[]? jobIds = null,
        Guid[]? jobTagIds = null,
        Guid[]? foremanIds = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        string? cursor = null,
        int? limit = null,
        Guid[]? costCodeIds = null,
        bool includeCostsAndHours = false,
        CancellationToken cancellationToken = default)
    {
        var request = new
        {
            businessUnitId,
            jobIds,
            jobTagIds,
            foremanIds,
            startDate,
            endDate,
            cursor,
            limit,
            costCodeIds
        };

        var url = "heavyjob/api/v1/costCodeTransactionAdjustments/advancedRequest";
        if (includeCostsAndHours)
            url += "?includeCostsAndHours=true";

        var response = await _httpClient.PostAsJsonAsync(url, request, cancellationToken);

        return new ApiResponse<CostCodeTransactionAdjustmentResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CostCodeTransactionAdjustmentResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CustomCostTypeInstalledResponse>> GetCustomCostTypeInstalled(
        Guid? businessUnitId = null,
        Guid[]? jobIds = null,
        Guid[]? jobTagIds = null,
        Guid[]? foremanIds = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        string? cursor = null,
        int? limit = null,
        Guid[]? costCodeIds = null,
        DateTime? modifiedSince = null,
        bool? onlyTM = null,
        CancellationToken cancellationToken = default)
    {
        var request = new
        {
            businessUnitId,
            jobIds,
            jobTagIds,
            foremanIds,
            startDate,
            endDate,
            cursor,
            limit,
            costCodeIds,
            modifiedSince,
            onlyTM
        };

        var response = await _httpClient.PostAsJsonAsync(
            "heavyjob/api/v1/costTypes/customInstalled/advancedRequest",
            request,
            cancellationToken);

        return new ApiResponse<CustomCostTypeInstalledResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CustomCostTypeInstalledResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CustomCostTypeItemReceivedResponse>> GetCustomCostTypeItemReceived(
        Guid? businessUnitId = null,
        Guid[]? jobIds = null,
        Guid[]? jobTagIds = null,
        Guid[]? foremanIds = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        string? cursor = null,
        int? limit = null,
        DateTime? modifiedSince = null,
        CancellationToken cancellationToken = default)
    {
        var request = new
        {
            businessUnitId,
            jobIds,
            jobTagIds,
            foremanIds,
            startDate,
            endDate,
            cursor,
            limit,
            modifiedSince
        };

        var response = await _httpClient.PostAsJsonAsync(
            "heavyjob/api/v1/costTypes/customReceived/advancedRequest",
            request,
            cancellationToken);

        return new ApiResponse<CustomCostTypeItemReceivedResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CustomCostTypeItemReceivedResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<CustomCostTypeItemsDataObject>>> GetCustomCostTypeItems(
        Guid businessUnitId,
        bool? isDeleted = null,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/businessUnits/{businessUnitId}/costTypes/custom";
        if (isDeleted.HasValue)
        {
            url += $"?isDeleted={isDeleted.Value}";
        }

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<CustomCostTypeItemsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<CustomCostTypeItemsDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CreateCustomCostTypeItemsActionOutput>> CreateCustomCostTypeItem(
        CreateCustomCostTypeItemsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync(
            $"heavyjob/api/v1/businessUnits/{input.BusinessUnitId}/costTypes/custom",
            new
            {
                costCategoryId = input.CostCategoryId,
                code = input.Code,
                description = input.Description,
                heavyBidCode = input.HeavyBidCode
            },
            cancellationToken);

        return new ApiResponse<CreateCustomCostTypeItemsActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CreateCustomCostTypeItemsActionOutput>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse> DeleteCustomCostTypeItem(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.DeleteAsync(
            $"heavyjob/api/v1/costTypes/custom/{id}",
            cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse> UpdateCustomCostTypeItem(
        UpdateCustomCostTypeItemsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsJsonAsync(
            $"heavyjob/api/v1/costTypes/custom/{input.Id}",
            new
            {
                costCategoryId = input.CostCategoryId,
                code = input.Code,
                description = input.Description,
                heavyBidCode = input.HeavyBidCode
            },
            cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<DiariesResponse>> GetDiaries(
        Guid businessUnitId,
        Guid[]? jobIds = null,
        Guid[]? jobTagIds = null,
        Guid[]? foremanIds = null,
        string? jobStatus = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        string? cursor = null,
        int? limit = null,
        CancellationToken cancellationToken = default)
    {
        var request = new
        {
            businessUnitId,
            jobIds,
            jobTagIds,
            foremanIds,
            jobStatus,
            startDate,
            endDate,
            cursor,
            limit
        };

        var response = await _httpClient.PostAsJsonAsync(
            "heavyjob/api/v1/diaries/search",
            request,
            cancellationToken);

        return new ApiResponse<DiariesResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<DiariesResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<DiaryDataObject>> UpsertDiary(
        DiaryDataObject diary,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsJsonAsync(
            "heavyjob/api/v1/diaries",
            new
            {
                jobId = diary.JobId,
                foremanId = diary.ForemanId,
                date = diary.Date,
                lockedById = diary.LockedById,
                lockedDateTime = diary.LockedDateTime,
                revision = diary.Revision,
                tags = diary.Tags,
                note = diary.Note,
                workingConditions = diary.WorkingConditions
            },
            cancellationToken);

        return new ApiResponse<DiaryDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<DiaryDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<EmployeeHoursResponse>> GetEmployeeHours(
        Guid businessUnitId,
        Guid[]? jobIds = null,
        Guid[]? jobTagIds = null,
        Guid[]? foremanIds = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        string? cursor = null,
        int? limit = null,
        bool includeAllJobs = false,
        bool includeInactiveEmployees = false,
        DateTime? modifiedSince = null,
        Guid[]? employeeIds = null,
        CancellationToken cancellationToken = default)
    {
        var request = new
        {
            businessUnitId,
            jobIds,
            jobTagIds,
            foremanIds,
            startDate,
            endDate,
            cursor,
            limit,
            includeAllJobs,
            includeInactiveEmployees,
            modifiedSince,
            employeeIds
        };

        var response = await _httpClient.PostAsJsonAsync(
            "heavyjob/api/v1/hours/employees",
            request,
            cancellationToken);

        return new ApiResponse<EmployeeHoursResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<EmployeeHoursResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<HeavyJob.v1.Employees.EmployeesDataObject>>> GetEmployees(
        Guid businessUnitId,
        string? accountingTemplateName = null,
        bool? isActive = null,
        bool? isDeleted = null,
        bool? isForeman = null,
        bool? includeHistoricalForeman = null,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/businessUnits/{businessUnitId}/employees";
        var queryParams = new List<string>();

        if (!string.IsNullOrEmpty(accountingTemplateName))
            queryParams.Add($"accountingTemplateName={accountingTemplateName}");
        if (isActive.HasValue)
            queryParams.Add($"isActive={isActive.Value}");
        if (isDeleted.HasValue)
            queryParams.Add($"isDeleted={isDeleted.Value}");
        if (isForeman.HasValue)
            queryParams.Add($"isForeman={isForeman.Value}");
        if (includeHistoricalForeman.HasValue)
            queryParams.Add($"includeHistoricalForeman={includeHistoricalForeman.Value}");

        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<HeavyJob.v1.Employees.EmployeesDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<HeavyJob.v1.Employees.EmployeesDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse> DeleteEmployees(
        Guid[] employeeIds,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, "heavyjob/api/v1/employees")
        {
            Content = JsonContent.Create(employeeIds)
        };
        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<EmployeesAdvancedResponse>> GetEmployeesAdvanced(
        Guid businessUnitId,
        string[]? employeeCodes = null,
        Guid[]? employeeIds = null,
        string? accountingTemplateName = null,
        bool? isActive = null,
        bool? isForeman = null,
        bool? includeHistoricalForeman = null,
        bool? isDeleted = null,
        string? cursor = null,
        int? limit = null,
        CancellationToken cancellationToken = default)
    {
        var request = new
        {
            businessUnitId,
            employeeCodes,
            employeeIds,
            accountingTemplateName,
            isActive,
            isForeman,
            includeHistoricalForeman,
            isDeleted,
            cursor,
            limit
        };

        var response = await _httpClient.PostAsJsonAsync(
            "heavyjob/api/v1/employees/advancedRequest",
            request,
            cancellationToken);

        return new ApiResponse<EmployeesAdvancedResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<EmployeesAdvancedResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<EmployeesWithDetailsResponse>> GetEmployeesWithDetails(
        bool? isDeleted = null,
        int? limit = 1000,
        string? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();

        if (isDeleted.HasValue)
            queryParams.Add($"isDeleted={isDeleted.Value}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit.Value}");
        if (!string.IsNullOrEmpty(cursor))
            queryParams.Add($"cursor={cursor}");

        var url = "heavyjob/api/v1/employees";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<EmployeesWithDetailsResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<EmployeesWithDetailsResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<HeavyJob.v1.Equipment.EquipmentDataObject>>> GetEquipment(
        Guid businessUnitId,
        string? accountingTemplateName = null,
        bool? isActive = null,
        bool? isDeleted = null,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/businessUnits/{businessUnitId}/equipment";
        var queryParams = new List<string>();

        if (!string.IsNullOrEmpty(accountingTemplateName))
            queryParams.Add($"accountingTemplateName={accountingTemplateName}");
        if (isActive.HasValue)
            queryParams.Add($"isActive={isActive.Value}");
        if (isDeleted.HasValue)
            queryParams.Add($"isDeleted={isDeleted.Value}");

        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<HeavyJob.v1.Equipment.EquipmentDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<HeavyJob.v1.Equipment.EquipmentDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<EquipmentAdvancedResponse>> GetEquipmentAdvanced(
        Guid businessUnitId,
        string[]? equipmentCodes = null,
        Guid[]? equipmentIds = null,
        Guid[]? jobIds = null,
        Guid[]? jobTagIds = null,
        string? accountingTemplateName = null,
        bool? isActive = null,
        bool? isActiveInAnyActiveJobs = null,
        bool? isDeleted = null,
        string? cursor = null,
        int? limit = null,
        CancellationToken cancellationToken = default)
    {
        var request = new
        {
            businessUnitId,
            equipmentCodes,
            equipmentIds,
            jobIds,
            jobTagIds,
            accountingTemplateName,
            isActive,
            isActiveInAnyActiveJobs,
            isDeleted,
            cursor,
            limit
        };

        var response = await _httpClient.PostAsJsonAsync(
            "heavyjob/api/v1/equipment/advancedRequest",
            request,
            cancellationToken);

        return new ApiResponse<EquipmentAdvancedResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<EquipmentAdvancedResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public class EquipmentAdvancedResponse
    {
        [JsonPropertyName("results")]
        [Required]
        public EquipmentDataObject[] Results { get; init; } = Array.Empty<EquipmentDataObject>();

        [JsonPropertyName("metadata")]
        [Required]
        public EquipmentMetadata Metadata { get; init; } = new();
    }

    public async Task<ApiResponse> UpdateEquipment(
        Guid businessUnitId,
        Guid equipmentId,
        HeavyJob.v1.Equipment.Update.UpdateEquipmentActionInput input,  // Change to HeavyJob namespace
        string? accountingTemplateName = null,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/businessUnits/{businessUnitId}/equipment/{equipmentId}";
        if (!string.IsNullOrEmpty(accountingTemplateName))
        {
            url += $"?accountingTemplateName={accountingTemplateName}";
        }

        var response = await _httpClient.PutAsJsonAsync(
            url,
            input,
            cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<EquipmentHoursResponse>> GetEquipmentHours(
        Guid businessUnitId,
        Guid[]? jobIds = null,
        Guid[]? jobTagIds = null,
        Guid[]? foremanIds = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        string? cursor = null,
        int? limit = null,
        bool includeAllJobs = false,
        bool includeInactiveEquipment = false,
        DateTime? modifiedSince = null,
        Guid[]? equipmentIds = null,
        Guid[]? linkedEmployeeIds = null,
        CancellationToken cancellationToken = default)
    {
        var request = new
        {
            businessUnitId,
            jobIds,
            jobTagIds,
            foremanIds,
            startDate,
            endDate,
            cursor,
            limit,
            includeAllJobs,
            includeInactiveEquipment,
            modifiedSince,
            equipmentIds,
            linkedEmployeeIds
        };

        var response = await _httpClient.PostAsJsonAsync(
            "heavyjob/api/v1/hours/equipment",
            request,
            cancellationToken);

        return new ApiResponse<EquipmentHoursResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<EquipmentHoursResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<HeavyJob.v1.EquipmentType.EquipmentTypeDataObject>>> GetEquipmentTypes(
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(
            "heavyjob/api/v1/equipmentTypes",
            cancellationToken);

        return new ApiResponse<IEnumerable<HeavyJob.v1.EquipmentType.EquipmentTypeDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<HeavyJob.v1.EquipmentType.EquipmentTypeDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CreateEquipmentTypeActionOutput>> CreateEquipmentType(
        HeavyJob.v1.EquipmentType.Create.CreateEquipmentTypeActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "heavyjob/api/v1/equipmentTypes",
            new { code = input.Code, description = input.Description },
            cancellationToken);

        return new ApiResponse<CreateEquipmentTypeActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CreateEquipmentTypeActionOutput>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<ForecastSummary>>> GetForecastSummary(
        Guid? jobId = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        DateTime? finalizedSince = null,
        int? limit = null,
        string? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (jobId.HasValue)
            queryParams.Add($"jobId={jobId}");
        if (startDate.HasValue)
            queryParams.Add($"startDate={startDate.Value:yyyy-MM-dd}");
        if (endDate.HasValue)
            queryParams.Add($"endDate={endDate.Value:yyyy-MM-dd}");
        if (finalizedSince.HasValue)
            queryParams.Add($"finalizedSince={finalizedSince.Value:O}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit}");
        if (!string.IsNullOrEmpty(cursor))
            queryParams.Add($"cursor={Uri.EscapeDataString(cursor)}");

        var url = "heavyjob/api/v1/forecastInfo";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<ForecastSummary>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<ForecastSummary>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<ForecastDataObject>> GetForecastDetails(
        Guid forecastId,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/forecasts/{forecastId}";

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<ForecastDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<ForecastDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public class ForecastSummary
    {
        [JsonPropertyName("id")]
        public Guid Id { get; init; }

        [JsonPropertyName("jobId")]
        public Guid JobId { get; init; }

        [JsonPropertyName("forecastDate")]
        public DateTime ForecastDate { get; init; }

        [JsonPropertyName("finalizedDateTime")]
        public DateTime? FinalizedDateTime { get; init; }
    }

    // Add this method to the ApiClient class
    public async Task<ApiResponse<ForecastInfoResponse>> GetForecastInfo(
        Guid? jobId = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        DateTime? finalizedSince = null,
        int? limit = null,
        string? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (jobId.HasValue)
            queryParams.Add($"jobId={jobId}");
        if (startDate.HasValue)
            queryParams.Add($"startDate={startDate.Value:yyyy-MM-dd}");
        if (endDate.HasValue)
            queryParams.Add($"endDate={endDate.Value:yyyy-MM-dd}");
        if (finalizedSince.HasValue)
            queryParams.Add($"finalizedSince={finalizedSince.Value:O}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit}");
        if (!string.IsNullOrEmpty(cursor))
            queryParams.Add($"cursor={Uri.EscapeDataString(cursor)}");

        var url = "heavyjob/api/v1/forecastInfo";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<ForecastInfoResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<ForecastInfoResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    // Add this method to the ApiClient class
    public async Task<ApiResponse<JobCostByCostCodeResponse>> GetJobCostByCostCode(
        Guid costCodeId,
        DateTime? effectiveDate = null,
        DateTime? startDate = null,
        string? cursor = null,
        int? limit = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>
        {
            $"costCodeId={costCodeId}"
        };
        
        if (effectiveDate.HasValue)
            queryParams.Add($"effectiveDate={effectiveDate.Value:O}");
        if (startDate.HasValue)
            queryParams.Add($"startDate={startDate.Value:O}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit}");
        if (!string.IsNullOrEmpty(cursor))
            queryParams.Add($"cursor={Uri.EscapeDataString(cursor)}");

        var url = "heavyjob/api/v1/jobCosts";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<JobCostByCostCodeResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<JobCostByCostCodeResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    // Add this method to the ApiClient class
    public async Task<ApiResponse<JobCostCustomCostResponse>> GetJobCostCustomCosts(
        Guid? businessUnitId = null,
        IEnumerable<Guid>? costCodeIds = null,
        IEnumerable<Guid>? jobIds = null,
        IEnumerable<Guid>? jobTagIds = null,
        IEnumerable<Guid>? foremanIds = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        string? cursor = null,
        int? limit = null,
        CancellationToken cancellationToken = default)
    {
        var request = new
        {
            businessUnitId,
            costCodeIds,
            jobIds,
            jobTagIds,
            foremanIds,
            startDate,
            endDate,
            cursor,
            limit
        };

        var response = await _httpClient.PostAsJsonAsync(
            "heavyjob/api/v1/jobCostCustomCosts/advancedRequest",
            request,
            cancellationToken);

        return new ApiResponse<JobCostCustomCostResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<JobCostCustomCostResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    // Add this method to the ApiClient class
    public async Task<ApiResponse<JobCostsDataObject>> GetJobCosts(
        Guid jobId,
        DateTime? effectiveDate = null,
        DateTime? startDate = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (effectiveDate.HasValue)
            queryParams.Add($"effectiveDate={effectiveDate.Value:O}");
        if (startDate.HasValue)
            queryParams.Add($"startDate={startDate.Value:O}");

        var url = $"heavyjob/api/v1/jobs/{jobId}/costs";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<JobCostsDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<JobCostsDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

        // Add this method to the ApiClient class
    public async Task<ApiResponse<JobCostsQueryResponse>> GetJobCostsQuery(
        Guid? businessUnitId = null,
        IEnumerable<Guid>? costCodeIds = null,
        IEnumerable<Guid>? jobIds = null,
        IEnumerable<Guid>? jobTagIds = null,
        IEnumerable<Guid>? foremanIds = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        string? cursor = null,
        int? limit = null,
        CancellationToken cancellationToken = default)
    {
        var request = new
        {
            businessUnitId,
            costCodeIds,
            jobIds,
            jobTagIds,
            foremanIds,
            startDate,
            endDate,
            cursor,
            limit
        };

        var response = await _httpClient.PostAsJsonAsync(
            "heavyjob/api/v2/jobCosts/advancedRequest",
            request,
            cancellationToken);

        return new ApiResponse<JobCostsQueryResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<JobCostsQueryResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    // Add this method to the ApiClient class
    public async Task<ApiResponse<JobCostsToDateResponse>> GetJobCostsToDate(
        Guid? businessUnitId = null,
        IEnumerable<Guid>? costCodeIds = null,
        IEnumerable<Guid>? jobIds = null,
        IEnumerable<Guid>? jobTagIds = null,
        IEnumerable<Guid>? foremanIds = null,
        IEnumerable<Guid>? costCodeTagIds = null,
        string? cursor = null,
        int? limit = null,
        CancellationToken cancellationToken = default)
    {
        var request = new
        {
            businessUnitId,
            costCodeIds,
            jobIds,
            jobTagIds,
            foremanIds,
            costCodeTagIds,
            cursor,
            limit
        };

        var response = await _httpClient.PostAsJsonAsync(
            "heavyjob/api/v1/jobCostsToDate/search",
            request,
            cancellationToken);

        return new ApiResponse<JobCostsToDateResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<JobCostsToDateResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    // Add this method to the ApiClient class
    public async Task<ApiResponse<JobCustomCostTypeItemDataObject>> GetJobCustomCostTypeItem(
        Guid id,
        bool? isDeleted = null,
        bool? isDiscontinued = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (isDeleted.HasValue)
            queryParams.Add($"isDeleted={isDeleted.Value}");
        if (isDiscontinued.HasValue)
            queryParams.Add($"isDiscontinued={isDiscontinued.Value}");

        var url = $"heavyjob/api/v1/costTypes/jobCustom/{id}";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<JobCustomCostTypeItemDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<JobCustomCostTypeItemDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    // Add this method to the ApiClient class
    public async Task<ApiResponse<JobCustomCostTypeItemDataObject>> CreateJobCustomCostTypeItem(
        Guid jobId,
        CreateJobCustomCostTypeItemActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync(
            $"heavyjob/api/v1/jobs/{jobId}/costTypes/jobCustom",
            new
            {
                input.CustomCostTypeItemId,
                input.Description,
                input.SalesTaxPercent,
                input.UnitCost,
                input.UnitOfMeasure,
                input.AccountingCode
            },
            cancellationToken);

        return new ApiResponse<JobCustomCostTypeItemDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<JobCustomCostTypeItemDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    // Add this method to the ApiClient class
    public async Task<ApiResponse> DeleteJobCustomCostTypeItem(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.DeleteAsync(
            $"heavyjob/api/v1/costTypes/jobCustom/{id}",
            cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<object>> UpdateJobCustomCostTypeItem(
        Guid id,
        UpdateJobCustomCostTypeItemActionInput input,
        CancellationToken cancellationToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Put, $"api/v1/costTypes/jobCustom/{id}")
        {
            Content = new StringContent(
                JsonSerializer.Serialize(input),
                Encoding.UTF8,
                "application/json")
        };

        return await SendAsync<object>(request, cancellationToken);
    }

    // Add this method to the ApiClient class
    private async Task<ApiResponse<T>> SendAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await _httpClient.SendAsync(request, cancellationToken);
        
        return new ApiResponse<T>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<T>(cancellationToken: cancellationToken)
                : default,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<JobCustomCostTypeItemsDataObject>>> GetJobCustomCostTypeItems(
        Guid jobId,
        bool? isDeleted = null,
        bool? isDiscontinued = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (isDeleted.HasValue)
            queryParams.Add($"isDeleted={isDeleted.Value}");
        if (isDiscontinued.HasValue)
            queryParams.Add($"isDiscontinued={isDiscontinued.Value}");

        var url = $"heavyjob/api/v1/jobs/{jobId}/costTypes/jobCustom";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<JobCustomCostTypeItemsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<JobCustomCostTypeItemsDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public class JobEmployeesResponse
    {
        [JsonPropertyName("results")]
        public JobEmployeesDataObject[] Results { get; init; } = Array.Empty<JobEmployeesDataObject>();

        [JsonPropertyName("metadata")]
        public JobEmployeesMetadata Metadata { get; init; } = new();
    }

    public class JobEmployeesMetadata
    {
        [JsonPropertyName("nextCursor")]
        public string? NextCursor { get; init; }
    }

    // Add this method to the ApiClient class
    public async Task<ApiResponse<JobEmployeesResponse>> GetJobEmployees(
        Guid? businessUnitId = null,
        Guid? jobId = null,
        Guid? employeeId = null,
        int? limit = 1000,
        string? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (businessUnitId.HasValue)
            queryParams.Add($"businessUnitId={businessUnitId}");
        if (jobId.HasValue)
            queryParams.Add($"jobId={jobId}");
        if (employeeId.HasValue)
            queryParams.Add($"employeeId={employeeId}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit}");
        if (!string.IsNullOrEmpty(cursor))
            queryParams.Add($"cursor={cursor}");

        var url = "heavyjob/api/v1/jobEmployees";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<JobEmployeesResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<JobEmployeesResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse> DeleteJobEmployees(
        Guid businessUnitId,
        Guid? jobId = null,
        Guid? employeeId = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>
        {
            $"businessUnitId={businessUnitId}"
        };
        
        if (jobId.HasValue)
            queryParams.Add($"jobId={jobId}");
        if (employeeId.HasValue)
            queryParams.Add($"employeeId={employeeId}");

        var url = "heavyjob/api/v1/jobEmployees";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.DeleteAsync(url, cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse> UpdateJobEmployees(
        Guid businessUnitId,
        JobEmployeeRelation[] relations,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/jobEmployees?businessUnitId={businessUnitId}";

        var request = new HttpRequestMessage(HttpMethod.Patch, url)
        {
            Content = JsonContent.Create(relations)
        };

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public class JobEquipmentResponse
    {
        [JsonPropertyName("results")]
        public JobEquipmentDataObject[] Results { get; init; } = Array.Empty<JobEquipmentDataObject>();

        [JsonPropertyName("metadata")]
        public JobEquipmentMetadata Metadata { get; init; } = new();
    }

    public class JobEquipmentMetadata
    {
        [JsonPropertyName("nextCursor")]
        public string? NextCursor { get; init; }
    }

    public async Task<ApiResponse<JobEquipmentResponse>> GetJobEquipment(
        Guid? businessUnitId = null,
        Guid? jobId = null,
        Guid? equipmentId = null,
        int? limit = 1000,
        string? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (businessUnitId.HasValue)
            queryParams.Add($"businessUnitId={businessUnitId}");
        if (jobId.HasValue)
            queryParams.Add($"jobId={jobId}");
        if (equipmentId.HasValue)
            queryParams.Add($"equipmentId={equipmentId}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit}");
        if (!string.IsNullOrEmpty(cursor))
            queryParams.Add($"cursor={cursor}");

        var url = "heavyjob/api/v1/jobEquipment";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<JobEquipmentResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<JobEquipmentResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse> DeleteJobEquipment(
        Guid businessUnitId,
        Guid? jobId = null,
        Guid? equipmentId = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>
        {
            $"businessUnitId={businessUnitId}"
        };
        
        if (jobId.HasValue)
            queryParams.Add($"jobId={jobId}");
        if (equipmentId.HasValue)
            queryParams.Add($"equipmentId={equipmentId}");

        var url = "heavyjob/api/v1/jobEquipment";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.DeleteAsync(url, cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse> UpdateJobEquipment(
        Guid businessUnitId,
        JobEquipmentRelation[] relations,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/jobEquipment?businessUnitId={businessUnitId}";

        var request = new HttpRequestMessage(HttpMethod.Patch, url)
        {
            Content = JsonContent.Create(relations)
        };

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public class JobMaterialResponse
    {
        [JsonPropertyName("results")]
        public JobMaterialDataObject[] Results { get; init; } = Array.Empty<JobMaterialDataObject>();

        [JsonPropertyName("metadata")]
        public JobMaterialMetadata Metadata { get; init; } = new();
    }

    public class JobMaterialMetadata
    {
        [JsonPropertyName("nextCursor")]
        public string? NextCursor { get; init; }
    }

    public async Task<ApiResponse<JobMaterialResponse>> GetJobMaterial(
        Guid? id = null,
        bool? isDeleted = null,
        bool? isDiscontinued = null,
        string? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (isDeleted.HasValue)
            queryParams.Add($"isDeleted={isDeleted}");
        if (isDiscontinued.HasValue)
            queryParams.Add($"isDiscontinued={isDiscontinued}");
        if (!string.IsNullOrEmpty(cursor))
            queryParams.Add($"cursor={cursor}");

        var url = id.HasValue 
            ? $"heavyjob/api/v1/costTypes/jobMaterial/{id}"
            : "heavyjob/api/v1/costTypes/jobMaterial";

        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<JobMaterialResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<JobMaterialResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<JobMaterialDataObject>> CreateJobMaterial(
        Guid jobId,
        CreateJobMaterialActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/jobs/{jobId}/costTypes/jobMaterial";

        var response = await _httpClient.PostAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<JobMaterialDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<JobMaterialDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse> DeleteJobMaterial(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/costTypes/jobMaterial/{id}";

        var response = await _httpClient.DeleteAsync(url, cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<JobMaterialDataObject>> UpdateJobMaterial(
        Guid id,
        UpdateJobMaterialActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/costTypes/jobMaterial/{id}";

        var response = await _httpClient.PutAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<JobMaterialDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<JobMaterialDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<JobMaterialsDataObject>>> GetJobMaterials(
        Guid jobId,
        bool? isDiscontinued = null,
        bool? isDeleted = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (isDiscontinued.HasValue)
            queryParams.Add($"isDiscontinued={isDiscontinued}");
        if (isDeleted.HasValue)
            queryParams.Add($"isDeleted={isDeleted}");

        var url = $"heavyjob/api/v1/jobs/{jobId}/costTypes/jobMaterial";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<JobMaterialsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<JobMaterialsDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<HeavyJob.v1.Jobs.JobsDataObject>>> GetJobs(
        Guid? businessUnitId = null,
        string? jobStatus = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (businessUnitId.HasValue)
            queryParams.Add($"businessUnitId={businessUnitId}");
        if (!string.IsNullOrEmpty(jobStatus))
            queryParams.Add($"jobStatus={jobStatus}");

        var url = "heavyjob/api/v1/jobs";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<HeavyJob.v1.Jobs.JobsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<HeavyJob.v1.Jobs.JobsDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

        public async Task<ApiResponse<Guid>> UpdateJobs(
            HeavyJob.v1.Jobs.Update.UpdateJobsActionInput input,
            CancellationToken cancellationToken = default)
        {
            var url = "heavyjob/api/v1/jobs";
            var response = await _httpClient.PatchAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<Guid>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<Guid>(cancellationToken: cancellationToken)
                : Guid.Empty,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<JobsAdvancedDataObject>>> GetJobsAdvanced(
        Guid[]? jobIds = null,
        Guid[]? jobTagIds = null,
        bool? isDeleted = null,
        bool? isIncludeHBCodeList = null,
        string[]? jobStatuses = null,
        CancellationToken cancellationToken = default)
    {
        var url = "heavyjob/api/v1/jobs/advanced";
        var request = new
        {
            jobIds,
            jobTagIds,
            isDeleted,
            isIncludeHBCodeList,
            jobStatuses
        };

        var response = await _httpClient.PostAsJsonAsync(url, request, cancellationToken);

        return new ApiResponse<IEnumerable<JobsAdvancedDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<JobsAdvancedDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<JobSubcontractDataObject>> GetJobSubcontract(
        Guid id,
        bool? isDeleted = null,
        bool? isDiscontinued = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (isDeleted.HasValue)
            queryParams.Add($"isDeleted={isDeleted}");
        if (isDiscontinued.HasValue)
            queryParams.Add($"isDiscontinued={isDiscontinued}");

        var url = $"heavyjob/api/v1/costTypes/jobSubcontract/{id}";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<JobSubcontractDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<JobSubcontractDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<JobSubcontractDataObject>> CreateJobSubcontract(
        Guid jobId,
        CreateJobSubcontractActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/jobs/{jobId}/costTypes/jobSubcontract";

        var response = await _httpClient.PostAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<JobSubcontractDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<JobSubcontractDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse> DeleteJobSubcontract(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/costTypes/jobSubcontract/{id}";

        var response = await _httpClient.DeleteAsync(url, cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<JobSubcontractDataObject>> UpdateJobSubcontract(
        Guid id,
        UpdateJobSubcontractActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/costTypes/jobSubcontract/{id}";

        var response = await _httpClient.PutAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<JobSubcontractDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<JobSubcontractDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<JobSubcontractsDataObject>>> GetJobSubcontracts(
        Guid jobId,
        bool? isDeleted = null,
        bool? isDiscontinued = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (isDeleted.HasValue)
            queryParams.Add($"isDeleted={isDeleted}");
        if (isDiscontinued.HasValue)
            queryParams.Add($"isDiscontinued={isDiscontinued}");

        var url = $"heavyjob/api/v1/jobs/{jobId}/costTypes/jobSubcontract";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<JobSubcontractsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<JobSubcontractsDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<MaterialPurchaseOrderDetailsDataObject>>> GetMaterialPurchaseOrderDetails(
        Guid purchaseOrderId,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/purchaseOrders/{purchaseOrderId}/details/material";

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<MaterialPurchaseOrderDetailsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<MaterialPurchaseOrderDetailsDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<MaterialPurchaseOrderDetailsDataObject>> CreateMaterialPurchaseOrderDetail(
        Guid purchaseOrderId,
        CreateMaterialPurchaseOrderDetailsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/purchaseOrders/{purchaseOrderId}/details/material";

        var response = await _httpClient.PostAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<MaterialPurchaseOrderDetailsDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<MaterialPurchaseOrderDetailsDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    // Add this method to the ApiClient class
    public async Task<ApiResponse> UpdateMaterialPurchaseOrderDetail(
        Guid id,
        UpdateMaterialPurchaseOrderDetailsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/purchaseOrders/details/material/{id}";

        var response = await _httpClient.PutAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<HeavyJob.v1.Materials.MaterialsDataObject>>> GetMaterials(
        Guid businessUnitId,
        bool? isDeleted = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (isDeleted.HasValue)
            queryParams.Add($"isDeleted={isDeleted}");

        var url = $"heavyjob/api/v1/businessUnits/{businessUnitId}/costTypes/material";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<HeavyJob.v1.Materials.MaterialsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<HeavyJob.v1.Materials.MaterialsDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<HeavyJob.v1.Materials.MaterialsDataObject>> CreateMaterial(
        Guid businessUnitId,
        CreateMaterialsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/businessUnits/{businessUnitId}/costTypes/material";

        var response = await _httpClient.PostAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<HeavyJob.v1.Materials.MaterialsDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<HeavyJob.v1.Materials.MaterialsDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse> DeleteMaterial(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/costTypes/material/{id}";

        var response = await _httpClient.DeleteAsync(url, cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    // Add this method to the ApiClient class
    public async Task<ApiResponse<HeavyJob.v1.Materials.MaterialsDataObject>> UpdateMaterial(
        Guid id,
        UpdateMaterialsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/costTypes/material/{id}";

        var response = await _httpClient.PutAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<HeavyJob.v1.Materials.MaterialsDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<HeavyJob.v1.Materials.MaterialsDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<MaterialsInstalledResponse>> GetMaterialsInstalled(
        MaterialsInstalledRequest request,
        CancellationToken cancellationToken = default)
    {
        var url = "heavyjob/api/v1/costTypes/materialInstalled/advancedRequest";

        var response = await _httpClient.PostAsJsonAsync(url, request, cancellationToken);

        return new ApiResponse<MaterialsInstalledResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<MaterialsInstalledResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<MaterialsInstalledQuantitiesResponse>> GetMaterialsInstalledQuantities(
        MaterialsInstalledQuantitiesRequest request,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (request.JobId.HasValue)
            queryParams.Add($"jobId={request.JobId}");
        if (request.ForemanId.HasValue)
            queryParams.Add($"foremanId={request.ForemanId}");
        if (request.StartDate.HasValue)
            queryParams.Add($"startDate={request.StartDate:yyyy-MM-ddTHH:mm:ssZ}");
        if (request.EndDate.HasValue)
            queryParams.Add($"endDate={request.EndDate:yyyy-MM-ddTHH:mm:ssZ}");
        if (request.ModifiedSince.HasValue)
            queryParams.Add($"modifiedSince={request.ModifiedSince:yyyy-MM-ddTHH:mm:ssZ}");
        if (request.Limit.HasValue)
            queryParams.Add($"limit={request.Limit}");
        if (!string.IsNullOrEmpty(request.Cursor))
            queryParams.Add($"cursor={request.Cursor}");

        var url = "heavyjob/api/v1/costTypeQuantities/materialInstalled";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<MaterialsInstalledQuantitiesResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<MaterialsInstalledQuantitiesResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<MaterialsReceivedResponse>> GetMaterialsReceived(
        MaterialsReceivedRequest request,
        CancellationToken cancellationToken = default)
    {
        var url = "heavyjob/api/v1/costTypes/materialReceived/advancedRequest";

        var response = await _httpClient.PostAsJsonAsync(url, request, cancellationToken);

        return new ApiResponse<MaterialsReceivedResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<MaterialsReceivedResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse> UpdateMaterialSubsAndCustomCosts(
        UpdateMaterialSubsAndCustomCostsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "heavyjob/api/v1/costTypeItems";

        var request = new HttpRequestMessage(HttpMethod.Patch, url)
        {
            Content = JsonContent.Create(input)
        };

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<MissingTimeCardForemenDataObject>>> GetMissingTimeCardForemen(
        Guid businessUnitId,
        DateTime startDate,
        DateTime endDate,
        DateTime targetDate,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>
        {
            $"startDate={startDate:yyyy-MM-dd}",
            $"endDate={endDate:yyyy-MM-dd}",
            $"targetDate={targetDate:yyyy-MM-dd}"
        };

        var url = $"heavyjob/api/v1/businessUnits/{businessUnitId}/missingTimeCards";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<MissingTimeCardForemenDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<MissingTimeCardForemenDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<MobileChangeOrdersByBusinessUnitDataObject>>> GetMobileChangeOrdersByBusinessUnit(
        Guid businessUnitId,
        DateTime? lastSyncTime = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>
        {
            $"id={businessUnitId}"
        };

        if (lastSyncTime.HasValue)
            queryParams.Add($"lastSyncTime={lastSyncTime.Value:yyyy-MM-ddTHH:mm:ssZ}");

        var url = "heavyjob/api/v1/changeOrderChangesByBU";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<MobileChangeOrdersByBusinessUnitDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<MobileChangeOrdersByBusinessUnitDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<NonuseHourTagsDataObject>>> GetNonuseHourTags(
        Guid businessUnitId,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/businessUnits/{businessUnitId}/nonuseHourTags";

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<NonuseHourTagsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<NonuseHourTagsDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<PayClassDataObject>>> GetPayClasses(
        Guid businessUnitId,
        bool? isActive = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (isActive.HasValue)
            queryParams.Add($"isActive={isActive.Value}");

        var url = $"heavyjob/api/v1/businessUnits/{businessUnitId}/payclass";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<PayClassDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<PayClassDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse> UpdatePayClass(
        Guid id,
        HeavyJob.v1.PayClass.Update.UpdatePayClassActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/payClasses/{id}";

        var request = new HttpRequestMessage(HttpMethod.Patch, url)
        {
            Content = JsonContent.Create(input)
        };

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<PayItemsResponse>> GetPayItems(
        Guid? jobId = null,
        bool? isDeleted = null,
        int? limit = null,
        string? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (jobId.HasValue)
            queryParams.Add($"jobId={jobId}");
        if (isDeleted.HasValue)
            queryParams.Add($"isDeleted={isDeleted.Value}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit}");
        if (!string.IsNullOrEmpty(cursor))
            queryParams.Add($"cursor={cursor}");

        var url = "heavyjob/api/v1/payItems";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<PayItemsResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<PayItemsResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public record PayItemsResponse
    {
        [JsonPropertyName("results")]
        [Required]
        public required PayItemsDataObject[] Results { get; init; }

        [JsonPropertyName("metadata")]
        [Required]
        public required PayItemsResponseMetadata Metadata { get; init; }
    }

    public record PayItemsResponseMetadata
    {
        [JsonPropertyName("nextCursor")]
        public string? NextCursor { get; init; }
    }

    // Add this method to the ApiClient class
    public async Task<ApiResponse<CreatePayItemsActionOutput>> CreatePayItem(
        CreatePayItemsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "heavyjob/api/v1/payItems";

        var response = await _httpClient.PostAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<CreatePayItemsActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CreatePayItemsActionOutput>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse> UpdatePayItems(
        UpdatePayItemsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (input.CreateOnly)
            queryParams.Add("createOnly=true");
        if (input.AddToExisting)
            queryParams.Add("addToExisting=true");

        var url = "heavyjob/api/v1/payItems";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var request = new HttpRequestMessage(HttpMethod.Patch, url)
        {
            Content = JsonContent.Create(input.PayItems)
        };

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<PurchaseOrderItemsResponse>> GetPurchaseOrderItems(
        Guid? businessUnitId = null,
        Guid? jobId = null,
        Guid? purchaseOrderId = null,
        DateTime? modifiedSince = null,
        bool? isDeleted = null,
        int? limit = 1000,
        string? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (businessUnitId.HasValue)
            queryParams.Add($"businessUnitId={businessUnitId}");
        if (jobId.HasValue)
            queryParams.Add($"jobId={jobId}");
        if (purchaseOrderId.HasValue)
            queryParams.Add($"purchaseOrderId={purchaseOrderId}");
        if (modifiedSince.HasValue)
            queryParams.Add($"modifiedSince={modifiedSince.Value:yyyy-MM-ddTHH:mm:ssZ}");
        if (isDeleted.HasValue)
            queryParams.Add($"isDeleted={isDeleted.Value}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit}");
        if (!string.IsNullOrEmpty(cursor))
            queryParams.Add($"cursor={cursor}");

        var url = "heavyjob/api/v1/purchaseOrderItems";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<PurchaseOrderItemsResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<PurchaseOrderItemsResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public record PurchaseOrderItemsResponse
    {
        [JsonPropertyName("results")]
        [Required]
        public required PurchaseOrderItemsDataObject[] Results { get; init; }

        [JsonPropertyName("metadata")]
        [Required]
        public required PurchaseOrderItemsResponseMetadata Metadata { get; init; }
    }

    public record PurchaseOrderItemsResponseMetadata
    {
        [JsonPropertyName("nextCursor")]
        public string? NextCursor { get; init; }
    }

    public async Task<ApiResponse<PurchaseOrdersResponse>> GetPurchaseOrders(
        Guid? businessUnitId = null,
        Guid? jobId = null,
        Guid? purchaseOrderId = null,
        DateTime? modifiedSince = null,
        bool? isDeleted = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        int? limit = 1000,
        string? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (businessUnitId.HasValue)
            queryParams.Add($"businessUnitId={businessUnitId}");
        if (jobId.HasValue)
            queryParams.Add($"jobId={jobId}");
        if (purchaseOrderId.HasValue)
            queryParams.Add($"purchaseOrderId={purchaseOrderId}");
        if (modifiedSince.HasValue)
            queryParams.Add($"modifiedSince={Uri.EscapeDataString(modifiedSince.Value.ToString("O"))}");
        if (isDeleted.HasValue)
            queryParams.Add($"isDeleted={isDeleted.Value.ToString().ToLower()}");
        if (startDate.HasValue)
            queryParams.Add($"startDate={Uri.EscapeDataString(startDate.Value.ToString("O"))}");
        if (endDate.HasValue)
            queryParams.Add($"endDate={Uri.EscapeDataString(endDate.Value.ToString("O"))}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit}");
        if (!string.IsNullOrEmpty(cursor))
            queryParams.Add($"cursor={cursor}");

        var url = "heavyjob/api/v1/purchaseOrders";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<PurchaseOrdersResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<PurchaseOrdersResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public record PurchaseOrdersResponse
    {
        [JsonPropertyName("results")]
        [Required]
        public required HeavyJob.v1.PurchaseOrders.PurchaseOrdersDataObject[] Results { get; init; }

        [JsonPropertyName("metadata")]
        [Required]
        public required PurchaseOrdersResponseMetadata Metadata { get; init; }
    }

    public record PurchaseOrdersResponseMetadata
    {
        [JsonPropertyName("nextCursor")]
        public string? NextCursor { get; init; }
    }

    public async Task<ApiResponse<CreatePurchaseOrdersActionOutput>> CreatePurchaseOrder(
        Guid jobId,
        CreatePurchaseOrdersActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/jobs/{jobId}/purchaseOrders";

        var response = await _httpClient.PostAsJsonAsync(url, new
        {
            purchaseOrder = input.PurchaseOrder,
            orderStatus = input.OrderStatus,
            dateIssued = input.DateIssued,
            description = input.Description,
            vendorId = input.VendorId
        }, cancellationToken);

        return new ApiResponse<CreatePurchaseOrdersActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CreatePurchaseOrdersActionOutput>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<object>> UpdatePurchaseOrder(
        Guid id,
        UpdatePurchaseOrdersActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/purchaseOrders/{id}";

        var response = await _httpClient.PutAsJsonAsync(url, new
        {
            purchaseOrder = input.PurchaseOrder,
            orderStatus = input.OrderStatus,
            dateIssued = input.DateIssued,
            description = input.Description,
            vendorId = input.VendorId
        }, cancellationToken);

        return new ApiResponse<object>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<object>> CreateQuantityAdjustment(
        CreateQuantityAdjustmentActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "heavyjob/api/v1/quantityAdjustment";

        var response = await _httpClient.PostAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<object>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<QuantityAdjustmentsResponse>> GetQuantityAdjustments(
        Guid? jobId = null,
        Guid? foremanId = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        DateTime? modifiedSince = null,
        int? limit = 1000,
        string? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (jobId.HasValue)
            queryParams.Add($"jobId={jobId}");
        if (foremanId.HasValue)
            queryParams.Add($"foremanId={foremanId}");
        if (startDate.HasValue)
            queryParams.Add($"startDate={Uri.EscapeDataString(startDate.Value.ToString("O"))}");
        if (endDate.HasValue)
            queryParams.Add($"endDate={Uri.EscapeDataString(endDate.Value.ToString("O"))}");
        if (modifiedSince.HasValue)
            queryParams.Add($"modifiedSince={Uri.EscapeDataString(modifiedSince.Value.ToString("O"))}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit}");
        if (!string.IsNullOrEmpty(cursor))
            queryParams.Add($"cursor={cursor}");

        var url = "heavyjob/api/v1/costTypeQuantities/adjustments";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<QuantityAdjustmentsResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<QuantityAdjustmentsResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public record QuantityAdjustmentsResponse
    {
        [JsonPropertyName("results")]
        [Required]
        public required QuantityAdjustmentsDataObject[] Results { get; init; }

        [JsonPropertyName("metadata")]
        [Required]
        public required QuantityAdjustmentsResponseMetadata Metadata { get; init; }
    }

    public record QuantityAdjustmentsResponseMetadata
    {
        [JsonPropertyName("nextCursor")]
        public string? NextCursor { get; init; }
    }

    public async Task<ApiResponse<RateSetGroupAccountingResponse>> GetRateSetGroupAccountingValues(
        Guid businessUnitId,
        Guid rateSetGroupId,
        Guid[]? entityIds = null,
        string? entityType = null,
        int? limit = 1000,
        string? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var url = "heavyjob/api/v1/rateSetGroupAccountingValues/search";

        var response = await _httpClient.PostAsJsonAsync(url, new
        {
            businessUnitId = businessUnitId,
            rateSetGroupId = rateSetGroupId,
            entityIds = entityIds,
            entityType = entityType,
            limit = limit,
            cursor = cursor
        }, cancellationToken);

        return new ApiResponse<RateSetGroupAccountingResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<RateSetGroupAccountingResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public record RateSetGroupAccountingResponse
    {
        [JsonPropertyName("results")]
        [Required]
        public required RateSetGroupAccountingDataObject[] Results { get; init; }

        [JsonPropertyName("metadata")]
        [Required]
        public required RateSetGroupAccountingResponseMetadata Metadata { get; init; }
    }

    public record RateSetGroupAccountingResponseMetadata
    {
        [JsonPropertyName("nextCursor")]
        public string? NextCursor { get; init; }
    }

    public async Task<ApiResponse<object>> DeleteReleaseOrderApprovalRuleApprovers(
        Guid[] approverIds,
        CancellationToken cancellationToken = default)
    {
        var url = "heavyjob/api/v1/releaseOrders/approvalRules/approvers";

        var request = new HttpRequestMessage(HttpMethod.Delete, url)
        {
            Content = JsonContent.Create(approverIds)
        };

        var response = await _httpClient.SendAsync(request, cancellationToken);

        return new ApiResponse<object>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<SetupFiltersDataObject[]>> GetSetupFilters(
        Guid businessUnitId,
        DateTime? modifiedSince = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>
        {
            $"businessUnitId={businessUnitId}"
        };
        
        if (modifiedSince.HasValue)
            queryParams.Add($"modifiedSince={Uri.EscapeDataString(modifiedSince.Value.ToString("O"))}");

        var url = "heavyjob/api/v1/costCodeSetupFilters";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<SetupFiltersDataObject[]>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<SetupFiltersDataObject[]>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<SubcontractsDataObject[]>> GetSubcontracts(
        Guid businessUnitId,
        bool? isDeleted = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (isDeleted.HasValue)
            queryParams.Add($"isDeleted={isDeleted.Value.ToString().ToLower()}");

        var url = $"heavyjob/api/v1/businessUnits/{businessUnitId}/costTypes/subcontract";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<SubcontractsDataObject[]>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<SubcontractsDataObject[]>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CreateSubcontractsActionOutput>> CreateSubcontract(
        Guid businessUnitId,
        CreateSubcontractsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/businessUnits/{businessUnitId}/costTypes/subcontract";

        var response = await _httpClient.PostAsJsonAsync(url, new
        {
            code = input.Code,
            description = input.Description,
            heavyBidCode = input.HeavyBidCode
        }, cancellationToken);

        return new ApiResponse<CreateSubcontractsActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CreateSubcontractsActionOutput>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<object>> DeleteSubcontract(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/costTypes/subcontract/{id}";

        var response = await _httpClient.DeleteAsync(url, cancellationToken);

        return new ApiResponse<object>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<object>> UpdateSubcontract(
        Guid id,
        UpdateSubcontractsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/costTypes/subcontract/{id}";

        var response = await _httpClient.PutAsJsonAsync(url, new
        {
            code = input.Code,
            description = input.Description,
            heavyBidCode = input.HeavyBidCode
        }, cancellationToken);

        return new ApiResponse<object>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<SubcontractTransactionsResponse>> GetSubcontractTransactions(
        Guid businessUnitId,
        Guid[]? jobIds = null,
        Guid[]? jobTagIds = null,
        Guid[]? foremanIds = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        Guid[]? costCodeIds = null,
        DateTime? modifiedSince = null,
        bool? onlyTM = null,
        int? limit = 1000,
        string? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var url = "heavyjob/api/v1/costTypes/subcontractWork/advancedRequest";

        var response = await _httpClient.PostAsJsonAsync(url, new
        {
            businessUnitId = businessUnitId,
            jobIds = jobIds,
            jobTagIds = jobTagIds,
            foremanIds = foremanIds,
            startDate = startDate,
            endDate = endDate,
            costCodeIds = costCodeIds,
            modifiedSince = modifiedSince,
            onlyTM = onlyTM,
            limit = limit,
            cursor = cursor
        }, cancellationToken);

        return new ApiResponse<SubcontractTransactionsResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<SubcontractTransactionsResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public record SubcontractTransactionsResponse
    {
        [JsonPropertyName("results")]
        [Required]
        public required SubcontractTransactionsDataObject[] Results { get; init; }

        [JsonPropertyName("metadata")]
        [Required]
        public required SubcontractTransactionsResponseMetadata Metadata { get; init; }
    }

    public record SubcontractTransactionsResponseMetadata
    {
        [JsonPropertyName("nextCursor")]
        public string? NextCursor { get; init; }
    }

    public async Task<ApiResponse<SubcontractWorkQuantitiesResponse>> GetSubcontractWorkQuantities(
        Guid? jobId = null,
        Guid? foremanId = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        DateTime? modifiedSince = null,
        int? limit = 1000,
        string? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (jobId.HasValue)
            queryParams.Add($"jobId={jobId}");
        if (foremanId.HasValue)
            queryParams.Add($"foremanId={foremanId}");
        if (startDate.HasValue)
            queryParams.Add($"startDate={Uri.EscapeDataString(startDate.Value.ToString("O"))}");
        if (endDate.HasValue)
            queryParams.Add($"endDate={Uri.EscapeDataString(endDate.Value.ToString("O"))}");
        if (modifiedSince.HasValue)
            queryParams.Add($"modifiedSince={Uri.EscapeDataString(modifiedSince.Value.ToString("O"))}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit}");
        if (!string.IsNullOrEmpty(cursor))
            queryParams.Add($"cursor={cursor}");

        var url = "heavyjob/api/v1/costTypeQuantities/subcontractWorked";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<SubcontractWorkQuantitiesResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<SubcontractWorkQuantitiesResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public record SubcontractWorkQuantitiesResponse
    {
        [JsonPropertyName("results")]
        [Required]
        public required SubcontractWorkQuantitiesDataObject[] Results { get; init; }

        [JsonPropertyName("metadata")]
        [Required]
        public required SubcontractWorkQuantitiesResponseMetadata Metadata { get; init; }
    }

    public record SubcontractWorkQuantitiesResponseMetadata
    {
        [JsonPropertyName("nextCursor")]
        public string? NextCursor { get; init; }
    }

    public async Task<ApiResponse<HeavyJob.v1.TimeCard.TimeCardDataObject>> GetTimeCard(
        Guid timeCardId,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/timeCards/{timeCardId}";

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<HeavyJob.v1.TimeCard.TimeCardDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<HeavyJob.v1.TimeCard.TimeCardDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<object>> UpdateTimeCard(
        Guid id,
        UpdateTimeCardActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/timeCards/{id}";

        var response = await _httpClient.PutAsJsonAsync(url, new
        {
            sentToPayrollRevision = input.SentToPayrollRevision,
            sentToPayrollDateTime = input.SentToPayrollDateTime
        }, cancellationToken);

        return new ApiResponse<object>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<TimeCardApprovalResponse>> GetTimeCardApprovals(
        Guid? jobId = null,
        Guid? foremanId = null,
        Guid? employeeId = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        DateTime? modifiedSince = null,
        int? limit = 1000,
        string? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (jobId.HasValue)
            queryParams.Add($"jobId={jobId}");
        if (foremanId.HasValue)
            queryParams.Add($"foremanId={foremanId}");
        if (employeeId.HasValue)
            queryParams.Add($"employeeId={employeeId}");
        if (startDate.HasValue)
            queryParams.Add($"startDate={Uri.EscapeDataString(startDate.Value.ToString("O"))}");
        if (endDate.HasValue)
            queryParams.Add($"endDate={Uri.EscapeDataString(endDate.Value.ToString("O"))}");
        if (modifiedSince.HasValue)
            queryParams.Add($"modifiedSince={Uri.EscapeDataString(modifiedSince.Value.ToString("O"))}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit}");
        if (!string.IsNullOrEmpty(cursor))
            queryParams.Add($"cursor={cursor}");

        var url = "heavyjob/api/v1/timeCardApprovalInfo";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<TimeCardApprovalResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<TimeCardApprovalResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public record TimeCardApprovalResponse
    {
        [JsonPropertyName("results")]
        [Required]
        public required TimeCardApprovalDataObject[] Results { get; init; }

        [JsonPropertyName("metadata")]
        [Required]
        public required TimeCardApprovalResponseMetadata Metadata { get; init; }
    }

    public record TimeCardApprovalResponseMetadata
    {
        [JsonPropertyName("nextCursor")]
        public string? NextCursor { get; init; }
    }

    public async Task<ApiResponse<TimeCardInfoResponse>> GetTimeCardInfo(
        Guid? jobId = null,
        Guid? foremanId = null,
        Guid? employeeId = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        DateTime? modifiedSince = null,
        bool? onlyTM = null,
        int? limit = 1000,
        string? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (jobId.HasValue)
            queryParams.Add($"jobId={jobId}");
        if (foremanId.HasValue)
            queryParams.Add($"foremanId={foremanId}");
        if (employeeId.HasValue)
            queryParams.Add($"employeeId={employeeId}");
        if (startDate.HasValue)
            queryParams.Add($"startDate={Uri.EscapeDataString(startDate.Value.ToString("O"))}");
        if (endDate.HasValue)
            queryParams.Add($"endDate={Uri.EscapeDataString(endDate.Value.ToString("O"))}");
        if (modifiedSince.HasValue)
            queryParams.Add($"modifiedSince={Uri.EscapeDataString(modifiedSince.Value.ToString("O"))}");
        if (onlyTM.HasValue)
            queryParams.Add($"onlyTM={onlyTM.Value.ToString().ToLower()}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit}");
        if (!string.IsNullOrEmpty(cursor))
            queryParams.Add($"cursor={cursor}");

        var url = "heavyjob/api/v1/timeCardInfo";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<TimeCardInfoResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<TimeCardInfoResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public record TimeCardInfoResponse
    {
        [JsonPropertyName("results")]
        [Required]
        public required TimeCardInfoDataObject[] Results { get; init; }

        [JsonPropertyName("metadata")]
        [Required]
        public required TimeCardInfoResponseMetadata Metadata { get; init; }
    }

    public record TimeCardInfoResponseMetadata
    {
        [JsonPropertyName("nextCursor")]
        public string? NextCursor { get; init; }
    }

    public async Task<ApiResponse<TimeCardsForEquipmentDataObject[]>> GetTimeCardsForEquipment(
        DateTime date,
        Guid? equipmentId = null,
        string? equipmentCode = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (equipmentId.HasValue)
            queryParams.Add($"equipmentId={equipmentId}");
        if (!string.IsNullOrEmpty(equipmentCode))
            queryParams.Add($"equipmentCode={equipmentCode}");
        queryParams.Add($"date={Uri.EscapeDataString(date.ToString("O"))}");

        var url = "heavyjob/api/v1/timeCardEquipment";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<TimeCardsForEquipmentDataObject[]>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<TimeCardsForEquipmentDataObject[]>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<UserDataObject>> GetUser(
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/users/{userId}";

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<UserDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<UserDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<UserAccessGroupDataObject[]>> GetUserAccessGroups(
        Guid[] userIds,
        CancellationToken cancellationToken = default)
    {
        var url = "heavyjob/api/v1/userAccessGroup/search";

        var response = await _httpClient.PostAsJsonAsync(url, new
        {
            userIds = userIds
        }, cancellationToken);

        return new ApiResponse<UserAccessGroupDataObject[]>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<UserAccessGroupDataObject[]>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<UpdateUserAccessGroupActionOutput[]>> UpdateUserAccessGroups(
        UpdateUserAccessGroupActionInput[] input,
        CancellationToken cancellationToken = default)
    {
        var url = "heavyjob/api/v1/userAccessGroup";

        var response = await _httpClient.PatchAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<UpdateUserAccessGroupActionOutput[]>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<UpdateUserAccessGroupActionOutput[]>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<VendorContractDetailsDataObject[]>> GetVendorContractDetails(
        Guid vendorContractId,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/vendorContracts/{vendorContractId}/details";

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<VendorContractDetailsDataObject[]>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<VendorContractDetailsDataObject[]>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CreateVendorContractDetailsActionOutput>> CreateVendorContractDetails(
        CreateVendorContractDetailsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/vendorContracts/{input.VendorContractId}/details";

        var response = await _httpClient.PostAsJsonAsync(url, new
        {
            input.JobSubcontractId,
            input.Sequence,
            input.IsComplete,
            input.Note,
            input.Quantity,
            input.UnitCost,
            input.UnitOfMeasure,
            input.SalesTaxPercent,
            input.IsCancelled,
            input.AlternateDescription,
            input.VendorItemNumber
        }, cancellationToken);

        return new ApiResponse<CreateVendorContractDetailsActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CreateVendorContractDetailsActionOutput>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<object>> UpdateVendorContractDetails(
        UpdateVendorContractDetailsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/vendorContracts/details/{input.Id}";

        var response = await _httpClient.PutAsJsonAsync(url, new
        {
            isComplete = input.IsComplete
        }, cancellationToken);

        return new ApiResponse<object>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<VendorContractItemsResponse>> GetVendorContractItems(
        Guid? jobId = null,
        Guid? businessUnitId = null,
        Guid? vendorContractId = null,
        DateTime? modifiedSince = null,
        bool? isDeleted = null,
        int? limit = 1000,
        string? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (jobId.HasValue)
            queryParams.Add($"jobId={jobId}");
        if (businessUnitId.HasValue)
            queryParams.Add($"businessUnitId={businessUnitId}");
        if (vendorContractId.HasValue)
            queryParams.Add($"vendorContractId={vendorContractId}");
        if (modifiedSince.HasValue)
            queryParams.Add($"modifiedSince={Uri.EscapeDataString(modifiedSince.Value.ToString("O"))}");
        if (isDeleted.HasValue)
            queryParams.Add($"isDeleted={isDeleted.Value.ToString().ToLower()}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit}");
        if (!string.IsNullOrEmpty(cursor))
            queryParams.Add($"cursor={cursor}");

        var url = "heavyjob/api/v1/vendorContractItems";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<VendorContractItemsResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<VendorContractItemsResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public record VendorContractItemsResponse
    {
        [JsonPropertyName("results")]
        [Required]
        public required VendorContractItemsDataObject[] Results { get; init; }

        [JsonPropertyName("metadata")]
        [Required]
        public required VendorContractItemsResponseMetadata Metadata { get; init; }
    }

    public record VendorContractItemsResponseMetadata
    {
        [JsonPropertyName("nextCursor")]
        public string? NextCursor { get; init; }
    }

    public async Task<ApiResponse<VendorContractsResponse>> GetVendorContracts(
        Guid? jobId = null,
        Guid? businessUnitId = null,
        Guid? vendorContractId = null,
        DateTime? modifiedSince = null,
        bool? isDeleted = null,
        int? limit = 1000,
        string? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (jobId.HasValue)
            queryParams.Add($"jobId={jobId}");
        if (businessUnitId.HasValue)
            queryParams.Add($"businessUnitId={businessUnitId}");
        if (vendorContractId.HasValue)
            queryParams.Add($"vendorContractId={vendorContractId}");
        if (modifiedSince.HasValue)
            queryParams.Add($"modifiedSince={Uri.EscapeDataString(modifiedSince.Value.ToString("O"))}");
        if (isDeleted.HasValue)
            queryParams.Add($"isDeleted={isDeleted.Value.ToString().ToLower()}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit}");
        if (!string.IsNullOrEmpty(cursor))
            queryParams.Add($"cursor={cursor}");

        var url = "heavyjob/api/v1/vendorContracts";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<VendorContractsResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<VendorContractsResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public record VendorContractsResponse
    {
        [JsonPropertyName("results")]
        [Required]
        public required VendorContractsDataObject[] Results { get; init; }

        [JsonPropertyName("metadata")]
        [Required]
        public required VendorContractsResponseMetadata Metadata { get; init; }
    }

    public record VendorContractsResponseMetadata
    {
        [JsonPropertyName("nextCursor")]
        public string? NextCursor { get; init; }
    }

    public async Task<ApiResponse<CreateVendorContractsActionOutput>> CreateVendorContract(
        CreateVendorContractsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/jobs/{input.JobId}/vendorContracts";

        var response = await _httpClient.PostAsJsonAsync(url, new
        {
            input.VendorContract,
            input.OrderStatus,
            input.DateIssued,
            input.Description,
            input.VendorId
        }, cancellationToken);

        return new ApiResponse<CreateVendorContractsActionOutput>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CreateVendorContractsActionOutput>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<object>> UpdateVendorContract(
        UpdateVendorContractsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/vendorContracts/{input.Id}";

        var response = await _httpClient.PutAsJsonAsync(url, new
        {
            input.OrderStatus,
            input.DateIssued,
            input.Description,
            input.VendorContract,
            input.VendorId
        }, cancellationToken);

        return new ApiResponse<object>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }


    public async Task<ApiResponse<HeavyJob.v1.Vendors.VendorsDataObject[]>> GetVendors(
        bool? isDeleted = null,
        DateTime? modifiedSince = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (isDeleted.HasValue)
            queryParams.Add($"isDeleted={isDeleted.Value.ToString().ToLower()}");
        if (modifiedSince.HasValue)
            queryParams.Add($"modifiedSince={Uri.EscapeDataString(modifiedSince.Value.ToString("O"))}");

        var url = "heavyjob/api/v2/vendors";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<HeavyJob.v1.Vendors.VendorsDataObject[]>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<HeavyJob.v1.Vendors.VendorsDataObject[]>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<HeavyJob.v1.Vendors.VendorsDataObject>> CreateVendor(
        CreateVendorsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "heavyjob/api/v1/vendors";

        var response = await _httpClient.PostAsJsonAsync(url, new
        {
            input.Name,
            input.Description,
            input.Address1,
            input.Address2,
            input.City,
            input.State,
            input.Zip,
            input.Country,
            input.PhoneNumber
        }, cancellationToken);

        return new ApiResponse<HeavyJob.v1.Vendors.VendorsDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<HeavyJob.v1.Vendors.VendorsDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<object>> DeleteVendor(
        DeleteVendorsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/vendors/{input.Id}";

        var response = await _httpClient.DeleteAsync(url, cancellationToken);

        return new ApiResponse<object>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

// Update the method signature in ApiClient.cs
    public async Task<ApiResponse<HeavyJob.v1.Vendors.VendorsDataObject>> UpdateHeavyJobVendor(
        HeavyJob.v1.Vendors.Update.UpdateVendorsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"heavyjob/api/v1/vendors/{input.Id}";

        var response = await _httpClient.PutAsJsonAsync(url, new
        {
            input.Name,
            input.Description,
            input.Address1,
            input.Address2,
            input.City,
            input.State,
            input.Zip,
            input.Country,
            input.PhoneNumber
        }, cancellationToken);

        return new ApiResponse<HeavyJob.v1.Vendors.VendorsDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<HeavyJob.v1.Vendors.VendorsDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<AccessGroupsResponse>> GetAccessGroups(
        bool? isDeleted = null,
        int? limit = 1000,
        string? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (isDeleted.HasValue)
            queryParams.Add($"isDeleted={isDeleted.Value.ToString().ToLower()}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit}");
        if (!string.IsNullOrEmpty(cursor))
            queryParams.Add($"cursor={cursor}");

        var url = "safety/v1/accessGroups";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<AccessGroupsResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<AccessGroupsResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public record AccessGroupsResponse
    {
        [JsonPropertyName("results")]
        [Required]
        public required AccessGroupsDataObject[] Results { get; init; }

        [JsonPropertyName("metadata")]
        [Required]
        public required AccessGroupsResponseMetadata Metadata { get; init; }
    }

    public record AccessGroupsResponseMetadata
    {
        [JsonPropertyName("nextCursor")]
        public string? NextCursor { get; init; }
    }

    public async Task<ApiResponse<AlertsResponse>> GetAlerts(
        string? businessUnitId = null,
        int? limit = 1000,
        string? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (!string.IsNullOrEmpty(businessUnitId))
            queryParams.Add($"businessUnitID={businessUnitId}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit}");
        if (!string.IsNullOrEmpty(cursor))
            queryParams.Add($"cursor={cursor}");

        var url = "safety/v1/alerts";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<AlertsResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<AlertsResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public record AlertsResponse
    {
        [JsonPropertyName("results")]
        [Required]
        public required AlertsDataObject[] Results { get; init; }

        [JsonPropertyName("metadata")]
        [Required]
        public required AlertsResponseMetadata Metadata { get; init; }
    }

    public record AlertsResponseMetadata
    {
        [JsonPropertyName("nextCursor")]
        public string? NextCursor { get; init; }
    }

    public async Task<ApiResponse<AlertsDataObject>> CreateAlert(
        CreateAlertsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "safety/v1/alerts";

        var response = await _httpClient.PostAsJsonAsync(url, new
        {
            input.Email,
            input.PhoneNumber,
            input.FirstName,
            input.LastName,
            input.ProviderId,
            input.BusinessUnitId,
            input.CarrierAddressOverride,
            input.NearMiss,
            input.Incidents,
            input.Inspections,
            input.Observations,
            input.Jobs
        }, cancellationToken);

        return new ApiResponse<AlertsDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<AlertsDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<object>> DeleteAlert(
        DeleteAlertsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"safety/v1/alerts/{input.AlertId}";

        var response = await _httpClient.DeleteAsync(url, cancellationToken);

        return new ApiResponse<object>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<AlertsDataObject>> UpdateAlert(
        UpdateAlertsActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "safety/v1/alerts";

        var response = await _httpClient.PutAsJsonAsync(url, new
        {
            input.Id,
            input.Email,
            input.PhoneNumber,
            input.ProviderId,
            input.CarrierAddressOverride,
            input.NearMiss,
            input.Incidents,
            input.Inspections,
            input.Observations,
            input.Jobs
        }, cancellationToken);

        return new ApiResponse<AlertsDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<AlertsDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IncidentDataObject[]>> GetIncidents(
        DateTime? modifiedAfterUtc = null,
        DateTime? createdAfterUtc = null,
        DateTime? incidentDateAfterUtc = null,
        DateTime? incidentDateBeforeUtc = null,
        int? limit = 1000,
        int? offset = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (modifiedAfterUtc.HasValue)
            queryParams.Add($"modifiedAfterUtc={Uri.EscapeDataString(modifiedAfterUtc.Value.ToString("O"))}");
        if (createdAfterUtc.HasValue)
            queryParams.Add($"createdAfterUtc={Uri.EscapeDataString(createdAfterUtc.Value.ToString("O"))}");
        if (incidentDateAfterUtc.HasValue)
            queryParams.Add($"incidentDateAfterUtc={Uri.EscapeDataString(incidentDateAfterUtc.Value.ToString("O"))}");
        if (incidentDateBeforeUtc.HasValue)
            queryParams.Add($"incidentDateBeforeUtc={Uri.EscapeDataString(incidentDateBeforeUtc.Value.ToString("O"))}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit}");
        if (offset.HasValue)
            queryParams.Add($"offset={offset}");

        var url = "safety/v1/incidents";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);
        var hasMorePages = response.Headers.TryGetValues("Pagination-MorePagesAvailable", out var morePages) 
            && morePages.FirstOrDefault()?.ToLower() == "yes";

        return new ApiResponse<IncidentDataObject[]>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IncidentDataObject[]>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken),
            HasMorePages = hasMorePages
        };
    }

    public async Task<ApiResponse<IncidentDataObject>> UpdateIncident(
        UpdateIncidentActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"safety/v1/incidents/{input.Id}";

        var response = await _httpClient.PutAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<IncidentDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IncidentDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public record IncidentFormTypesResponse
    {
        [JsonPropertyName("results")]
        [Required]
        public required IncidentFormTypesDataObject[] Results { get; init; }

        [JsonPropertyName("metadata")]
        [Required]
        public required IncidentFormTypesResponseMetadata Metadata { get; init; }
    }

    public record IncidentFormTypesResponseMetadata
    {
        [JsonPropertyName("nextCursor")]
        public string? NextCursor { get; init; }
    }

    public async Task<ApiResponse<IncidentFormTypesResponse>> GetIncidentFormTypes(
        int? limit = 1000,
        Guid? businessUnitId = null,
        string? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (limit.HasValue)
            queryParams.Add($"limit={limit}");
        if (businessUnitId.HasValue)
            queryParams.Add($"businessUnitId={businessUnitId}");
        if (!string.IsNullOrEmpty(cursor))
            queryParams.Add($"cursor={cursor}");

        var url = "safety/v1/incidentFormTypes";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IncidentFormTypesResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IncidentFormTypesResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IncidentsDataObject[]>> GetIncidentsList(
        DateTime? modifiedAfterUtc = null,
        DateTime? createdAfterUtc = null,
        DateTime? incidentDateAfterUtc = null,
        DateTime? incidentDateBeforeUtc = null,
        int? limit = 1000,
        int? offset = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (modifiedAfterUtc.HasValue)
            queryParams.Add($"modifiedAfterUtc={Uri.EscapeDataString(modifiedAfterUtc.Value.ToString("O"))}");
        if (createdAfterUtc.HasValue)
            queryParams.Add($"createdAfterUtc={Uri.EscapeDataString(createdAfterUtc.Value.ToString("O"))}");
        if (incidentDateAfterUtc.HasValue)
            queryParams.Add($"incidentDateAfterUtc={Uri.EscapeDataString(incidentDateAfterUtc.Value.ToString("O"))}");
        if (incidentDateBeforeUtc.HasValue)
            queryParams.Add($"incidentDateBeforeUtc={Uri.EscapeDataString(incidentDateBeforeUtc.Value.ToString("O"))}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit}");
        if (offset.HasValue)
            queryParams.Add($"offset={offset}");

        var url = "safety/v1/incidents";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);
        var hasMorePages = response.Headers.TryGetValues("Pagination-MorePagesAvailable", out var morePages) 
            && morePages.FirstOrDefault()?.ToLower() == "yes";

        return new ApiResponse<IncidentsDataObject[]>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IncidentsDataObject[]>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken),
            HasMorePages = hasMorePages
        };
    }

    public async Task<ApiResponse<IncidentV2DataObject>> GetIncidentV2(
        Guid id,
        bool? excludeForms = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (excludeForms.HasValue)
            queryParams.Add($"excludeForms={excludeForms.Value.ToString().ToLower()}");

        var url = $"safety/v2/incidents/{id}";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IncidentV2DataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IncidentV2DataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public class InspectionTypesResponse
    {
        [JsonPropertyName("results")]
        public required Safety.v1.InspectionTypes.InspectionTypesDataObject[] Results { get; init; }

        [JsonPropertyName("metadata")]
        public ResponseMetadata? Metadata { get; init; }
    }

    public class ResponseMetadata
    {
        [JsonPropertyName("nextCursor")]
        public string? NextCursor { get; init; }
    }

    public async Task<ApiResponse<InspectionTypesResponse>> GetInspectionTypes(
        int limit = 1000,
        string? businessUnitID = null,
        string? cursor = null,
        bool includeInactive = false,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new Dictionary<string, string>();
        
        if (limit != 1000)
        {
            queryParams.Add("limit", limit.ToString());
        }
        
        if (!string.IsNullOrEmpty(businessUnitID))
        {
            queryParams.Add("businessUnitID", businessUnitID);
        }
        
        if (!string.IsNullOrEmpty(cursor))
        {
            queryParams.Add("cursor", cursor);
        }
        
        if (includeInactive)
        {
            queryParams.Add("includeInactive", "true");
        }

        var url = "v1/inspectionTypes";
        if (queryParams.Any())
        {
            url += "?" + string.Join("&", queryParams.Select(x => $"{x.Key}={Uri.EscapeDataString(x.Value)}"));
        }

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<InspectionTypesResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? 
                await response.Content.ReadFromJsonAsync<InspectionTypesResponse>(cancellationToken: cancellationToken) : 
                null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public class JobsResponse
    {
        [JsonPropertyName("results")]
        public required Safety.v1.Jobs.JobsDataObject[] Results { get; init; }

        [JsonPropertyName("metadata")]
        public ResponseMetadata? Metadata { get; init; }
    }

    public async Task<ApiResponse<JobsResponse>> GetJobs(
        int limit = 1000,
        string? businessUnitId = null,
        string? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new Dictionary<string, string>();
        
        if (limit != 1000)
        {
            queryParams.Add("limit", limit.ToString());
        }
        
        if (!string.IsNullOrEmpty(businessUnitId))
        {
            queryParams.Add("businessUnitId", businessUnitId);
        }
        
        if (!string.IsNullOrEmpty(cursor))
        {
            queryParams.Add("cursor", cursor);
        }

        var url = "v1/jobs";
        if (queryParams.Any())
        {
            url += "?" + string.Join("&", queryParams.Select(x => $"{x.Key}={Uri.EscapeDataString(x.Value)}"));
        }

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<JobsResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? 
                await response.Content.ReadFromJsonAsync<JobsResponse>(cancellationToken: cancellationToken) : 
                null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public class MeetingsResponse
    {
        [JsonPropertyName("meetings")]
        public required Safety.v1.Meetings.MeetingsDataObject[] Meetings { get; init; }
    }

    public async Task<ApiResponse<MeetingsResponse>> GetMeetings(
        Guid? jobId = null,
        Guid? recorderId = null,
        Guid? businessUnitId = null,
        Guid? employeeId = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        int? skip = null,
        int? take = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new Dictionary<string, string>();
        
        if (jobId.HasValue)
            queryParams.Add("jobId", jobId.Value.ToString());
        
        if (recorderId.HasValue)
            queryParams.Add("recorderId", recorderId.Value.ToString());
        
        if (businessUnitId.HasValue)
            queryParams.Add("businessUnitId", businessUnitId.Value.ToString());
        
        if (employeeId.HasValue)
            queryParams.Add("employeeId", employeeId.Value.ToString());
        
        if (startDate.HasValue)
            queryParams.Add("startDate", startDate.Value.ToString("O"));
        
        if (endDate.HasValue)
            queryParams.Add("endDate", endDate.Value.ToString("O"));
        
        if (skip.HasValue)
            queryParams.Add("skip", skip.Value.ToString());
        
        if (take.HasValue)
            queryParams.Add("take", take.Value.ToString());

        var url = "v1/meetings";
        if (queryParams.Any())
        {
            url += "?" + string.Join("&", queryParams.Select(x => $"{x.Key}={Uri.EscapeDataString(x.Value)}"));
        }

        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<MeetingsResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? 
                await response.Content.ReadFromJsonAsync<MeetingsResponse>(cancellationToken: cancellationToken) : 
                null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<Safety.v1.Providers.ProvidersDataObject[]>> GetProviders(
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync("v1/providers", cancellationToken);

        return new ApiResponse<Safety.v1.Providers.ProvidersDataObject[]>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? 
                await response.Content.ReadFromJsonAsync<Safety.v1.Providers.ProvidersDataObject[]>(cancellationToken: cancellationToken) : 
                null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public class UserAccessGroupsResponse
    {
        [JsonPropertyName("results")]
        public required Safety.v1.UserAccessGroups.UserAccessGroupsDataObject[] Results { get; init; }

        [JsonPropertyName("metadata")]
        public ResponseMetadata? Metadata { get; init; }
    }

    public async Task<ApiResponse<UserAccessGroupsResponse>> SearchUserAccessGroups(
        Guid[]? userIds = null,
        int limit = 1000,
        string? cursor = null,
        CancellationToken cancellationToken = default)
    {
        var request = new
        {
            userIds = userIds,
            limit = limit,
            cursor = cursor
        };

        var response = await _httpClient.PostAsJsonAsync("v1/userAccessGroups/search", request, cancellationToken);

        return new ApiResponse<UserAccessGroupsResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? 
                await response.Content.ReadFromJsonAsync<UserAccessGroupsResponse>(cancellationToken: cancellationToken) : 
                null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<UpdateUserAccessGroupsActionOutput[]>> UpdateUserAccessGroups(
        UpdateUserAccessGroupsActionInput[] input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PatchAsJsonAsync("v1/userAccessGroups", input, cancellationToken);

        return new ApiResponse<UpdateUserAccessGroupsActionOutput[]>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? 
                await response.Content.ReadFromJsonAsync<UpdateUserAccessGroupsActionOutput[]>(cancellationToken: cancellationToken) : 
                null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<UsersDataObject>> GetSafetyUser(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync($"v1/users/{id}", cancellationToken);

        return new ApiResponse<UsersDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode ? 
                await response.Content.ReadFromJsonAsync<UsersDataObject>(cancellationToken: cancellationToken) : 
                null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<AccountingTemplateDataObject>>> GetAccountingTemplates(
        string businessUnitCode,
        CancellationToken cancellationToken = default)
    {
        var url = $"setups/api/v1/AccountingTemplate?businessUnitCode={Uri.EscapeDataString(businessUnitCode)}";
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<AccountingTemplateDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<AccountingTemplateDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<object>> CreateBulkCostCodes(
        BulkCostCodeDataObject[] costCodes,
        CancellationToken cancellationToken = default)
    {
        var url = "setups/api/v1/CostCode/bulk";
        
        var response = await _httpClient.PostAsJsonAsync(url, costCodes, cancellationToken);

        return new ApiResponse<object>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<Connector.Setups.v1.BusinessUnit.BusinessUnitDataObject>>> GetSetupsBusinessUnits(
        CancellationToken cancellationToken = default)
    {
        var url = "setups/api/v1/BusinessUnit";
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<Connector.Setups.v1.BusinessUnit.BusinessUnitDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<Connector.Setups.v1.BusinessUnit.BusinessUnitDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<Connector.Setups.v1.BusinessUnit.BusinessUnitDataObject>> CreateSetupsBusinessUnit(
        CreateBusinessUnitActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "setups/api/v1/BusinessUnit";
        
        var response = await _httpClient.PostAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<Connector.Setups.v1.BusinessUnit.BusinessUnitDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<Connector.Setups.v1.BusinessUnit.BusinessUnitDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<BusinessUnitDefaultDataObject>> GetSetupsDefaultBusinessUnit(
        CancellationToken cancellationToken = default)
    {
        var url = "setups/api/v1/BusinessUnit/default";
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<BusinessUnitDefaultDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<BusinessUnitDefaultDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<CostCodeDataObject>>> GetSetupsCostCodes(
        string businessUnitCode,
        string jobCode,
        string? accountingTemplateName = null,
        CancellationToken cancellationToken = default)
    {
        var url = $"setups/api/v1/CostCode?businessUnitCode={Uri.EscapeDataString(businessUnitCode)}&jobCode={Uri.EscapeDataString(jobCode)}";
        if (!string.IsNullOrEmpty(accountingTemplateName))
        {
            url += $"&accountingTemplateName={Uri.EscapeDataString(accountingTemplateName)}";
        }
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<CostCodeDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<CostCodeDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CostCodeDataObject>> CreateSetupsCostCode(
        CreateCostCodeActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "setups/api/v1/CostCode";
        
        var response = await _httpClient.PostAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<CostCodeDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CostCodeDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<CostCodeDataObject>> UpdateSetupsCostCode(
        Guid id,
        UpdateCostCodeActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"setups/api/v1/CostCode/{id}";
        
        var response = await _httpClient.PutAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<CostCodeDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<CostCodeDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<object>> UpdateSetupsBulkCostCodes(
        CostCodeDataObject[] costCodes,
        CancellationToken cancellationToken = default)
    {
        var url = "setups/api/v1/CostCode";
        
        var response = await _httpClient.PatchAsJsonAsync(url, costCodes, cancellationToken);

        return new ApiResponse<object>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<Connector.Setups.v1.Employee.EmployeeDataObject>>> GetSetupsEmployees(
        string businessUnitCode,
        string? accountingTemplateName = null,
        bool includeDeleted = false,
        CancellationToken cancellationToken = default)
    {
        var url = $"setups/api/v1/Employee?businessUnitCode={Uri.EscapeDataString(businessUnitCode)}";
        if (!string.IsNullOrEmpty(accountingTemplateName))
        {
            url += $"&accountingTemplateName={Uri.EscapeDataString(accountingTemplateName)}";
        }
        url += $"&includeDeleted={includeDeleted}";
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<Connector.Setups.v1.Employee.EmployeeDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<Connector.Setups.v1.Employee.EmployeeDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<Connector.Setups.v1.Employee.EmployeeDataObject>> CreateSetupsEmployee(
        Connector.Setups.v1.Employee.Create.CreateEmployeeActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "setups/api/v1/Employee";
        
        var response = await _httpClient.PostAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<Connector.Setups.v1.Employee.EmployeeDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<Connector.Setups.v1.Employee.EmployeeDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<EmployeeDataObject>> UpdateSetupsEmployee(
        Guid id,
        Connector.Setups.v1.Employee.Update.UpdateEmployeeActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"setups/api/v1/Employee/{id}";
        
        var response = await _httpClient.PutAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<EmployeeDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<EmployeeDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<Connector.Setups.v1.Equipment.EquipmentDataObject>>> GetSetupsEquipment(
        string businessUnitCode,
        string? accountingTemplateName = null,
        CancellationToken cancellationToken = default)
    {
        var url = $"setups/api/v1/Equipment?businessUnitCode={Uri.EscapeDataString(businessUnitCode)}";
        if (!string.IsNullOrEmpty(accountingTemplateName))
        {
            url += $"&accountingTemplateName={Uri.EscapeDataString(accountingTemplateName)}";
        }
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<Connector.Setups.v1.Equipment.EquipmentDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<Connector.Setups.v1.Equipment.EquipmentDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    // Add this method to the existing ApiClient class
    public async Task<ApiResponse<EquipmentDataObject>> CreateSetupsEquipment(
        Setups.v1.Equipment.Create.CreateEquipmentActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "setups/api/v1/Equipment";
        
        var response = await _httpClient.PostAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<EquipmentDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<EquipmentDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<EquipmentDataObject>> UpdateSetupsEquipment(
        Guid id,
        Setups.v1.Equipment.Update.UpdateEquipmentActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"setups/api/v1/Equipment/{id}";
        
        var response = await _httpClient.PutAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<EquipmentDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<EquipmentDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<JobDataObject>>> GetSetupsJobs(
        string businessUnitCode,
        string? accountingTemplateName = null,
        CancellationToken cancellationToken = default)
    {
        var url = $"setups/api/v1/Job?businessUnitCode={Uri.EscapeDataString(businessUnitCode)}";
        if (!string.IsNullOrEmpty(accountingTemplateName))
        {
            url += $"&accountingTemplateName={Uri.EscapeDataString(accountingTemplateName)}";
        }
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<JobDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<JobDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<JobDataObject>> CreateSetupsJob(
        CreateJobActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "setups/api/v1/Job";
        
        var response = await _httpClient.PostAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<JobDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<JobDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<JobDataObject>> UpdateSetupsJob(
        Guid id,
        UpdateJobActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"setups/api/v1/Job/{id}";
        
        var response = await _httpClient.PutAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<JobDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<JobDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<Connector.Setups.v1.PayClass.PayClassDataObject>>> GetSetupsPayClasses(
        string businessUnitCode,
        string? accountingTemplateName = null,
        CancellationToken cancellationToken = default)
    {
        var url = $"setups/api/v1/PayClass?businessUnitCode={Uri.EscapeDataString(businessUnitCode)}";
        if (!string.IsNullOrEmpty(accountingTemplateName))
        {
            url += $"&accountingTemplateName={Uri.EscapeDataString(accountingTemplateName)}";
        }
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<Connector.Setups.v1.PayClass.PayClassDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<Connector.Setups.v1.PayClass.PayClassDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<PayClassDataObject>> CreateSetupsPayClass(
        CreatePayClassActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "setups/api/v1/PayClass";
        
        var response = await _httpClient.PostAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<PayClassDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<PayClassDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<PayClassDataObject>> UpdateSetupsPayClass(
        Guid id,
        Setups.v1.PayClass.Update.UpdatePayClassActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"setups/api/v1/PayClass/{id}";
        
        var response = await _httpClient.PutAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<PayClassDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<PayClassDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<RateSetDataObject>> GetEmployeeRateSet(
        string businessUnitCode,
        string employeeRateSetGroupCode,
        CancellationToken cancellationToken = default)
    {
        var url = $"setups/api/v1/RateSet/Employee?businessUnitCode={Uri.EscapeDataString(businessUnitCode)}&employeeRateSetGroupCode={Uri.EscapeDataString(employeeRateSetGroupCode)}";
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<RateSetDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<RateSetDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<RateSetDataObject>> CreateEmployeeRateSet(
        CreateRateSetActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "setups/api/v1/RateSet/Employee";
        
        var response = await _httpClient.PostAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<RateSetDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<RateSetDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<RateSetDataObject>> UpdateEmployeeRateSet(
        Guid id,
        UpdateRateSetActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"setups/api/v1/RateSet/Employee/{id}";
        
        var response = await _httpClient.PutAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<RateSetDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<RateSetDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<RateSetCostAdjustmentDataObject>> GetCostAdjustmentRateSet(
        string businessUnitCode,
        string costAdjustmentRateSetGroupCode,
        CancellationToken cancellationToken = default)
    {
        var url = $"setups/api/v1/RateSet/CostAdjustment?businessUnitCode={Uri.EscapeDataString(businessUnitCode)}&costAdjustmentRateSetGroupCode={Uri.EscapeDataString(costAdjustmentRateSetGroupCode)}";
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<RateSetCostAdjustmentDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<RateSetCostAdjustmentDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<RateSetCostAdjustmentDataObject>> CreateCostAdjustmentRateSet(
        CreateRateSetCostAdjustmentActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "setups/api/v1/RateSet/CostAdjustment";
        
        var response = await _httpClient.PostAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<RateSetCostAdjustmentDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<RateSetCostAdjustmentDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<RateSetCostAdjustmentDataObject>> UpdateCostAdjustmentRateSet(
        Guid id,
        UpdateRateSetCostAdjustmentActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"setups/api/v1/RateSet/CostAdjustment/{id}";
        
        var response = await _httpClient.PutAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<RateSetCostAdjustmentDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<RateSetCostAdjustmentDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<RateSetEquipmentDataObject>> GetEquipmentRateSet(
        string businessUnitCode,
        string equipmentRateSetGroupCode,
        CancellationToken cancellationToken = default)
    {
        var url = $"setups/api/v1/RateSet/Equipment?businessUnitCode={Uri.EscapeDataString(businessUnitCode)}&equipmentRateSetGroupCode={Uri.EscapeDataString(equipmentRateSetGroupCode)}";
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<RateSetEquipmentDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<RateSetEquipmentDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<RateSetEquipmentDataObject>> CreateEquipmentRateSet(
        CreateRateSetEquipmentActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "setups/api/v1/RateSet/Equipment";
        
        var response = await _httpClient.PostAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<RateSetEquipmentDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<RateSetEquipmentDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<RateSetEquipmentDataObject>> UpdateEquipmentRateSet(
        Guid id,
        UpdateRateSetEquipmentActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"setups/api/v1/RateSet/Equipment/{id}";
        
        var response = await _httpClient.PutAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<RateSetEquipmentDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<RateSetEquipmentDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<RateSetGroupDataObject>>> GetRateSetGroups(
        string businessUnitCode,
        string? type = null,
        CancellationToken cancellationToken = default)
    {
        var url = $"setups/api/v1/RateSetGroup?businessUnitCode={Uri.EscapeDataString(businessUnitCode)}";
        if (!string.IsNullOrEmpty(type))
        {
            url += $"&type={Uri.EscapeDataString(type)}";
        }
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<RateSetGroupDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<RateSetGroupDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<Guid>> CreateRateSetGroup(
        CreateRateSetGroupActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "setups/api/v1/RateSetGroup";
        
        var response = await _httpClient.PostAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<Guid>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<Guid>(cancellationToken: cancellationToken)
                : Guid.Empty,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<RateSetGroupDataObject>> UpdateRateSetGroup(
        Guid id,
        UpdateRateSetGroupActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"setups/api/v1/RateSetGroup/{id}";
        
        var response = await _httpClient.PutAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<RateSetGroupDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<RateSetGroupDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<RateSetPayClassDataObject>> GetPayClassRateSet(
        string businessUnitCode,
        string payClassRateSetGroupCode,
        CancellationToken cancellationToken = default)
    {
        var url = $"setups/api/v1/RateSet/PayClass?businessUnitCode={Uri.EscapeDataString(businessUnitCode)}&payClassRateSetGroupCode={Uri.EscapeDataString(payClassRateSetGroupCode)}";
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<RateSetPayClassDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<RateSetPayClassDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    // Add this method to the ApiClient class
    public async Task<ApiResponse<RateSetPayClassDataObject>> CreatePayClassRateSet(
        CreateRateSetPayClassActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "setups/api/v1/RateSet/PayClass";
        
        var response = await _httpClient.PostAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<RateSetPayClassDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<RateSetPayClassDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<RateSetPayClassDataObject>> UpdatePayClassRateSet(
        Guid id,
        UpdateRateSetPayClassActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"setups/api/v1/RateSet/PayClass/{id}";
        
        var response = await _httpClient.PutAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<RateSetPayClassDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<RateSetPayClassDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<object>> ImportEmployeeSkills(
        EmployeeSkillImportDataObject[] skills,
        bool usePayrollCode = false,
        CancellationToken cancellationToken = default)
    {
        var url = $"skills/api/v1/employeeSkills/import?usePayrollCode={usePayrollCode}";
        
        var response = await _httpClient.PostAsJsonAsync(url, skills, cancellationToken);

        return new ApiResponse<object>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<object>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<EmployeeSkillsDataObject>>> GetEmployeeSkills(
        DateTime? dateAfterUtc = null,
        int? limit = null,
        int? offset = null,
        bool includeDismissed = false,
        bool usePayrollCode = false,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (dateAfterUtc.HasValue)
            queryParams.Add($"dateAfterUtc={Uri.EscapeDataString(dateAfterUtc.Value.ToString("O"))}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit.Value}");
        if (offset.HasValue)
            queryParams.Add($"offset={offset.Value}");
        
        queryParams.Add($"includeDismissed={includeDismissed}");
        queryParams.Add($"usePayrollCode={usePayrollCode}");

        var url = "skills/api/v1/employeeSkills";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<EmployeeSkillsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<EmployeeSkillsDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    // Add this method to the ApiClient class
    public async Task<ApiResponse<string>> CreateEmployeeSkill(
        CreateEmployeeSkillsActionInput input,
        bool usePayrollCode = false,
        CancellationToken cancellationToken = default)
    {
        var url = $"skills/api/v1/employeeSkills?usePayrollCode={usePayrollCode}";
        
        var response = await _httpClient.PostAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<string>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<string>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<EmployeeSkillsByEmployeeDataObject>>> GetEmployeeSkillsByEmployee(
        string employeeCode,
        DateTime? dateAfterUtc = null,
        int? limit = null,
        int? offset = null,
        bool usePayrollCode = false,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (dateAfterUtc.HasValue)
            queryParams.Add($"dateAfterUtc={Uri.EscapeDataString(dateAfterUtc.Value.ToString("O"))}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit.Value}");
        if (offset.HasValue)
            queryParams.Add($"offset={offset.Value}");
        
        queryParams.Add($"usePayrollCode={usePayrollCode}");

        var url = $"skills/api/v1/employeeSkills/employee/{Uri.EscapeDataString(employeeCode)}";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<EmployeeSkillsByEmployeeDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<EmployeeSkillsByEmployeeDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<EmployeeSkillsBySkillDataObject>>> GetEmployeeSkillsBySkill(
        string courseCodeOrName,
        DateTime? dateAfterUtc = null,
        int? limit = null,
        int? offset = null,
        bool usePayrollCode = false,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (dateAfterUtc.HasValue)
            queryParams.Add($"dateAfterUtc={Uri.EscapeDataString(dateAfterUtc.Value.ToString("O"))}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit.Value}");
        if (offset.HasValue)
            queryParams.Add($"offset={offset.Value}");
        
        queryParams.Add($"usePayrollCode={usePayrollCode}");

        var url = $"skills/api/v1/employeeSkills/skill/{Uri.EscapeDataString(courseCodeOrName)}";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<EmployeeSkillsBySkillDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<EmployeeSkillsBySkillDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<SkillDataObject>> GetSkill(
        string courseCodeOrName,
        CancellationToken cancellationToken = default)
    {
        var url = $"skills/api/v1/skills/{Uri.EscapeDataString(courseCodeOrName)}";
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<SkillDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<SkillDataObject>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<object>> CreateSkill(
        CreateSkillActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = "skills/api/v1/skills";
        
        var response = await _httpClient.PostAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<object>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<object>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<object>> DeleteSkill(
        string courseCodeOrName,
        CancellationToken cancellationToken = default)
    {
        var url = $"skills/api/v1/skills/{Uri.EscapeDataString(courseCodeOrName)}";
        
        var response = await _httpClient.DeleteAsync(url, cancellationToken);

        return new ApiResponse<object>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<object>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    // Add this method to the ApiClient class
    public async Task<ApiResponse<object>> UpdateSkill(
        string courseCodeOrName,
        UpdateSkillActionInput input,
        CancellationToken cancellationToken = default)
    {
        var url = $"skills/api/v1/skills/{Uri.EscapeDataString(courseCodeOrName)}";
        
        var response = await _httpClient.PutAsJsonAsync(url, input, cancellationToken);

        return new ApiResponse<object>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<object>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<IEnumerable<SkillsDataObject>>> GetSkills(
        DateTime? dateAfterUtc = null,
        int? limit = null,
        int? offset = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (dateAfterUtc.HasValue)
            queryParams.Add($"dateAfterUtc={Uri.EscapeDataString(dateAfterUtc.Value.ToString("O"))}");
        if (limit.HasValue)
            queryParams.Add($"limit={limit.Value}");
        if (offset.HasValue)
            queryParams.Add($"offset={offset.Value}");

        var url = "skills/api/v1/skills";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<IEnumerable<SkillsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<SkillsDataObject>>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    // Add this method to the ApiClient class
    public async Task<ApiResponse<ImportResult[]>> ImportSkills(
        SkillsimportDataObject[] skills,
        CancellationToken cancellationToken = default)
    {
        var url = "skills/api/v1/skills/import";
        
        var response = await _httpClient.PostAsJsonAsync(url, skills, cancellationToken);

        return new ApiResponse<ImportResult[]>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<ImportResult[]>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<EquipmentResponse>> GetEquipment(
        int? limit = null,
        string? cursor = null,
        bool? isRegistered = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();
        
        if (limit.HasValue)
            queryParams.Add($"limit={limit.Value}");
        if (!string.IsNullOrEmpty(cursor))
            queryParams.Add($"cursor={Uri.EscapeDataString(cursor)}");
        if (isRegistered.HasValue)
            queryParams.Add($"isRegistered={isRegistered.Value}");

        var url = "telematics/api/v1/equipment";
        if (queryParams.Any())
            url += "?" + string.Join("&", queryParams);
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        return new ApiResponse<EquipmentResponse>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<EquipmentResponse>(cancellationToken: cancellationToken)
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public class EquipmentResponse
    {
        [JsonPropertyName("results")]
        [Required]
        public required Telematics.v1.Equipment.EquipmentDataObject[] Results { get; init; }

        [JsonPropertyName("metadata")]
        [Required]
        public required EquipmentMetadata Metadata { get; init; }
    }

    public class EquipmentMetadata
    {
        [JsonPropertyName("nextCursor")]
        public string? NextCursor { get; init; }
    }
}