using System;
using Xchange.Connector.SDK.Client.AuthTypes;
using Xchange.Connector.SDK.Client.ConnectionDefinitions.Attributes;

namespace Connector.Connections;

[ConnectionDefinition(title: "HCSS OAuth2", description: "OAuth2 client credentials authentication for HCSS APIs")]
public class OAuth2ClientCredentials : OAuth2ClientCredentialsBase
{
    [ConnectionProperty(title: "Connection Environment", description: "Select the HCSS environment to connect to", isRequired: true, isSensitive: false)]
    public ConnectionEnvironmentOAuth2ClientCredentials ConnectionEnvironment { get; set; } = ConnectionEnvironmentOAuth2ClientCredentials.Unknown;

    [ConnectionProperty(title: "Scope", description: "Space-separated list of required API scopes (e.g. 'heavyjob:read skills:read')", isRequired: true, isSensitive: false)]
    public new string Scope { get; set; } = string.Empty;

    public string TokenEndpoint => $"{BaseUrl}/identity/connect/token";

    public string BaseUrl
    {
        get
        {
            switch (ConnectionEnvironment)
            {
                case ConnectionEnvironmentOAuth2ClientCredentials.Production:
                    return "https://api.hcssapps.com";
                case ConnectionEnvironmentOAuth2ClientCredentials.Test:
                    return "http://test.example.com";
                default:
                    throw new Exception("No environment was selected. Please select either Production or Test environment.");
            }
        }
    }

    protected object CreateTokenRequestBody()
    {
        return new
        {
            grant_type = "client_credentials",
            client_id = ClientId,
            client_secret = ClientSecret,
            scope = Scope
        };
    }

    protected string FormatAuthorizationHeader(string accessToken)
    {
        return $"Bearer {accessToken}";
    }
}

public enum ConnectionEnvironmentOAuth2ClientCredentials
{
    Unknown = 0,
    Production = 1,
    Test = 2
}