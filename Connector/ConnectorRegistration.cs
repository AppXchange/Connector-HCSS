namespace Connector;
using Connector.Attachments.v1;
using Connector.Client;
using Connector.Connections;
using Connector.Contacts.v1;
using Connector.Equipment360.v1;
using Connector.HeavyBidEstimate.v1;
using Connector.HeavyBidPreConstruction.v1;
using Connector.HeavyJob.v1;
using Connector.Safety.v1;
using Connector.Setups.v1;
using Connector.Skills.v1;
using Connector.Telematics.v1;
using Connector.Users.v1;
using Connector.Webhooks.v1;
using ESR.Hosting;
using ESR.Hosting.Client;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using Xchange.Connector.SDK.Abstraction.Hosting;
using Xchange.Connector.SDK.Client.Testing;

/// <summary>
/// The registration object for your connector. This will be passed to the <see cref = "Extensions.UseGenericServiceRun"/> method at
/// Program startup. <see cref = "Program.Main(string[])"/>
/// </summary>
public class ConnectorRegistration : IConnectorRegistration<ConnectorRegistrationConfig>, IConfigureConnectorApiClient
{
    /// <summary>
    /// Registers any objects that are needed for dependency injection for the connector. 
    /// </summary>
    /// <param name = "serviceCollection"><see cref = "IServiceCollection"/> to register connector types with.</param>
    /// <param name = "hostContext">Host context that provides any configuration for the service run.</param>
    public void ConfigureServices(IServiceCollection serviceCollection, IHostContext hostContext)
    {
        var connectorRegistrationConfig = JsonSerializer.Deserialize<ConnectorRegistrationConfig>(hostContext.GetSystemConfig().Configuration);
        serviceCollection.AddSingleton(connectorRegistrationConfig!);
        serviceCollection.AddTransient<RetryPolicyHandler>();
    }

    /// <summary>
    /// Registers all <see cref = "IConnectorServiceDefinition"/> implementations. If using the xchange CLI tooling, it will normally
    /// add these for you when adding a new module to the connector. Most modules will have an Action processor service definition
    /// and a Cache Writer service definition
    /// </summary>
    /// <param name = "serviceCollection"></param>
    public void RegisterServiceDefinitions(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IConnectorServiceDefinition, AttachmentsV1ActionProcessorServiceDefinition>();
        serviceCollection.AddSingleton<IConnectorServiceDefinition, AttachmentsV1CacheWriterServiceDefinition>();
        serviceCollection.AddSingleton<IConnectorServiceDefinition, ContactsV1ActionProcessorServiceDefinition>();
        serviceCollection.AddSingleton<IConnectorServiceDefinition, ContactsV1CacheWriterServiceDefinition>();
        serviceCollection.AddSingleton<IConnectorServiceDefinition, Equipment360V1ActionProcessorServiceDefinition>();
        serviceCollection.AddSingleton<IConnectorServiceDefinition, Equipment360V1CacheWriterServiceDefinition>();
        serviceCollection.AddSingleton<IConnectorServiceDefinition, HeavyBidEstimateV1ActionProcessorServiceDefinition>();
        serviceCollection.AddSingleton<IConnectorServiceDefinition, HeavyBidEstimateV1CacheWriterServiceDefinition>();
        serviceCollection.AddSingleton<IConnectorServiceDefinition, HeavyBidPreConstructionV1ActionProcessorServiceDefinition>();
        serviceCollection.AddSingleton<IConnectorServiceDefinition, HeavyBidPreConstructionV1CacheWriterServiceDefinition>();
        serviceCollection.AddSingleton<IConnectorServiceDefinition, HeavyJobV1ActionProcessorServiceDefinition>();
        serviceCollection.AddSingleton<IConnectorServiceDefinition, HeavyJobV1CacheWriterServiceDefinition>();
        serviceCollection.AddSingleton<IConnectorServiceDefinition, SafetyV1ActionProcessorServiceDefinition>();
        serviceCollection.AddSingleton<IConnectorServiceDefinition, SafetyV1CacheWriterServiceDefinition>();
        serviceCollection.AddSingleton<IConnectorServiceDefinition, SetupsV1ActionProcessorServiceDefinition>();
        serviceCollection.AddSingleton<IConnectorServiceDefinition, SetupsV1CacheWriterServiceDefinition>();
        serviceCollection.AddSingleton<IConnectorServiceDefinition, SkillsV1ActionProcessorServiceDefinition>();
        serviceCollection.AddSingleton<IConnectorServiceDefinition, SkillsV1CacheWriterServiceDefinition>();
        serviceCollection.AddSingleton<IConnectorServiceDefinition, TelematicsV1ActionProcessorServiceDefinition>();
        serviceCollection.AddSingleton<IConnectorServiceDefinition, TelematicsV1CacheWriterServiceDefinition>();
        serviceCollection.AddSingleton<IConnectorServiceDefinition, UsersV1ActionProcessorServiceDefinition>();
        serviceCollection.AddSingleton<IConnectorServiceDefinition, UsersV1CacheWriterServiceDefinition>();
        serviceCollection.AddSingleton<IConnectorServiceDefinition, WebhooksV1ActionProcessorServiceDefinition>();
        serviceCollection.AddSingleton<IConnectorServiceDefinition, WebhooksV1CacheWriterServiceDefinition>();
    }

    public void ConfigureConnectorApiClient(IServiceCollection serviceCollection, IHostConnectionContext hostConnectionContext)
    {
        var activeConnection = hostConnectionContext.GetConnection();
        serviceCollection.ResolveServices(activeConnection);
    }

    public void RegisterConnectionTestHandler(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IConnectionTestHandler, ConnectionTestHandler>();
    }
}