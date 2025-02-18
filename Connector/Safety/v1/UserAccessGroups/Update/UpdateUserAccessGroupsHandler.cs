using Connector.Client;
using ESR.Hosting.Action;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xchange.Connector.SDK.Action;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Client.AppNetwork;

namespace Connector.Safety.v1.UserAccessGroups.Update;

public class UpdateUserAccessGroupsHandler : IActionHandler<UpdateUserAccessGroupsAction>
{
    private readonly ILogger<UpdateUserAccessGroupsHandler> _logger;
    private readonly ApiClient _apiClient;

    public UpdateUserAccessGroupsHandler(
        ILogger<UpdateUserAccessGroupsHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<UpdateUserAccessGroupsActionInput[]>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.UpdateUserAccessGroups(input, cancellationToken);

            if (!response.IsSuccessful || response.Data == null)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(UpdateUserAccessGroupsHandler) },
                            Text = $"Failed to update user access groups. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            // Build sync operations to update cache
            var operations = new List<SyncOperation>();
            var keyResolver = new DefaultDataObjectKey();

            foreach (var result in response.Data.Where(r => r.Success))
            {
                var userAccessGroup = new UserAccessGroupsDataObject
                {
                    UserId = result.UserId,
                    AccessGroupId = result.AccessGroupId
                };

                var key = keyResolver.BuildKeyResolver()(userAccessGroup);
                operations.Add(SyncOperation.CreateSyncOperation(UpdateOperation.Upsert.ToString(), key.UrlPart, key.PropertyNames, userAccessGroup));
            }

            var resultList = new List<CacheSyncCollection>
            {
                new CacheSyncCollection() { DataObjectType = typeof(UserAccessGroupsDataObject), CacheChanges = operations.ToArray() }
            };

            return ActionHandlerOutcome.Successful(response.Data, resultList);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating user access groups");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "500",
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(UpdateUserAccessGroupsHandler) },
                        Text = ex.Message
                    }
                }
            });
        }
    }
}
