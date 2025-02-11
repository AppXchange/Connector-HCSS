namespace Connector.Contacts.v1;
using Connector.Contacts.v1.Contact;
using Connector.Contacts.v1.Contact.Create;
using Connector.Contacts.v1.Contact.Delete;
using Connector.Contacts.v1.Contact.Update;
using Connector.Contacts.v1.ContactProducts;
using Connector.Contacts.v1.ContactProducts.Create;
using Connector.Contacts.v1.ContactProducts.Delete;
using Connector.Contacts.v1.Office;
using Connector.Contacts.v1.Office.Create;
using Connector.Contacts.v1.Office.Delete;
using Connector.Contacts.v1.Office.Update;
using Connector.Contacts.v1.ProductType;
using Connector.Contacts.v1.ProductType.Create;
using Connector.Contacts.v1.ProductType.Delete;
using Connector.Contacts.v1.ProductType.Update;
using Connector.Contacts.v1.Vendor;
using Connector.Contacts.v1.Vendor.Create;
using Connector.Contacts.v1.Vendor.Delete;
using Connector.Contacts.v1.Vendor.Update;
using Connector.Contacts.v1.VendorProducts;
using Connector.Contacts.v1.VendorProducts.Create;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.Action;

public class ContactsV1ActionProcessorServiceDefinition : BaseActionHandlerServiceDefinition<ContactsV1ActionProcessorConfig>
{
    public override string ModuleId => "contacts-1";
    public override Type ServiceType => typeof(GenericActionHandlerService<ContactsV1ActionProcessorConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var options = new JsonSerializerOptions
        {
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };
        var serviceConfig = JsonSerializer.Deserialize<ContactsV1ActionProcessorConfig>(serviceConfigJson, options);
        serviceCollection.AddSingleton<ContactsV1ActionProcessorConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericActionHandlerService<ContactsV1ActionProcessorConfig>>();
        serviceCollection.AddSingleton<IActionHandlerServiceDefinition<ContactsV1ActionProcessorConfig>>(this);
        // Register Action Handlers as scoped dependencies
        serviceCollection.AddScoped<CreateContactProductsHandler>();
        serviceCollection.AddScoped<DeleteContactProductsHandler>();
        serviceCollection.AddScoped<DeleteContactHandler>();
        serviceCollection.AddScoped<UpdateContactHandler>();
        serviceCollection.AddScoped<CreateContactHandler>();
        serviceCollection.AddScoped<DeleteOfficeHandler>();
        serviceCollection.AddScoped<UpdateOfficeHandler>();
        serviceCollection.AddScoped<CreateOfficeHandler>();
        serviceCollection.AddScoped<DeleteProductTypeHandler>();
        serviceCollection.AddScoped<UpdateProductTypeHandler>();
        serviceCollection.AddScoped<CreateProductTypeHandler>();
        serviceCollection.AddScoped<DeleteVendorHandler>();
        serviceCollection.AddScoped<UpdateVendorHandler>();
        serviceCollection.AddScoped<CreateVendorHandler>();
        serviceCollection.AddScoped<CreateVendorProductsHandler>();
    }

    public override void ConfigureService(IActionHandlerService service, ContactsV1ActionProcessorConfig config)
    {
        // Register Action Handler configurations for the Action Processor Service
        service.RegisterHandlerForDataObjectAction<CreateContactProductsHandler, ContactProductsDataObject>(ModuleId, "contact-products", "create", config.CreateContactProductsConfig);
        service.RegisterHandlerForDataObjectAction<DeleteContactProductsHandler, ContactProductsDataObject>(ModuleId, "contact-products", "delete", config.DeleteContactProductsConfig);
        service.RegisterHandlerForDataObjectAction<DeleteContactHandler, ContactDataObject>(ModuleId, "contact", "delete", config.DeleteContactConfig);
        service.RegisterHandlerForDataObjectAction<UpdateContactHandler, ContactDataObject>(ModuleId, "contact", "update", config.UpdateContactConfig);
        service.RegisterHandlerForDataObjectAction<CreateContactHandler, ContactDataObject>(ModuleId, "contact", "create", config.CreateContactConfig);
        service.RegisterHandlerForDataObjectAction<DeleteOfficeHandler, OfficeDataObject>(ModuleId, "office", "delete", config.DeleteOfficeConfig);
        service.RegisterHandlerForDataObjectAction<UpdateOfficeHandler, OfficeDataObject>(ModuleId, "office", "update", config.UpdateOfficeConfig);
        service.RegisterHandlerForDataObjectAction<CreateOfficeHandler, OfficeDataObject>(ModuleId, "office", "create", config.CreateOfficeConfig);
        service.RegisterHandlerForDataObjectAction<DeleteProductTypeHandler, ProductTypeDataObject>(ModuleId, "product-type", "delete", config.DeleteProductTypeConfig);
        service.RegisterHandlerForDataObjectAction<UpdateProductTypeHandler, ProductTypeDataObject>(ModuleId, "product-type", "update", config.UpdateProductTypeConfig);
        service.RegisterHandlerForDataObjectAction<CreateProductTypeHandler, ProductTypeDataObject>(ModuleId, "product-type", "create", config.CreateProductTypeConfig);
        service.RegisterHandlerForDataObjectAction<DeleteVendorHandler, VendorDataObject>(ModuleId, "vendor", "delete", config.DeleteVendorConfig);
        service.RegisterHandlerForDataObjectAction<UpdateVendorHandler, VendorDataObject>(ModuleId, "vendor", "update", config.UpdateVendorConfig);
        service.RegisterHandlerForDataObjectAction<CreateVendorHandler, VendorDataObject>(ModuleId, "vendor", "create", config.CreateVendorConfig);
        service.RegisterHandlerForDataObjectAction<CreateVendorProductsHandler, VendorProductsDataObject>(ModuleId, "vendor-products", "create", config.CreateVendorProductsConfig);
    }
}