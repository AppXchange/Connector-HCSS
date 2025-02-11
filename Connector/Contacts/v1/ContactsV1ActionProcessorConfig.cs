namespace Connector.Contacts.v1;
using Connector.Contacts.v1.Contact.Create;
using Connector.Contacts.v1.Contact.Delete;
using Connector.Contacts.v1.Contact.Update;
using Connector.Contacts.v1.ContactProducts.Create;
using Connector.Contacts.v1.ContactProducts.Delete;
using Connector.Contacts.v1.Office.Create;
using Connector.Contacts.v1.Office.Delete;
using Connector.Contacts.v1.Office.Update;
using Connector.Contacts.v1.ProductType.Create;
using Connector.Contacts.v1.ProductType.Delete;
using Connector.Contacts.v1.ProductType.Update;
using Connector.Contacts.v1.Vendor.Create;
using Connector.Contacts.v1.Vendor.Delete;
using Connector.Contacts.v1.Vendor.Update;
using Connector.Contacts.v1.VendorProducts.Create;
using Json.Schema.Generation;
using Xchange.Connector.SDK.Action;

/// <summary>
/// Configuration for the Action Processor for this module. This configuration will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// The schema will be used for validation at runtime to make sure the configurations are properly formed. 
/// The schema also helps provide integrators more information for what the values are intended to be.
/// </summary>
[Title("Contacts V1 Action Processor Configuration")]
[Description("Configuration of the data object actions for the module.")]
public class ContactsV1ActionProcessorConfig
{
    // Action Handler configuration
    public DefaultActionHandlerConfig CreateContactProductsConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteContactProductsConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteContactConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateContactConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateContactConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteOfficeConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateOfficeConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateOfficeConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteProductTypeConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateProductTypeConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateProductTypeConfig { get; set; } = new();
    public DefaultActionHandlerConfig DeleteVendorConfig { get; set; } = new();
    public DefaultActionHandlerConfig UpdateVendorConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateVendorConfig { get; set; } = new();
    public DefaultActionHandlerConfig CreateVendorProductsConfig { get; set; } = new();
}