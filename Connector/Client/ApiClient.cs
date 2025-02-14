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

    public async Task<ApiResponse<IEnumerable<EmployeesDataObject>>> GetEmployees(
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

        return new ApiResponse<IEnumerable<EmployeesDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<EmployeesDataObject>>(cancellationToken: cancellationToken) 
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
        CreateEquipmentActionInput input,
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
        UpdateEquipmentActionInput input,
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

    public async Task<ApiResponse<IEnumerable<EquipmentTypeDataObject>>> GetEquipmentTypes(
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync("e360/api/v1/equipmentType", cancellationToken);

        return new ApiResponse<IEnumerable<EquipmentTypeDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<IEnumerable<EquipmentTypeDataObject>>(cancellationToken: cancellationToken) 
                : null,
            RawResult = await response.Content.ReadAsStreamAsync(cancellationToken)
        };
    }

    public async Task<ApiResponse<EquipmentTypeDataObject>> CreateEquipmentType(
        CreateEquipmentTypeActionInput input,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync(
            "e360/api/v1/equipmentType",
            JsonContent.Create(input),
            cancellationToken);

        return new ApiResponse<EquipmentTypeDataObject>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<EquipmentTypeDataObject>(cancellationToken: cancellationToken) 
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

    public async Task<ApiResponse<HeavyBidResponse<MaterialsDataObject>>> GetMaterials(
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

        return new ApiResponse<HeavyBidResponse<MaterialsDataObject>>
        {
            IsSuccessful = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Data = response.IsSuccessStatusCode 
                ? await response.Content.ReadFromJsonAsync<HeavyBidResponse<MaterialsDataObject>>(cancellationToken: cancellationToken) 
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
}