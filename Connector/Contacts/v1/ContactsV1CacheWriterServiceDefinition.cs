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
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using Xchange.Connector.SDK.Abstraction.Change;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Hosting.Configuration;

public class ContactsV1CacheWriterServiceDefinition : BaseCacheWriterServiceDefinition<ContactsV1CacheWriterConfig>
{
    public override string ModuleId => "contacts-1";
    public override Type ServiceType => typeof(GenericCacheWriterService<ContactsV1CacheWriterConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var serviceConfig = JsonSerializer.Deserialize<ContactsV1CacheWriterConfig>(serviceConfigJson);
        serviceCollection.AddSingleton<ContactsV1CacheWriterConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericCacheWriterService<ContactsV1CacheWriterConfig>>();
        serviceCollection.AddSingleton<ICacheWriterServiceDefinition<ContactsV1CacheWriterConfig>>(this);
        // Register Data Readers as Singletons
        serviceCollection.AddSingleton<ContactProductsDataReader>();
        serviceCollection.AddSingleton<ContactDataReader>();
        serviceCollection.AddSingleton<ContactsDataReader>();
        serviceCollection.AddSingleton<OfficeDataReader>();
        serviceCollection.AddSingleton<OfficesDataReader>();
        serviceCollection.AddSingleton<ProductTypeDataReader>();
        serviceCollection.AddSingleton<VendorDataReader>();
        serviceCollection.AddSingleton<VendorsDataReader>();
        serviceCollection.AddSingleton<VendorProductsDataReader>();
        serviceCollection.AddSingleton<ProductsDataReader>();
        serviceCollection.AddSingleton<ProductContactsDataReader>();
        serviceCollection.AddSingleton<ProductVendorsDataReader>();
    }

    public override IDataObjectChangeDetectorProvider ConfigureChangeDetectorProvider(IChangeDetectorFactory factory, ConnectorDefinition connectorDefinition)
    {
        var options = factory.CreateProviderOptionsWithNoDefaultResolver();
        // Configure Data Object Keys for Data Objects that do not use the default
        this.RegisterKeysForObject<ContactProductsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ContactDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ContactsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<OfficeDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<OfficesDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ProductTypeDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<VendorDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<VendorsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<VendorProductsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ProductsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ProductContactsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ProductVendorsDataObject>(options, connectorDefinition);
        return factory.CreateProvider(options);
    }

    public override void ConfigureService(ICacheWriterService service, ContactsV1CacheWriterConfig config)
    {
        var dataReaderSettings = new DataReaderSettings
        {
            DisableDeletes = false,
            UseChangeDetection = true
        };
        // Register Data Reader configurations for the Cache Writer Service
        service.RegisterDataReader<ContactProductsDataReader, ContactProductsDataObject>(ModuleId, config.ContactProductsConfig, dataReaderSettings);
        service.RegisterDataReader<ContactDataReader, ContactDataObject>(ModuleId, config.ContactConfig, dataReaderSettings);
        service.RegisterDataReader<ContactsDataReader, ContactsDataObject>(ModuleId, config.ContactsConfig, dataReaderSettings);
        service.RegisterDataReader<OfficeDataReader, OfficeDataObject>(ModuleId, config.OfficeConfig, dataReaderSettings);
        service.RegisterDataReader<OfficesDataReader, OfficesDataObject>(ModuleId, config.OfficesConfig, dataReaderSettings);
        service.RegisterDataReader<ProductTypeDataReader, ProductTypeDataObject>(ModuleId, config.ProductTypeConfig, dataReaderSettings);
        service.RegisterDataReader<VendorDataReader, VendorDataObject>(ModuleId, config.VendorConfig, dataReaderSettings);
        service.RegisterDataReader<VendorsDataReader, VendorsDataObject>(ModuleId, config.VendorsConfig, dataReaderSettings);
        service.RegisterDataReader<VendorProductsDataReader, VendorProductsDataObject>(ModuleId, config.VendorProductsConfig, dataReaderSettings);
        service.RegisterDataReader<ProductsDataReader, ProductsDataObject>(ModuleId, config.ProductsConfig, dataReaderSettings);
        service.RegisterDataReader<ProductContactsDataReader, ProductContactsDataObject>(ModuleId, config.ProductContactsConfig, dataReaderSettings);
        service.RegisterDataReader<ProductVendorsDataReader, ProductVendorsDataObject>(ModuleId, config.ProductVendorsConfig, dataReaderSettings);
    }
}