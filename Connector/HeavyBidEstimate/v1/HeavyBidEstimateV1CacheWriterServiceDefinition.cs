namespace Connector.HeavyBidEstimate.v1;
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
using Connector.HeavyBidEstimate.v1.Estimate;
using Connector.HeavyBidEstimate.v1.EstimateAttachments;
using Connector.HeavyBidEstimate.v1.Estimates;
using Connector.HeavyBidEstimate.v1.MaterialCodebook;
using Connector.HeavyBidEstimate.v1.Materials;
using Connector.HeavyBidEstimate.v1.Partition;
using Connector.HeavyBidEstimate.v1.Partitions;
using Connector.HeavyBidEstimate.v1.QuoteFolder;
using Connector.HeavyBidEstimate.v1.QuoteFolders;
using Connector.HeavyBidEstimate.v1.Resource;
using Connector.HeavyBidEstimate.v1.Resources;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using Xchange.Connector.SDK.Abstraction.Change;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Hosting.Configuration;

public class HeavyBidEstimateV1CacheWriterServiceDefinition : BaseCacheWriterServiceDefinition<HeavyBidEstimateV1CacheWriterConfig>
{
    public override string ModuleId => "heavybidestimate-1";
    public override Type ServiceType => typeof(GenericCacheWriterService<HeavyBidEstimateV1CacheWriterConfig>);

    public override void ConfigureServiceDependencies(IServiceCollection serviceCollection, string serviceConfigJson)
    {
        var serviceConfig = JsonSerializer.Deserialize<HeavyBidEstimateV1CacheWriterConfig>(serviceConfigJson);
        serviceCollection.AddSingleton<HeavyBidEstimateV1CacheWriterConfig>(serviceConfig!);
        serviceCollection.AddSingleton<GenericCacheWriterService<HeavyBidEstimateV1CacheWriterConfig>>();
        serviceCollection.AddSingleton<ICacheWriterServiceDefinition<HeavyBidEstimateV1CacheWriterConfig>>(this);
        // Register Data Readers as Singletons
        serviceCollection.AddSingleton<ActivitiesDataReader>();
        serviceCollection.AddSingleton<ActivityDataReader>();
        serviceCollection.AddSingleton<ActivityCodeBooksDataReader>();
        serviceCollection.AddSingleton<ActivityCodeBookDataReader>();
        serviceCollection.AddSingleton<ActivityCodebookResourcesDataReader>();
        serviceCollection.AddSingleton<ActivityCodebookResourceDataReader>();
        serviceCollection.AddSingleton<EstimateAttachmentsDataReader>();
        serviceCollection.AddSingleton<DownloadEstimateAttachmentDataReader>();
        serviceCollection.AddSingleton<AllBiditemCodebookDataReader>();
        serviceCollection.AddSingleton<BiditemCodebookDataReader>();
        serviceCollection.AddSingleton<BiditemsDataReader>();
        serviceCollection.AddSingleton<BiditemDataReader>();
        serviceCollection.AddSingleton<BusinessUnitsDataReader>();
        serviceCollection.AddSingleton<EstimatesDataReader>();
        serviceCollection.AddSingleton<EstimateDataReader>();
        serviceCollection.AddSingleton<AllCalulatedKPIsDataReader>();
        serviceCollection.AddSingleton<AllMaterialCodebookDataReader>();
        serviceCollection.AddSingleton<MaterialCodebookDataReader>();
        serviceCollection.AddSingleton<MaterialsDataReader>();
        serviceCollection.AddSingleton<PartitionsDataReader>();
        serviceCollection.AddSingleton<PartitionDataReader>();
        serviceCollection.AddSingleton<QuoteFoldersDataReader>();
        serviceCollection.AddSingleton<QuoteFolderDataReader>();
        serviceCollection.AddSingleton<ResourcesDataReader>();
        serviceCollection.AddSingleton<ResourceDataReader>();
    }

    public override IDataObjectChangeDetectorProvider ConfigureChangeDetectorProvider(IChangeDetectorFactory factory, ConnectorDefinition connectorDefinition)
    {
        var options = factory.CreateProviderOptionsWithNoDefaultResolver();
        // Configure Data Object Keys for Data Objects that do not use the default
        this.RegisterKeysForObject<ActivitiesDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ActivityDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ActivityCodeBooksDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ActivityCodeBookDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ActivityCodebookResourcesDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ActivityCodebookResourceDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<EstimateAttachmentsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<DownloadEstimateAttachmentDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<AllBiditemCodebookDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<BiditemCodebookDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<BiditemsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<BiditemDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<BusinessUnitsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<EstimatesDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<EstimateDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<AllCalulatedKPIsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<AllMaterialCodebookDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<MaterialCodebookDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<MaterialsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<PartitionsDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<PartitionDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<QuoteFoldersDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<QuoteFolderDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ResourcesDataObject>(options, connectorDefinition);
        this.RegisterKeysForObject<ResourceDataObject>(options, connectorDefinition);
        return factory.CreateProvider(options);
    }

    public override void ConfigureService(ICacheWriterService service, HeavyBidEstimateV1CacheWriterConfig config)
    {
        var dataReaderSettings = new DataReaderSettings
        {
            DisableDeletes = false,
            UseChangeDetection = true
        };
        // Register Data Reader configurations for the Cache Writer Service
        service.RegisterDataReader<ActivitiesDataReader, ActivitiesDataObject>(ModuleId, config.ActivitiesConfig, dataReaderSettings);
        service.RegisterDataReader<ActivityDataReader, ActivityDataObject>(ModuleId, config.ActivityConfig, dataReaderSettings);
        service.RegisterDataReader<ActivityCodeBooksDataReader, ActivityCodeBooksDataObject>(ModuleId, config.ActivityCodeBooksConfig, dataReaderSettings);
        service.RegisterDataReader<ActivityCodeBookDataReader, ActivityCodeBookDataObject>(ModuleId, config.ActivityCodeBookConfig, dataReaderSettings);
        service.RegisterDataReader<ActivityCodebookResourcesDataReader, ActivityCodebookResourcesDataObject>(ModuleId, config.ActivityCodebookResourcesConfig, dataReaderSettings);
        service.RegisterDataReader<ActivityCodebookResourceDataReader, ActivityCodebookResourceDataObject>(ModuleId, config.ActivityCodebookResourceConfig, dataReaderSettings);
        service.RegisterDataReader<EstimateAttachmentsDataReader, EstimateAttachmentsDataObject>(ModuleId, config.EstimateAttachmentsConfig, dataReaderSettings);
        service.RegisterDataReader<DownloadEstimateAttachmentDataReader, DownloadEstimateAttachmentDataObject>(ModuleId, config.DownloadEstimateAttachmentConfig, dataReaderSettings);
        service.RegisterDataReader<AllBiditemCodebookDataReader, AllBiditemCodebookDataObject>(ModuleId, config.AllBiditemCodebookConfig, dataReaderSettings);
        service.RegisterDataReader<BiditemCodebookDataReader, BiditemCodebookDataObject>(ModuleId, config.BiditemCodebookConfig, dataReaderSettings);
        service.RegisterDataReader<BiditemsDataReader, BiditemsDataObject>(ModuleId, config.BiditemsConfig, dataReaderSettings);
        service.RegisterDataReader<BiditemDataReader, BiditemDataObject>(ModuleId, config.BiditemConfig, dataReaderSettings);
        service.RegisterDataReader<BusinessUnitsDataReader, BusinessUnitsDataObject>(ModuleId, config.BusinessUnitsConfig, dataReaderSettings);
        service.RegisterDataReader<EstimatesDataReader, EstimatesDataObject>(ModuleId, config.EstimatesConfig, dataReaderSettings);
        service.RegisterDataReader<EstimateDataReader, EstimateDataObject>(ModuleId, config.EstimateConfig, dataReaderSettings);
        service.RegisterDataReader<AllCalulatedKPIsDataReader, AllCalulatedKPIsDataObject>(ModuleId, config.AllCalulatedKPIsConfig, dataReaderSettings);
        service.RegisterDataReader<AllMaterialCodebookDataReader, AllMaterialCodebookDataObject>(ModuleId, config.AllMaterialCodebookConfig, dataReaderSettings);
        service.RegisterDataReader<MaterialCodebookDataReader, MaterialCodebookDataObject>(ModuleId, config.MaterialCodebookConfig, dataReaderSettings);
        service.RegisterDataReader<MaterialsDataReader, MaterialsDataObject>(ModuleId, config.MaterialsConfig, dataReaderSettings);
        service.RegisterDataReader<PartitionsDataReader, PartitionsDataObject>(ModuleId, config.PartitionsConfig, dataReaderSettings);
        service.RegisterDataReader<PartitionDataReader, PartitionDataObject>(ModuleId, config.PartitionConfig, dataReaderSettings);
        service.RegisterDataReader<QuoteFoldersDataReader, QuoteFoldersDataObject>(ModuleId, config.QuoteFoldersConfig, dataReaderSettings);
        service.RegisterDataReader<QuoteFolderDataReader, QuoteFolderDataObject>(ModuleId, config.QuoteFolderConfig, dataReaderSettings);
        service.RegisterDataReader<ResourcesDataReader, ResourcesDataObject>(ModuleId, config.ResourcesConfig, dataReaderSettings);
        service.RegisterDataReader<ResourceDataReader, ResourceDataObject>(ModuleId, config.ResourceConfig, dataReaderSettings);
    }
}