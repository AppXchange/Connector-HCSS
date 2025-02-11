namespace Connector.Client
{
    using Connector.Connections;
    using ESR.Hosting.Client;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Text.Json;
    using Xchange.Connector.SDK.Client.AuthTypes;
    using Xchange.Connector.SDK.Client.AuthTypes.DelegatingHandlers;
    using Xchange.Connector.SDK.Client.ConnectivityApi.Models;

    public static class ClientHelper
    {
        public static class AuthTypeKeyEnums
        {
            public const string OAuth2ClientCredentials = "oAuth2ClientCredentials";
        }

        public static void ResolveServices(this IServiceCollection serviceCollection, ConnectionContainer activeConnection)
        {
            serviceCollection.AddTransient<RetryPolicyHandler>();
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            switch (activeConnection.DefinitionKey)
            {
                case AuthTypeKeyEnums.OAuth2ClientCredentials:
                    var configOAuth2ClientCredentials = JsonSerializer.Deserialize<OAuth2ClientCredentials>(activeConnection.Configuration, options);
                    serviceCollection.AddSingleton<OAuth2ClientCredentialsBase>(configOAuth2ClientCredentials!);
                    serviceCollection.AddTransient<RetryPolicyHandler>();
                    serviceCollection.AddTransient<OAuth2ClientCredentialsHandler>();
                    serviceCollection.AddHttpClient<ApiClient, ApiClient>(client => new ApiClient(client, configOAuth2ClientCredentials!.BaseUrl)).AddHttpMessageHandler<OAuth2ClientCredentialsHandler>().AddHttpMessageHandler<RetryPolicyHandler>();
                    break;
                default:
                    throw new Exception($"Unable to find services for definition key {activeConnection.DefinitionKey}");
            }
        }
    }
}