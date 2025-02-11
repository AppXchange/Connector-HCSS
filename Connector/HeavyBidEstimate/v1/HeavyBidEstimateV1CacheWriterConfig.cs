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
using Json.Schema.Generation;

/// <summary>
/// Configuration for the Cache writer for this module. This configuration will be converted to a JsonSchema, 
/// so add attributes to the properties to provide any descriptions, titles, ranges, max, min, etc... 
/// The schema will be used for validation at runtime to make sure the configurations are properly formed. 
/// The schema also helps provide integrators more information for what the values are intended to be.
/// </summary>
[Title("HeavyBidEstimate V1 Cache Writer Configuration")]
[Description("Configuration of the data object caches for the module.")]
public class HeavyBidEstimateV1CacheWriterConfig
{
    // Data Reader configuration
    public CacheWriterObjectConfig ActivitiesConfig { get; set; } = new();
    public CacheWriterObjectConfig ActivityConfig { get; set; } = new();
    public CacheWriterObjectConfig ActivityCodeBooksConfig { get; set; } = new();
    public CacheWriterObjectConfig ActivityCodeBookConfig { get; set; } = new();
    public CacheWriterObjectConfig ActivityCodebookResourcesConfig { get; set; } = new();
    public CacheWriterObjectConfig ActivityCodebookResourceConfig { get; set; } = new();
    public CacheWriterObjectConfig EstimateAttachmentsConfig { get; set; } = new();
    public CacheWriterObjectConfig DownloadEstimateAttachmentConfig { get; set; } = new();
    public CacheWriterObjectConfig AllBiditemCodebookConfig { get; set; } = new();
    public CacheWriterObjectConfig BiditemCodebookConfig { get; set; } = new();
    public CacheWriterObjectConfig BiditemsConfig { get; set; } = new();
    public CacheWriterObjectConfig BiditemConfig { get; set; } = new();
    public CacheWriterObjectConfig BusinessUnitsConfig { get; set; } = new();
    public CacheWriterObjectConfig EstimatesConfig { get; set; } = new();
    public CacheWriterObjectConfig EstimateConfig { get; set; } = new();
    public CacheWriterObjectConfig AllCalulatedKPIsConfig { get; set; } = new();
    public CacheWriterObjectConfig AllMaterialCodebookConfig { get; set; } = new();
    public CacheWriterObjectConfig MaterialCodebookConfig { get; set; } = new();
    public CacheWriterObjectConfig MaterialsConfig { get; set; } = new();
    public CacheWriterObjectConfig PartitionsConfig { get; set; } = new();
    public CacheWriterObjectConfig PartitionConfig { get; set; } = new();
    public CacheWriterObjectConfig QuoteFoldersConfig { get; set; } = new();
    public CacheWriterObjectConfig QuoteFolderConfig { get; set; } = new();
    public CacheWriterObjectConfig ResourcesConfig { get; set; } = new();
    public CacheWriterObjectConfig ResourceConfig { get; set; } = new();
}