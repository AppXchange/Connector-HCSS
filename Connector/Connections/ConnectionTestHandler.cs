using Connector.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Xchange.Connector.SDK.Client.Testing;

namespace Connector.Connections
{
    public class ConnectionTestHandler : IConnectionTestHandler
    {
        private readonly ILogger<IConnectionTestHandler> _logger;
        private readonly ApiClient _apiClient;

        public ConnectionTestHandler(
            ILogger<IConnectionTestHandler> logger,
            ApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        public async Task<TestConnectionResult> TestConnection()
        {
            try
            {
                _logger.LogInformation("Testing connection to HCSS API");
                var response = await _apiClient.TestConnection();

                if (response == null)
                {
                    _logger.LogError("No response received from HCSS API");
                    return new TestConnectionResult
                    {
                        Success = false,
                        Message = "Failed to get response from HCSS API",
                        StatusCode = 500
                    };
                }

                if (response.IsSuccessful)
                {
                    return new TestConnectionResult
                    {
                        Success = true,
                        Message = "Successfully authenticated with HCSS API",
                        StatusCode = response.StatusCode
                    };
                }

                switch (response.StatusCode)
                {
                    case 400:
                        return new TestConnectionResult
                        {
                            Success = false,
                            Message = "Invalid request. Please check your connection settings.",
                            StatusCode = response.StatusCode
                        };
                    case 401:
                        return new TestConnectionResult
                        {
                            Success = false,
                            Message = "Invalid credentials: Unauthorized. Please check your client ID and secret.",
                            StatusCode = response.StatusCode
                        };
                    case 403:
                        return new TestConnectionResult
                        {
                            Success = false,
                            Message = "Invalid credentials: Forbidden. Please check if you have the correct scope permissions.",
                            StatusCode = response.StatusCode
                        };
                    default:
                        _logger.LogError("Unexpected response from HCSS API. Status: {StatusCode}", 
                            response.StatusCode);
                        return new TestConnectionResult
                        {
                            Success = false,
                            Message = $"Unexpected response from server (Status code: {response.StatusCode})",
                            StatusCode = response.StatusCode
                        };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error testing connection to HCSS API");
                return new TestConnectionResult
                {
                    Success = false,
                    Message = $"Connection test failed: {ex.Message}",
                    StatusCode = 500
                };
            }
        }
    }
}
