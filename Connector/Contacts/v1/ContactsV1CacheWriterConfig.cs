namespace Connector.Contacts.v1;
using Connector.Contacts.v1.Contact;
using Connector.Contacts.v1.ContactProducts;
using Connector.Contacts.v1.Contacts;
using Connector.Contacts.v1.Office;
using Connector.Contacts.v1.Offices;
using Connector.Contacts.v1.ProductContacts;
using Connector.Contacts.v1.Products;
using Connector.Contacts.v1.ProductType;
using Connector.Contacts.v1.ProductVendors;
using Connector.Contacts.v1.Vendor;
using Connector.Contacts.v1.VendorProducts;
using Connector.Contacts.v1.Vendors;
using ESR.Hosting.CacheWriter;
using Json.Schema.Generation;

/// <summary>
/// Configuration for the Cache writer for this module. This configuration will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// The schema will be used for validation at runtime to make sure the configurations are properly formed. 
/// The schema also helps provide integrators more information for what the values are intended to be.
/// </summary>
[Title("Contacts V1 Cache Writer Configuration")]
[Description("Configuration of the data object caches for the module.")]
public class ContactsV1CacheWriterConfig
{
    // Data Reader configuration
    public CacheWriterObjectConfig ContactProductsConfig { get; set; } = new();
    public CacheWriterObjectConfig ContactConfig { get; set; } = new();
    public CacheWriterObjectConfig ContactsConfig { get; set; } = new();
    public CacheWriterObjectConfig OfficeConfig { get; set; } = new();
    public CacheWriterObjectConfig OfficesConfig { get; set; } = new();
    public CacheWriterObjectConfig ProductTypeConfig { get; set; } = new();
    public CacheWriterObjectConfig VendorConfig { get; set; } = new();
    public CacheWriterObjectConfig VendorsConfig { get; set; } = new();
    public CacheWriterObjectConfig VendorProductsConfig { get; set; } = new();
    public CacheWriterObjectConfig ProductsConfig { get; set; } = new();
    public CacheWriterObjectConfig ProductContactsConfig { get; set; } = new();
    public CacheWriterObjectConfig ProductVendorsConfig { get; set; } = new();
}