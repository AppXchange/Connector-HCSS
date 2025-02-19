using Connector.Client;
using System;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Text.Json;

namespace Connector.Users.v1.Users;

public class UsersDataReader : TypedAsyncDataReaderBase<UsersDataObject>
{
    private readonly ILogger<UsersDataReader> _logger;
    private readonly ApiClient _apiClient;

    public UsersDataReader(
        ILogger<UsersDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<UsersDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var businessUnitId = dataObjectRunArguments?.RequestParameterOverrides?.RootElement != null 
            && dataObjectRunArguments.RequestParameterOverrides.RootElement.TryGetProperty("businessUnitId", out var businessUnitElement)
            ? businessUnitElement.GetString()
            : null;

        var page = 0;
        var pageSize = 50;
        bool hasMorePages;

        do
        {
            var response = await _apiClient.GetUsers(
                page,
                pageSize,
                businessUnitId != null ? Guid.Parse(businessUnitId) : null,
                cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve users. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve users. API StatusCode: {response.StatusCode}");
            }

            if (response.Data?.Items == null)
            {
                _logger.LogWarning("No users found");
                yield break;
            }

            foreach (var item in response.Data.Items)
            {
                var apiUser = JsonSerializer.Deserialize<UserApiResponse>(item.GetRawText());
                if (apiUser == null) continue;
                
                yield return new UsersDataObject
                {
                    Id = apiUser.Id,
                    UserName = apiUser.UserName,
                    FirstName = apiUser.FirstName,
                    LastName = apiUser.LastName,
                    Email = apiUser.Email,
                    PhoneNumber = apiUser.PhoneNumber,
                    ContactMethod = apiUser.ContactMethod,
                    UserRole = apiUser.UserRole,
                    SubscriptionGroup = apiUser.SubscriptionGroup,
                    Note = apiUser.Note,
                    HomeBusinessUnit = apiUser.HomeBusinessUnit,
                    EmployeeCode = apiUser.EmployeeCode,
                    AllowPhoneNumberLogin = apiUser.AllowPhoneNumberLogin,
                    ExcludeFromExternalAuthentication = apiUser.ExcludeFromExternalAuthentication,
                    BusinessUnitAccess = apiUser.BusinessUnitAccess,
                    JobAccess = apiUser.JobAccess,
                    CreatedDate = apiUser.CreatedDate,
                    ModifiedDate = apiUser.ModifiedDate
                };
            }

            page++;
            hasMorePages = page < response.Data.TotalPages;

        } while (hasMorePages);
    }

    private class UserApiResponse 
    {
        public Guid Id { get; init; }
        public string? UserName { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? PhoneNumber { get; init; }
        public string? Email { get; init; }
        public string? ContactMethod { get; init; }
        public Guid UserRole { get; init; }
        public Guid? SubscriptionGroup { get; init; }
        public string? Note { get; init; }
        public Guid HomeBusinessUnit { get; init; }
        public string? EmployeeCode { get; init; }
        public bool? AllowPhoneNumberLogin { get; init; }
        public bool? ExcludeFromExternalAuthentication { get; init; }
        public BusinessUnitAccess BusinessUnitAccess { get; init; } = null!;
        public JobAccess JobAccess { get; init; } = null!;
        public DateTime? CreatedDate { get; init; }
        public DateTime? ModifiedDate { get; init; }
    }
}