using System;
using Xchange.Connector.SDK.Client.AuthTypes;
using Xchange.Connector.SDK.Client.ConnectionDefinitions.Attributes;

namespace Connector.Connections;

[ConnectionDefinition(title: "OAuth2ClientCredentials", description: "")]
public class OAuth2ClientCredentials : OAuth2ClientCredentialsBase
{
    [ConnectionProperty(title: "Connection Environment", description: "", isRequired: true, isSensitive: false)]
    public ConnectionEnvironmentOAuth2ClientCredentials ConnectionEnvironment { get; set; } = ConnectionEnvironmentOAuth2ClientCredentials.Unknown;

    public string BaseUrl
    {
        get
        {
            switch (ConnectionEnvironment)
            {
                case ConnectionEnvironmentOAuth2ClientCredentials.Production:
                    return "http://prod.example.com";
                case ConnectionEnvironmentOAuth2ClientCredentials.Test:
                    return "http://test.example.com";
                default:
                    throw new Exception("No base url was set.");
            }
        }
    }
}

public enum ConnectionEnvironmentOAuth2ClientCredentials
{
    Unknown = 0,
    Production = 1,
    Test = 2
}